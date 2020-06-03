using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SaoDomingos.Web.Dev.Mvc.Dados;
using SaoDomingos.Web.Dev.Mvc.Models;
using SaoDomingos.Web.Dev.Mvc.Models.ModelView;
using System;
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

       // [HttpGet]
        //public object GetByDate(DataSourceLoadOptions loadOptions, string DtIni, string DtFim)
        //{
        // //  return Get(loadOptions, DtIni, DtFim);
        //}

        //[HttpPost]
        //public object GetByDateP(DataSourceLoadOptions loadOptions, string DtIni, string DtFim)
        //{
        // //   return Get(loadOptions, DtIni, DtFim);
        //}


        public object Get(DataSourceLoadOptions loadOptions, string DtIni, string DtFim)
        {
            
            DreDAL dre = new DreDAL();
            var dirView = dre.GetbyData(DtIni, DtFim);

            return DataSourceLoader.Load(dirView, loadOptions);
        }
    }     
}
