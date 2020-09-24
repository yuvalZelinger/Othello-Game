namespace Ex02_Othelo_UI
{
    public partial class GameMainForm
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
            this.TilesTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // TilesTableLayout
            // 
            this.TilesTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TilesTableLayout.BackColor = System.Drawing.SystemColors.Control;
            this.TilesTableLayout.ColumnCount = 2;
            this.TilesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TilesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TilesTableLayout.Location = new System.Drawing.Point(15, 16);
            this.TilesTableLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TilesTableLayout.Name = "TilesTableLayout";
            this.TilesTableLayout.RowCount = 2;
            this.TilesTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TilesTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TilesTableLayout.Size = new System.Drawing.Size(1076, 1159);
            this.TilesTableLayout.TabIndex = 0;
            // 
            // GameMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1105, 1191);
            this.Controls.Add(this.TilesTableLayout);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameMainForm_FormClosed);
            this.Load += new System.EventHandler(this.gameMainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TilesTableLayout;
    }
}