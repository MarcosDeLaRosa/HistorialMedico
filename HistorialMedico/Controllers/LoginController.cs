﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HistorialMedico.Models;

namespace HistorialMedico.Controllers
{
    public class LoginController : Controller
    {

        private HistoricoMedicoContext db = new HistoricoMedicoContext();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string user, string password) {
            if (user != null && password != null)
            {

                usuario usuario = db.usuario.Where(e => e.usuario1 == user).FirstOrDefault();
                if (usuario.usuario1 == user && usuario.contrasena == password) {
                    if (usuario.roles == "doctor") {
                        return RedirectToAction("Index","Doctor");
                    }
                    else if (usuario.roles == "asistente")
                    {
                        return RedirectToAction("Index","asistentes");
                    }
                }
            }
            else {
                return View("Error");
            }

            return View();
        }

        public ActionResult Error() {

            return View("Login");
        }

    }
}