using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Monopoly
{
   class Program
    {

        static string s;
        static string[] beolvasas()
        {
            StreamReader sr = new StreamReader("monopoly.txt");

            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();

            }
            sr.Close();

            string[] beolvasas = s.Split(';');
            foreach (string word in beolvasas)
            {
                //Console.WriteLine(word);
            }
            return beolvasas;
        }
        static void Main(string[] args)
        {

            string[] asd = new string[beolvasas().Length];
            asd = beolvasas();
            

            int soronLévőJátékos = 0;
            Console.WriteLine("Üdvözöllek a monopolymban."+"\n"+ "Rövid leírás a programról: A játékosok számát a játék elején adhatod meg." + "\n" + " A játék akkor ér véget ha valamelyik játékos a pálya végére ért vagy egy játékos maradt játékban." + "\n" + " Egy játékos akkor tud kiesni ha elfogy a pénze." + "\n" + " A mezőkre lehet venni házakat és szállodát(5 ház felel meg egy szállodának)." + "\n" + "A pályán vannak elhelyezve csapdák és gyorsító mezők, ha csapdába lépsz akkor a következő körből kimaradsz, ha pedig gyorsító mezőre lépsz akkor amennyivel a mezőre érkeztél annyival tovább lépsz.");
            Console.WriteLine("\n" + "Kezdődjön a játék add meg a játékosok számát:");
            int játékosokSzáma = int.Parse(Console.ReadLine());
            Játékos[] játékosok = new Játékos[játékosokSzáma];
            
            for (int i = 0; i < játékosokSzáma; i++)
            {
                játékosok[i] = new Játékos(int.Parse(asd[1]));
            }

            Pálya pálya = new Pálya(int.Parse(asd[0]));

           
            for (int i = 0; i < asd.Length-3; i++)
            {
                pálya.PályánLévőMezők[i] = new Mező(int.Parse(asd[i+2]));
            }
            int számláló = 0;
            while (játékosok[soronLévőJátékos].vége(int.Parse(asd[0])))
            {

                for (int i = 0; i < játékosokSzáma; i++)
                {
                    if (játékosok[i].JátékbanVanE)
                    {
                        számláló++;
                    }
                }

                if (számláló == 1)
                {
                    Console.WriteLine("\n"+"A(z) {0}. Játékos nyert. Mivel nincs több játékos.",soronLévőJátékos+1);
                    break;
                }
                else
                {
                    számláló = 0;
                    int dobás = Util.rnd.Next(1, 7);
                    
                    Console.WriteLine("\n" + "\n");
                    if (pálya.PályánLévőMezők.Length-1 < (játékosok[soronLévőJátékos].TartozkodásiHely + dobás))
                    {
                        Console.WriteLine((soronLévőJátékos + 1) + ". játékos nyert gratulálok.");
                        break;

                    }
                    else
                    {
                        if ((pálya.PályánLévőMezők[játékosok[soronLévőJátékos].TartozkodásiHely + dobás].Érték != -1)  && (játékosok[soronLévőJátékos].JátékbanVanE == true)&& játékosok[soronLévőJátékos].KimaradásokSzáma == 0)
                        {
                            Console.WriteLine((soronLévőJátékos + 1) + ".Játékos" + "\n" + "Pénz: " + játékosok[soronLévőJátékos].Pénz + " Ft" + "\n" + "Dobásod száma: " + dobás + "\n" + "Pozíció: " + (játékosok[soronLévőJátékos].TartozkodásiHely + dobás) + ". mező.");
                            játékosok[soronLévőJátékos].lép(dobás, pálya.PályánLévőMezők[játékosok[soronLévőJátékos].TartozkodásiHely + dobás], int.Parse(asd[0]));
                        }
                        else if (pálya.PályánLévőMezők[játékosok[soronLévőJátékos].TartozkodásiHely + dobás].Érték == -1 && játékosok[soronLévőJátékos].JátékbanVanE == true && (játékosok[soronLévőJátékos].KimaradásokSzáma == 0))
                        {

                            if (pálya.PályánLévőMezők.Length < (játékosok[soronLévőJátékos].TartozkodásiHely + dobás * 2))
                            {
                                Console.WriteLine((soronLévőJátékos + 1) + ". játékos nyert gratulálok.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine((soronLévőJátékos + 1) + ".Játékos" + "\n" + "Pénz: " + játékosok[soronLévőJátékos].Pénz + " Ft" + "\n" + "Dobásod száma megduplázódik a gyorsító mező miatt: " + (dobás * 2) + "\n" + "Pozíció: " + (játékosok[soronLévőJátékos].TartozkodásiHely + (dobás * 2)) + ". mező.");
                                játékosok[soronLévőJátékos].lép(dobás * 2, pálya.PályánLévőMezők[játékosok[soronLévőJátékos].TartozkodásiHely + dobás * 2], int.Parse(asd[0]));
                            }
                        }
                        else if (játékosok[soronLévőJátékos].KimaradásokSzáma == 1 && játékosok[soronLévőJátékos].JátékbanVanE == true)
                        {
                            Console.WriteLine((soronLévőJátékos + 1) + ".Játékos" + "\n" + "Pénz: " + játékosok[soronLévőJátékos].Pénz + " Ft" + "\n" + "Pozíció: " + (játékosok[soronLévőJátékos].TartozkodásiHely) + ". mező.");
                            játékosok[soronLévőJátékos].lép(dobás, pálya.PályánLévőMezők[játékosok[soronLévőJátékos].TartozkodásiHely + dobás], int.Parse(asd[0]));

                        }

                        if (játékosok[soronLévőJátékos].TartozkodásiHely == int.Parse(asd[0]) - 1)
                        {

                            Console.WriteLine((soronLévőJátékos + 1) + ". játékos nyert gratulálok.");
                            break;
                        }
                        soronLévőJátékos = soronLévőJátékos + 1;
                        if (soronLévőJátékos >= játékosokSzáma)
                        {
                            soronLévőJátékos = 0;
                        }
                    }
                    

                }
            }

            Console.ReadKey();
        }
    }
}
