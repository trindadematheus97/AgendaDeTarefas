using AgendaDeTarefas.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeTarefas.ViewComponents
{
    public class ListaTarefasViewComponent : ViewComponent
    {
        private readonly TarefaContext _context;

        public ListaTarefasViewComponent(TarefaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string data)
        {
            return View(await _context.Tarefas
                .OrderBy(t => t.Horario).Where(t => t.Data == data).ToListAsync());
        }
    }
}
