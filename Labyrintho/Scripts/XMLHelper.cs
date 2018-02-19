using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;
using System.IO;

namespace Labyrintho.Scripts
{
    class XMLHelper
    {
        //Variables for import
        public SpawnPoint spawn { get; private set; }
        public List<Hostile> hostiles { get; private set; }

        public List<Draw>Import(string f_name, Boolean putFloor)
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"../../Resources/" + f_name + ".xml");
            //document.Load(@"../../Resources/Floor01.xml");

            List<Draw> map = new List<Draw>();
            List<Draw> drawables = new List<Draw>();
            hostiles = new List<Hostile>();

            //Spawn XML
            foreach(XmlNode node in document.SelectNodes("MAP/SPAWNPOINT"))
            {
                int x = int.Parse(node["X"].InnerText);
                int y = int.Parse(node["Y"].InnerText);
                spawn = new SpawnPoint(x, y);

                drawables.Add(spawn);
            }

            //EndPoint XML
            foreach (XmlNode node in document.SelectNodes("MAP/ENDPOINT"))
            {
                int x = int.Parse(node["X"].InnerText);
                int y = int.Parse(node["Y"].InnerText);
                Draw endPoint = new EndPoint(x, y);

                drawables.Add(endPoint);
            }

            //Wall XML
            foreach (XmlNode node in document.SelectNodes("MAP/WALL"))
            {
                int x = int.Parse(node["X"].InnerText);
                int y = int.Parse(node["Y"].InnerText);
                Wall wall = new Wall(x, y);

                drawables.Add(wall);
            }

            //Key XML
            foreach (XmlNode node in document.SelectNodes("MAP/KEY"))
            {
                Door door = null;
                foreach (XmlNode door_node in node.SelectNodes("DOOR"))
                {
                    int xD = int.Parse(door_node["X"].InnerText);
                    int yD = int.Parse(door_node["Y"].InnerText);
                    string door_name = door_node["NAME"].InnerText;
                    door = new Door(xD, yD, door_name);
                    Debug.WriteLine("Added door to the list and xD/xY: " + xD + "/" + yD);
                    drawables.Add(door);
                    break;
                }
                int x = int.Parse(node["X"].InnerText);
                int y = int.Parse(node["Y"].InnerText);
                Key key = new Key(x, y, door);

                drawables.Add(key);

            }

            //Duck XML
            foreach(XmlNode node in document.SelectNodes("MAP/HOSTILE"))
            {
                int x = int.Parse(node["X"].InnerText);
                int y = int.Parse(node["Y"].InnerText);
                string enemy_name = node["NAME"].InnerText;
                Player.Navigator navigator = Player.Navigator.Up;

                if (enemy_name == "Duck")
                {
                    string facing = node["FACING"].InnerText;
                    switch(facing.ToLower())
                    {
                        case "up":
                            navigator = Player.Navigator.Up;
                            break;
                        case "down":
                            navigator = Player.Navigator.Down;
                            break;
                        case "left":
                            navigator = Player.Navigator.Left;
                            break;
                        case "right":
                            navigator = Player.Navigator.Right;
                            break;
                    }
                    Hostile hostile = new Duck(x, y, navigator);
                    hostiles.Add(hostile);
                }
            }

            //Add enemies to drawables
            drawables.AddRange(hostiles);

            if (putFloor)
            {
                bool has = false;
                for (int x = 0; x < 40; x++)
                {
                    int xy = 0;
                    for (int y = 0; y < 20; y++)
                    {
                        has = false;
                        
                        foreach(Draw d in drawables)
                        {
                            if ((d.location.x) == x && (d.location.y) == y && d is Wall)
                            {
                                has = true;
                            }

                            xy = y;
                        }
                        if (!has)
                        {
                            map.Add(new Floor(x, xy));
                        }
                    }
                }
            }

            map.AddRange(drawables);
            return map;
        }
    }
}
