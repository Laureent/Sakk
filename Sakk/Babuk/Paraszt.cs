namespace Sakk.Babuk
{
	public class Paraszt : LepesSzamlalo
	{
		public Paraszt(int sor, int oszlop) : base(sor, oszlop)
		{
            babuNeve = "Paraszt";
        }
        public override void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
        {
            ParasztLepesek(babuHelyzete, tabla);
        }
	}
}
