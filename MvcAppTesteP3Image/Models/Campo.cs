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
    [Table("Campos")]
    public class Campo
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        public int Ordem { get; set; }

        [Required]
        [DataMember]
        public String Descricao { get; set; }

        [Required]
        [DataMember]
        public String Tipo { get; set; }

        [DataMember]
        public String[] Lista
        {
            get
            {
                if (_Lista != null)
                    return _Lista.Split(';');

                return null;
            }
            set { _Lista = String.Join(";", value); }
        }

        public String _Lista
        {
            get;
            set;
        }

        [Required]
        public int? CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
    }
}