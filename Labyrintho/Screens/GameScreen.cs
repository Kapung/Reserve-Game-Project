using Labyrintho.Scripts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Media;
using System.Windows.Forms;

namespace Labyrintho.Screens
{
    public partial class GameScreen : Form
    {
        //Main variables
        public List<Draw> drawables = new List<Draw>();
        public Player player { get; set; }
        public Map map { get; set; }
                                                                                                                            //Fix Game -> Main Menu -> Game -> Main Menu Memory overload
        //For gameplay
        public const int tileSize = 32;
        public int hp { get; private set; }
        private SoundPlayer music;
        private bool music_mute = false;
        public Keys keyPress;
       // public List<Lightning> lights = new List<Lightning>(); USE LATER
        public static bool refreshBar;

        //Timer
        private int mSeconds = 0;
        public int seconds = 0;
        public int minutes = 0;
        private PointF clockation = new PointF(1200, 650); //Timer location

        public GameScreen(Player player, Map map)
        {
            //Loads essentials
            this.map = map;
            this.player = player;
            drawables = map.drawables;
            InitializeComponent();
            hp = player.hitpoints;
            //Makes game better
            ResizeRedraw = true;
            DoubleBuffered = true;
            refreshBar = true;
            music = new SoundPlayer(Labyrintho.Properties.Resources.bgmusic);
            UI.GameScreenSetup(this);
            music.PlayLooping();

        }

        public void MusicStop()
        {
            music.Stop();
        }

        //Draws timer
        protected override void OnPaint(PaintEventArgs p) 
        {
            base.OnPaint(p);
            Graphics g = p.Graphics;
            if (minutes < 10)
            {
                if (seconds < 10)
                {
                    g.DrawString("0" + minutes + ":" + "0" + seconds, new Font(FontFamily.GenericMonospace, 14F), new SolidBrush(Color.White), clockation);
                }
                else
                {
                    g.DrawString("0" + minutes + ":" + seconds, new Font(FontFamily.GenericMonospace, 14F), new SolidBrush(Color.White), clockation);
                }
            }
            else
            {
                if (seconds < 10)
                {
                    g.DrawString(minutes + ":" + "0" + seconds, new Font(FontFamily.GenericMonospace, 14F), new SolidBrush(Color.White), clockation);
                }
                else
                {
                    g.DrawString(minutes + ":" + seconds, new Font(FontFamily.GenericMonospace, 14F), new SolidBrush(Color.White), clockation);
                }
            }
            foreach (Draw d in drawables)
            {
                if (Darkness.CalculateSize(player, d))
                {
                    if (!(d.source == null))
                    {
                        if (d is Wall wall)
                        {
                            wall.checkErrors(drawables);
                        }
                        else if (d is Door door)
                        {
                            door.checkErrors(drawables);
                        }

                        ColorMatrix colorizer = new ColorMatrix();
                        colorizer.Matrix33 = Darkness.DarkLevel(player, d);

                        ImageAttributes attr = new ImageAttributes();
                        attr.SetColorMatrix(colorizer, ColorMatrixFlag.Default);

                        Rectangle rect = new Rectangle((int)d.location.x * tileSize, (int)d.location.y * tileSize, (int)d.width * tileSize, (int)d.height * tileSize);
                        g.DrawImage(d.source, rect, 0, 0, tileSize, tileSize, GraphicsUnit.Pixel, attr);
                    }
                    else
                    {
                        //Troubleshooting
                        g.FillRectangle(d.brush, d.location.x * tileSize, d.location.y * tileSize, d.width * tileSize, d.height * tileSize);
                    }
                }
            }
            //Player
            Rectangle player_sprite = new Rectangle((int)player.location.x * tileSize, (int)player.location.y * tileSize, (int)player.width * tileSize, (int)player.height * tileSize);
            g.DrawImage(player.source, player_sprite);

            int times = 0;

            if (refreshBar)
            {
                times++;
                Debug.WriteLine("Bar refreshed: " + times + "times");
                Graphics g2 = panel1.CreateGraphics();
                g2.DrawImage(Properties.Resources.inventory, new PointF(494, 0));
                int n = 1;

                foreach(Draw d in player.inventory.inventory_items)
                {
                    Image texture = d.source;
                    PointF point = new PointF(0, 0);
                    switch (n)
                    {
                        case 1:
                            point = Inventory.inventory_slot1;
                            n+=1;
                            break;
                        case 2:
                            point = Inventory.inventory_slot2;
                            n+=1;
                            break;
                        case 3:
                            point = Inventory.inventory_slot3;
                            n+=1;
                            break;
                        case 4:
                            point = Inventory.inventory_slot4;
                            n+=1;
                            break;
                        case 5:
                            point = Inventory.inventory_slot5;
                            break;
                    }
                    Rectangle rect_location = new Rectangle((int)point.X + 7, (int)point.Y + 7, 32, 32);
                    Debug.WriteLine("Location: " + rect_location);
                    g2.DrawImage(texture, rect_location);

                    if (d is Key key)
                    {
                        g2.DrawString(key.door.door_name, new Font(FontFamily.GenericMonospace, 7.0F), new SolidBrush(Color.White), new PointF(point.X + 2, 32));
                    }
                }

                //Empty hearts under full heart
                for (int lives = player.max_hitpoints; lives > 0; lives--)
                {
                    Rectangle hp_position = new Rectangle(15 + lives * 35 - 35, 5, 32, 32);
                    g2.DrawImage(Properties.Resources.hpEmpty, hp_position);
                }

                //Full hearts on top
                for (int lives = 0; lives < player.hitpoints; lives++)
                {
                    Rectangle hp_position = new Rectangle(15 + lives * 35, 5, 32, 32);
                    g2.DrawImage(Properties.Resources.hpFull, hp_position);
                }
                refreshBar = false;
            }
            UI.DisplayMessage(g);
        }

