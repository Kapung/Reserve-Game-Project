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
using Labyrintho.Scripts;
using System.IO;

namespace Labyrintho.Screens
{
    public partial class VictoryScreen : Form
    {
        private GameScreen gs;
        private int counter;
        private int number;
        private string map_name;

        public VictoryScreen(GameScreen gs)
        {
            counter = 0;
            this.gs = gs;
            InitializeComponent();
            finishLabel.Text = "You finished " + gs.map.name.ToLower();
            TimeSet();
            FileCounter();
            ChangeMap();
            if (counter < number)
            {
                nextLevelButton.Visible = false;
            }
        }
        
        private void TimeSet()
        {
            if (gs.minutes < 10 && gs.seconds < 10)
            {
                timeLabel.Text = "Time: 0" + gs.minutes + ":0" + gs.seconds;
            }
            else if (gs.minutes < 10)
            {
                timeLabel.Text = "Time: 0" + gs.minutes + ":" + gs.seconds;
            }
            else if (gs.seconds < 10)
            {
                timeLabel.Text = "Time: " + gs.minutes + ":0" + gs.seconds;
            }
            else
            {
                timeLabel.Text = "Time: " + gs.minutes + ":" + gs.seconds;
            }
        }

        private void FileCounter()
        {
            DirectoryInfo dir = new DirectoryInfo(@"../../Resources/");
            FileInfo[] file = dir.GetFiles("*.xml");

            foreach (FileInfo f in file)
            {
                counter++;
            }
        }

        private void ChangeMap()
        {
            counter = 0;
            FileCounter();
            map_name = gs.map.name;
            string numberL = map_name.Substring(map_name.Length - 1);
            number = Int32.Parse(numberL);
            number++;
        }

        private void NextLevelButton_Click(object sender, EventArgs e)
        {
            string new_map = map_name.Substring(0, map_name.Length - 1) + number.ToString() + "";

            Map map = new Map(new_map);
            Player p = new Player(map.spawn.location.x, map.spawn.location.y);
            GameScreen screen = new GameScreen(p, map);
            screen.Closed += (s, args) => Application.Exit();
            screen.Show();
            Dispose();
            gs.Dispose();
            

        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            Dispose();
            gs.MusicStop();
            gs.Dispose();

            MainMenu1 m = new MainMenu1();
            m.Show();
        }

        private void finishLabel_Click(object sender, EventArgs e)
        {
            //Ddint know how to delete these
        }
    }
}
