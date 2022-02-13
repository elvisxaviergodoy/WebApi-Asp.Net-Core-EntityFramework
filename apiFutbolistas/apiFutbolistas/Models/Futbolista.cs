using System;
using System.Collections.Generic;
//libreria para la PK
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiFutbolistas.Models
{
    public class Futbolista
    {
        /*Agregamos todos los campos de la tabla futbolistas*/
        [Key]/*Importamos la libreria(System.ComponentModel.DataAnnotations) para indicar que esta es la PK*/
        //los nombres tienen que coincidir con los que esta en la bd
        public int id { get; set; }
        public string nombre { get; set; }
        public string posicion { get; set; }
        public string nacionalidad { get; set; }
        public string imagen { get; set; }
    }
}
