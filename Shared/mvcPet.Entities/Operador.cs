using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;


namespace mvcPet.Entities
{
    public partial class Operador : IEntity
    {
        [Browsable(false)]
        public int Id { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Telefono { get; set; }
        [DataType(DataType.Url)]
        public string Url { get; set; }
        [Required]
        [Range(18,99,ErrorMessage = "La edad debe ser entre 18 y 99 años")]
        public int Edad { get; set; }
        [Required]
        public string Domicilio { get; set; }
    }
}
