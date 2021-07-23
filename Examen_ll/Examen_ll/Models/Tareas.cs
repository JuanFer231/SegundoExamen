using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_ll.Models
{
    public class Tareas
    {

        [Key]
        public int TareaId { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        
        public DateTime FechaDeInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Final date")]

        public DateTime FechaFinal { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Tittle")]
        [StringLength(70, ErrorMessage = "It should not be more than 70 characters.")]
        [MinLength(3, ErrorMessage = "It must have more than 3 characters.")]

        public string Titulo { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Description")]
        [StringLength(5000, ErrorMessage = "It should not be more than 5000 characters.")]
        [MinLength(3, ErrorMessage = "It must have more than 3 characters.")]

        public string Descripcion { get; set; }

        [Display(Name = "Category")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]

        [Display(Name = "Category")]
        public TareaCategoria Tarea { get; set; }
    }
}
