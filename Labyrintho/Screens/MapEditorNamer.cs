using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrintho.Screens
{
    public partial class MapEditorNamer : Form
    {
        private MapEditor editor;

        public MapEditorNamer(MapEditor editor)
        {
            this.editor = editor;
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            editor.isCanceled = true;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.TextLength >= 1)
            {
                Debug.WriteLine("Namer");
                editor.nameTextBoxFilled = nameTextBox.Text;
                Close();

            }
            else
            {
                MessageBox.Show("The name must be atleast 1 letter long");
            }

        }

        private void cancelButton_MouseClick(object sender, MouseEventArgs e)
        {
            //holder
        }
    }
}
