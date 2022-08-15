using System.Globalization;

namespace TesteBravi.ListaDeContatos.Exceptions
{
    public class NomeCurtoOuInexistenteException : Exception
    {
        public NomeCurtoOuInexistenteException() : base("O nome não foi inserido ou é muito curto. Deve conter pelo menos 3 caracteres")
        {
        }

        public NomeCurtoOuInexistenteException(string message)
            : base(message)
        {
        }

        public NomeCurtoOuInexistenteException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
