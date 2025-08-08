using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
public class Usuario{

    public Usuario(){
    }
    public Usuario(string pUsername, string pPassword, string pNombre, string pApellido, string pFoto, DateTime pUltimoLogin){
      username=pUsername;
      password=pPassword;
      nombre=pNombre;
      apellido=pApellido;
      foto=pFoto;
      ultimoLogin=pUltimoLogin;
    }
    [JsonProperty]
    public int id{ get; private set;}
    public string username{ get; private set;}
    public string password{ get; private set;}
    public string nombre{ get; private set;}
    public string apellido { get; private set;}
    public string foto{ get; private set;}
    public DateTime ultimoLogin{ get; private set;}

}
