using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sakk
{
	public class Tabla
	{
        public Mezo[,] tabla { get; set; }
        private Koordinata aktivMezo { get; set; }


        public Tabla(int tablameret)
        {
            //tábla legenerálása
            tabla = new Mezo[tablameret, tablameret];
            int gombMeret = 70;

            for (int i = 0; i < tablameret; i++)
            {
                for (int h = 0; h < tablameret; h++)
                {
                    tabla[i, h] = new Mezo(h, i);
                    tabla[i, h].gomb.Height = gombMeret;
                    tabla[i, h].gomb.Width = gombMeret;
                }
            }
        }
        
        public void GombNyomas(Mezo mezo)
        {
            if (mezo.foglalt && !mezo.lepesek)
            {
                LehetosegekTorlese();
                LehetosegekBeallitasa(mezo, mezo.babuNeve);
                aktivMezo = new Koordinata(mezo.oszlop, mezo.sor);

            }
            else if (mezo.lepesek)
            {
                Mezo regiMezo = tabla[aktivMezo.x, aktivMezo.y];
                Lepes(regiMezo,mezo);    
            }
        }
        public void Lepes(Mezo honnan, Mezo hova)
        {
            
            Mezo ujMezo = new Mezo(hova.sor, hova.oszlop);
            ujMezo.babuNeve = honnan.babuNeve;
            ujMezo.babuSzine = honnan.babuSzine;
            ujMezo.lepesek = false;
            //ujMezo.gomb.Location = hova.gomb.Location;
            Mezo regiMezo = new Mezo(honnan.sor, honnan.oszlop);
            //gomb.Location = honnan.gomb.Location;
            tabla[ujMezo.oszlop, ujMezo.sor] = ujMezo;
            tabla[regiMezo.oszlop, regiMezo.sor] = regiMezo;
            LehetosegekTorlese();
        }
        public void LehetosegekTorlese()
        {
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int h = 0; h < tabla.GetLength(1); h++)
                {
                    tabla[i, h].lepesek = false;
                }
            }
        }
        public void lepesiLehetoseg(Mezo cel, Mezo start) 
        {
            if ((cel.foglalt && cel.babuSzine != start.babuSzine) || !cel.foglalt)
            {
                tabla[cel.oszlop, cel.sor].lepesek = true;
            }
        }
        public void LehetosegekBeallitasa(Mezo babuHelyzete, string babuNev)
        {
            switch (babuNev)
            {
                case "Ló":
                    //felfele balra
                    if (babuHelyzete.sor - 2 > -1 && babuHelyzete.oszlop - 1 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 2], babuHelyzete);
                    }
                    //felfele jobbra
                    if (babuHelyzete.sor - 2 > -1 && babuHelyzete.oszlop + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 2], babuHelyzete);
                    }
                    //jobbra fel
                    if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop + 2 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor - 1], babuHelyzete);
                    }
                    //jobbra le
                    if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop + 2 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor + 1], babuHelyzete);

                    }
                    //balra fel
                    if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop - 2 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor - 1], babuHelyzete);
                    }
                    //balra le
                    if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop - 2 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor + 1], babuHelyzete);
                    }
                    //le balra
                    if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop - 1 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 2], babuHelyzete);
                    }
                    //le jobbra
                    if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 2], babuHelyzete);
                    }
                    break;
                default:
                    break;
            }
        }

        public void jatekInditasa()
        {


            tabla[0, 0].babuNeve = "Bástya";
            tabla[0, 0].babuSzine = "Fehér";




            tabla[4, 3].babuNeve = "Ló";
            tabla[4, 3].babuSzine = "Fehér";




            tabla[0, 2].babuNeve = "Futó";
            tabla[0, 2].babuSzine = "Fehér";




            tabla[7, 0].babuNeve = "Bástya";
            tabla[7, 0].babuSzine = "Fekete";




            tabla[7, 1].babuNeve = "Ló";
            tabla[7, 1].babuSzine = "Fekete";




            tabla[7, 2].babuNeve = "Futó";
            tabla[7, 2].babuSzine = "Fekete";

        }
    }
}
