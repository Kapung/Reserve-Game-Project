using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrintho.Screens
{
    public partial class MapEditorRotator : Form
    {
        private String hostileType;
        private Image up;
        private Image down;
        private Image left;
        private Image right;
        private Scripts.Player.Navigator CurrentChoice;
        private Boolean chosen;
        private MapEditor mE;

        public MapEditorRotator(String hostileType, MapEditor mE)
        {
            this.hostileType = hostileType;
            this.mE = mE;
            InitializeComponent();
            LoadImages();
            hostilePicture.Image = down;
        }

        private void LoadImages()
        {
            if (hostileType == "Duck")
            {
                up = Properties.Resources.kks_up_1;
                down = Properties.Resources.kks_down_1;
                left = Properties.Resources.kks_left_1;
                right = Properties.Resources.kks_right_1;

            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            hostilePicture.Image = up;
            CurrentChoice = Scripts.Player.Navigator.Up;
            chosen = true;
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            hostilePicture.Image = down;
            CurrentChoice = Scripts.Player.Navigator.Down;
            chosen = true;
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            hostilePicture.Image = left;
            CurrentChoice = Scripts.Player.Navigator.Left;
            chosen = true;
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            hostilePicture.Image = right;
            CurrentChoice = Scripts.Player.Navigator.Right;
            chosen = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (chosen)
            {
                Debug.WriteLine(CurrentChoice);
                mE.navigator = CurrentChoice;
                Close();
            }
            else
            {
                MessageBox.Show("Please select direction");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mE.isCanceled = true;
            Close();
        }
    }
}
