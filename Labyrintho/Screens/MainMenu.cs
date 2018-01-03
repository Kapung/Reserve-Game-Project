using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrintho.Screens
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            
        }

        private void play_button_Click(object sender, EventArgs e)
        {

        }
    }
}
