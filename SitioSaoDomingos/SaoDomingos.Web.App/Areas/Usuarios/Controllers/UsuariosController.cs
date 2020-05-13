using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SaoDomingos.Web.App.Areas.Usuarios.Controllers
{
    [Area("Usuarios")]
    public class UsuariosController : Controller
    {
        public IActionResult Usuarios()

        {
            return View();
        }
    }
}