using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Labyrintho.Scripts;
using System.IO;

namespace Labyrintho.Screens
{
    public partial class SelectMap : Form
    {
        //Holds screen value
        private MainMenu1 main;

        public SelectMap(MainMenu1 main_m)
        {
            main = main_m;
            InitializeComponent();
            PreloadList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PreloadList()
        {
            DirectoryInfo dir = new DirectoryInfo("../../Resources/");
            FileInfo[] file = dir.GetFiles("*.xml");

            foreach(FileInfo f in file)
            {
                //Deletes last 4 (.xml) from name
                map_list.Items.Add(f.ToString().Substring(0, f.ToString().Length - 4));
            }
        }

        private void load_button_Click(object sender, EventArgs e)
        {
            Map map = new Map(map_list.SelectedItem.ToString());
            Player p = new Player(map.spawn.location.x, map.spawn.location.y);
            GameScreen screen = new GameScreen(p, map);
            screen.Closed += (s, args) => Application.Exit();
            screen.Show();
            Dispose();
            main.Dispose();

        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
