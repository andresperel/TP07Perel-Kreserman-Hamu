using Microsoft.Data.SqlClient;
public class Tarea
{

    public Tarea()
    {

    }
    public Tarea(string pTitulo, string pDescripcion, DateTime pFecha, bool pFinalizada, int pIdUsuario)
    {
        titulo = pTitulo;
        descripcion = pDescripcion;
        fecha = pFecha;
        finalizada = pFinalizada;
        idUsuario = pIdUsuario;
    }
    public Tarea(int pId, string pTitulo, string pDescripcion, DateTime pFecha, bool pFinalizada, int pIdUsuario)
    {
        id=pId;
        titulo = pTitulo;
        descripcion = pDescripcion;
        fecha = pFecha;
        finalizada = pFinalizada;
        idUsuario = pIdUsuario;
    }
    public int id { get; private set; }
    public string titulo { get; private set; }
    public string descripcion { get; private set; }
    public DateTime fecha { get; private set; }
    public bool finalizada { get; private set; }
    public int idUsuario { get; private set; }

    public DateOnly sacarFecha()
    {
        return DateOnly.FromDateTime(DateTime.Now);
    }
}
