using Dominio.Advogado;
using Repositorio.Implementacao;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModel;
using Web.Filtros;

namespace Web.Controllers
{
    [Autorizacao]
    public class AdvogadoController : Controller
    {
        private readonly AdvogadoRepositorio _repositorio;

        public AdvogadoController()
        {
            _repositorio = new AdvogadoRepositorio();
        }

        public ActionResult Index()
        {
            var advogados = _repositorio.ListarTodos();
            var viewModel = new List<AdvogadoViewModel>();

            foreach (var adv in advogados)
            {
                viewModel.Add(new AdvogadoViewModel
                {
                    Id = adv.Id,
                    Nome = adv.Nome,
                    Senioridade = adv.Senioridade,
                    Logradouro = adv.Logradouro,
                    Bairro = adv.Bairro,
                    Estado = adv.Estado,
                    CEP = adv.CEP,
                    Numero = adv.Numero,
                    Complemento = adv.Complemento
                });
            }

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var model = new AdvogadoViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AdvogadoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var advogado = new Advogado
                {
                    Nome = model.Nome,
                    Senioridade = model.Senioridade,
                    Logradouro = model.Logradouro,
                    Bairro = model.Bairro,
                    Estado = model.Estado,
                    CEP = model.CEP,
                    Numero = model.Numero,
                    Complemento = model.Complemento
                };

                _repositorio.Adicionar(advogado);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Advogado/Edit/5
        public ActionResult Edit(int id)
        {
            var adv = _repositorio.ObterPorId(id);
            if (adv == null) return HttpNotFound();

            var model = new AdvogadoViewModel
            {
                Id = adv.Id,
                Nome = adv.Nome,
                Senioridade = adv.Senioridade,
                Logradouro = adv.Logradouro,
                Bairro = adv.Bairro,
                Estado = adv.Estado,
                CEP = adv.CEP,
                Numero = adv.Numero,
                Complemento = adv.Complemento
            };

            return View(model);
        }

        // POST: Advogado/Edit/5
        [HttpPost]
        public ActionResult Edit(AdvogadoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var advogado = new Advogado
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Senioridade = model.Senioridade,
                    Logradouro = model.Logradouro,
                    Bairro = model.Bairro,
                    Estado = model.Estado,
                    CEP = model.CEP,
                    Numero = model.Numero,
                    Complemento = model.Complemento
                };

                _repositorio.Atualizar(advogado);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Advogado/Delete/5
        public ActionResult Delete(int id)
        {
            _repositorio.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}