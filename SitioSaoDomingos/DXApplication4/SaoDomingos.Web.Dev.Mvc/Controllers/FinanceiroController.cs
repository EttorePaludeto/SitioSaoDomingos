using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SaoDomingos.Web.Dev.Mvc.Models;
using SaoDomingos.Web.Dev.Mvc.Models.ModelView;
using System.Security.Claims;

namespace SaoDomingos.Web.Dev.Mvc.Controllers
{
    public class FinanceiroController : Controller
    {
        private readonly Base_SaoDomingosContext _ctx;
        private readonly IHttpContextAccessor _user;

        public FinanceiroController(Base_SaoDomingosContext ctx, IHttpContextAccessor accessor)
        {
            _ctx = ctx;
            _user = accessor;
        }

             // GET: Financeiro
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Adicionar(int Key, string values)
        {
            try
            {
                var diario = new Diario();
                JsonConvert.PopulateObject(values, diario);
                diario.DataCadastro = DateTime.UtcNow;
                diario.UsuarioId = Convert.ToInt32(_user.HttpContext.User.Identity.Name);
                _ctx.Diario.Add(diario);
                
               _ctx.SaveChanges();
                // TODO: Add insert logic here
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

        // POST: Financeiro/Delete/5
        [HttpDelete]      
        public ActionResult Delete(int Key, string values)
        {
            try
            {
                // TODO: Add delete logic here
                var diario = _ctx.Diario.First(c => c.Id == Key);
                _ctx.Diario.Remove(diario);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public object Pegar(DataSourceLoadOptions loadOptions)
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
            return DataSourceLoader.Load(dirView, loadOptions);
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

    }
}