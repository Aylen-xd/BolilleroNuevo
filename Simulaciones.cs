namespace BolilleroNuevo;

public class Simulaciones //Multiprogramacion 
{
    public long SimularSinHilos(Bolillero bolillero, List<int> juagada, int CantidadSimulaciones) //devuelve un tipo de dato int, pero que es mas grande
            => bolillero.JugarNVeces(juagada, CantidadSimulaciones);

    public long SimularConHilos(Bolillero bolillero, List<int> juagada, int CantidadSimulaciones, int CantidadHilos)
    { 
        int simulacionPorHilo = CantidadSimulaciones / CantidadHilos; 
        //cuantas simulaciones le toca a cada hilo
        //se divide el total de la cantidad de simulciones con los hilos 

        Task<long>[] tareas = new Task<long>[CantidadHilos]; //se utiliza vector porque yo ya tengo un resultado con tamaño fijo, cantidadHilos 


        for (int i = 0; i < CantidadHilos; i++)
        {
            Bolillero copia = (Bolillero)bolillero.Clonar(); //copia del bolillero, cada hilo hace su propia copia
            tareas[i] = Task.Run<long>(() => 
                copia.JugarNVeces(juagada, simulacionPorHilo));
        }

        Task.WaitAll(tareas.ToArray()); //espera que todas las terminen antes de arrancar

        long totalResultado = tareas.Sum(t => t.Result); //devuelve los resultado de cada tarea, las veces que se gano la jugada. Accede a los resultados de cada una 

        return totalResultado;
    }
}
