using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakk
{
    public class tablaGeneralas
    {
        public tablaGeneralas()
        {
            const int tablameret = 8;
            int[,] tabla = new int[8, 8]{
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                };
            for (int i = 0; i < tablameret; i++)
            {
                for (int h = 0; h < tablameret; h++)
                {
                    tabla[i,h] = 0;
                }
            }

           
            
            Babuk alapHelyzet = new Babuk();
            for (int i = 0; i < tablameret; i++)
            {
                for (int h = 0; h < tablameret; h++)
                {
                    if ()
                    {
                        
                    }
                }
            }
        }
    }
}
