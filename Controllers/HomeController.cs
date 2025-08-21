using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07Perel_Kreserman_Hamu.Models;

namespace TP07Perel_Kreserman_Hamu.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return RedirectToAction("login", "Account");
    }

    public IActionResult listarTareas()
    {
        int id= int.Parse(HttpContext.Session.GetString("id"));
        ViewBag.listaTareas=BD.listarTareas(id);
        return View("listarTareas");
    }

    public IActionResult crearTarea(){
        return View("crearTarea");
    }
    
    [HttpPost]
    public IActionResult crearTareaGuardar(string titulo, string descripcion, DateTime fecha, bool finalizada){
        int id= int.Parse(HttpContext.Session.GetString("id"));
        Tarea tarea= new Tarea(titulo ,descripcion, fecha, finalizada, id);
        BD.crearTarea(tarea, id);
        return RedirectToAction("listarTareas", "Home");
    }

    public IActionResult finalizarTarea(int idTarea){
        BD.finalizarTarea(idTarea);
        return RedirectToAction("listarTareas", "Home");
    }

    public IActionResult eliminarTarea(int idTarea){
        BD.eliminarTarea(idTarea);
        return RedirectToAction("listarTareas", "Home");
    }
    public IActionResult editarTarea(int idTarea){
        Tarea tarea=BD.traerTareaACambiar(idTarea);
        ViewBag.tarea=tarea;
        return View("editarTarea");
    }
    public IActionResult editarTareaGuardar(int idTarea, string titulo, string descripcion, DateTime fecha, bool finalizo, int idUsuario)
    {
        int id= int.Parse(HttpContext.Session.GetString("id"));
        Tarea tarea= new Tarea(titulo ,descripcion, fecha,finalizo, idTarea);
        BD.actualizarTarea(tarea);
        return RedirectToAction("listarTareas", "Home");
    } 
}
