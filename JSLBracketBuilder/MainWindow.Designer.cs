namespace JSLBracketBuilder
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.SelectBtags = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.QueryAPI = new System.Windows.Forms.Button();
            this.MakeGroups = new System.Windows.Forms.Button();
            this.SaveGroups = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LoadExisting = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SaveData = new System.Windows.Forms.Button();
            this.SwitchRegion = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label_region = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectBtags
            // 
            this.SelectBtags.Location = new System.Drawing.Point(169, 153);
            this.SelectBtags.Name = "SelectBtags";
            this.SelectBtags.Size = new System.Drawing.Size(109, 23);
            this.SelectBtags.TabIndex = 0;
            this.SelectBtags.Text = "Select Battletags";
            this.SelectBtags.UseVisualStyleBackColor = true;
            this.SelectBtags.Click += new System.EventHandler(this.SelectBtags_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(445, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "JSL Bracket Builder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Step 2: Pull Data from Blizzard";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Step 3: Generate Groups";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Step 4: Save Groups to Disk";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Current State:";
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(393, 129);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(96, 13);
            this.label_state.TabIndex = 6;
            this.label_state.Text = "Awaiting Operation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Step 1: Load in Battletags";
            // 
            // QueryAPI
            // 
            this.QueryAPI.Location = new System.Drawing.Point(169, 182);
            this.QueryAPI.Name = "QueryAPI";
            this.QueryAPI.Size = new System.Drawing.Size(109, 23);
            this.QueryAPI.TabIndex = 9;
            this.QueryAPI.Text = "Query API";
            this.QueryAPI.UseVisualStyleBackColor = true;
            this.QueryAPI.Click += new System.EventHandler(this.QueryAPI_Click);
            // 
            // MakeGroups
            // 
            this.MakeGroups.Location = new System.Drawing.Point(169, 211);
            this.MakeGroups.Name = "MakeGroups";
            this.MakeGroups.Size = new System.Drawing.Size(109, 23);
            this.MakeGroups.TabIndex = 10;
            this.MakeGroups.Text = "Give Me Groups!";
            this.MakeGroups.UseVisualStyleBackColor = true;
            this.MakeGroups.Click += new System.EventHandler(this.MakeGroups_Click);
            // 
            // SaveGroups
            // 
            this.SaveGroups.Location = new System.Drawing.Point(169, 240);
            this.SaveGroups.Name = "SaveGroups";
            this.SaveGroups.Size = new System.Drawing.Size(109, 23);
            this.SaveGroups.TabIndex = 11;
            this.SaveGroups.Text = "Select Destination";
            this.SaveGroups.UseVisualStyleBackColor = true;
            this.SaveGroups.Click += new System.EventHandler(this.SaveGroups_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 102);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(321, 148);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(222, 23);
            this.progressBar1.TabIndex = 17;
            // 
            // LoadExisting
            // 
            this.LoadExisting.Location = new System.Drawing.Point(169, 124);
            this.LoadExisting.Name = "LoadExisting";
            this.LoadExisting.Size = new System.Drawing.Size(109, 23);
            this.LoadExisting.TabIndex = 18;
            this.LoadExisting.Text = "Select File";
            this.LoadExisting.UseVisualStyleBackColor = true;
            this.LoadExisting.Click += new System.EventHandler(this.LoadExisting_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Load in Existing Data";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(324, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Save Current Data";
            // 
            // SaveData
            // 
            this.SaveData.Location = new System.Drawing.Point(425, 196);
            this.SaveData.Name = "SaveData";
            this.SaveData.Size = new System.Drawing.Size(118, 23);
            this.SaveData.TabIndex = 22;
            this.SaveData.Text = "Select Destination";
            this.SaveData.UseVisualStyleBackColor = true;
            this.SaveData.Click += new System.EventHandler(this.SaveData_Click);
            // 
            // SwitchRegion
            // 
            this.SwitchRegion.Location = new System.Drawing.Point(425, 240);
            this.SwitchRegion.Name = "SwitchRegion";
            this.SwitchRegion.Size = new System.Drawing.Size(118, 23);
            this.SwitchRegion.TabIndex = 23;
            this.SwitchRegion.Text = "Switch Regions";
            this.SwitchRegion.UseVisualStyleBackColor = true;
            this.SwitchRegion.Click += new System.EventHandler(this.SwitchRegion_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(318, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Current Region: ";
            // 
            // label_region
            // 
            this.label_region.AutoSize = true;
            this.label_region.Location = new System.Drawing.Point(394, 246);
            this.label_region.Name = "label_region";
            this.label_region.Size = new System.Drawing.Size(22, 13);
            this.label_region.TabIndex = 25;
            this.label_region.Text = "US";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 277);
            this.Controls.Add(this.label_region);
            this.Controls.Add(this.SwitchRegion);
            this.Controls.Add(this.SaveData);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LoadExisting);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SaveGroups);
            this.Controls.Add(this.MakeGroups);
            this.Controls.Add(this.QueryAPI);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectBtags);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "JSL Bracket Builder";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectBtags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button QueryAPI;
        private System.Windows.Forms.Button MakeGroups;
        private System.Windows.Forms.Button SaveGroups;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button LoadExisting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SaveData;
        private System.Windows.Forms.Button SwitchRegion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_region;
    }
}