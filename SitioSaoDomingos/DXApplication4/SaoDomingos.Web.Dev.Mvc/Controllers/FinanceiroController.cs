using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SaoDomingos.Web.Dev.Mvc.Models;
using SaoDomingos.Web.Dev.Mvc.Models.ModelView;

namespace SaoDomingos.Web.Dev.Mvc.Controllers
{
    public class FinanceiroController : Controller
    {
        private readonly Base_SaoDomingosContext _ctx;

        public FinanceiroController(Base_SaoDomingosContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public object DataGridLookUpPlanoContas(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_ctx.PlanoContas, loadOptions);
        }

        [HttpGet]
        public object DataGridLookUpParticipantes(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_ctx.Participante, loadOptions);
        }



        // GET: Financeiro
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public object Pegar(DataSourceLoadOptions loadOptions)
        {
            var d = diarioview();
            return DataSourceLoader.Load(d, loadOptions);

        }

        private List<DiarioView> diarioview()
        {
            List<Diario> dir = _ctx.Diario
               .Include(c => c.Debito)
               .Include(d => d.Credito)
               .Include(e => e.Participante)
               .Include(f => f.Usuario)
               .ToList();

            List<DiarioView> dirView = new List<DiarioView>();

            foreach (var item in dir)
            {
                DiarioView itemView = new DiarioView(item);
                dirView.Add(itemView);
            }

            return dirView;
        }




        public object GetDiario(DataSourceLoadOptions loadOptions)
        {
            var dir = _ctx.Diario.FromSqlRaw(
                 @"select d.id, d.Data, d.Historico, d.Valor, deb.Contabil, cre.Contabil
                 from diario as d inner join PlanoContas as deb on d.DebitoId = deb.Id  
                inner join PlanoContas as cre on d.CreditoId = cre.Id");


            return DataSourceLoader.Load(dir, loadOptions);
        }

        // GET: Financeiro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Financeiro/Create
        public ActionResult Adicionar()
        {
            return View();
        }

        // POST: Financeiro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(IFormCollection collection)
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

        [HttpGet]
        public ActionResult Edit(int Id)
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
        // POST: Financeiro/Edit/5
        [HttpPut]
        public ActionResult Edit(int Key, string values)
        {
            try
            {
                var diario = _ctx.Diario.First(c => c.Id == Key);
                JsonConvert.PopulateObject(values, diario);
                _ctx.SaveChanges();
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