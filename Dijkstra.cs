using System;

namespace Algoritmo_de_Dijkstra
{
    internal class Dijkstra
    {
        private int rango = 0;
        private int[,] L;
        private int[] C;
        private int[] D;
        private int trango = 0;

        public Dijkstra(int paramRango, int[,] paramArreglo)
        {
            //Variables que controlan el flujo del algoritmo
            L = new int[paramRango, paramRango];
            C = new int[paramRango];
            D = new int[paramRango];
            rango = paramRango;

            //Implementacion del algoritmo de Dijkstra
            //Estos bucles se encarga de crear y posicionar los valores correctamente
            for (int i = 0; i < rango; i++)
            {
                for (int j = 0; j < rango; j++)
                {
                    L[i,j] = paramArreglo[i,j];
                }
            }

            for (int i = 0; i < rango; i++)
            {
                C[i] = i;
            }

            for (int i = 0; i < rango; i++)
            {
                D[i] = L[0, i];
            }
        }

        //Este metodo se encaga de buscar la solucion mas eficiiente tomando en cuenta el algoritmo previamente creado
        public void SolucionDijkstra()
        {
            //Variables que controlan el flujo del metodo
            int minValor = Int32.MaxValue;
            int minNodo = 0;

            for (int i = 0; i < rango; i++)
            {
                if (C[i] == -1)
                {
                    continue;
                }

                if (D[i] > 0 && D[i] < minValor)
                {
                    minValor = D[i];
                    minNodo = i;
                }
            }

            C[minNodo] = -1;

            for (int i = 0; i < rango; i++)
            {
                if (L[minNodo, i] < 0) //En caso de que no exista arco
                {
                    continue;
                }

                if (D[i] < 0) //En caso de que no haya un peso asignado
                {
                    D[i] = minValor + L[minNodo, i];
                    continue;
                }

                if (D[minNodo] + L[minNodo, i] < D[i])
                {
                    D[i] = minValor + L[minNodo, i];
                }
            }
        }

        //Este metodo se encarga de implementar el algoritmo en base a lo previamente creado
        public void CorrerDijkstra()
        {
            for (trango = 1; trango < rango; trango++)
            {
                SolucionDijkstra();
                Console.WriteLine("Iteracion No." + trango);
                Console.WriteLine("Matriz de distancias:");

                for (int i = 0; i < rango; i++)
                {
                    Console.WriteLine(i + " ");
                }

                Console.WriteLine(" ");

                for (int i = 0; i < rango; i++)
                {
                    Console.WriteLine(D[i] + " ");
                }

                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }
        }


        static void Main(string[] args)
        {
            //Creamos una matriz para el ejemplo
            int[,] L = {
                {-1, 10, 18, -1, -1, -1, -1 },
                {-1, -1, 6, -1, 3, -1, -1 },
                {-1, -1, -1, 3, -1, 20, -1 },
                {-1, -1, 2, -1, -1, -1, 2 },
                {-1, -1,-1, 6, -1, -1, 10 },
                {-1, -1,-1,-1,-1, -1, -1 },
                {-1, -1, 10, -1, -1, 5, -1 }
            };

            //Llamamos nuestro metodo para crear el algoritmo
            Dijkstra prueba = new Dijkstra((int)Math.Sqrt(L.Length), L);
            prueba.CorrerDijkstra();


            //Corremos el programa para ver los resultados
            Console.WriteLine("La solucion de la ruta mas corta tomando como nodo inicial el Nodo 1 es: ");

            int nodo = 1;
            foreach (int i in prueba.D)
            {
                Console.Write("Distancia minima a nodo " + nodo + " es ");
                Console.WriteLine(i);
                nodo++;
            }

            Console.WriteLine();
            Console.WriteLine("Presione la tecla Enter para salir");
            Console.Read();
        }
    }
}
