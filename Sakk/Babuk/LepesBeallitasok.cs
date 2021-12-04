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
        public void LepesBeallitasJobbra(Mezo babuHelyzete, Tabla tabla, int hasznyorFussonLe)
        {
            int seged = 1;
            while (babuHelyzete.oszlop + seged < 8)
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
                if (seged == hasznyorFussonLe && hasznyorFussonLe != -1)
                {
                    break;
                }
                seged++;               
            }
        }

        public void LepesBeallitasBalra(Mezo babuHelyzete, Tabla tabla, int hanyszorFussonLe)
        {
            int seged = 1;
            while (babuHelyzete.oszlop - seged > -1 )
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
                if (seged == hanyszorFussonLe && hanyszorFussonLe != -1)
                {
                    break;
                }
                seged++;               
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
        
        public void ParasztElore(Mezo babuHelyzete ,Tabla tabla)
        {
            if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuFeher)
            {
                if (babuHelyzete.oszlop + 2 < 8 && !tabla.tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor].foglalt && (babuHelyzete as LepesSzamlalo).nemLepettMeg)
                {
                    LepesBeallitasJobbra(babuHelyzete, tabla, 2);
                }
                if (oszlop + 1 < 8 && !tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor].foglalt)
                {
                    LepesBeallitasJobbra(babuHelyzete, tabla, 1);
                }
                if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop + 1 < 8 && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].foglalt && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].babuFekete)
                {
                    LepesBeallitasJobbraFel(babuHelyzete, tabla, true);
                }
                if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop + 1 < 8 && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].foglalt && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].babuFekete)
                {
                    LepesBeallitasJobbraLe(babuHelyzete, tabla, true);
                }
            }
            if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuFekete)
            {
                if (babuHelyzete.oszlop - 2 > -1 && !tabla.tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor].foglalt && (babuHelyzete as LepesSzamlalo).nemLepettMeg)
                {
                    LepesBeallitasBalra(babuHelyzete, tabla, 2);
                }
                if (!tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor].foglalt)
                {
                    LepesBeallitasBalra(babuHelyzete, tabla, 1);
                }
                if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop - 1 > -1 && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].foglalt && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].babuFeher)
                {
                    LepesBeallitasBalraFel(babuHelyzete, tabla, true);
                }
                if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop - 1 > -1 && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].foglalt && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].babuFeher)
                {
                    LepesBeallitasBalraLe(babuHelyzete, tabla, true);
                }
            }
        }
    }
}
