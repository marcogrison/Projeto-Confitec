using Microsoft.EntityFrameworkCore;
using Projeto_Confitec.DataContextInterface;
using Projeto_Confitec.Models;

namespace Projeto_Confitec.Repository
{
    public class Repositorio : IRepositoryDataContext
    {
        private readonly DataContext.ApplicationDbContext _context;

        public Repositorio(DataContext.ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SalvarAlteracoesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Usuario[]> GetTodosUsuariosAsync()
        {
            IQueryable<Usuario> query = _context.Usuarios;


            query = query.Include(u => u.NivelEscolar);

            query = query.AsNoTracking()
                         .OrderBy(c => c.IdUsuario);

            return await query.ToArrayAsync();
        }

        public Task<NivelEscolar[]> GetTodosNiveisEscolaresAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetUsuarioPorId(int usuarioId)
        {
            IQueryable<Usuario> query = _context.Usuarios;


            query = query.Include(u => u.NivelEscolar);

            query = query.AsNoTracking()
                         .OrderBy(c => c.IdUsuario)
                         .Where(u => u.IdUsuario == usuarioId);


            return await query.FirstOrDefaultAsync();
        }
    }
}
