using System.Globalization;

namespace TesteBravi.ListaDeContatos.Exceptions
{
    public class TipoDeContatoInvalidoException : Exception
    {
        public TipoDeContatoInvalidoException() : base("Tipo de Contato Inválido")
        {
        }

        public TipoDeContatoInvalidoException(string message)
            : base(message)
        {
        }

        public TipoDeContatoInvalidoException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
