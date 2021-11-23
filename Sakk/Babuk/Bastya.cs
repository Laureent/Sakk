namespace Sakk.Babuk
{
	public class Bastya : LepesSzamlalo
	{
		public new string babuNeve { get; set; }
		public Bastya(int sor, int oszlop) : base(sor, oszlop)
		{
            babuNeve = "Bástya";
		}
		public override void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
		{
			BastyaLepesek(babuHelyzete, tabla);
		}
	}
}
