using Microsoft.EntityFrameworkCore;

namespace Projeto_Confitec.DataContext
{
    public class DataContext : DataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }



    }
}
