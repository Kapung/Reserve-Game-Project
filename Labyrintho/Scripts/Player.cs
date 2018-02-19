using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrintho.Screens;

namespace Labyrintho.Scripts
{
    public class Player : Lightning
    {

        //Player variables
        public int hitpoints { get; private set; }
        public int max_hitpoints { get; private set; }
        public bool isAlive { get; private set; }
        public bool victorious { get; private set; }

        //Player sprite graphics      
        private Image look_up = Properties.Resources.GCharBack;
        private Image look_down = Properties.Resources.GCharFront;
        private Image look_left = Properties.Resources.GCharLeft;
        private Image look_right = Properties.Resources.GCharRight;

        //Inventory
        public Inventory inventory { get; private set; }

        //Navigation system for movement
        public enum Navigator
        {
            Left, Right, Up, Down
        }
        private int animation_counter = 1;

        //Constuctor for player
        public Player(float starting_position_x, float starting_position_y) : base(starting_position_x, starting_position_y, 1, 1, Properties.Resources.GCharFront, 5)
        {
            isAlive = true;
            hitpoints = 5;
            max_hitpoints = hitpoints;
            inventory = new Inventory();
            Debug.WriteLine("Player spawned");
        }

        //public void SpriteManager()
        //{
        //    switch (animation_counter)
        //    {
        //        case 1:
        //            look_up = Properties.Resources.kks_up_1;
        //            look_down = Properties.Resources.kks_down_1;
        //            look_left = Properties.Resources.kks_left_1;
        //            look_right = Properties.Resources.kks_right_1;
        //            animation_counter++;
        //            break;
        //        case 2:
        //            look_up = Properties.Resources.kks_up_2;
        //            look_down = Properties.Resources.kks_down_2;
        //            look_left = Properties.Resources.kks_left_2;
        //            look_right = Properties.Resources.kks_right_2;
        //            animation_counter++;
        //            break;
        //        case 3:
        //            look_up = Properties.Resources.kks_up_3;
        //            look_down = Properties.Resources.kks_down_3;
        //            look_left = Properties.Resources.kks_left_3;
        //            look_right = Properties.Resources.kks_right_3;
        //            animation_counter++;
        //            break;
        //        case 4:
        //            look_up = Properties.Resources.kks_up_4;
        //            look_down = Properties.Resources.kks_down_4;
        //            look_left = Properties.Resources.kks_left_4;
        //            look_right = Properties.Resources.kks_right_4;
        //            animation_counter = 1;
        //            break;
        //    }
        //}

        //Moving
        public void Move(Navigator n, List<Draw> hostiles)
        {
            float current_position_x = location.x;
            float current_position_y = location.y;

            switch (n)
            {
                case Navigator.Left:
                    //SpriteManager();
                    --location.x;
                    source = look_left;
                    break;
                case Navigator.Right:
                    //SpriteManager();
                    ++location.x;
                    source = look_right;
                    break;
                case Navigator.Up:
                    //SpriteManager();
                    --location.y;
                    source = look_up;
                    break;
                case Navigator.Down:
                    //SpriteManager();
                    ++location.y;
                    source = look_down;
                    break;
            }

            //Variables for hostiles
            List<Draw> hostile_list = new List<Draw>();
            List<object> item_list = new List<object>();
            hostile_list.AddRange(hostiles);
            item_list.AddRange(inventory.inventory_items);

            foreach (Draw d in hostile_list)
            {
                if (d.location.x == location.x && d.location.y == location.y)
                {
                    if (d is Wall)
                    {
                        location.y = current_position_y;
                        location.x = current_position_x;
                    }
                    else if (d is Key key)
                    {
                        if (inventory.items == 5)
                        {
                            UI.Message("Your inventory is full");
                        }
                        else if (!key.hasIt)
                        {
                            key.PickUp(this, hostiles);
                            GameScreen.refreshBar = true;
                        }
                    }
                    else if (d is Door door)
                    {
                        bool isOpen = false;
                        foreach (object o in item_list)
                        {
                            if (o is Key key1)
                            {
                                if (door == key1.door)
                                {
                                    inventory.inventory_items.Remove(key1);
                                    inventory.items -= 1;
                                    GameScreen.refreshBar = true;
                                    hostiles.Remove(door);
                                    isOpen = true;
                                    UI.Message("Unlocked " + door.door_name + " door");
                                }
                            }
                        }
                        if (!isOpen)
                        {
                            location.y = current_position_y;
                            location.x = current_position_x;
                            UI.Message(door.door_name + " is locked, you need a key.");
                        }
                    }
                    else if (d is EndPoint)
                    {
                        victorious = true;
                    }
                }
            }
            //OOP checker
            if (location.y < 0 || location.x < 0 || location.x > (39) || location.y > (19))
            {
                location.x = current_position_x;
                location.y = current_position_y;
            }
        }

        int i = 0;
        public void EnemyCollider(List<Draw>hostiles)
        {
            foreach (Draw d in hostiles)
            {
                if (location.x == d.location.x && location.y == d.location.y)
                {
                    if (d is Hostile hostile)
                    {
                        if (d is Duck duck)
                        {
                            i++;
                            Debug.WriteLine("Duck hitting enemy" + i);
                            duck.Hit(this);
                            UI.Message("You took 1 damage");
                        }
                    }
                }
            }
        }

        public void DamageTaken(int amount)
        {
            if (hitpoints - amount <= 0)
            {
                isAlive = false;
            }
            hitpoints -= amount;
            GameScreen.refreshBar = true;
        }
    }

}
