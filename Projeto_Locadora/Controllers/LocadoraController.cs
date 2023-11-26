using Projeto_Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Locadora.Controllers
{
    public abstract class EntidadeBaseController<T> : Controller where T : EntidadeBase
    {
        private static IList<T> entidades = new List<T>();

        public abstract IActionResult Index();

        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Create(T entidade)
        {
            entidade.Id = entidades.Any() ? entidades.Max(i => i.Id) + 1 : 1;
            entidades.Add(entidade);
            return RedirectToAction("Index");
        }

        public virtual IActionResult Edit(long id)
        {
            return View(entidades.FirstOrDefault(i => i.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Edit(T entidade)
        {
            var entidadeExistente = entidades.FirstOrDefault(i => i.Id == entidade.Id);

            if (entidadeExistente == null)
            {
                return NotFound();
            }

            entidades.Remove(entidadeExistente);
            entidades.Add(entidade);
            return RedirectToAction("Index");
        }

        public virtual IActionResult Details(long id)
        {
            return View(entidades.FirstOrDefault(i => i.Id == id));
        }

        public virtual IActionResult Delete(long id)
        {
            var entidade = entidades.FirstOrDefault(i => i.Id == id);

            if (entidade == null)
            {
                return NotFound();
            }

            return View(entidade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual IActionResult DeleteConfirmed(long id)
        {
            var entidade = entidades.FirstOrDefault(i => i.Id == id);

            if (entidade == null)
            {
                return NotFound();
            }

            entidades.Remove(entidade);
            return RedirectToAction("Index");
        }
    }

    public class LocadoraController : EntidadeBaseController<Locadora>
    {
        private static IList<Locadora> locadoras = new List<Locadora>()
        {
            new Locadora()
            {
                Id = 1,
                Nome = "Gente Grande",
                Descricao = "Filme de comédia"
            },
            new Locadora()
            {
                Id = 2,
                Nome = "A Freira",
                Descricao = "Filme de terror"
            }
        };

        public override IActionResult Index()
        {
            return View(locadoras);
        }
    }
}



