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
        private readonly ADOContext _ctxADO;

        public ResultadoController(Base_SaoDomingosContext context, ADOContext ctxADO)
        {
            _ctxADO = ctxADO;
            _ctx = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public object Get(DataSourceLoadOptions loadOptions, string DtIni, string DtFim)
        {   
            DreDAL dre = new DreDAL(_ctxADO);
            var dirView = dre.GetbyData(DtIni, DtFim);
            return DataSourceLoader.Load(dirView, loadOptions);
        }
    }     
}
