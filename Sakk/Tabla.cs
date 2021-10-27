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
            Mezo regiMezo = new Mezo(honnan.sor, honnan.oszlop);
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
        public void kiralynoLepesiLehetoseg(Mezo cel, Mezo start)
        {

        }
        public void LehetosegekBeallitasa(Mezo babuHelyzete, string babuNev)
        {
            int seged = 1;
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

                case "Király":
                    //felfelé
                    if (babuHelyzete.sor - 1 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor - 1], babuHelyzete);
                    }
                    //felfelé jobbra
                    if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
                    }
                    //felfelé balra
                    if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop - 1 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
                    }
                    //jobbra
                    if (babuHelyzete.oszlop + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor], babuHelyzete);
                    }
                    //balra
                    if (babuHelyzete.oszlop - 1 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor], babuHelyzete);
                    }
                    //lefelé
                    if (babuHelyzete.sor + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor + 1], babuHelyzete);
                    }
                    //lefelé jobbra
                    if (babuHelyzete.oszlop + 1 < 8 && babuHelyzete.sor + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
                    }
                    //lefelé balra
                    if (babuHelyzete.oszlop - 1 > -1 && babuHelyzete.sor + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
                    }
                    break;

                case "Királynő":
                    //felfelé
                        while (babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);                               
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé
                        while (babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //jobbra
                        while (babuHelyzete.oszlop + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //balra
                        while (babuHelyzete.oszlop - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //felfelé jobbra
                        while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;  
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                            }                            
                            seged++;
                        }
                    seged = 1;
                    //felfelé balra
                        while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé jobbra
                        while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé balra
                        while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    break;

                case "Futó":
                    //felfelé jobbra
                        while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //felfelé balra
                        while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé jobbra
                        while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé balra
                        while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    break;

                case "Bástya":
                    //felfelé
                        while (babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé
                        while (babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //jobbra
                        while (babuHelyzete.oszlop + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //balra
                        while (babuHelyzete.oszlop - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    break;
                    
                case "Paraszt":
                    //fehér
                    if (tabla[babuHelyzete.oszlop,babuHelyzete.sor].babuSzine == "Fehér")
                    {
                        if (babuHelyzete.oszlop + 1 < 8)
                        {
                            if (!tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor].foglalt)
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor], babuHelyzete);
                                if (tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
                                }
                                if (tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
                                }
                            }
                            else if(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor -1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].foglalt)
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
                                if (tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
                                }
                            }
                            else if (tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].foglalt)
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
                                if (tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
                                }
                            }                           
                        }
                    }
                    //fekete
                    if (tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine == "Fekete")
                    {
                        if (babuHelyzete.oszlop - 1 > -1)
                        {
                            if (!tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor].foglalt)
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor], babuHelyzete);
                                if (tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
                                }
                                if (tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
                                }
                            }
                            else if (tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].foglalt)
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
                                if (tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
                                }
                            }
                            else if (tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].foglalt)
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
                                if (tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
                                }
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        //tábla alaphelyzet
        public void jatekInditasa()
        {


            tabla[0, 0].babuNeve = "Bástya";
            tabla[0, 0].babuSzine = "Fehér";




            tabla[0, 1].babuNeve = "Ló";
            tabla[0, 1].babuSzine = "Fehér";




            tabla[0, 2].babuNeve = "Futó";
            tabla[0, 2].babuSzine = "Fehér";




            tabla[0, 3].babuNeve = "Király";
            tabla[0, 3].babuSzine = "Fehér";




            tabla[0, 4].babuNeve = "Királynő";
            tabla[0, 4].babuSzine = "Fehér";




            tabla[0, 5].babuNeve = "Futó";
            tabla[0, 5].babuSzine = "Fehér";




            tabla[0, 6].babuNeve = "Ló";
            tabla[0, 6].babuSzine = "Fehér";




            tabla[0, 7].babuNeve = "Bástya";
            tabla[0, 7].babuSzine = "Fehér";




            tabla[1, 0].babuNeve = "Paraszt";
            tabla[1, 0].babuSzine = "Fehér";




            tabla[1, 1].babuNeve = "Paraszt";
            tabla[1, 1].babuSzine = "Fehér";




            tabla[1, 2].babuNeve = "Paraszt";
            tabla[1, 2].babuSzine = "Fehér";




            tabla[1, 3].babuNeve = "Paraszt";
            tabla[1, 3].babuSzine = "Fehér";




            tabla[1, 4].babuNeve = "Paraszt";
            tabla[1, 4].babuSzine = "Fehér";




            tabla[1, 5].babuNeve = "Paraszt";
            tabla[1, 5].babuSzine = "Fehér";




            tabla[1, 6].babuNeve = "Paraszt";
            tabla[1, 6].babuSzine = "Fehér";




            tabla[1, 7].babuNeve = "Paraszt";
            tabla[1, 7].babuSzine = "Fehér";




            tabla[7, 0].babuNeve = "Bástya";
            tabla[7, 0].babuSzine = "Fekete";




            tabla[7, 1].babuNeve = "Ló";
            tabla[7, 1].babuSzine = "Fekete";




            tabla[7, 2].babuNeve = "Futó";
            tabla[7, 2].babuSzine = "Fekete";



            tabla[7, 3].babuNeve = "Király";
            tabla[7, 3].babuSzine = "Fekete";




            tabla[7, 4].babuNeve = "Királynő";
            tabla[7, 4].babuSzine = "Fekete";




            tabla[7, 5].babuNeve = "Futó";
            tabla[7, 5].babuSzine = "Fekete";




            tabla[7, 6].babuNeve = "Ló";
            tabla[7, 6].babuSzine = "Fekete";




            tabla[7, 7].babuNeve = "Bástya";
            tabla[7, 7].babuSzine = "Fekete";



            tabla[6, 0].babuNeve = "Paraszt";
            tabla[6, 0].babuSzine = "Fekete";




            tabla[6, 1].babuNeve = "Paraszt";
            tabla[6, 1].babuSzine = "Fekete";




            tabla[6, 2].babuNeve = "Paraszt";
            tabla[6, 2].babuSzine = "Fekete";




            tabla[6, 3].babuNeve = "Paraszt";
            tabla[6, 3].babuSzine = "Fekete";




            tabla[6, 4].babuNeve = "Paraszt";
            tabla[6, 4].babuSzine = "Fekete";




            tabla[6, 5].babuNeve = "Paraszt";
            tabla[6, 5].babuSzine = "Fekete";




            tabla[6, 6].babuNeve = "Paraszt";
            tabla[6, 6].babuSzine = "Fekete";




            tabla[6, 7].babuNeve = "Paraszt";
            tabla[6, 7].babuSzine = "Fekete";
        }
    }
}
