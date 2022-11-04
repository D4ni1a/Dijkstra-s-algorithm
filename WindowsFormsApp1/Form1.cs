using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static Dictionary<int, float[]> Dict;
        Graphics gr;
        Random rnd;
        int[,] myArray;
        int n;
        int count=0;
        Dictionary<string, int> D;
        public Form1()
        {
            InitializeComponent();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            button2.Hide();
            button3.Hide();

            label2.Hide();
            label3.Hide();
            label4.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                n = System.Convert.ToInt32(textBox1.Text);
                if ((n==0) || (n==1) || (n==2))
                {
                    MessageBox.Show("Ошибка!");
                    return;
                }
                myArray = new int[n, n];
                rnd = new Random();
                gr = CreateGraphics();
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                Dict = new Dictionary<int, float[]>(n);
                Font font = new Font("Times New Roman", 10);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                for (int i = 0; i < n; i++)
                {
                    float[] point = new float[2];
                    float x_con = rnd.Next(20, 300);
                    float y_con = rnd.Next(20, 300);
                    point[0] = x_con;
                    point[1] = y_con;
                    gr.DrawEllipse(pen, x_con - 2, y_con - 2, 4, 4);
                    gr.DrawString(System.Convert.ToString(i + 1), font, drawBrush, x_con, y_con - 15);
                    Dict[i] = point;
                }

                textBox1.Hide();
                textBox2.Show();
                textBox3.Show();
                textBox4.Show();
                button2.Show();
                button3.Show();
                button1.Hide();
                label1.Hide();
                label2.Show();
                label3.Show();
                label4.Show();

            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Pen pen = new Pen(Color.Red);
                int s1 = System.Convert.ToInt32(textBox2.Text) - 1;
                int s2 = System.Convert.ToInt32(textBox3.Text) - 1;

                float deltaX = (Dict[s1][0] + Dict[s2][0]) / 2;
                float deltaY = (Dict[s1][1] + Dict[s2][1]) / 2;
                Font font = new Font("Times New Roman", 9);
                SolidBrush drawBrush = new SolidBrush(Color.Blue);
                gr.DrawString(textBox4.Text, font, drawBrush, deltaX+5, deltaY - 5);

                gr.DrawLine(pen, Dict[s1][0], Dict[s1][1], Dict[s2][0], Dict[s2][1]);
                myArray[s1, s2] = System.Convert.ToInt32(textBox4.Text);
                myArray[s2, s1] = System.Convert.ToInt32(textBox4.Text);
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                count += 1;
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                D = new Dictionary<string, int>(count);
                string mas;
                List<int> tops = new List<int>();

                Dictionary<string, int> D1 = new Dictionary<string, int>();

                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        mas = "";
                        if (myArray[i, j] != 0)
                        {
                            if (i < j)
                            {
                                mas += i;
                                mas += " ";
                                mas += j;
                            }
                            else
                            {
                                mas += j;
                                mas += " ";
                                mas += i;
                            }
                            D.Add(mas, myArray[i, j]);
                        }
                    }
                }
                D = D.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

                int cycle;
                List<string> vershinas=new List<string>();

                foreach (var item in D)
                {
                    
                    cycle = 0;
                    
                    D1.Add(item.Key, item.Value);
                    vershinas.Add(item.Key);
                    cycle = Program.Cycle(vershinas, n);
                    if (cycle==1)
                    {
                        D1.Remove(item.Key);
                        vershinas.Remove(item.Key);
                    }
                }

                gr.Clear(Color.White);
                

                Pen pen = new Pen(Color.Black);
                Font font = new Font("Times New Roman", 10);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                for (int i = 0; i < n; i++)
                {
                    float x_con = Dict[i][0];
                    float y_con = Dict[i][1];

                    gr.DrawEllipse(pen, x_con - 2, y_con - 2, 4, 4);
                    gr.DrawString(System.Convert.ToString(i + 1), font, drawBrush, x_con, y_con - 15);

                }
                int sum = 0;
                int k1;
                int k2;
                foreach (var item in D1)
                {
                    k1 = Int32.Parse(item.Key.Split()[0]);
                    k2 = Int32.Parse(item.Key.Split()[1]);
                    Pen penw = new Pen(Color.Red);

                    float deltaX = (Dict[k1][0] + Dict[k2][0]) / 2;
                    float deltaY = (Dict[k1][1] + Dict[k2][1]) / 2;
                    Font font1 = new Font("Times New Roman", 9);
                    SolidBrush drawBrush1 = new SolidBrush(Color.Blue);
                    gr.DrawString(item.Value.ToString(), font1, drawBrush1, deltaX + 5, deltaY - 5);

                    gr.DrawLine(penw, Dict[k1][0], Dict[k1][1], Dict[k2][0], Dict[k2][1]);
                    sum+=item.Value;
                }
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                button2.Hide();
                button3.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                MessageBox.Show("Длина минимального остовного дерева: "+System.Convert.ToString(sum));
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
