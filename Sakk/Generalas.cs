using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakk
{
    public class tablaGeneralas
    {
        const int tablameret = 8;
        public Mező[,] tabla { get; set; }

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
        public void BabuLepesek(Mező bábuHelyzete, string bábuNév)
        {
            for (int i = 0; i < tablameret; i++)
            {
                for (int h = 0; h < tablameret; h++)
                {
                    tabla[i, h].lepesek = false;
                    tabla[i, h].foglalt = false;
                }
            }

        }
    }
}
