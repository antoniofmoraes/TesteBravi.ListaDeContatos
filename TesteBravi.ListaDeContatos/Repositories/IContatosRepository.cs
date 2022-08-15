using TesteBravi.ListaDeContatos.Models;

namespace TesteBravi.ListaDeContatos.Repositories
{
    public interface IContatosRepository : IRepositoryBase
    {
        public List<Contato> GetMany();
        public List<Contato> GetManyByPessoaId(int pessoaId);
        public Contato? Get(int id);
        public Contato? Add(Contato Contato, int pessoaId);
        public Contato? Update(int id, Contato Contato);
        public void Delete(int id);
        public bool ContatoExistePorId(int id);
        public bool ContatoExistePorTipoDado(int pessoaId, string tipo, string dado);
    }
}
