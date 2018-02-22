using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Labyrintho.Scripts
{
    class Editor
    {
        private string fileLocation = "";

        public Boolean SaveMap(string map_name, List<Draw> floor)
        {
            fileLocation = "@../../Resources" + map_name + ".xml";
            using (FileStream streamer = new FileStream(fileLocation, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(streamer))
            using (XmlTextWriter xml = new XmlTextWriter(sw))
            {
                xml.Formatting = Formatting.Indented;
                xml.Indentation = 4;
                xml.WriteStartDocument();
                xml.WriteStartElement("MAP");

                foreach(Draw d in floor)
                {
                    if (d is Wall)
                    {
                        xml.WriteStartElement("WALL");
                        xml.WriteElementString("X", d.location.x.ToString());
                        xml.WriteElementString("Y", d.location.y.ToString());
                        xml.WriteEndElement();

                    }
                    else if (d is Key key)
                    {
                        Door door = key.door;

                        xml.WriteStartElement("KEY");
                        xml.WriteElementString("X", d.location.x.ToString());
                        xml.WriteElementString("Y", d.location.y.ToString());
                        xml.WriteStartElement("DOOR");
                        xml.WriteElementString("X", door.location.x.ToString());
                        xml.WriteElementString("Y", door.location.y.ToString());
                        xml.WriteElementString("NAME", door.door_name.ToString());
                        xml.WriteEndElement();
                        xml.WriteEndElement();

                    }
                    else if (d is Hostile hostile)
                    {
                        xml.WriteStartElement("ENEMY");

                        if (hostile is Duck duck)
                        {
                            xml.WriteElementString("X", duck.location.x.ToString());
                            xml.WriteElementString("Y", duck.location.y.ToString());
                            xml.WriteElementString("NAME", "Duck");                         //Errors might be coming from this check later
                            xml.WriteElementString("FACING", duck.getNavigator().ToString());
                            xml.WriteEndElement();

                        }
                    } 
                    else if (d is SpawnPoint)
                    {
                        xml.WriteStartElement("SPAWNPOINT");
                        xml.WriteElementString("X", d.location.x.ToString());
                        xml.WriteElementString("Y", d.location.y.ToString());
                        xml.WriteEndElement();

                    }
                    else if (d is EndPoint)
                    {
                        xml.WriteStartElement("ENDPOINT");
                        xml.WriteElementString("X", d.location.x.ToString());
                        xml.WriteElementString("Y", d.location.y.ToString());
                        xml.WriteEndElement();

                    }
                    xml.WriteEndElement();
                    xml.WriteEndDocument();

                }
                return true;

            }
        }
    }

}
