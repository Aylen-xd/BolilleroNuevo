namespace BolilleroNuevo;

public class Bolillero //Conceptos de los elementos de un booliillero comun  
{

    //genero el metdoo random, implemento l interfaz

    public List<int> Adentro;
    public List<int> Afuera;
    ILogica _logica; //pide una bolilla, no importa como o quien.

    //implementamos el metodo de icloneable
    public Bolillero Clonar()
    {
        var nuevo = new Bolillero(this); //se crea un nuevo bolillero con misma cantidad
        nuevo.Adentro = new List<int>(this.Adentro); //copia la lista de Adentro
        nuevo.Afuera = new List<int>(this.Afuera); //copia la lista de Afuera
        return nuevo;  //devuelve el bolillero nuevo
    }

    public Bolillero(int cantidad, ILogica logica)
    {
        int Cantidad = cantidad;
        Adentro = new List<int>(); //cantidad de bolillas que estan ADENTRO del bolillero
        Afuera = new List<int>(); //cantidad de bolillas que estan AFUERA del bolillero

        for (int i = 0; i < cantidad; Adentro.Add(i++)) ;
        _logica = logica;
    }

    private Bolillero(Bolillero original)
    {
        Adentro = new List<int>(original.Adentro); 
        Afuera = new List<int>(original.Afuera);
        _logica = original._logica;
    }

    public int Sacar() //int
    {
        //int bolilla = _logica.SacarBolilla(this);
        //saco la bolita con su numero, saca la bolita de Adentro y la agrega Afuera

        int bolilla = _logica.SacarBolilla(this);

        Adentro.Remove(bolilla);
        Afuera.Add(bolilla);
        return bolilla;  //devuelve la bolilla que se saco                           
    }

    public bool Jugar(List<int> jugada) //bool true ; false  
    {
        //Compara que las bolillas sean iguales a las que jugo, para ve si gano o no

        foreach(int numero in jugada) //recorre uno a uno la lista 
        {
            int bolilla = Sacar();

            if(bolilla != numero) //si las bolilas son diferentes al numero que se saco, perdio
            {
                DevolverBolillas(); //despues de perder se meten todas las bolillas al bolillero para la    siguiente jugada 
                return false;
            }
        }

        DevolverBolillas(); //En el caso que si sean iguales, gano la jugada y se devuelven las bolillas al bolillero para jugar otra vez
        return true;
    }

    public void DevolverBolillas()
    {
        Adentro.AddRange(Afuera); //agrega los elementos de la lista de una sola vez a Adentro 
        Afuera.Clear(); //borra todos los elementos de la lista de Afuera 
    }

    public int JugarNVeces(List<int> jugada, int Cantidad) //int
    {
        //me devuelve la cantidad de veces que se hizo la jugada
        
        int aciertos = 0; 

        for(int i = 0; i < Cantidad; i++) //se recorre la cantidad de veces que se quiera jugar 
        {
            if(Jugar(jugada)) //devuelve un true o false, y el if permite decidir que hacer en cada caso
            {
                aciertos++; //al final de las jugadas se suman todas las que fueron TRUE 
            }
        }
        return aciertos; //devuelve todos lo aciertos 
    }
}
