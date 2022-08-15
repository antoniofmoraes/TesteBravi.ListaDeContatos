using System.Globalization;

namespace TesteBravi.ListaDeContatos.Exceptions
{
    public class TelefoneInvalidoException : Exception
    {
        public TelefoneInvalidoException() : base("Telefone/Whatsapp inválido")
        {
        }

        public TelefoneInvalidoException(string message)
            : base(message)
        {
        }

        public TelefoneInvalidoException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
