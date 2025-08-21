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
    public IActionResult crearTareaGuardar(string titulo, string descripcion, DateOnly fecha, bool finalizada){
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
        ViewBag.titulo=tarea.titulo;
        ViewBag.descripcion=tarea.descripcion;
        ViewBag.fecha=tarea.fecha;
        ViewBag.finalizada=tarea.finalizada;
        ViewBag.idUsuario=tarea.idUsuario;
        return View("editarTarea");
    }
/*    public IActionResult editarTareaGuardar(string pTitulo, string pDescripcion, DateOnly pFecha, bool pFinalizada, int pIdUsuario)
    {
        int id= int.Parse(HttpContext.Session.GetString("id"));
        Tarea tarea= new Tarea(pTitulo ,pDescripcion, pFecha,pFinalizada, pIdUsuario);
        BD.actualizarTarea(tarea);
    } 
*/
}
