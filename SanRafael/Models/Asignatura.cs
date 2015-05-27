namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Código")]
        public int id_asignatura { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(30)]
        [DisplayName("Nombre")]
        [RegularExpression("[a-zA-Záéíóúñ ]{1,30}", ErrorMessage = "Min. 1 y Max. 30 caracteres, solo letras.")]
        public string nombre_asignatura { get; set; }

        [StringLength(500)]
        [DisplayName("Observacion")]
        [RegularExpression("[a-zA-Záéíóúñ0-9 ]{1,500}", ErrorMessage = "Min. 1 y Max. 500 caracteres.")]
        public string observacion { get; set; }

        [DisplayName("Deshabilitada")]
        public bool estado_eliminado { get; set; }

        public virtual ICollection<Detalle_alumno_asignatura_> Detalle_alumno_asignatura_ { get; set; }

        public virtual ICollection<Detalle_docente_asignatura_> Detalle_docente_asignatura_ { get; set; }

        public virtual ICollection<Doc_Asignatura> Doc_Asignatura { get; set; }
    }
}
