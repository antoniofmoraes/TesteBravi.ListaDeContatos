using System.Globalization;

namespace TesteBravi.ListaDeContatos.Exceptions
{
    public class ContatoJaExistenteException : Exception
    {
        public ContatoJaExistenteException() : base("O contato já existe para essa pessoa")
        {
        }

        public ContatoJaExistenteException(string message)
            : base(message)
        {
        }

        public ContatoJaExistenteException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
