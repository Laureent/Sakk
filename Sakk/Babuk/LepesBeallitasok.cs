namespace Sakk.Babuk
{
	public class LepesBeallitasok : Mezo
	{
		public LepesBeallitasok(int sor, int oszlop) : base(sor, oszlop)
		{

		}
        public void LepesBeallitasFelfele(Mezo babuHelyzete, Tabla tabla, bool egyszerFussonLe)
        {
            int seged = 1;
            int db = 0;
            while (babuHelyzete.sor - seged > -1)
            {
                if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);
                }
                seged++;
                if (egyszerFussonLe)
                {
                    break;
                }
            }
        }
        public void LepesBeallitasLefele(Mezo babuHelyzete, Tabla tabla, bool egyszerFussonLe)
        {
            int seged = 1;
            while (babuHelyzete.sor + seged < 8)
            {
                if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                }
                seged++;
                if (egyszerFussonLe)
                {
                    break;
                }
            }
        }
        public void LepesBeallitasJobbra(Mezo babuHelyzete, Tabla tabla, int egyszerFussonLe)
        {
            int seged = 1;
            int db = 0;
            while (babuHelyzete.oszlop + seged < 8 && egyszerFussonLe != db)
            {
                if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                }
                seged++;
                db++;
                /*if (egyszerFussonLe)
                {
                    break;
                }*/
            }
        }

        public void LepesBeallitasBalra(Mezo babuHelyzete, Tabla tabla, int egyszerFussonLe)
        {
            int seged = 1;
            int db = 0;
            while (babuHelyzete.oszlop - seged > -1 && egyszerFussonLe != db)
            {
                if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                }
                seged++;
                db++;
                /*if (egyszerFussonLe)
                {
                    break;
                }*/
            }
        }

        public void LepesBeallitasBalraFel(Mezo babuHelyzete, Tabla tabla, bool egyszerFussonLe)
        {
            int seged = 1;
            while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor - seged > -1)
            {
                if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                }
                seged++;
                if (egyszerFussonLe)
                {
                    break;
                }
            }
        }
        public void LepesBeallitasJobbraFel(Mezo babuHelyzete, Tabla tabla, bool egyszerFussonLe)
        {
            int seged = 1;
            while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor - seged > -1)
            {
                if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                }
                seged++;
                if (egyszerFussonLe)
                {
                    break;
                }
            }
        }
        public void LepesBeallitasBalraLe(Mezo babuHelyzete, Tabla tabla, bool egyszerFussonLe)
        {
            int seged = 1;
            while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor + seged < 8)
            {
                if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                }
                seged++;
                if (egyszerFussonLe)
                {
                    break;
                }
            }
        }
        public void LepesBeallitasJobbraLe(Mezo babuHelyzete, Tabla tabla, bool egyszerFussonLe)
        {
            int seged = 1;
            while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor + seged < 8)
            {
                if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                }
                seged++;
                if (egyszerFussonLe)
                {
                    break;
                }
            }
        }

        public void LoFelBalra(Mezo babuHelyzete, Tabla tabla)
        {
            if (babuHelyzete.sor - 2 > -1 && babuHelyzete.oszlop - 1 > -1)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 2], babuHelyzete);
            }
        }
        public void LoFelJobbra(Mezo babuHelyzete, Tabla tabla)
        {
            if (babuHelyzete.sor - 2 > -1 && babuHelyzete.oszlop + 1 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 2], babuHelyzete);
            }
        }
        public void LoJobbraFel(Mezo babuHelyzete, Tabla tabla)
        {
            if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop + 2 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor - 1], babuHelyzete);
            }
        }
        public void LoJobbraLe(Mezo babuHelyzete, Tabla tabla)
        {
            if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop + 2 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor + 1], babuHelyzete);
            }
        }
        public void LoBalraFel(Mezo babuHelyzete, Tabla tabla)
        {
            if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop - 2 > -1)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor - 1], babuHelyzete);
            }
        }
        public void LoBalraLe(Mezo babuHelyzete, Tabla tabla)
        {
            if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop - 2 > -1)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor + 1], babuHelyzete);
            }
        }
        public void LoLeBalra(Mezo babuHelyzete, Tabla tabla)
        {
            if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop - 1 > -1)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 2], babuHelyzete);
            }
        }
        public void LoLeJobbra(Mezo babuHelyzete, Tabla tabla)
        {
            if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop + 1 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 2], babuHelyzete);
            }
        }      
    }
}
