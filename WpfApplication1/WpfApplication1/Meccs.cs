using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Meccs
    {
        private string elsocsap;
        private string masodikcsap;
        private int elsogol;
        private int masodikgol;
        private int ido;
        static Random R = new Random();
        public override string ToString() //szintaxishoz
        {
            return string.Format("{0} | {1} - {2} | {3} - {4}", ido, elsocsap,masodikcsap,elsogol,masodikgol);
        }

        public void play() //ez lesz a mecs szimulálo task
        {
            for (ido = 0; ido < 90; ido++)
            {
                Thread.Sleep(100);
                if (R.Next(100)<5)
	            {
                    if (R.Next(2)==0)
                    {
                        elsogol++;
                    }else
                    { masodikgol++; }
	            }
            }
        }


        public int Masodikgol
        {
            get { return masodikgol; }
            set { masodikgol = value; }
        }
        public int Elsogol
        {
            get { return elsogol; }
            set { elsogol = value; }
        }
        public string Masodikcsap
        {
            get { return masodikcsap; }
            set { masodikcsap = value; }
        }
        public string Elsocsap
        {
            get { return elsocsap; }
            set { elsocsap = value; }
        }
        



    }
}
