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

        internal void szinez()
        {
            if (lepesek && !foglalt)
            {
                gomb.BackColor = Color.Gray;
            }
            else if (babuFeher)
            {
                gomb.BackColor = Color.White;
            }
            else if (babuFekete)
            {
                gomb.BackColor = Color.Black;
                gomb.ForeColor = Color.White;
            }
            else if (!lepesek)
            {
                gomb.BackColor = default(Color);
            }
        }
    }
}
