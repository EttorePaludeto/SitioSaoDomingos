using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using SaoDomingos.Web.Dev.Mvc.Dados;
using SaoDomingos.Web.Dev.Mvc.Models;



namespace SaoDomingos.Web.Dev.Mvc.Controllers
{
    public class RazaoController : Controller
    {
        private readonly Base_SaoDomingosContext _ctx;
        private readonly ADOContext _ctxADO;

        public RazaoController(Base_SaoDomingosContext ctx, ADOContext ctxAdo)
        {
            _ctx = ctx;
            _ctxADO = ctxAdo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public object Get(DataSourceLoadOptions loadOptions, string userData)
        {          
            var md = JsonConvert.DeserializeObject<parametros>(userData);

            RazaoDAL dre = new RazaoDAL(_ctxADO);
            var dirView = dre.GetbyData(md.DtIni, md.DtFim, md.Conta);
            return DataSourceLoader.Load(dirView, loadOptions);
        }

        public object GetContas(DataSourceLoadOptions loadOptions)
        {
            var dirView = _ctx.PlanoContas;
            return DataSourceLoader.Load(dirView, loadOptions);
        }

    }
}