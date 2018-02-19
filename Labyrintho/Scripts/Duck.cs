using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Labyrintho.Scripts
{
    class Duck : Hostile
    {
        private static Image look_up = Properties.Resources.kks_up_1;
        private static Image look_down = Properties.Resources.kks_down_1;
        private static Image look_left = Properties.Resources.kks_left_1;
        private static Image look_right = Properties.Resources.kks_right_1;

        private Player.Navigator navigator;
        private static int animation_counter = 1;
        private int movement_counter = 0;

        public Duck(int position_X, int position_Y, Player.Navigator navigator) : base(position_X, position_Y, Properties.Resources.kks_down_1)
        {
            Debug.WriteLine("loaded duck");
            this.navigator = navigator;
        }

        public void SpriteManager()
        {
            switch(animation_counter)
            {
                case 1:
                    Debug.WriteLine("Animation++");
                    look_up = Properties.Resources.kks_up_1;
                    look_down = Properties.Resources.kks_down_1;
                    look_left = Properties.Resources.kks_left_1;
                    look_right = Properties.Resources.kks_right_1;
                    animation_counter++;
                    break;
                case 2:
                    look_up = Properties.Resources.kks_up_2;
                    look_down = Properties.Resources.kks_down_2;
                    look_left = Properties.Resources.kks_left_2;
                    look_right = Properties.Resources.kks_right_2;
                    animation_counter++;
                    break;
                case 3:
                    look_up = Properties.Resources.kks_up_3;
                    look_down = Properties.Resources.kks_down_3;
                    look_left = Properties.Resources.kks_left_3;
                    look_right = Properties.Resources.kks_right_3;
                    animation_counter++;
                    break;
                case 4:
                    look_up = Properties.Resources.kks_up_4;
                    look_down = Properties.Resources.kks_down_4;
                    look_left = Properties.Resources.kks_left_4;
                    look_right = Properties.Resources.kks_right_4;
                    animation_counter = 1;
                    break;
            }
        }

        public override void Move(List<Draw> solid)
        {
            switch (navigator)
            {
                case Player.Navigator.Up:
                    source = look_up;
                    Debug.WriteLine("Duck Moving up");
                    foreach(Draw d in solid)
                    {
                        if (location.y - 1 == d.location.y && location.x == d.location.x)
                        {
                            if (d is Wall || d is Door)
                            {
                                //Moves player back down if hitting wall
                                navigator = Player.Navigator.Down;
                                movement_counter = 0;
                                Move(solid);
                            }
                        }
                    }

                    --location.y;
                    ++movement_counter;
                    SpriteManager();
                    if (movement_counter == 4)
                    {
                        movement_counter = 0;
                        navigator = Player.Navigator.Down;
                    }

                    break;

                case Player.Navigator.Down:
                    source = look_down;
                    Debug.WriteLine("Duck Moving down");
                    foreach (Draw d in solid)
                    {
                        if (location.y + 1 == d.location.y && location.x == d.location.x)
                        {
                            if (d is Wall || d is Door)
                            {
                                //Moves player back down if hitting wall
                                navigator = Player.Navigator.Up;
                                movement_counter = 0;
                                Move(solid);
                            }
                        }
                    }
                    ++location.y;
                    ++movement_counter;
                    SpriteManager();
                    if (movement_counter == 4)
                    {
                        movement_counter = 0;
                        navigator = Player.Navigator.Up;
                    }

                    break;

                case Player.Navigator.Left:
                    source = look_left;
                    Debug.WriteLine("Duck Moving left");
                    foreach (Draw d in solid)
                    {
                        if (location.y == d.location.y && location.x - 1 == d.location.x)
                        {
                            if (d is Wall || d is Door)
                            {
                                //Moves player back down if hitting wall
                                navigator = Player.Navigator.Right;
                                movement_counter = 0;
                                Move(solid);
                            }
                        }
                    }
                    --location.x;
                    ++movement_counter;
                    SpriteManager();
                    if (movement_counter == 4)
                    {
                        movement_counter = 0;
                        navigator = Player.Navigator.Right;
                    }

                    break;

                case Player.Navigator.Right:
                    source = look_right;
                    Debug.WriteLine("Duck Moving right");
                    foreach (Draw d in solid)
                    {
                        if (location.y == d.location.y && location.x + 1 == d.location.x)
                        {
                            if (d is Wall || d is Door)
                            {
                                //Moves player back down if hitting wall
                                navigator = Player.Navigator.Left;
                                movement_counter = 0;
                                Move(solid);
                            }
                        }
                    }
                    ++location.x;
                    ++movement_counter;
                    SpriteManager();
                    if (movement_counter == 4)
                    {
                        movement_counter = 0;
                        navigator = Player.Navigator.Left;
                    }

                    break;

            }
        }

        public override void Hit(Player player)
        {
            player.DamageTaken(1);
        }
    }
}
