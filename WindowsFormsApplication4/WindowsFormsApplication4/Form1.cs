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
using System.Media;
using System.IO;
using System.Xml.Serialization;


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
        int[] mouse_pos = new int[100]; // will keep track of a
        int i = 0;
        int k = 0;
        int l = 0;
        int num = 0;
        int numb = 0;
        SoundPlayer victory = new SoundPlayer(@"C:\Users\Dom\Desktop\Mouse\WindowsFormsApplication4\Victory.wav");
        

        private void button1_Click(object sender, EventArgs e)
        {
            swag = 1;
            listView1.Items.Add("Swag is set to 1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            swag = 0;
            listView1.Items.Add("Swag is set to 0");
            victory.Stop();
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
                if (i == 100)
                {
                    listView1.Items.Add("i is filled, no more positions can be detected");

                }
                else
                { 
                    mouse_pos[i] = Cursor.Position.X;
                    listView1.Items.Add("Mouse X is at" + mouse_pos[i].ToString());
                    i++;
                    mouse_pos[i] = Cursor.Position.Y;
                    listView1.Items.Add("Mouse Y is at" + mouse_pos[i].ToString());
                    i++;
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

        private void button3_Click(object sender, EventArgs e) //click
        {
            mouse_pos[i] = -1;
            i++;
            listView1.Items.Add("Mouse click");

        }

        private void button6_Click(object sender, EventArgs e) //copy
        {
            mouse_pos[i] = -2;
            i++;
            listView1.Items.Add("Copyied");
        }

        private void button7_Click(object sender, EventArgs e) //paste
        {
            mouse_pos[i] = -3;
            i++;
            listView1.Items.Add("Paste");
        }

        private void button8_Click(object sender, EventArgs e) //Enter
        {
            mouse_pos[i] = -4;
            i++;
            listView1.Items.Add("Enter");
        }

        private void button9_Click(object sender, EventArgs e) //Pause
        {
            mouse_pos[i] = -5;
            i++;
            listView1.Items.Add("Pause");
        }

        private void button10_Click(object sender, EventArgs e) // Next
        {
            mouse_pos[i] = -6;
            i++;
            listView1.Items.Add("Next Video");
        }

        private void button11_Click(object sender, EventArgs e) //tab
        {
            mouse_pos[i] = -7;
            i++;
            listView1.Items.Add("Tabbed");
        }

        private void button12_Click(object sender, EventArgs e) // save
        {
            try {
                int j = 0;
                arr save = new arr();
                save.data = new int[i];
                for (j = 0; j < i; j++) {
                    save.data[j] = mouse_pos[j];
                }
                save.num = j;
                SaveXML.SaveData(save, "data.xml");
                listView1.Items.Clear();
                listView1.Items.Add("Saved");
            }
            catch
            {
                listView1.Items.Clear();
                listView1.Items.Add("Unexpected error");
            }
        }

        private void button13_Click(object sender, EventArgs e) // load
        {

            if (File.Exists("data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(arr));
                FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                arr load = (arr)xs.Deserialize(read);
                i = 0;
                for (i = 0; i < load.num; i++)
                {
                    mouse_pos[i] = load.data[i];
                }
                listView1.Items.Clear();
                listView1.Items.Add("Loaded");
                read.Close();
            }
            else {
                listView1.Items.Clear();
                listView1.Items.Add("Could not find save file");
            }
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


            listView1.Items.Add("i is cleared");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            swag = 2;
            listView1.Items.Clear();
            listView1.Items.Add("Starting Cycle");
            timer1.Start();

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                numb = 1;
            }
            else
            {
                numb = int.Parse(textBox1.Text);
            }

            textBox1.Clear();

        }

        void start_mouse(int e)
        {
            if (num < e) {
                if (i > l)
                {
                    if (mouse_pos[l] > 0)
                    {
                        Cursor.Position = new Point(mouse_pos[l], mouse_pos[l + 1]);
                        l += 2;
                        listView1.Items.Add("Moved");
                    }
                    if (mouse_pos[l] == -1)
                    {
                        mouse_cl();
                        l++;
                    }
                    if (mouse_pos[l] == -2)
                    {
                        SendKeys.Send("^c");
                        l++;
                    }
                    if (mouse_pos[l] == -3)
                    {
                        SendKeys.Send("^v");
                        l++;
                    }
                    if(mouse_pos[l] == -4)
                    {
                        SendKeys.Send("~");
                        l++;
                    }
                    if (mouse_pos[l] == -5)
                    {
                        SendKeys.Send("k");
                        l++;
                    }
                    if (mouse_pos[l] == -6)
                    {
                        SendKeys.Send("+n");
                        l++;
                    }
                    if(mouse_pos[l] == -7)
                    {
                        SendKeys.Send("{TAB}");
                        SendKeys.Send("{TAB}");
                        SendKeys.Send("~");
                        l++;
                    }
                }
                else
                {
                    l = 0;
                    num++;
                    listView1.Items.Add(num.ToString() + " times");
                    
                }
            }
            else
            {
                swag = 0;
                listView1.Items.Clear();
                listView1.Items.Add("All done");
                timer1.Stop();
                victory.PlayLooping();
                email.mail();
                num = 0;
            }

        }

        
    }
}
