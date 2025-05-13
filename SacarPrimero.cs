namespace BolilleroNuevo;

public class SacarPrimero : ILogica
{
    //Saca la primer bolilla del bolillero, con posicion 0
    //coleccion.DideloSaco.First
    public int SacarBolilla(Bolillero bolillero)
    {
        return bolillero.Adentro.First(); //es un metodo que devuelve el primer elemento de la lista en la posicion 0
    }
}
