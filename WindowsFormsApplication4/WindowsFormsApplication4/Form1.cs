using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowsFormsApplication4
{
    public partial class Mouse_Mover : Form
    {
        public Mouse_Mover()
        {
            InitializeComponent();
        }
        int swag = 0; // state machine
        int[] mouse_pos = new int[20]; // will keep track of a
        int i = 0;
        int j = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            swag = 1;
            listView1.Items.Add("Swag is set to 1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            swag = 0;
            listView1.Items.Add("Swag is set to 0");
        }
    

        private void Mouse_Mover_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.B)
            {
               
            }

            if (swag == 1)
            {
                timer1.Start();
            }

            if (swag == 0)
            {
                timer1.Stop();
                
            }
            if (swag == 1 && e.KeyCode == Keys.A)
            {
                listView1.Items.Clear();
                if (i == 20)
                {
                    listView1.Items.Add("i is filled, no more positions can be detected");

                }
                else
                { 
                    mouse_pos[i] = Cursor.Position.X;
                    i++;
                    mouse_pos[i] = Cursor.Position.Y;
                    i++;
                    listView1.Items.Add("Mouse X is at" + mouse_pos[j].ToString());
                    listView1.Items.Add("Mouse Y is at" + mouse_pos[j+1].ToString());
                    j = i;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("^C");
        }
    }
}
