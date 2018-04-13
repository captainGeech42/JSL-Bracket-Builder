﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace JSLBracketBuilder
{
    public partial class MainWindow : Form
    {
        private int NumGroups { get; } = 8;

        private List<string> Battletags = null;
        private List<Player> ExistingData = null;

        private BackgroundWorker Worker;
        private Operation Operation;

        private new Region Region;
        private int SeasonID;
        private List<Ladder> Ladders = null;
        private List<Player> Players = null;
        private List<Group> Groups = null;

        public MainWindow()
        {
            InitializeComponent();

            Worker = new BackgroundWorker();
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        #region UI Handlers

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (!File.Exists(@"access_token.txt"))
            {
                MessageBox.Show(@"Please put your Blizzard API access token in access_token.txt in the same directory this executable is located, and then relaunch the application.");
                Application.Exit();
            }

            API.SetRegion(Region.US);
        }

        private void LoadExisting_Click(object sender, EventArgs e)
        {
            using (var stream = GetOpenFile(@"json files (*.json)|*.json"))
            {
                if (stream != null)
                {
                    using (var sr = new StreamReader(stream))
                    {
                        ExistingData = JsonConvert.DeserializeObject<List<Player>>(sr.ReadToEnd());
                    }
                }
            }
        }

        private void SelectBtags_Click(object sender, EventArgs e)
        {
            using (Stream stream = GetOpenFile(@"txt files (*.txt)|*.txt|All files|*.*", 1))
            {
                if (stream != null)
                    ParseBattletags(stream);
            }
        }

        private void QueryAPI_Click(object sender, EventArgs e)
        {
            //progressBar1.Style = ProgressBarStyle.Marquee;
            //Worker.RunWorkerAsync();

            // get current season id
            StartWorker(Operation.GET_SEASON_ID);

            // get all ladders bronze-diamond for the current season
            StartWorker(Operation.GET_ALL_LADDERS);

            // for each ladder, save the players that are registered
            StartWorker(Operation.GET_PLAYERS_IN_LADDER);
        }

        private void MakeGroups_Click(object sender, EventArgs e)
        {
            StartWorker(Operation.GENERATE_GROUPS);
        }

        private void SaveGroups_Click(object sender, EventArgs e)
        {
            if (Groups != null)
            {
                using (Stream stream = GetSaveFile(@"txt files (*.txt)|*.txt|All files|*.*", 1))
                {
                    if (stream != null)
                    {
                        using (var sw = new StreamWriter(stream))
                        {
                            sw.Write(JsonConvert.SerializeObject(Groups));
                        }
                    }
                }
            }
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            if (Players != null)
            {
                using (Stream stream = GetSaveFile(@"player files (*.player)|*.player", 1))
                {
                    if (stream != null)
                    {
                        using (var sw = new StreamWriter(stream))
                        {
                            sw.Write(JsonConvert.SerializeObject(Players));
                        }
                    }
                }
            }
        }

        private void SwitchRegion_Click(object sender, EventArgs e)
        {
            if (Region == Region.US) Region = Region.EU;
            else Region = Region.US;

            label_region.Text = Region.ToString();
        }

        #endregion

        #region BackgroundWorker

        private void StartWorker(Operation operation)
        {
            API.SetRegion(Region);
            Operation = operation;
            switch (Operation)
            {
                case Operation.GET_SEASON_ID:
                    label_state.Text = @"Getting current season ID";
                    break;
                case Operation.GET_ALL_LADDERS:
                    label_state.Text = @"Getting all ladders";
                    break;
                case Operation.GET_PLAYERS_IN_LADDER:
                    label_state.Text = @"Getting players in a ladder";
                    break;
                case Operation.GENERATE_GROUPS:
                    label_state.Text = @"Generating groups";
                    break;
            }
            progressBar1.Style = ProgressBarStyle.Marquee;

            Worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (Operation)
            {
                case Operation.GET_SEASON_ID:
                    SeasonID = API.GetCurrentSeasonID();
                    break;
                case Operation.GET_ALL_LADDERS:
                    Ladders = API.GetAllLadders(League.DIAMOND, SeasonID);
                    break;
                case Operation.GET_PLAYERS_IN_LADDER:
                    GetJSLPlayersInAllLadders();
                    break;
                case Operation.GENERATE_GROUPS:
                    GenerateGroups();
                    break;
            }

            var seasonID = API.GetCurrentSeasonID();
            var ladders = API.GetAllLadders(League.BRONZE, seasonID);
            var players = API.GetAllPlayersInLadder(ladders[0]);
            MessageBox.Show(players[0].Battletag);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            label_state.Text = @"Awaiting Operation";
        }

        #endregion

        #region Process Data

        private void GetJSLPlayersInAllLadders()
        {
            if (Ladders == null) return;

            if (Players == null) Players = new List<Player>();

            Players.AddRange((from l in Ladders
                              from p in API.GetAllPlayersInLadder(l)
                              where Battletags.Contains(p.Battletag)
                              select p));
        }

        private void GenerateGroups()
        {
            if (Players == null) return;

            char id = 'A';
            for (var i = 0; i < NumGroups; i++) Groups.Add(new Group(id++));

            var groupNum = 0;
            foreach (var player in Players)
            {
                Groups[groupNum].Members.Add(player);
                if (groupNum == NumGroups - 1) groupNum = 0;
                else groupNum++;
            }
        }

        #endregion

        #region Utilities

        private Stream GetOpenFile(string filter, int filterIndex = 1)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = filter,
                FilterIndex = filterIndex
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                return openFileDialog.OpenFile();

            return null;
        }

        private Stream GetSaveFile(string filter, int filterIndex = 1)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = filter,
                FilterIndex = filterIndex
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                return saveFileDialog.OpenFile();

            return null;
        }

        private List<string> ParseBattletags(Stream filestream)
        {
            Battletags = new List<string>();

            using (var sr = new StreamReader(filestream))
            {
                var line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                    Battletags.Add(line.ToLower());
            }

            return Battletags;
        }

        #endregion
    }
}
