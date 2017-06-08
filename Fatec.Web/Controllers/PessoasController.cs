using Fatec.Models;
using Fatec.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fatec.Web.Controllers
{
    public class PessoasController: Controller
    {
        public async Task<IActionResult> Index()
        {
            var pessoas = new PessoasServices("http://localhost:54307/pessoas");
            List<Pessoa> lista = await pessoas.Todos();
            return View(lista);
        }

        public async Task<IActionResult> Cadastro(string id = null)
        {
            if (id != null)
            {
                var tiposEventos = new PessoasServices("http://localhost:54307/pessoas");
                Pessoa objeto = await tiposEventos.Consultar(Convert.ToInt64(id));
                return View(objeto);
            }
            return View();
        }

    }
}
