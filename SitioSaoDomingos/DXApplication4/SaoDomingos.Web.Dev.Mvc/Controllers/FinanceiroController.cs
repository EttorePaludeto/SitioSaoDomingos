using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaoDomingos.Web.Dev.Mvc.Models;

namespace SaoDomingos.Web.Dev.Mvc.Controllers
{
    public class FinanceiroController : Controller
    {
        private readonly Base_SaoDomingosContext _ctx;

        public FinanceiroController(Base_SaoDomingosContext ctx)
        {
            _ctx = ctx;
        }

        // GET: Financeiro
        public ActionResult Index()
        {
            return View();
        }

        public object GetDiario(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_ctx.Diario.ToList(), loadOptions);
        }

        // GET: Financeiro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Financeiro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Financeiro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Financeiro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Financeiro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Financeiro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Financeiro/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}