using AgendaDeTarefas.Context;
using AgendaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDeTarefas.Controllers
{
    public class TarefasController : Controller
    {
        public readonly TarefaContext _context;

        public TarefasController(TarefaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(PegarDatas());
        }

        private List<DatasViewModel> PegarDatas()
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataLimite = DateTime.Now.AddDays(10);
            int qtdDias = 0;
            DatasViewModel data;
            List<DatasViewModel> listaDatas = new List<DatasViewModel>();

            while(dataAtual < dataLimite)
            {
                data = new DatasViewModel();
                data.Datas = dataAtual.ToShortDateString();
                data.Identificadores = "collapse" + dataAtual.ToShortDateString().Replace("/", "");
                listaDatas.Add(data);
                qtdDias = qtdDias + 1;
                dataAtual = DateTime.Now.AddDays(qtdDias);
            }

            return listaDatas;
        }

        [HttpGet]
        public IActionResult CriarTarefa(string dataTarefa)
        {
            Tarefa tarefa = new Tarefa
            {
                Data = dataTarefa
            };

            return View(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tarefa);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarTarefa(int tarefaId)
        {
            Tarefa tarefa = await _context.Tarefas.FindAsync(tarefaId);

            if (tarefa == null)
                return NotFound();

            return View(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarTarefa(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Update(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tarefa);
        }

        [HttpPost]
        public async Task<JsonResult> ExcluirTarefa(int tarefaId)
        {
            Tarefa tarefa = await _context.Tarefas.FindAsync(tarefaId);
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return Json(true);
        }
    }
}
