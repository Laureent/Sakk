namespace Sakk.Babuk
{
    public class Babu : LepesBeallitasok
    {
        public Babu(int sor, int oszlop) : base(sor, oszlop)
        {

        }

        public virtual void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
        {
            if (babuHelyzete.babuTipus is Paraszt)
            {
                new Paraszt(sor, oszlop).LepesBeallitas(babuHelyzete, tabla);
            }
            else if (babuHelyzete.babuTipus is Bastya)
            {
                new Bastya(sor, oszlop).LepesBeallitas(babuHelyzete, tabla);
            }
        }
        public void ParasztLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            FeherParasztLepes(babuHelyzete, tabla);
            FeketeParasztLepes(babuHelyzete, tabla);
        }
        public void BastyaLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            LepesBeallitasFelfele(babuHelyzete, tabla, false);
            LepesBeallitasLefele(babuHelyzete, tabla, false);
            LepesBeallitasJobbra(babuHelyzete, tabla, 7);
            LepesBeallitasBalra(babuHelyzete, tabla, 7);
        }
        public void FutoLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            LepesBeallitasBalraFel(babuHelyzete, tabla, false);
            LepesBeallitasJobbraFel(babuHelyzete, tabla, false);
            LepesBeallitasBalraLe(babuHelyzete, tabla, false);
            LepesBeallitasJobbraLe(babuHelyzete, tabla, false);
        }

        public bool FeherFelfeleTudSancolni(Tabla tabla)
        {
            return tabla.tabla[0, 3] is Kiraly && tabla.tabla[0, 3].babuFeher && (tabla.tabla[0, 3] as LepesSzamlalo).nemLepettMeg && tabla.tabla[0, 0] is Bastya && (tabla.tabla[0, 0] as LepesSzamlalo).nemLepettMeg && tabla.tabla[0, 0].babuFeher && !tabla.tabla[0, 1].foglalt && !tabla.tabla[0, 2].foglalt;
        }
        public bool FeherLefeleTudSancolni(Tabla tabla)
        {
            return tabla.tabla[0, 3] is Kiraly && tabla.tabla[0, 3].babuFeher && (tabla.tabla[0, 3] as LepesSzamlalo).nemLepettMeg && tabla.tabla[0, 7] is Bastya && (tabla.tabla[0, 7] as LepesSzamlalo).nemLepettMeg && tabla.tabla[0, 7].babuFeher && !tabla.tabla[0, 4].foglalt && !tabla.tabla[0, 5].foglalt && !tabla.tabla[0, 6].foglalt;
        }
        public bool FeketeFelfeleTudSancolni(Tabla tabla)
        {
            return tabla.tabla[7, 3] is Kiraly && tabla.tabla[7, 3].babuFekete && (tabla.tabla[7, 3] as LepesSzamlalo).nemLepettMeg && tabla.tabla[7, 0] is Bastya && (tabla.tabla[7, 0] as LepesSzamlalo).nemLepettMeg && tabla.tabla[7, 0].babuFekete && !tabla.tabla[7, 1].foglalt && !tabla.tabla[7, 2].foglalt;
        }
        public bool FeketeLefeleTudSancolni(Tabla tabla)
        {
            return tabla.tabla[7, 3] is Kiraly && tabla.tabla[7, 3].babuFekete && (tabla.tabla[7, 3] as LepesSzamlalo).nemLepettMeg && tabla.tabla[7, 7] is Bastya && (tabla.tabla[7, 7] as LepesSzamlalo).nemLepettMeg && tabla.tabla[7, 7].babuFekete && !tabla.tabla[7, 4].foglalt && !tabla.tabla[7, 5].foglalt && !tabla.tabla[7, 6].foglalt;
        }

        public void SancolasVizsgalat(Mezo babuHelyzete,Tabla tabla)
        {
            if (babuHelyzete.babuFeher)
            {
                if (FeherFelfeleTudSancolni(tabla))
                {
                    tabla.tabla[0, 1].lepesek = true;
                }
                if (FeherLefeleTudSancolni(tabla))
                {
                    tabla.tabla[0, 5].lepesek = true;
                }
            }
            if(babuHelyzete.babuFekete)
            {
                if (FeketeFelfeleTudSancolni(tabla))
                {
                    tabla.tabla[7, 1].lepesek = true;
                }
                if (FeketeLefeleTudSancolni(tabla))
                {
                    tabla.tabla[7, 5].lepesek = true;
                }
            }           
        }

        public void KiralyLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            SancolasVizsgalat(babuHelyzete,tabla);
            LepesBeallitasFelfele(babuHelyzete, tabla, true);
            LepesBeallitasJobbra(babuHelyzete, tabla, 1);
            LepesBeallitasLefele(babuHelyzete, tabla, true);
            LepesBeallitasBalra(babuHelyzete, tabla, 1);
            LepesBeallitasBalraFel(babuHelyzete, tabla, true);
            LepesBeallitasJobbraFel(babuHelyzete, tabla, true);
            LepesBeallitasBalraLe(babuHelyzete, tabla, true);
            LepesBeallitasJobbraLe(babuHelyzete, tabla, true);
        }
        public void KiralynoLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            LepesBeallitasFelfele(babuHelyzete, tabla, false);
            LepesBeallitasJobbra(babuHelyzete, tabla, 7);
            LepesBeallitasLefele(babuHelyzete, tabla, false);
            LepesBeallitasBalra(babuHelyzete, tabla, 7);
            LepesBeallitasBalraFel(babuHelyzete, tabla, false);
            LepesBeallitasJobbraFel(babuHelyzete, tabla, false);
            LepesBeallitasBalraLe(babuHelyzete, tabla, false);
            LepesBeallitasJobbraLe(babuHelyzete, tabla, false);
        }
        public void LoLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            LoFelBalra(babuHelyzete, tabla);
            LoFelJobbra(babuHelyzete, tabla);
            LoBalraFel(babuHelyzete, tabla);
            LoBalraLe(babuHelyzete, tabla);
            LoJobbraFel(babuHelyzete, tabla);
            LoJobbraLe(babuHelyzete, tabla);
            LoLeBalra(babuHelyzete, tabla);
            LoLeJobbra(babuHelyzete, tabla);
        }
    }
}
