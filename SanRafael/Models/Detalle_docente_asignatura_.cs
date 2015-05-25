namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Detalle(docente-asignatura)")]
    public partial class Detalle_docente_asignatura_
    {
        [Key]
        public int id_detalle_docente_asignatura { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_termino { get; set; }

        public int id_asignatura_fk { get; set; }

        public int rut_docente_fk { get; set; }

        public int id_anio_semestre_fk { get; set; }

        public virtual Anio_Semestre Anio_Semestre { get; set; }

        public virtual Asignatura Asignatura { get; set; }

        public virtual Docente Docente { get; set; }
    }
}
