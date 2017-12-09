using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LithoFormas
{
    public class autenticados
    {
        string id;
        string user_id;
        int rol;
        string nombre;
        bool deleted;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty(PropertyName = "user_id")]
        public string User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        [JsonProperty(PropertyName = "rol")]
        public int Rol
        {
            get { return rol; }
            set { rol = value; }
        }
        [JsonProperty(PropertyName = "nombre")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
