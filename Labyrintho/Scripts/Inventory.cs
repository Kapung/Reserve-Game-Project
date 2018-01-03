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
        public static PointF inventory_slot6 { get; private set; }
        public static PointF inventory_slot7 { get; private set; }

        //Inventory
        public List<object>inventory_items { get; private set; }

        //Initialize  inventory
        public Inventory()
        {
            inventory_slot1 = new PointF();
            inventory_slot2 = new PointF();
            inventory_slot3 = new PointF();
            inventory_slot4 = new PointF();
            inventory_slot5 = new PointF();
            inventory_slot6 = new PointF();
            inventory_slot7 = new PointF();

            inventory_items = new List<object>();
        }

        //Add item to inventory
        public void add_item(object item)
        {
            inventory_items.Add(item);
        }
    }
}
