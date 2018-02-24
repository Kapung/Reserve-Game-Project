using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Labyrintho.Scripts
{
    class Editor
    {

        public Boolean SaveMap(string map_name, List<Draw> floor)
        {
            string fileLocation = "../../Resources/" + map_name + ".xml";
            using (FileStream streamer = new FileStream(fileLocation, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(streamer))
            using (XmlTextWriter xml = new XmlTextWriter(sw))
            {
                xml.Formatting = Formatting.Indented;
                xml.Indentation = 4;
                xml.WriteStartDocument();
                xml.WriteStartElement("MAP");
                Debug.WriteLine(fileLocation);
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
                        Debug.WriteLine("Saving key");
                        Door door = key.door;
                        Debug.WriteLine(door);
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
                        Debug.WriteLine("Saving enemy");
                        xml.WriteStartElement("HOSTILE");

                        if (hostile is Duck duck)
                        {
                            Debug.WriteLine("Saving enemyProceed");
                            xml.WriteElementString("X", duck.location.x.ToString());
                            xml.WriteElementString("Y", duck.location.y.ToString());
                            xml.WriteElementString("NAME", "Duck");                         //Errors might be coming from this check later
                            xml.WriteElementString("FACING", duck.getNavigator().ToString());

                        }
                        xml.WriteEndElement();
                    } 
                    else if (d is SpawnPoint)
                    {
                        Debug.WriteLine("Saving SP");
                        xml.WriteStartElement("SPAWNPOINT");
                        xml.WriteElementString("X", d.location.x.ToString());
                        xml.WriteElementString("Y", d.location.y.ToString());
                        xml.WriteEndElement();

                    }
                    else if (d is EndPoint)
                    {
                        Debug.WriteLine("Saving EP");
                        xml.WriteStartElement("ENDPOINT");
                        xml.WriteElementString("X", d.location.x.ToString());
                        xml.WriteElementString("Y", d.location.y.ToString());
                        xml.WriteEndElement();

                    }
                }
                Debug.WriteLine("Done with typing");
                xml.WriteEndElement();
                xml.WriteEndDocument();

            }
            return true;
        }
    }
}
