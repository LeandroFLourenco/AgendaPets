using Microsoft.AspNetCore.Mvc;
using AgendaPets.Models;
using AgendaPets.Data;

namespace AgendaPets.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly AgendamentoRepository _repo;

        public AgendamentoController(AgendamentoRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Salvar(Agendamento agendamento)
        {
            if (agendamento == null) return RedirectToAction("Index", "Home");

            if (agendamento.Id == 0)
                _repo.Inserir(agendamento);
            else
                _repo.Atualizar(agendamento);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            _repo.Deletar(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
