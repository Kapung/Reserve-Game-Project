using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrintho
{
    public partial class MainMenu1 : Form
    {
        public MainMenu1()
        {
            InitializeComponent();
        }

        private void play_button_Click(object sender, EventArgs e)
        {
            Screens.SelectMap m = new Screens.SelectMap(this);
            m.ShowDialog();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            DialogResult exit_choice = MessageBox.Show("Do you really want to quit?","", MessageBoxButtons.YesNo);
            if (exit_choice == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (exit_choice == DialogResult.No)
            {
                ;
            }
        }

        private void exit_button_MouseEnter(object sender, EventArgs e)
        {
            exit_button.UseVisualStyleBackColor = false;
            exit_button.BackColor = Color.DarkRed;
        }

        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.UseVisualStyleBackColor = true;
        }

        private void MainMenu1_Load(object sender, EventArgs e)
        {
            //Nothing
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
            Screens.MapEditor edi = new Screens.MapEditor();
            edi.ShowDialog();
        }
    }
}
