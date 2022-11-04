using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static int Cycle(List<string> Dict, int num)
        {
            List<string> D = Dict;
            int count = 0;
            string versh = "";

            for (int i=0; i<num; i++)
            {
                versh += i.ToString();
            }

            foreach (char t in versh)
            {
                int v_last = 0;
                int v_prev = 0;
                int v_now = Int32.Parse(System.Convert.ToString(t));
                string seq;
                int z = 0;
                int n = 0;
                seq = System.Convert.ToString(t);

                while (z < 5)
                {
                    int kk = 0;
                    while (true)
                    {
                        n += 1;
                        kk = seq.Length;
                        foreach (var item in D)
                        {

                            if ((Int32.Parse(item.Split()[0]) == v_now) && (Int32.Parse(item.Split()[1]) != v_last) && (Int32.Parse(item.Split()[1]) != v_prev))
                            {
                                seq += item.Split()[1];
                                v_now = Int32.Parse(item.Split()[1]);
                                v_prev = Int32.Parse(item.Split()[0]);
                                v_last = Int32.Parse(item.Split()[1]);
                                break;
                            }
                            if ((Int32.Parse(item.Split()[1]) == v_now) && (Int32.Parse(item.Split()[0]) != v_last) && (Int32.Parse(item.Split()[0]) != v_prev))
                            {
                                seq += item.Split()[0];
                                v_now = Int32.Parse(item.Split()[0]);
                                v_prev = Int32.Parse(item.Split()[1]);
                                v_last = Int32.Parse(item.Split()[0]);
                                break;
                            }

                        }
                        if ((kk == seq.Length) || (n == 20)) break;
                    }
                    if ((seq[0] == seq[seq.Length - 1]) && (seq.Length != 1))
                    {
                        return 1;
                    }

                    if (seq.Length >= 3)
                    {
                        v_last = Int32.Parse(System.Convert.ToString(seq[seq.Length - 1]));
                        v_now = Int32.Parse(System.Convert.ToString(seq[seq.Length - 2]));
                        v_prev = Int32.Parse(System.Convert.ToString(seq[seq.Length - 3]));
                    }
                    else
                    {
                        v_last = Int32.Parse(System.Convert.ToString(seq[seq.Length - 1]));
                        v_prev = 0;
                        v_now = Int32.Parse(System.Convert.ToString(seq[0]));
                    }
                    string seq1 = System.Convert.ToString(t);
                    for (int s = 1; s < seq.Length - 1; s++)
                    {
                        seq1 += seq[s];
                    }
                    seq = seq1;
                    z += 1;
                }
            }
            return 0;
        }
    }
}
