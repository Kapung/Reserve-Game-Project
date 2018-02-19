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

namespace Labyrintho.Screens
{
    public partial class DeathMenu : Form
    {
        private GameScreen gs;

        public DeathMenu(GameScreen screen)
        {
            gs = screen;
            InitializeComponent();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            Map map = new Map(gs.map.name);
            Player player = new Player(map.spawn.location.x, map.spawn.location.y);
            GameScreen g = new GameScreen(player, map);
            g.Closed += (s, args) => Application.Exit();
            g.Show();

            gs.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
            gs.MusicStop();
            gs.Dispose();

            MainMenu1 m = new MainMenu1();
            m.Show();
        }
    }
}
