namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Asignatura")]
    public partial class Asignatura
    {
        public Asignatura()
        {
            Detalle_alumno_asignatura_ = new HashSet<Detalle_alumno_asignatura_>();
            Detalle_docente_asignatura_ = new HashSet<Detalle_docente_asignatura_>();
            Doc_Asignatura = new HashSet<Doc_Asignatura>();
        }

        [Key]
        public int id_asignatura { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre_asignatura { get; set; }

        [StringLength(500)]
        public string observacion { get; set; }

        public bool estado_eliminado { get; set; }

        public virtual ICollection<Detalle_alumno_asignatura_> Detalle_alumno_asignatura_ { get; set; }

        public virtual ICollection<Detalle_docente_asignatura_> Detalle_docente_asignatura_ { get; set; }

        public virtual ICollection<Doc_Asignatura> Doc_Asignatura { get; set; }
    }
}
