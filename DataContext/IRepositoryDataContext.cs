using Projeto_Confitec.Models;

namespace Projeto_Confitec.DataContextInterface
{
    public interface IRepositoryDataContext
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SalvarAlteracoesAsync();


        Task<Usuario[]> GetTodosUsuariosAsync();

        Task<NivelEscolar[]> GetTodosNiveisEscolaresAsync();

        Task<Usuario> GetUsuarioPorId(int usuarioId);
    }
}
