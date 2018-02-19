namespace Labyrintho.Screens
{
    partial class PauseMenu
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
            this.resume_button = new System.Windows.Forms.Button();
            this.restart_button = new System.Windows.Forms.Button();
            this.mainMenu_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resume_button
            // 
            this.resume_button.FlatAppearance.BorderSize = 0;
            this.resume_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resume_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resume_button.Location = new System.Drawing.Point(30, 62);
            this.resume_button.Name = "resume_button";
            this.resume_button.Size = new System.Drawing.Size(350, 50);
            this.resume_button.TabIndex = 0;
            this.resume_button.Text = "Resume";
            this.resume_button.UseVisualStyleBackColor = true;
            this.resume_button.Click += new System.EventHandler(this.resume_button_Click);
            // 
            // restart_button
            // 
            this.restart_button.FlatAppearance.BorderSize = 0;
            this.restart_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restart_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restart_button.Location = new System.Drawing.Point(30, 145);
            this.restart_button.Name = "restart_button";
            this.restart_button.Size = new System.Drawing.Size(350, 50);
            this.restart_button.TabIndex = 1;
            this.restart_button.Text = "Restart";
            this.restart_button.UseVisualStyleBackColor = true;
            this.restart_button.Click += new System.EventHandler(this.restart_button_Click);
            // 
            // mainMenu_button
            // 
            this.mainMenu_button.FlatAppearance.BorderSize = 0;
            this.mainMenu_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainMenu_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenu_button.Location = new System.Drawing.Point(30, 231);
            this.mainMenu_button.Name = "mainMenu_button";
            this.mainMenu_button.Size = new System.Drawing.Size(350, 50);
            this.mainMenu_button.TabIndex = 2;
            this.mainMenu_button.Text = "Main Menu";
            this.mainMenu_button.UseVisualStyleBackColor = true;
            this.mainMenu_button.Click += new System.EventHandler(this.mainMenu_button_Click);
            // 
            // PauseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 372);
            this.Controls.Add(this.mainMenu_button);
            this.Controls.Add(this.restart_button);
            this.Controls.Add(this.resume_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PauseMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PauseMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button resume_button;
        private System.Windows.Forms.Button restart_button;
        private System.Windows.Forms.Button mainMenu_button;
    }
}