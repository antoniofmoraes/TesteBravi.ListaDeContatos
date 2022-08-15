using System.ComponentModel.DataAnnotations;
using TesteBravi.ListaDeContatos.Exceptions;

namespace TesteBravi.ListaDeContatos.Models
{
    public class Contato
    {
        public int? Id { get; set; }
        public string? Tipo { get; set; }
        public string? Dado { get; set; } 

        public void ValidarContato()
        {
            Tipo = Tipo == null ? null : char.ToUpper(Tipo[0]) + Tipo[1..];

            switch (Tipo)
            {
                case "Whatsapp":
                case "Telefone":
                    var telefoneValidator = new PhoneAttribute();
                    if (!telefoneValidator.IsValid(Dado))
                        throw new TelefoneInvalidoException();
                    break;
                case "Email":
                    var emailValidator = new EmailAddressAttribute();
                    if (!emailValidator.IsValid(Dado))
                        throw new EmailInvalidoException();
                    break;
                default:
                        throw new TipoDeContatoInvalidoException();
            }
        }
    }
}
