using Microsoft.Data.SqlClient;
using Dapper;
public class BD
{
    private static string _connectionString = @"Server=localhost; 
    DataBase = TP07_KresermanHamuPerel; Integrated Security=True; TrustServerCertificate=True;";

    public static int iniciarSesion(string username, string password)
    {
        Usuario usuario = new Usuario();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM usuarios WHERE username = @username AND password = @password ";
            usuario = connection.QueryFirstOrDefault<Usuario>(query, new { username, password });

        }
        return usuario.id;
    }

    public static bool registrar(Usuario usuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            bool sePudo = false;
            
            if (usuario!= null)
            {

                string query2 = "INSERT INTO  usuarios (username,password,nombre,apellido,foto,ultimoLogin) VALUES (@username,@password,@nombre,@apellido,@foto,@ultimoLogin)";
                usuario = connection.QueryFirstOrDefault<Usuario>(query2, new { username = usuario.username, password = usuario.password,nombre=usuario.nombre,apellido=usuario.apellido,foto=usuario.foto,ultimoLogin=usuario.ultimoLogin });

                sePudo = true;
            }

            return sePudo;

        }
    }
    
        public static List<Tarea> listarTareas(int idUsuario)
        {
            List<Tarea> listTareas = new List<Tarea>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Tareas WHERE idUsuario = @idUsuario";
                listTareas = connection.Query<Tarea>(query, new { idUsuario }).ToList();
                

            }
            return listTareas;
        }
        public static void crearTarea(Tarea tarea, int idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Tareas (titulo,descripcion,fecha,finalizada,idUsuario)  VALUES (@titulo,@descripcion,@fecha,@finalizada,@idUsuario)";
                tarea = connection.QueryFirstOrDefault<Tarea>(query, new { titulo=tarea.titulo , descripcion= tarea.titulo ,fecha = tarea.fecha ,finalizada = tarea.finalizada,idUsuario = tarea.idUsuario});
            }
        }
        public static void eliminarTarea(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Tareas WHERE id = @id";
                connection.QueryFirstOrDefault<Tarea>(query, new { id });

            }
        }
        public static Tarea traerTareaACambiar(int id)
        {
            Tarea tarea = new Tarea();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Tareas WHERE id = @id";
                tarea = connection.QueryFirstOrDefault<Tarea>(query, new { id });

            }
            return tarea;
        }
        public static void actualizarTarea(int idTarea, string titulo, string descripcion, DateTime fecha)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Tareas SET titulo = @titulo, descripcion=@descripcion, fecha = @fechaWHERE id = @idTarea";
                connection.QueryFirstOrDefault<Tarea>(query, new {idTarea, titulo, descripcion, fecha});

            }
        }
        public static void finalizarTarea(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Tareas SET finalizada = 1 WHERE id = @id";
                connection.QueryFirstOrDefault<Tarea>(query, new {id});

            }
        }
        public static void cambiarFechaLogin(string id)
        {
            Tarea tarea = new Tarea();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Tareas SET fecha = DateTime.Now() WHERE id = @id  ";
                tarea = connection.QueryFirstOrDefault<Tarea>(query, new {tarea.id});
                
            }
        }



    }