using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakk
{
    class Babuk
    {
        private Dictionary<int, int> paraszt = new Dictionary<int, int>();
        private Dictionary<int, int> bástya = new Dictionary<int, int>();
        private Dictionary<int, int> ló = new Dictionary<int, int>();
        private Dictionary<int, int> futó = new Dictionary<int, int>();
        private Dictionary<int, int> királynő = new Dictionary<int, int>();
        private Dictionary<int, int> király = new Dictionary<int, int>();

        public Dictionary<int, int> Paraszt {
            get 
            {
                return paraszt;
            } set {
                Paraszt = value;    
            }
        }
        public Dictionary<int, int> Bástya {
            get
            {
                return bástya;
            }
            set
            {
                bástya = value;
            }
        }
        public Dictionary<int, int> Ló
        {
            get
            {
                return ló;
            }
            set
            {
                ló = value;
            }
        }
        public Dictionary<int, int> Futó
        {
            get
            {
                return futó;
            }
            set
            {
                futó = value;
            }
        }
        public Dictionary<int, int> Királynő
        {
            get
            {
                return királynő;
            }
            set
            {
                királynő = value;
            }
        }
        public Dictionary<int, int> Király
        {
            get
            {
                return király;
            }
            set
            {
                király = value;
            }
        }
        public Babuk()
        {
            
        }
    }
}
