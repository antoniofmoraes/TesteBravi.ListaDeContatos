using System.Globalization;

namespace TesteBravi.ListaDeContatos.Exceptions
{
    public class EmailInvalidoException : Exception
    {
        public EmailInvalidoException() : base("Email Inválido")
        {
        }

        public EmailInvalidoException(string message)
            : base(message)
        {
        }

        public EmailInvalidoException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
