namespace AsignacionPilas
{
    public abstract class ConvertirInfijaPostfija
    {
        #region ATRIBUTOS

        private char[] operadores = "+-*/^%".ToCharArray();
        private char[] agrupacion = "()".ToCharArray();

        private char[]? operandos;


        private Pila p;
        private char[] entrada;

        #endregion

        #region CONSTRUCTOR
        public ConvertirInfijaPostfija(char[] e)
        {
            p = new Pila(e.Length);
            entrada = e;
        }
        #endregion

        #region SETTERS

        public void SetOperandos(char[] op)
        {
            operandos = op;
        }

        public void SetPUSH(string expresion)
        {
            p.PUSH(expresion);
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

        #region METODOS ABSTRACTOS

        // LOGICA DE SEGUN SEA CONVERTIR - EVALUAR
        public abstract string? Logica(string operador, char[] operando1, char[] operando2);

        // INGRESAR 3 ELEMENTOS DE LA PILA
        public abstract int IngresarElementos(int i, char l); // Acceder y devolver i

        // INICIAR CONVERSION - EVALUACION SEGUN EL CASO
        public abstract void Iniciar(); // El "MAIN" para iniciar las operaciones dentro de las clases derivadas

        #endregion

        #region METODOS DE "INICIAR"

        // VERIFICAR ARREGLOS DE CARACTERES
        private bool CompararArreglos(char[] s, int len) // op puede ser tanto operandoNum como operandos
        {
            foreach (char item in s)
            {
                if (len > 1)
                {
                    // Si el arreglo de caracteres tiene una longitud mayor a 1, entonces deberia estar en forma de expresion infija
                    // Por ende, se debe verificar que tenga tanto operadores como operandos
                    if (!Comparar(item, operandos) && !Comparar(item, operadores))
                        return false;

                    return true;
                }

                // Caso contrario, comparar como un caracter normal
                if (!Comparar(item, operandos))
                    return false;
            }

            return true;
        }

        // METODO PARA EXPRESIONES INFIJAS DEPENDIENDO DE SI ES EVALUAR O CONVERTIR
        public void Opcion()
        {
            // Return; = abortar

            #region VALIDAR ENTRADA

            if (!ValidarEntrada())
            {
                Console.WriteLine("ERROR. Expresion invalida");
                Console.ReadKey();
                return;
            }

            #endregion

            #region DECLARACION DE VARIABLES

            string operador; // Se declaran en diferentes lineas debido a que esta variable puede ser nula mientras que expresion no
            char[] operando1, operando2;
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
                    SetPUSH(l.ToString());
                    continue;
                }

                if (c && i == 0 && l == ')')
                {
                    MostrarErrorFormato();
                    return;
                }


                #endregion

                #region LOGICA DE CONVERTIR - EVALUAR SEGUN SEA EL CASO

                // Si hay un parentesis que cierra, hacer la conversion
                if (l == ')')
                {
                    #region ASIGNACION Y VALIDACION DE LOS VALORES A LOS OPERANDOS/OPERADOR

                    // Se toman como arreglos en el caso de que sean varios caracteres convertidos a expresiones infijas
                    operando2 = p.POPTOPE().ToCharArray();
                    operador = p.POPTOPE();
                    operando1 = p.POPTOPE().ToCharArray();

                    if (!ValidarFormato(operando1, operando2, operador))
                        return;

                    #endregion

                    // No hace falta limpiar las variables debido a que con la funcion, solo se pasa una copia de ellas, mas no se modifica su referencia
                    string? expresion = Logica(operador, operando1, operando2);

                    if (expresion == null)
                        return;

                    SetPUSH(expresion);

                    // Parentesis que cierra significa continuar = falso
                    c = false;

                    // Reiniciar
                    i = 0;

                    // Terminar iteracion
                    continue;
                }

                #endregion


                #region INGRESAR 3 DATOS A LA PILA DE TIPO OPERANDO/OPERADORES DESPUES DE UN PARENTESIS QUE ABRE

                if (c)
                    i = IngresarElementos(i, l);

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

        // VALIDAR FORMATO
        private bool ValidarFormato(char[] operando1, char[] operando2, string operador)
        {
            // Verificar que las variables operando1 y operando2 sean operandos

            if (!CompararArreglos(operando1, operando1.Length) || !CompararArreglos(operando2, operando2.Length))
            {
                MostrarErrorFormato();
                return false;
            }

            // Verificar que operador sea un operador
            foreach (char item in operador)
                if (!Comparar(item, operadores))
                {
                    MostrarErrorFormato();
                    return false;
                }

            return true;
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
            bool val = false;

            // Val recorrerá todo el arreglo de caracteres para descubrir si hay un caracter inválido
            foreach (var l in entrada)
            {
                if (Comparar(l, operandos))
                {
                    val = true;
                    continue;
                }
                if (Comparar(l, operadores))
                {
                    val = true;
                    continue;
                }
                if (Comparar(l, agrupacion))
                {
                    val = true;
                    continue;
                }

                // Detener el ciclo si encuentra un caracter invalido
                val = false;
                break;
            }

            return val;
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
            int cantoperandos = 0, cantOperadores = 0;

            foreach (var l in entrada)
            {
                foreach (var item in operandos)
                    if (l == item)
                        cantoperandos++;

                foreach (var item in operadores)
                    if (l == item)
                        cantOperadores++;
            }

            return cantoperandos == cantOperadores + 1;
        }

        #endregion

    }
}