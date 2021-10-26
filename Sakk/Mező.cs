using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakk
{
    public class Mező
    {
        public bool lepesek { get; set; }
        public bool foglalt { get; set; }
        public int oszlop { get; set; }
        public int sor { get; set; }
        public string babuNeve { get; set; }
		public string babuSzine { get; set; }

		public Mező(int sor, int oszlop)
        {
            this.sor = sor;
            this.oszlop = oszlop;
        }
    }
}
