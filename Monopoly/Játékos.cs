using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Játékos
    {

        
        public void lép(int lépésSzám,Mező aktuálisMező,int méret) {


                if (this.kimaradásokSzáma == 0)
                {
                    if (tartozkodásiHely + lépésSzám >= méret - 1)
                    {
                        tartozkodásiHely = méret - 1;

                    }
                    else
                    {
                        tartozkodásiHely += lépésSzám;
                    }
                    if (aktuálisMező.Érték == -2)
                    {

                        Console.WriteLine("Hopp!"+"\n"+"Csapdába léptél a következő körben kimaradsz.");
                        this.kimaradásokSzáma = 1;

                    }
                    else if (aktuálisMező.Érték == -1)
                    {

                    if (tartozkodásiHely + lépésSzám  > méret - 1)
                        {
                            tartozkodásiHely = méret-1;

                            if (aktuálisMező.Tulajdonos == null)
                            {
                                Console.WriteLine("Gyorsító mezőre léptél a dobásod dupláját léped.");
                                Vásárol(aktuálisMező);
                            }
                            else
                            {
                                Console.WriteLine("Gyorsító mezőre léptél a dobásod dupláját léped.");
                                Fizet(aktuálisMező);
                            }

                        }
                        else
                        {


                            tartozkodásiHely += lépésSzám;

                            if (aktuálisMező.Tulajdonos == null)
                            {
                                Vásárol(aktuálisMező);
                            }
                            else
                            {
                                Fizet(aktuálisMező);
                            }
                        }
                    }
                    else
                    {
                        if (aktuálisMező.Tulajdonos == null)
                        {
                            Vásárol(aktuálisMező);
                        }
                        else
                        {
                            Fizet(aktuálisMező);
                        }
                    }
                }
                else
                {
                    this.kimaradásokSzáma = 0;
                    Console.WriteLine("Most kimaradsz ebből a körből.");
                }      

        }


        public bool vége(int méret)
        {
            if (this.tartozkodásiHely < méret-1)
            {
                return true;
            }
            else return false;
        }
        private void Vásárol(Mező aktuálisMező) {
            if (aktuálisMező.Érték > this.pénz)
            {
                Console.WriteLine("Nincs elegendő pénzed az aktuális telek megvásárlására! ");
            }
            else {
                Console.WriteLine("Megakarod venni az aktuális telket {0} ennyi Ft-ért? (i/n)",aktuálisMező.Érték);
                string s = Console.ReadLine();
                if (s =="i") {
                    this.Pénz -= aktuálisMező.Érték;
                    aktuálisMező.Tulajdonos = this;
                    int házakSzáma = 0;
                    do
                    {
                        Console.WriteLine("Hány házat szeretnél venni az aktuális mezőre? (1 ház = 500Ft)(5 ház = 1 szálloda)");
                        házakSzáma = int.Parse(Console.ReadLine());
                    } while (házakSzáma*500>this.pénz);
                    aktuálisMező.IngatlanokSzáma += házakSzáma;
                    this.Pénz -= házakSzáma * 500;
                    
                }
                
                
            }
        }
        private void Fizet(Mező aktuálisMező)
        {

            if (aktuálisMező.Tulajdonos.játékbanVanE)
            {
                aktuálisMező.Tulajdonos.Pénz += aktuálisMező.Érték + aktuálisMező.IngatlanokSzáma * 500;
                this.pénz -= aktuálisMező.Érték + aktuálisMező.IngatlanokSzáma * 500;
                Console.WriteLine("Fizetned kell: " + (aktuálisMező.Érték + aktuálisMező.IngatlanokSzáma * 500 )+ " forintot a mező tulajdonosának.");
                if (this.pénz < 0)
                {
                    this.játékbanVanE = false;
                    Console.WriteLine("Ez a játékos kiesett");
                }
            }
            else
            {
                Vásárol(aktuálisMező);
            }
            
            
        }



        private int pénz;
        private int tartozkodásiHely;
        private int kimaradásokSzáma;
        private bool játékbanVanE;

        public Játékos(int pénz)
        {
            this.Pénz = pénz;
            this.TartozkodásiHely = 0;
            this.KimaradásokSzáma = 0;
            this.JátékbanVanE = true;
        }

        public int Pénz
        {
            get
            {
                return pénz;
            }

            set
            {
                pénz = value;
            }
        }

        public int TartozkodásiHely
        {
            get
            {
                return tartozkodásiHely;
            }

            set
            {
                tartozkodásiHely = value;
            }
        }

  

        public bool JátékbanVanE
        {
            get
            {
                return játékbanVanE;
            }

            set
            {
                játékbanVanE = value;
            }
        }

        public int KimaradásokSzáma
        {
            get
            {
                return kimaradásokSzáma;
            }

            set
            {
                kimaradásokSzáma = value;
            }
        }
    }   
}
