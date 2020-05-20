using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SaoDomingos.Web.App.Areas.Usuarios.Models;

namespace SaoDomingos.Web.App.Areas.Usuarios.Pages.Contas
{
    public class RegistrarModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public InserirModel Inserir { get; set; }

        public class InserirModel: InserirDadosRegistar
        {
            public  IFormFile AvatarImage{ get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}
