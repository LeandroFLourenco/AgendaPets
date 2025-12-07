using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AgendaPets.Models;
using AgendaPets.Data;

namespace AgendaPets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AgendamentoRepository _repo;

        public HomeController(ILogger<HomeController> logger, AgendamentoRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var agendamentos = _repo.ObterTodos();
            return View(agendamentos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Agendamento { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
