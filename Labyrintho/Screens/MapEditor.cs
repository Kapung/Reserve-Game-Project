using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Labyrintho.Scripts;
using System.Diagnostics;

namespace Labyrintho.Screens
{
    public partial class MapEditor : Form
    {

        private Editor editor = new Scripts.Editor();
        private List<Draw> map = new List<Draw>();
        private List<Rectangle> grid = new List<Rectangle>();

        private int tileSize = GameScreen.tileSize;
        private int x = 40;
        private int y = 20;

        //MapEditorNamer variables
        public Boolean isCanceled = false;
        public string nameTextBoxFilled = "";

        //Temporary holders
        private Door editorDoor;
        private string type = "";
        public Player.Navigator navigator;

        //These will be used on close after you have set the name for door/key
        private int xHolder = 0;
        private int yHolder = 0;

        //For confirmation that SP and EP exists
        private SpawnPoint editorSP;
        private EndPoint editorEP;


        Dictionary<string, string> TileList = new Dictionary<string, string>()
        {
            {"Wall", "Wall" },
            {"Spawn", "SpawnPoint" },
            {"Finish", "EndPoint" },
            {"Key", "Key" },
            {"Door", "Door" },
            {"Duck", "Duck" }
        };

        public MapEditor()
        {
            InitializeComponent();
            DoubleBuffered = true;
            tileList.DataSource = new BindingSource(TileList, null);
            tileList.DisplayMember = "Value";
            tileList.ValueMember = "Key";

            tileList.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Debug.WriteLine("Running through");
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Pen s = new Pen(Color.Black);

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Rectangle gridTile = new Rectangle(j * tileSize, i * tileSize, tileSize, tileSize);

                    grid.Add(gridTile);

                    g.FillRectangle(new SolidBrush(Color.White), gridTile);

                }
            }

            for (int yGrid = 0; yGrid <= y; yGrid++)
            {
                g.DrawLine(s, 0, yGrid * tileSize, x * tileSize, yGrid * tileSize);
            }

            for (int xGrid = 0; xGrid <= x; xGrid++)
            {
                g.DrawLine(s, xGrid * tileSize, 0, xGrid * tileSize, y * tileSize);
            }

