using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sakk
{
    public class tablaGeneralas
    {
        const int tablameret = 8;
        static public Mező[,] tabla { get; set; }

        public tablaGeneralas()
        {
            //tábla legenerálása
            tabla = new Mező[tablameret, tablameret];

            for (int i = 0; i < tablameret; i++)
            {
                for (int h = 0; h < tablameret; h++)
                {
                    tabla[i,h] = new Mező(i,h);
                }
            }
        }

        //bábu lépés szabályok
        public void BabuLepesek(Mező babuHelyzete, string babuNev)
        {
            for (int i = 0; i < tablameret; i++)
            {
                for (int h = 0; h < tablameret; h++)
                {
                    tabla[i, h].lepesek = false;
                    tabla[i, h].foglalt = false;
                }
            }
			switch (babuNev)
			{
                case "ló":
					//előre balra
                    if (babuHelyzete.sor+2<8&&babuHelyzete.oszlop-1>-1)
					{
                        tabla[babuHelyzete.sor + 2, babuHelyzete.oszlop - 1].lepesek = true;
					}
                    //előre jobbra
                    if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop + 1 < 8)
                    {
                        tabla[babuHelyzete.sor + 2, babuHelyzete.oszlop + 1].lepesek = true;
                    }
                    //jobbra előre
                    if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop + 2 < 8)
                    {
                        tabla[babuHelyzete.sor + 1, babuHelyzete.oszlop + 2].lepesek = true;
                    }
                    //jobbra hátra
                    if (babuHelyzete.sor -1 > -1 && babuHelyzete.oszlop + 2 < 8)
                    {
                        tabla[babuHelyzete.sor + 2, babuHelyzete.oszlop - 1].lepesek = true;
                    }
                    if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop - 1 > -1)
                    {
                        tabla[babuHelyzete.sor + 2, babuHelyzete.oszlop - 1].lepesek = true;
                    }
                    if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop - 1 > -1)
                    {
                        tabla[babuHelyzete.sor + 2, babuHelyzete.oszlop - 1].lepesek = true;
                    }
                    if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop - 1 > -1)
                    {
                        tabla[babuHelyzete.sor + 2, babuHelyzete.oszlop - 1].lepesek = true;
                    }
                    if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop - 1 > -1)
                    {
                        tabla[babuHelyzete.sor + 2, babuHelyzete.oszlop - 1].lepesek = true;
                    }

                    break;
				default:
					break;
			}
           
		}
	}
}
