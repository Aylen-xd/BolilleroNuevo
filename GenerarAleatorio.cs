
namespace BolilleroNuevo
{
    public class GenerarAleatorio : ILogica
    {
        public int SacarBolilla(Bolillero bolillero)
        {
            int indice = Random.Shared.Next(bolillero.Adentro.Count);
            return bolillero.Adentro[indice];
        }
    }
}
