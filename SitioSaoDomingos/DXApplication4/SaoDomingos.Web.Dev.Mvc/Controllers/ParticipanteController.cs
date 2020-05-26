using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaoDomingos.Web.Dev.Mvc.Models;
using System.Linq;

namespace SaoDomingos.Web.Dev.Mvc.Controllers
{
    public class ParticipanteController: Controller
    {
        private readonly Base_SaoDomingosContext _ctx;

        public ParticipanteController(Base_SaoDomingosContext context)
        {
            _ctx = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public object GetAll(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_ctx.Participante, loadOptions);
        }

        [HttpPost]
        public ActionResult Insert(int Key, string values)
        {
            try
            {
                var obj = new Participante();
                JsonConvert.PopulateObject(values, obj);
                _ctx.Participante.Add(obj);
                _ctx.SaveChanges();
                // TODO: Add insert logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPut]
        public ActionResult Edit(int Key, string values)
        {
            try
            {
                var obj = _ctx.Participante.First(c => c.Id == Key);
                JsonConvert.PopulateObject(values, obj);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int Key, string values)
        {
            try
            {
                // TODO: Add delete logic here
                var obj = _ctx.Participante.First(c => c.Id == Key);
                _ctx.Participante.Remove(obj);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
