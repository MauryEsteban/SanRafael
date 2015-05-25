namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Doc_Alumno
    {
        [Key]
        public int id_doc_alumno { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        [StringLength(500)]
        public string observacion { get; set; }

        [Required]
        [StringLength(100)]
        public string path { get; set; }

        public bool estado_eliminado { get; set; }

        public int rut_alumno_fk { get; set; }

        public int id_tipo_doc_alumno_fk { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Tipo_Doc_Alumno Tipo_Doc_Alumno { get; set; }
    }
}
