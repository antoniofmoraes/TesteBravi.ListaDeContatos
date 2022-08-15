using System.Globalization;

namespace TesteBravi.ListaDeContatos.Exceptions
{
    public class ContatoNaoEncontradoException : Exception
    {
        public ContatoNaoEncontradoException() : base("O contato especificado não foi encontrado")
        {
        }

        public ContatoNaoEncontradoException(string message)
            : base(message)
        {
        }

        public ContatoNaoEncontradoException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
