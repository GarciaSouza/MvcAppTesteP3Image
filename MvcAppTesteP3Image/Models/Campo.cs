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

        [DataMember]
        public uint Ordem { get; set; }

        [DataMember]
        public String Descricao { get; set; }

        [DataMember]
        public String Tipo { get; set; }

        [DataMember]
        public String[] Lista { get; set; }

        [DataMember]
        public int? CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        [DataMember]
        public virtual Categoria Categoria { get; set; }
    }
}