namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alumno")]
    public partial class Alumno
    {
        public Alumno()
        {
            Detalle_alumno_asignatura_ = new HashSet<Detalle_alumno_asignatura_>();
            Doc_Alumno = new HashSet<Doc_Alumno>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rut_alumno { get; set; }

        [Required]
        [StringLength(30)]
        public string nombres { get; set; }

        [Required]
        [StringLength(30)]
        public string apellidos { get; set; }

        public int telefono { get; set; }

        public int? telefono2 { get; set; }

        [Required]
        [StringLength(50)]
        public string direccion { get; set; }

        public bool estado_eliminado { get; set; }

        public virtual ICollection<Detalle_alumno_asignatura_> Detalle_alumno_asignatura_ { get; set; }

        public virtual ICollection<Doc_Alumno> Doc_Alumno { get; set; }
    }
}
