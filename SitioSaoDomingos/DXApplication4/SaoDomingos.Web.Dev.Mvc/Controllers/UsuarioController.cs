﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaoDomingos.Web.Dev.Mvc.Models;

namespace SaoDomingos.Web.Dev.Mvc.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Base_SaoDomingosContext _ctx;

        public UsuarioController(Base_SaoDomingosContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult LoginPage()
        {
            if (User.Identity.IsAuthenticated)
            {
                //return RedirectToAction("GridUsuarios");
                return RedirectToAction("PageMain");
            }

            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(Usuario usuario)
        {

            Usuario usuarioBD = _ctx.Usuario.Where(c => c.Nome == usuario.Nome && c.Senha == usuario.Senha).FirstOrDefault();

            try
            {
                if (ModelState.IsValid)
                {
                    if (usuarioBD != null)
                    {
                        Login(usuarioBD);
                        return RedirectToAction("PageMain");
                    }
                    else
                    {
                        ViewBag.Erro = "Dados Login Inválidos";
                    }
                }
            }
            catch (System.Exception)
            {
                ViewBag.Erro = "Ocorreu algum problema :-(";

            }

            return View();
        }

        private async void Login(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, "Usuario_Comum")
            };

            var identidadeDeUsuario = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeDeUsuario);

            var propriedadesDeAutenticacao = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddMinutes(30),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, propriedadesDeAutenticacao);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("LoginPage");
        }

        [Authorize]
        public IActionResult PageMain()
        {
            return RedirectToAction("BemVindo", "Home");
        }

      

    


    }
}