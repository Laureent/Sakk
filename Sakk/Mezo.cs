using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sakk.Babuk
{
    public class Mezo
    {
        public bool lepesek { get; set; }
        public bool foglalt { get{
				if (babuNeve==null)
				{
                    return false;
				}
				return babuNeve.Length>0;
            }
        }
        public int oszlop { get; private set; }
        public int sor { get; private set; }
        public string babuNeve { get; set; }
		public BabuSzine babuSzine { get; set; }
        public bool babuFekete { get => babuSzine == BabuSzine.FEKETE && !IsType(typeof(Mezo)); }
        public bool babuFeher { get => babuSzine == BabuSzine.FEHER && !IsType(typeof(Mezo)); }
        public Button gomb { get; set; }
        public bool changed { get; private set; }
        public Babu babuTipus { get; set; }
        public Tabla tabla { get; set; }

        public Mezo(int sor, int oszlop)
        {
            this.sor = sor;
            this.oszlop = oszlop;
            gomb = new Button();
            changed = true;
        }

        virtual public void Lepes(int sor, int oszlop)
        {
            this.oszlop = oszlop;
            this.sor = sor;
        }

        public bool IsType(Type type)
        {
            return GetType() == type;
        }

        public void clearChanged() => changed = false;

        public void setChanged() => changed = true;

        public void SzegelySzinezes(Button gomb,Color szegelySzin,int meret)
        {
            gomb.FlatAppearance.BorderColor = szegelySzin;
            gomb.FlatAppearance.BorderSize = meret;
        }

        public void HatterEsBetuszinAllitas(Button gomb,Color hatterSzin = default(Color), Color betuSzin = default(Color))
        {
            gomb.BackColor = hatterSzin;
            gomb.ForeColor = betuSzin;
        }

        //mezők kinézetének beállítása(színek)
        internal void szinez()
        {
            if (lepesek && !foglalt)
            {
                SzegelySzinezes(gomb, Color.Black,2);
            }
            else if (lepesek && foglalt)
            {
                SzegelySzinezes(gomb, Color.Red,3);
            }
            else if (babuFeher)
            {
                SzegelySzinezes(gomb, Color.White, 2);
                HatterEsBetuszinAllitas(gomb, Color.White, Color.Black);
            } 
            else if (babuFekete)
            {
                SzegelySzinezes(gomb, Color.Black, 2);
                HatterEsBetuszinAllitas(gomb, Color.Black, Color.White);
            }
            else if (!lepesek)
            {
                SzegelySzinezes(gomb, Color.LightGray, 2);
                HatterEsBetuszinAllitas(gomb);
            }
        }
    }
}
