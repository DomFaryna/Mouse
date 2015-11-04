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
using System.Runtime.InteropServices;

namespace WindowsFormsApplication4
{
    public partial class Mouse_Mover : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public Mouse_Mover()
        {
            InitializeComponent();
        }
        int swag = 0; // state machine
        int[] mouse_pos = new int[20]; // will keep track of a
        int i = 0;
        int j = 0;
        int k = 0;
        int l = 0;
        int num = 0;
        int numb = 0;
        String to = "Lala";

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
               // timer1.Start();
            }

            if (swag == 0)
            {
               // timer1.Stop();
                
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
            if (swag == 2)
            {
                
                start_mouse(numb);
            }
        }

        void mouse_cl()
        {
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            to = textBox1.Text;
            listView1.Items.Add(to);
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            while(k != i)
            {
                mouse_pos[k] = 0;
                k++;
            }

            k = 0;
            i = 0;
            j = 0;

            listView1.Items.Add("i is cleared");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            swag = 2;
            listView1.Items.Clear();
            listView1.Items.Add("Starting Cycle");
            //Cursor.Position = new Point(mouse_pos[0], mouse_pos[1]);
            timer1.Start();
            numb = int.Parse(textBox1.Text);
            textBox1.Clear();
            


        }

        void start_mouse(int e)
        {
            if (num < e) {
                if (i > l)
                {
                    Cursor.Position = new Point(mouse_pos[l], mouse_pos[l + 1]);
                    l += 2;
                    listView1.Items.Add("Test");
                }
                else
                {
                    l = 0;
                    listView1.Items.Add(num.ToString() + " times");
                    num++;
                }
            }
            else
            {
                swag = 0;
                listView1.Items.Clear();
                listView1.Items.Add("All done");
                timer1.Stop();
                num = 0;
            }

        }
    }
}
