using System;
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
        private List<string> Battletags;
        private List<Player> ExistingData;

        private BackgroundWorker Worker;
        private Operation Operation;

        private new Region Region;
        private int SeasonID;
        private List<Ladder> Ladders;
        private List<Player> Players;
        private List<Group> Groups;

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
            using (var stream = GetFile(@"json files (*.json)|*.json"))
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
            using (Stream stream = GetFile(@"txt files (*.txt)|*.txt|All files|*.*", 1))
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

        }

        private void SaveGroups_Click(object sender, EventArgs e)
        {

        }

        private void SaveData_Click(object sender, EventArgs e)
        {

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
                case Operation.SAVE_GROUPS:
                    label_state.Text = @"Saving groups to disk";
                    break;
                case Operation.SAVE_DATA:
                    label_state.Text = @"Saving data to disk";
                    break;
                case Operation.LOAD_DATA:
                    label_state.Text = @"Loading existing data";
                    break;
                case Operation.LOAD_BTAGS:
                    label_state.Text = @"Loading Battletags";
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
                case Operation.SAVE_GROUPS:
                    SaveGroupsToDisk();
                    break;
                case Operation.SAVE_DATA:
                    SaveDataToDisk();
                    break;
                case Operation.LOAD_DATA:
                    LoadData();
                    break;
                case Operation.LOAD_BTAGS:
                    LoadBattletags();
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

        }

        private void GenerateGroups()
        {

        }

        private void SaveGroupsToDisk()
        {

        }

        private void SaveDataToDisk()
        {

        }

        private void LoadData()
        {

        }

        private void LoadBattletags()
        {
            
        }

        #endregion

        #region Utilities

        private Stream GetFile(string filter, int filterIndex = 1)
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
