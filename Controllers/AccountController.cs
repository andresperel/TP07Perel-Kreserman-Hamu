using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07Perel_Kreserman_Hamu.Models;

namespace TP07Perel_Kreserman_Hamu.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    public IActionResult login(){
        return View("loginForm");
    }
    [HttpPost]
    public IActionResult recibirLogin(string username, string password){
        if(username!=null && password!=null)
        {
            Usuario usuario = (BD.iniciarSesion(username, password));
            if(usuario!=null){
                HttpContext.Session.SetString("id", usuario.id.ToString());
            return RedirectToAction("listarTareas", "Home");
            } else{
                return RedirectToAction("login", "Account");
            }
        } else{return RedirectToAction("login", "Account");}
    }

    public IActionResult cerrarSesion(){
        HttpContext.Session.SetString("id", 0.ToString());
        return View("loginForm");
    }
    public IActionResult registrarse(){
        return View("registrarse");
    }

    public IActionResult recibirRegistro(string username, string password, string nombre, string apellido, string foto){
        if(username!=null && password!=null && nombre!=null && apellido!=null && foto!=null){
            Usuario usuario=new Usuario(username, password, nombre, apellido, foto, DateTime.Now);
            BD.registrar(usuario);
            return View("loginForm");
        } else{
            return View("registrarse");
        }
    }
}
