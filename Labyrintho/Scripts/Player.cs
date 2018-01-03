using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Image look_up = Labyrintho.Properties.Resources.look_up;
        private Image look_down = Labyrintho.Properties.Resources.look_down;
        private Image look_left = Labyrintho.Properties.Resources.look_left;
        private Image look_right = Labyrintho.Properties.Resources.look_right;

        //Inventory
        public Inventory inventory { get; private set; }

        //Navigation system for movement
        public enum Navigator
        {
            Left, Right, Up, Down
        }

        //Constuctor for player
        public Player(float starting_position_x, float starting_position_y) : base(starting_position_x, starting_position_y, 1, 1, Labyrintho.Properties.Resources.look_down, 5)
        {
            isAlive = true;
            hitpoints = 5;
            max_hitpoints = hitpoints;
            inventory = new Inventory();
        }

        //Moving
        public void Move(Navigator n, List<Draw> hostiles)
        {
            float current_position_x = location.x;
            float current_position_y = location.y;

            switch(n)
            {
                case Navigator.Left:
                    --location.x;
                    source = look_left;
                    break;
                case Navigator.Right:
                    ++location.x;
                    source = look_right;
                    break;
                case Navigator.Up:
                    --location.y;
                    source = look_up;
                    break;
                case Navigator.Down:
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
                }
            }

            if (location.y < 0 || location.x < 0 || location.x > 40 ||location.y > 30 )
            {
                location.x = current_position_x;
                location.y = current_position_y;
            }

        } 

        public void DamageTaken(int amount)
        {
            if (hitpoints - amount <= 0)
            {
                isAlive = false;
            }
            hitpoints -= amount;
            //Add something here later
        }

    }

}
