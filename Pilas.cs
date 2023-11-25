namespace AsignacionPilas
{
    class Pila
    {
        #region ATRIBUTOS

        object[] Elements;
        int tope;

        #endregion

        #region CONSTRUCTOR

        public Pila(int MAX)
        {
            tope = -1;
            Elements = new object[MAX];
        }

        #endregion

        #region METODOS

        // AGREGAR AL FINAL DE LA PILA
        public void PUSH(string dato)
        {
            Elements[++tope] = dato;
        }

        // SACAR ELEMENTO AL FINAL DE LA PILA
        public String POPTOPE()
        {
            return (string)Elements[tope--];
        }

        // MOSTAR PILA
        public void Mostrar()
        {
            for (int i = 0; i < tope + 1; i++)
            {
                Console.WriteLine(Elements[i]);
            }
        }

        // OBTENER TOPE
        public int GetTope()
        {
            return tope;
        }

        #endregion
    }

}