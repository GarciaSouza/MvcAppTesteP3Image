using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcAppTesteP3Image.Models
{
    public class P3ImageContext : DbContext
    {
        public P3ImageContext()
            : base("P3Image_Dev")
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }

        public virtual DbSet<Campo> Campos { get; set; }
    }
}