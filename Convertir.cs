namespace AsignacionPilas
{
    class Convertir : ConvertirInfijaPostfija
    {
        char[] op = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

        public Convertir(char[] e) : base(e)
        {
        }

        public override void Iniciar()
        {
            SetOperandos(op);
            Opcion();
        }

        public override string? Logica(string operador, char[] operando1, char[] operando2)
        {
            string expresion = "";

            // TRANSFORMAR ARREGLOS DE CARACTERES EN STRINGS

            expresion += new string(operando1);
            expresion += new string(operando2);
            expresion += new string(operador);

            return expresion;

        }
    }

}
