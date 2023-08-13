namespace FilmesApi.Excepitions
{
    public class GenericExeception : Exception
    {
        public GenericExeception() { }

        public GenericExeception(string message) : base(message) { }
    }
}
