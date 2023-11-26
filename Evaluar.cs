namespace AsignacionPilas
{
    class Evaluar : ConvertirInfijaPostfija
    {
        char[] op = "0123456789".ToCharArray();

        public Evaluar(char[] e) : base(e)
        {
        }

        public override void Iniciar()
        {
            SetOperandos(op);
            Opcion();
        }

        public override string? Logica(string operador, char[] operando1, char[] operando2)
        {
            int expresion = 0;

            switch (operador)
            {
                case "+":

                    expresion = Int32.Parse(operando1) + Int32.Parse(operando2);
                    break;

                case "-":

                    expresion = Int32.Parse(operando1) - Int32.Parse(operando2);
                    break;

                case "*":

                    expresion = Int32.Parse(operando1) * Int32.Parse(operando2);
                    break;

                case "/":

                    if (Int32.Parse(operando2) == 0)
                        return null;

                    expresion = Int32.Parse(operando1) / Int32.Parse(operando2);
                    break;

                case "^":

                    // Realizar operacion de potenciacion
                    expresion = (int)Math.Pow(Double.Parse(operando1), Double.Parse(operando2));
                    break;

                case "%":

                    if (Int32.Parse(operando2) == 0)
                        return null;

                    expresion = Int32.Parse(operando1) % Int32.Parse(operando2);
                    break;
            }
            // TRANSFORMAR ARREGLOS DE CARACTERES EN STRINGS

            return expresion.ToString();

        }
    }

}
