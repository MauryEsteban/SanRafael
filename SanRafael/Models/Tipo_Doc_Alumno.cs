namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipo_Doc_Alumno
    {
        public Tipo_Doc_Alumno()
        {
            Doc_Alumno = new HashSet<Doc_Alumno>();
        }

        [Key]
        public int id_tipo_doc_alumno { get; set; }

        [Required]
        [StringLength(20)]
        public string nombre { get; set; }

        public virtual ICollection<Doc_Alumno> Doc_Alumno { get; set; }
    }
}
