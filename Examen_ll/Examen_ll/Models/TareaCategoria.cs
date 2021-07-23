using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_ll.Models
{
    public class TareaCategoria
    {

        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Category")]
        [StringLength(70, ErrorMessage = "It should not be more than 70 characters.")]
        [MinLength(3, ErrorMessage = "It must have more than 3 characters.")]

        public string CategoriaNombre { get; set; }

        public IEnumerable<Tareas> Tareas { get; set; }
    }
}
