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
    public IActionResult recibirLogin(string username, string password){
        int id = BD.iniciarSesion(username, password);
        if(id!=0){
            HttpContext.Session.SetString("id", id.ToString());
           return RedirectToAction("Index", "listarTareas");
        } else{
            return RedirectToAction("login", "Account");
        }
    }

    public IActionResult cerrarSesion(){
        HttpContext.Session.SetString("id", 0.ToString());
        return View("login");
    }
    public IActionResult registrarse(){
        ViewBag.pude=true;
        return View("registrarse");
    }

    public IActionResult recibirRegistro(string username, string password, string nombre, string apellido, string foto){
        Usuario usuario=new Usuario(username, password, nombre, apellido, foto, DateTime.Now);
        if(BD.registrar(usuario)){
            return View("login");
        } else{
            ViewBag.pude=false;
            return View("registrarse");
        }
    }
}
