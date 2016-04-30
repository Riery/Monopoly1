using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Pálya
    {
        private int méret;
        private Mező[] pályánLévőMezők;
        public Pálya(int méret)
        {
            this.Méret = méret;
            this.PályánLévőMezők = new Mező[méret];
            
        }

        public int Méret
        {
            get
            {
                return méret;
            }

            set
            {
                méret = value;
            }
        }

        internal Mező[] PályánLévőMezők
        {
            get
            {
                return pályánLévőMezők;
            }

            set
            {
                pályánLévőMezők = value;
            }
        }
    }
}
