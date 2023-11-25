using System;

namespace AsignacionPilas
{
    public class Program
    {
        public static void Main()
        {
            /*
            String str;
            int opc;

            switch (opc)
            {
                case 1:
                    Console.ReadKey();
                    break;
                case 2:
                    Console.ReadKey();
                    break;
                case 3:
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("La opcion ingresada no es valida. Por favor, intente de nuevo.");
                    Console.ReadKey();
                    break;
            }
            */

            String str = "(((A+B)/(C-D)+(E*F)))".Replace(" ", "");
            Convertir c = new Convertir(str.ToCharArray());
            c.Iniciar();
        }
    }

}
