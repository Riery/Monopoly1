using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Mező
    {
        private int érték;
        private Játékos tulajdonos;
        private int ingatlanokSzáma;

        public int Érték
        {
            get
            {
                return érték;
            }

            set
            {
                érték = value;
            }
        }

        internal Játékos Tulajdonos
        {
            get
            {
                return tulajdonos;
            }

            set
            {
                tulajdonos = value;
            }
        }

        public int IngatlanokSzáma
        {
            get
            {
                return ingatlanokSzáma;
            }

            set
            {
                ingatlanokSzáma = value;
            }
        }

        public Mező(int érték)
        {
            this.Érték = érték;
            this.IngatlanokSzáma = 0;
            this.Tulajdonos = null;  //azért null mert másik objektum van meghívva
        }

    }
}