        private void Death()
        {
            player.EnemyCollider(drawables);

            if (!player.isAlive)
            {
                Invalidate();
                clockTimer.Stop();
                Form d_screen = new DeathMenu((GameScreen)this);
                d_screen.ShowDialog();
            }
        }

        private void GameScreen_KeyDown_1(object sender, KeyEventArgs e)
        {
            keyPress = e.KeyCode;
            time_out = 2;
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

        int i = 0;
        private void clockTimer_Tick(object sender, EventArgs e)
        {
            mSeconds += 500;
            if (mSeconds == 1000)
            {
                seconds += 1;
                mSeconds = 0;

                if (seconds == 60)
                {
                    minutes += 1;
                    seconds = 0;
                }

                foreach(Hostile hostile in map.hostiles)
                {
                    i++;
                    Debug.WriteLine("Moving..." + i);
                    hostile.Move(drawables);

                    Death(); //Checks if enemy hits

                }
            }
            Invalidate();
        }

        public void StartEnemyTimer()
        {
            clockTimer.Start();
        }

        int time_out = 0;

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            --time_out;
            if (time_out == 1)
            {
                time_out = 0;
                //Player keys
                switch (keyPress)
                {
                    case Keys.Up:
                    case Keys.W:
                        player.Move(Player.Navigator.Up, drawables);
                        break;

                    case Keys.Down:
                    case Keys.S:
                        player.Move(Player.Navigator.Down, drawables);
                        break;

                    case Keys.Left:
                    case Keys.A:
                        player.Move(Player.Navigator.Left, drawables);
                        break;

                    case Keys.Right:
                    case Keys.D:
                        player.Move(Player.Navigator.Right, drawables);
                        break;

                    case Keys.Escape:
                        clockTimer.Stop();
                        Form PauseMenu = new PauseMenu((GameScreen)ActiveForm);
                        PauseMenu.ShowDialog();
                        break;

                    case Keys.M:
                        switch(music_mute)
                        {
                            case false:
                                music.Stop();
                                break;
                            case true:
                                music.PlayLooping();
                                break;
                        }
                        music_mute = !music_mute;
                        break;
                }

                Death();
                Invalidate();

                if (player.victorious)
                {
                    clockTimer.Stop();
                    VictoryScreen vs = new VictoryScreen((GameScreen)this);
                    vs.ShowDialog();
                }
            }
        }

        private void messageTimer_Tick(object sender, EventArgs e)
        {
            UI.FadeMessage();
        }

        public void Reset_Timer()
        {
            minutes = 0;
            seconds = 0;
        }
    }
}
