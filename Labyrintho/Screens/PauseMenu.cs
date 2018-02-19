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
    public partial class PauseMenu : Form
    {
        private GameScreen gs;
        public PauseMenu(GameScreen gs)
        {
            this.gs = gs;
            InitializeComponent();
        }

        private void resume_button_Click(object sender, EventArgs e)
        {
            //Resumes timer and closes window
            gs.StartEnemyTimer();
            Close();
        }

        private void restart_button_Click(object sender, EventArgs e)
        {
            //Loads same map again
            Map map = new Map(gs.map.name);
            Player player = new Player(map.spawn.location.x, map.spawn.location.y);
            GameScreen g = new GameScreen(player, map);
            g.Closed += (s, args) => Application.Exit();
            g.Show();

            gs.Dispose();
            
        }

        private void mainMenu_button_Click(object sender, EventArgs e)
        {
            Dispose();
            gs.MusicStop();
            gs.Dispose();

            MainMenu1 m = new MainMenu1();
            m.Show();
        }
    }
}
