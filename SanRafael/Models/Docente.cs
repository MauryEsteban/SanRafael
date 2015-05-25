namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Docente")]
    public partial class Docente
    {
        public Docente()
        {
            Detalle_docente_asignatura_ = new HashSet<Detalle_docente_asignatura_>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rut_docente { get; set; }

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

        [StringLength(40)]
        public string especialidad { get; set; }

        [Required]
        [StringLength(20)]
        public string contrasena { get; set; }

        public bool estado_eliminado { get; set; }

        public virtual ICollection<Detalle_docente_asignatura_> Detalle_docente_asignatura_ { get; set; }
    }
}
