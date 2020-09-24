namespace Ex02_Othelo_UI
{
    public partial class GameSettingsForm
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
            this.SetBoardSizeButton = new System.Windows.Forms.Button();
            this.ComputerPlayerButton = new System.Windows.Forms.Button();
            this.HumanPlayerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SetBoardSizeButton
            // 
            this.SetBoardSizeButton.Location = new System.Drawing.Point(16, 15);
            this.SetBoardSizeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SetBoardSizeButton.Name = "SetBoardSizeButton";
            this.SetBoardSizeButton.Size = new System.Drawing.Size(511, 58);
            this.SetBoardSizeButton.TabIndex = 0;
            this.SetBoardSizeButton.Text = "Board Size: 6x6 (click to increase)";
            this.SetBoardSizeButton.UseVisualStyleBackColor = true;
            this.SetBoardSizeButton.Click += new System.EventHandler(this.setBoardSizeButton_Click);
            // 
            // ComputerPlayerButton
            // 
            this.ComputerPlayerButton.Location = new System.Drawing.Point(16, 98);
            this.ComputerPlayerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ComputerPlayerButton.Name = "ComputerPlayerButton";
            this.ComputerPlayerButton.Size = new System.Drawing.Size(224, 63);
            this.ComputerPlayerButton.TabIndex = 1;
            this.ComputerPlayerButton.Text = "Play Against Computer";
            this.ComputerPlayerButton.UseVisualStyleBackColor = true;
            this.ComputerPlayerButton.Click += new System.EventHandler(this.computerPlayerButton_Click);
            // 
            // HumanPlayerButton
            // 
            this.HumanPlayerButton.Location = new System.Drawing.Point(304, 98);
            this.HumanPlayerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HumanPlayerButton.Name = "HumanPlayerButton";
            this.HumanPlayerButton.Size = new System.Drawing.Size(223, 63);
            this.HumanPlayerButton.TabIndex = 2;
            this.HumanPlayerButton.Text = "Play Against Your Friend";
            this.HumanPlayerButton.UseVisualStyleBackColor = true;
            this.HumanPlayerButton.Click += new System.EventHandler(this.humanPlayerButton_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 187);
            this.Controls.Add(this.HumanPlayerButton);
            this.Controls.Add(this.ComputerPlayerButton);
            this.Controls.Add(this.SetBoardSizeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello - Game Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.gameSettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.gameSettingsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SetBoardSizeButton;
        private System.Windows.Forms.Button ComputerPlayerButton;
        private System.Windows.Forms.Button HumanPlayerButton;
    }
}