using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Csapat
    {
        private string nev;

        private string varos;

        private int alapitas;

        public override string ToString() //listboxba íráshoz
        {
            return string.Format("{0} | {1} | {2}", Nev, Varos, Alapitas);
        }

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }
        public string Varos
        {
            get { return varos; }
            set { varos = value; }
        }
        public int Alapitas
        {
            get { return alapitas; }
            set { alapitas = value; }
        }



    }
}