            foreach(Draw d in map)
            {
                Debug.WriteLine("Drawing images");
                if (!(d.source == null))
                {
                    if (d is Wall wall)
                    {
                        wall.checkErrors(map);
                    }
                    else if (d is Door door)
                    {
                        door.checkErrors(map);
                    }
                    else if (d is SpawnPoint sp)
                    {
                        editorSP = sp;
                    }
                    else if (d is EndPoint ep)
                    {
                        editorEP = ep;
                    }
                    Rectangle rect = new Rectangle((int)d.location.x * tileSize, (int)d.location.y * tileSize, (int)d.width * tileSize, (int)d.height * tileSize);
                    e.Graphics.DrawImage(d.source, rect);
                } else
                {
                    g.FillRectangle(d.brush, d.location.x * tileSize, d.location.y * tileSize, d.width * tileSize, d.height * tileSize);
                }
            }
        }

        private Boolean Exist<T>()
        {
            foreach(Draw d in map)
            {
                if (tileList is T)
                {
                    return true;
                }
            }
            return false;
        }

        private Boolean DoorExist(string name)
        {
            foreach (Draw d in map)
            {
                if (d is Door door && door.door_name == name)
                {
                    editorDoor = door;
                    return true;
                }
            }
            return false;
        }

        private String examineTile(Point click)
        {
            foreach (Rectangle rect in grid)
            {
                if (rect.Contains(click))
                {
                    foreach (Draw d in map)
                    {
                        if (d is Door door && (rect.X / tileSize == d.location.x) && (rect.Y / tileSize == d.location.y))
                        {
                            return door.door_name.ToString();
                        }
                        else if (d is Key key && (rect.X / tileSize == d.location.x) && (rect.Y / tileSize == d.location.y))
                        {
                            return key.door.door_name.ToString();
                        }
                        else if (d is SpawnPoint sp && (rect.X / tileSize == d.location.x) && (rect.Y / tileSize == d.location.y))
                        {
                            return "SpawnPoint";
                        }
                        else if (d is EndPoint ep && (rect.X / tileSize == d.location.x) && (rect.Y / tileSize == d.location.y))
                        {
                            return "EndPoint";
                        }
                        else if (d is Wall wall && (rect.X / tileSize == d.location.x) && (rect.Y / tileSize == d.location.y))
                        {
                            return "Wall";
                        }
                        else if (d is Hostile hostile && (rect.X / tileSize == d.location.x) && (rect.Y / tileSize == d.location.y))
                        {
                            if (d is Duck duck)
                            {
                                return "Duck / Way: " + duck.getNavigator().ToString();
                            }
                        }
                    }
                }
            }
            return "Error";
        }

        private void MapEditorNamer_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (!isCanceled)
            {
                if (nameTextBoxFilled.Length >= 1)
                {
                    switch (type)
                    {
                        case "Door":
                            map.Add(new Door(xHolder, yHolder, nameTextBoxFilled));
                            break;
                        case "Key":
                            if (DoorExist(nameTextBoxFilled))
                            {
                                map.Add(new Key(xHolder, yHolder, editorDoor));
                            }
                            else
                            {
                                MessageBox.Show("Door by that name doesn't exist");
                            }
                            break;
                    }

                }
            }
        }

        private void MapEditorRotator_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("Rotator first phase");
            if (!isCanceled)
            {
                switch (type)
                {
                    case "Duck":
                        Debug.WriteLine(navigator);
                        map.Add(new Duck(xHolder, yHolder, navigator));
                        break;
                }
            }
        }

        private void Add(Point click)
        {
            Boolean canDraw = true;

            foreach (Rectangle rect in grid)
            {
                if (rect.Contains(click))
                {
                    foreach (Draw d in map)
                    {
                        //If tile is occupied
                        if ((rect.X / tileSize == d.location.x) && (rect.Y / tileSize == d.location.y))
                        {
                            canDraw = false;
                        }
                    }

                    if (canDraw)
                    {
                        String what = ((KeyValuePair<string, string>)tileList.SelectedItem).Key;
                        MapEditorNamer namer = new MapEditorNamer(this);
                        MapEditorRotator rotator = new MapEditorRotator(what, this);
                        namer.FormClosing += MapEditorNamer_FormClosing;
                        rotator.FormClosing += MapEditorRotator_FormClosing;
                        int posX = rect.X / tileSize;
                        int posY = rect.Y / tileSize;

                        switch (what)
                        {
                            case "Wall":
                                map.Add(new Wall(posX, posY));
                                break;

                            case "Key":
                                xHolder = posX;
                                yHolder = posY;
                                type = what;
                                namer.ShowDialog();
                                break;

                            case "Door":
                                xHolder = posX;
                                yHolder = posY;
                                type = what;
                                namer.ShowDialog();
                                break;

                            case "Spawn":
                                if (Exist<SpawnPoint>())
                                {
                                    Delete(new Point((int)editorSP.location.x * tileSize, (int)editorSP.location.y * tileSize));
                                }
                                SpawnPoint sp = new SpawnPoint(posX, posY);
                                editorSP = sp;
                                map.Add(sp);
                                break;

                            case "Finish":
                                if (Exist<EndPoint>())
                                {
                                    Delete(new Point((int)editorEP.location.x * tileSize, (int)editorEP.location.y * tileSize));
                                }

                                EndPoint ep = new EndPoint(posX, posY);
                                editorEP = ep;
                                map.Add(ep);
                                break;
                            case "Duck":
                                xHolder = posX;
                                yHolder = posY;
                                type = what;
                                rotator.ShowDialog();
                                break;

                        }
                        break;
                    }
                }
            }

            Invalidate();
        }

        private void Delete(Point click)
        {
            //To delete multiple at the same time
            List<int> removalList = new List<int>();

            foreach (Rectangle rect in grid)
            {
                if (rect.Contains(click))
                {
                    for (int i = 0; i < map.Count(); i++)
                    {
                        if ((rect.X / tileSize == map[i].location.x) && (rect.Y / tileSize == map[i].location.y))
                        {
                            removalList.Add(i);

                            if (map[i] is Door door)
                            {
                                for (int j = 0; j < map.Count(); j++)
                                {
                                    if (map[j] is Key key && key.door.door_name == door.door_name)
                                    {
                                        removalList.Add(j);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            map.RemoveAll(index => removalList.Contains(map.IndexOf(index)));
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e) // Save button
        {
            Debug.WriteLine("Saving file");
            if (Exist<SpawnPoint>() && Exist<EndPoint>() && nameBox.TextLength >= 1)
            {
                Debug.WriteLine("Saving phase 1");
                if (editor.SaveMap(nameBox.Text, map))
                {
                    Debug.WriteLine("Saving complete");
                    MessageBox.Show("A floor has been succesfully created", "Proceed");
                }
            }
        }

        private void mainMenu_Button_Click(object sender, EventArgs e)
        {
            Dispose();
            MainMenu1 m = new MainMenu1();
            m.ShowDialog();
        }

        private void MapEditor_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    Add(e.Location);
                    break;
                case MouseButtons.Middle:
                    examineBox.Text = examineTile(e.Location);
                    break;
                case MouseButtons.Right:
                    Delete(e.Location);
                    break;
            }
        }

        private void MapEditor_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    Add(e.Location);
                    break;
                case MouseButtons.Middle:
                    examineBox.Text = examineTile(e.Location);
                    break;
                case MouseButtons.Right:
                    Delete(e.Location);
                    break;
            }
        }
    }
}
