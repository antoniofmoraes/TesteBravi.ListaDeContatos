using System.Globalization;

namespace TesteBravi.ListaDeContatos.Exceptions
{
    public class PessoaNaoEncontradaException : Exception
    {
        public PessoaNaoEncontradaException() : base("A pessoa especificada não foi encontrada")
        {
        }

        public PessoaNaoEncontradaException(string message)
            : base(message)
        {
        }

        public PessoaNaoEncontradaException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
