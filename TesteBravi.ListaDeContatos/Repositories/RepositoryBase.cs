using Microsoft.EntityFrameworkCore;
using TesteBravi.ListaDeContatos.Data;

namespace TesteBravi.ListaDeContatos.Repositories
{
    public class RepositoryBase : IRepositoryBase
    {
        private readonly ListaDeContatosContext _context;

        public RepositoryBase(ListaDeContatosContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
