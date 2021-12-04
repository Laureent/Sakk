namespace Sakk.Babuk
{
	public class Kiraly : LepesSzamlalo
	{
		public Kiraly(int sor, int oszlop) : base(sor, oszlop)
		{
            babuNeve = "Király";
        }		
		public override void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
		{
			KiralyLepesek(babuHelyzete, tabla);
        }
	}
}
