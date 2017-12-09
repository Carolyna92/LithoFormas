using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LithoFormas
{
    public class litho
    {
        string id;
        int n_titulo;
        string titulo;
        string descripcion;
        string asignada;
        string nombre_persona;
        DateTime fecha_entrega;
        int n_dependencia;
        string dependencia;
        int prioridad;
        int status;
        bool deleted;

        //[MaxLength(8), PrimaryKey, Unique]
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty(PropertyName = "n_titulo")]
        public int N_Titulo
        {
            get { return n_titulo; }
            set { n_titulo = value; }
        }
        [JsonProperty(PropertyName = "titulo")]
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        [JsonProperty(PropertyName = "asignada")]
        public string Asignada
        {
            get { return asignada; }
            set { asignada = value; }
        }
        [JsonProperty(PropertyName = "nombre_persona")]
        public string Nombre_Persona
        {
            get { return nombre_persona; }
            set { nombre_persona = value; }
        }
        [JsonProperty(PropertyName = "fecha_entrega")]
        public DateTime Fecha_Entrega
        {
            get { return fecha_entrega; }
            set { fecha_entrega = value; }
        }
        [JsonProperty(PropertyName = "n_dependencia")]
        public int N_Dependencia
        {
            get { return n_dependencia; }
            set { n_dependencia = value; }
        }
        [JsonProperty(PropertyName = "dependencia")]
        public string Dependencia
        {
            get { return dependencia; }
            set { dependencia = value; }
        }

        [JsonProperty(PropertyName = "prioridad")]
        public int Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        [JsonProperty(PropertyName = "status")]
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
