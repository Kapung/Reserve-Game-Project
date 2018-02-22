namespace Labyrintho.Screens
{
    partial class MapEditor
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.mainMenu_Button = new System.Windows.Forms.Button();
            this.tileList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.examineBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1304, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBox.Location = new System.Drawing.Point(1308, 77);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(163, 29);
            this.nameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1304, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tiles";
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1308, 574);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainMenu_Button
            // 
            this.mainMenu_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainMenu_Button.Location = new System.Drawing.Point(1308, 605);
            this.mainMenu_Button.Name = "mainMenu_Button";
            this.mainMenu_Button.Size = new System.Drawing.Size(163, 23);
            this.mainMenu_Button.TabIndex = 5;
            this.mainMenu_Button.Text = "Main Menu";
            this.mainMenu_Button.UseVisualStyleBackColor = true;
            this.mainMenu_Button.Click += new System.EventHandler(this.mainMenu_Button_Click);
            // 
            // tileList
            // 
            this.tileList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileList.FormattingEnabled = true;
            this.tileList.Location = new System.Drawing.Point(1308, 263);
            this.tileList.Name = "tileList";
            this.tileList.Size = new System.Drawing.Size(163, 32);
            this.tileList.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1304, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Examine";
            // 
            // examineBox
            // 
            this.examineBox.Enabled = false;
            this.examineBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examineBox.Location = new System.Drawing.Point(1308, 169);
            this.examineBox.Name = "examineBox";
            this.examineBox.Size = new System.Drawing.Size(163, 29);
            this.examineBox.TabIndex = 8;
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 640);
            this.Controls.Add(this.examineBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tileList);
            this.Controls.Add(this.mainMenu_Button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MapEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapEditor";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MapEditor_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapEditor_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button mainMenu_Button;
        private System.Windows.Forms.ComboBox tileList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox examineBox;
    }
}