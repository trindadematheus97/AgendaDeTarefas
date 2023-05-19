using AgendaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeTarefas.Context
{
    public class TarefaContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {

        }
    }
}
