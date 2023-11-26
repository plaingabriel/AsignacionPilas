namespace AsignacionPilas
{
    public class Program
    {
        public static void Menu(int opc)
        {
            Boolean b = false;
            do
            {
                ConvertirInfijaPostfija cip;

                if (opc == 1)
                    Console.WriteLine("Escriba una expresion infija cuyos operandos sean letras del abecedario (Mayusculas y minusculas):");

                if (opc == 2)
                    Console.WriteLine("Escriba una expresion infija cuyos operandos sean numeros enteros del 0 al 9");

                string str = Console.ReadLine().Replace(" ", "");

                if (opc == 1)
                {
                    cip = new Convertir(str.ToCharArray());
                    cip.Iniciar();
                    b = cip.GetBool();
                }

                if (opc == 2)
                {
                    cip = new Evaluar(str.ToCharArray());
                    cip.Iniciar();
                    b = cip.GetBool();
                }

            }
            while (!b);
        }
        public static void Main()
        {
            int opc;

            // MENU
            do
            {
                Console.WriteLine("Escriba el numero de una de las siguientes opciones:");
                Console.WriteLine("1 - Convertir");
                Console.WriteLine("2 - Evaluar");
                Console.WriteLine("3 - Salir");
                opc = Int32.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:

                        Menu(1);
                        Console.ReadKey();
                        break;

                    case 2:

                        Menu(2);
                        Console.ReadKey();
                        break;

                    case 3:

                        Console.WriteLine("Cerrando el programa...");
                        Console.ReadKey();
                        break;

                    default:

                        Console.WriteLine("La opcion ingresada no es valida. Por favor, intente de nuevo.");
                        Console.ReadKey();
                        break;

                }

            } while (opc != 3);
        }

    }

}
