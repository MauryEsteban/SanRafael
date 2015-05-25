namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Anio_Semestre
    {
        public Anio_Semestre()
        {
            Detalle_alumno_asignatura_ = new HashSet<Detalle_alumno_asignatura_>();
            Detalle_docente_asignatura_ = new HashSet<Detalle_docente_asignatura_>();
        }

        [Key]
        public int id_anio_semestre { get; set; }

        public int anio { get; set; }

        public int semestre { get; set; }

        public virtual ICollection<Detalle_alumno_asignatura_> Detalle_alumno_asignatura_ { get; set; }

        public virtual ICollection<Detalle_docente_asignatura_> Detalle_docente_asignatura_ { get; set; }
    }
}
