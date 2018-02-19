using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Labyrintho.Scripts
{
    public class Map
    {
        public String name { get; private set; }
        public List<Hostile> hostiles { get; private set; }
        public SpawnPoint spawn { get; private set; }
        public List<Draw> drawables { get; private set; }

        public Map() : this("Floor01")
        {
            //Default floor selection
        }

        public Map(String f_name)
        {
            name = f_name;
            XMLHelper xml = new XMLHelper();
            drawables = xml.Import(name, true);
            spawn = xml.spawn;
            hostiles = xml.hostiles;
        }
    }
}
