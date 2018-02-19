namespace Labyrintho.Screens
{
    partial class VictoryScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.finishLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.nextLevelButton = new System.Windows.Forms.Button();
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Congratulations";
            // 
            // finishLabel
            // 
            this.finishLabel.AutoSize = true;
            this.finishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishLabel.Location = new System.Drawing.Point(42, 136);
            this.finishLabel.Name = "finishLabel";
            this.finishLabel.Size = new System.Drawing.Size(0, 31);
            this.finishLabel.TabIndex = 1;
            this.finishLabel.Click += new System.EventHandler(this.finishLabel_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(42, 183);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 31);
            this.timeLabel.TabIndex = 2;
            // 
            // nextLevelButton
            // 
            this.nextLevelButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.nextLevelButton.FlatAppearance.BorderSize = 0;
            this.nextLevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextLevelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextLevelButton.Location = new System.Drawing.Point(12, 308);
            this.nextLevelButton.Name = "nextLevelButton";
            this.nextLevelButton.Size = new System.Drawing.Size(172, 40);
            this.nextLevelButton.TabIndex = 3;
            this.nextLevelButton.Text = "Next Level";
            this.nextLevelButton.UseVisualStyleBackColor = true;
            this.nextLevelButton.Click += new System.EventHandler(this.NextLevelButton_Click);
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainMenuButton.FlatAppearance.BorderSize = 0;
            this.mainMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuButton.Location = new System.Drawing.Point(220, 308);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(172, 40);
            this.mainMenuButton.TabIndex = 4;
            this.mainMenuButton.Text = "Main Menu";
            this.mainMenuButton.UseVisualStyleBackColor = true;
            this.mainMenuButton.Click += new System.EventHandler(this.mainMenuButton_Click);
            // 
            // VictoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 372);
            this.Controls.Add(this.mainMenuButton);
            this.Controls.Add(this.nextLevelButton);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.finishLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VictoryScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VictoryScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label finishLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button nextLevelButton;
        private System.Windows.Forms.Button mainMenuButton;
    }
}