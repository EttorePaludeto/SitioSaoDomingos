using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SaoDomingos.Web.Dev.Mvc.Models;
using SaoDomingos.Web.Dev.Mvc.Models.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace SaoDomingos.Web.Dev.Mvc.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly Base_SaoDomingosContext _ctx;

        public ResultadoController(Base_SaoDomingosContext context)
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
    }     
}
