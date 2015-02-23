using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MvcAppTesteP3Image.Models
{
    [DataContract]
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        public String Descricao { get; set; }

        [Required]
        [DataMember]
        public String Slug { get; set; }

        [DataMember]
        public int? CategoriaPaiId { get; set; }

        [ForeignKey("CategoriaPaiId")]
        [DataMember]
        public virtual Categoria CategoriaPai { get; set; }

        public virtual ICollection<Campo> Campos { get; set; }
    }
}