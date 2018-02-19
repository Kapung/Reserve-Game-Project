using System;
using System.Drawing;
using System.Collections.Generic;

namespace Labyrintho.Scripts
{
    public class Inventory
    {
        //Inventory slots
        public static PointF inventory_slot1 { get; private set; }
        public static PointF inventory_slot2 { get; private set; }
        public static PointF inventory_slot3 { get; private set; }
        public static PointF inventory_slot4 { get; private set; }
        public static PointF inventory_slot5 { get; private set; }

        //Inventory
        public List<object>inventory_items { get; private set; }
        public int items = 0;

        //Initialize  inventory
        public Inventory()
        {
            //Every 48 tiles
            inventory_slot1 = new PointF(496, 2); 
            inventory_slot2 = new PointF(544, 2);
            inventory_slot3 = new PointF(592, 2);
            inventory_slot4 = new PointF(640, 2);
            inventory_slot5 = new PointF(688, 2);

            inventory_items = new List<object>();
        }

        //Add item to inventory
        public void add_item(object item)
        {
            inventory_items.Add(item);
            items++;
        }
    }
}
