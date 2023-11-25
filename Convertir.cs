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

        public override void Logica(string expresion, string operador, char[] operando1, char[] operando2)
        {
            #region TRANSFORMAR ARREGLOS DE CARACTERES EN STRINGS

            expresion += new string(operando1);
            expresion += new string(operando2);
            expresion += new string(operador);

            SetPUSH(expresion);

            #endregion
        }

        public override int IngresarElementos(int i)
        {
            return i;
        }
    }

}
