namespace BolilleroNuevo;

public class SacarAleatorio : ILogica
{
    //declara metodo aleatorio, recibe un minimo y maximo
    //Random

    Random _r => Random.Shared;
    public int SacarBolilla(Bolillero bolillero)
    {
        int posicion = _r.Next(bolillero.Adentro.Count); //posicion representa un indice de una bolilla en la lista de Adentro - muestra el indice que le pertenece a esa boilla
        return bolillero.Adentro[posicion]; //devuelve el valor de la bolilla que esta en esa posicion del indice
    }
}
