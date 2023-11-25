namespace AsignacionPilas
{
    public class ConvertirInfija
    {
        #region ATRIBUTOS
        readonly char[] operandosABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        readonly char[] operandosNum = "0123456789".ToCharArray();
        readonly char[] operadores = "+-*/^%".ToCharArray();
        readonly char[] agrupacion = "()".ToCharArray();

        Pila p;
        char[] entrada;
        #endregion

        #region CONSTRUCTOR
        public ConvertirInfija(char[] e)
        {
            p = new Pila(e.Length);
            entrada = e;
        }
        #endregion

        #region METODOS ESTATICOS
        private static bool Comparar(char l, char[] s)
        {
            foreach (var item in s)
            {
                if (l == item)
                {
                    return true;
                }
            }
            return false;
        }
        private static void MostrarErrorFormato()
        {

            Console.WriteLine("La operacion ingresada no esta en formato correcto");
            Console.ReadKey();
            return;

        }
        #endregion

        #region OPCIONES

        // CONVERTIR
        public void Convertir()
        {
            Opcion(operandosABC);
        }

        // EVALUAR
        public void Evaluar()
        {
            Opcion(operandosNum);
        }
        #endregion

        #region METODOS COMPLEMENTARIOS DE "OPCIONES"

        // VERIFICAR ARREGLOS DE CARACTERES
        private bool CompararArreglos(char[] s, int len, char[] op) // op puede ser tanto operandoNum como operandosABC
        {
            foreach (char item in s)
            {
                if (len > 1)
                {
                    // Si el arreglo de caracteres tiene una longitud mayor a 1, entonces deberia estar en forma de expresion infija
                    // Por ende, se debe verificar que tenga tanto operadores como operandosABC
                    if (!Comparar(item, op) && !Comparar(item, operadores))
                        return false;

                    return true;
                }

                // Caso contrario, comparar como un caracter normal
                if (!Comparar(item, operandosABC))
                    return false;
            }

            return true;
        }

        // METODO PARA EXPRESIONES INFIJAS DEPENDIENDO DE SI ES EVALUAR O CONVERTIR
        private void Opcion(char[] op)
        {
            // Return; = abortar

            #region VALIDAR ENTRADA

            if (!ValidarEntrada())
            {
                Console.WriteLine("La operacion ingresada contiene caracteres invalidos");
                Console.ReadKey();
                return;
            }

            #endregion

            #region DECLARACION DE VARIABLES

            String expresion = "";
            String? operador; // Se declaran en diferentes lineas debido a que esta variable puede ser nula mientras que expresion no
            char[]? operando1, operando2;
            int i = 0;
            bool c = false; // Variable continuar. Se utiliza para saber si se debe continuar despues de un parentesis que abre

            #endregion

            // CICLO
            foreach (char l in entrada)
            {
                #region CASOS PARENTESIS

                // Si hay un parentesis que abre, saltarse esta iteracion
                if (l == '(')
                {
                    c = true;
                    continue;
                }

                // Si c es falso, significa que ha salido de un parentesis que cierra
                // Hasta que no vuelva a entrar en un parentesis que abre, ingresara todo elemento que encuentre
                // Esto, con el fin de ingresar operadores entre dos operaciones parentizadas
                // Sin embargo, si el elemento que encuntra resulta ser un parentesis que cierra, se ignora y se continua con la interacion
                if (!c && l != ')')
                {
                    p.PUSH(l.ToString());
                    continue;
                }

                #endregion

                #region LOGICA DE CONVERSION

                // Si hay un parentesis que cierra, hacer la conversion
                if (l == ')')
                {
                    #region ASIGNACION Y VALIDACION DE LOS VALORES A LOS OPERANDOS/OPERADOR

                    // Se toman como arreglos en el caso de que sean varios caracteres convertidos a expresiones infijas
                    operando2 = p.POPTOPE().ToCharArray();
                    operador = p.POPTOPE();
                    operando1 = p.POPTOPE().ToCharArray();

                    // Verificar que las variables operando1 y operando2 sean operandosABC

                    if (!CompararArreglos(operando1, operando1.Length, op) || !CompararArreglos(operando2, operando2.Length, op))
                    {
                        MostrarErrorFormato();
                        return;
                    }

                    // Verificar que operador sea un operador
                    foreach (var item in operador)
                        if (!Comparar(item, operadores))
                        {
                            MostrarErrorFormato();
                            return;
                        }

                    #endregion

                    #region NOTA: ZONA A CAMBIAR

                    // Transformar los arreglos de caracteres en strings
                    expresion += new string(operando1);
                    expresion += new string(operando2);
                    expresion += new string(operador);

                    p.PUSH(expresion);

                    #endregion

                    #region LIMPIAR VARIABLES PARA PODER SER REUTILIZADAS

                    operando2 = null;
                    operador = null;
                    operando1 = null;

                    expresion = "";

                    c = false;

                    #endregion

                    // Terminar iteracion
                    continue;
                }

                #endregion

                #region INGRESAR 3 DATOS A LA PILA DE TIPO OPERANDO/OPERADORES DESPUES DE UN PARENTESIS QUE ABRE

                if (c)
                {
                    i++;

                    if (i % 3 == 1)
                        p.PUSH(l.ToString()); // Operando 1

                    if (i % 3 == 2)
                        p.PUSH(l.ToString()); // Operador

                    if (i % 3 == 0)
                        p.PUSH(l.ToString()); // Operando 2
                }

                #endregion
            }

            // Validar que solo exista un elemento en el arreglo
            if (p.GetTope() != 0)
            {
                MostrarErrorFormato();
                return;
            }

            // Salida
            Console.WriteLine("Expresion Infija: ");
            p.Mostrar();
        }
        #endregion

        #region METODOS PARA VALIDAR ENTRADA

        // VALIDAR ENTRADA
        // Agrupar todas las funciones diseñadas para validar que una expresion tiene caracteres validos para ser una expresion infija
        private bool ValidarEntrada()
        {

            if (!CompararTodos())
                return false;

            if (!ContarParentesis())
                return false;

            if (!CompararOp())
                return false;

            return true;
        }

        // COMPARAR TODOS
        // Comparar un caracter con todos los posibles caracteres validos que puede tener una expresion infija
        private bool CompararTodos()
        {
            foreach (var l in entrada)
            {
                if (Comparar(l, operandosABC))
                    return true;
                if (Comparar(l, operadores))
                    return true;
                if (Comparar(l, agrupacion))
                    return true;
            }

            return false;
        }

        // CONTAR PARENTESIS
        // Verificar que la cantidad de parentesis que abren sean igual a la cantidad de parentesis que cierran
        private bool ContarParentesis()
        {
            int cont1 = 0, cont2 = 0;

            foreach (var l in entrada)
            {
                if (l == '(')
                    cont1++;
                if (l == ')')
                    cont2++;

            }

            return cont1 == cont2;
        }

        // COMPARAR OPERADORES
        // Verificar que la cantidad de operadores sea la cantidad de operandos + 1
        private bool CompararOp()
        {
            int cantoperandosABC = 0, cantOperadores = 0;

            foreach (var l in entrada)
            {
                foreach (var item in operandosABC)
                    if (l == item)
                        cantoperandosABC++;

                foreach (var item in operadores)
                    if (l == item)
                        cantOperadores++;
            }

            return cantoperandosABC == cantOperadores + 1;
        }

        #endregion

    }
}