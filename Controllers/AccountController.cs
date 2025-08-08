using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07Perel_Kreserman_Hamu.Models;

namespace TP07Perel_Kreserman_Hamu.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    public IActionResult login(){
        ViewBag.existe=true;
        return View("loginForm");
    }
    public IActionResult recibirLogin(string username, string password){
        if(BD.iniciarSesion(username, password)!=0){
            /*setear id en session*/
           return RedirectToAction("Index", "listarTareas");
        } else{
            ViewBag.existe=false;
            return RedirectToAction("login", "Account");
        }
    }

    public IActionResult registrarse(){
        ViewBag.pude=true;
        return View("registrarse");
    }

    public IActionResult recibirRegistro(string username, string password, string nombre, string apellido, string foto){
        Usuario usuario=new Usuario(username, password, nombre, apellido, foto, DateTime.Now);
        if(BD.registrar(usuario)){
            /*setear id en session*/
            return View("listarTareas");
        } else{
            ViewBag.pude=false;
            return View("registrarse");
        }
    }
}
