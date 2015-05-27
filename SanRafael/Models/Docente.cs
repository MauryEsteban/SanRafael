namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Rut")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("[0-9]{7,8}[0-9kK]{1}", ErrorMessage = "Min. 8 y Max. 9 caracteres, solo números y letra 'k'.")]
        public int rut_docente { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(30)]
        [DisplayName("Nombres")]
        [RegularExpression("[a-zA-Záéíóúñ ]{1,20}", ErrorMessage = "Min. 1 y Max. 20 caracteres, solo letras.")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(30)]
        [DisplayName("Apellidos")]
        [RegularExpression("[a-zA-Záéíóúñ ]{1,30}", ErrorMessage = "Min. 1 y Max. 30 caracteres, solo letras.")]
        public string apellidos { get; set; }

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("[0-9]{1,10}", ErrorMessage = "Min. 1 y Max. 10 caracteres, solo números.")]
        public int telefono { get; set; }

        [DisplayName("Teléfono2 (opcional)")]
        [RegularExpression("[0-9]{0,10}", ErrorMessage = "Min. 0 y Max. 10 caracteres, solo números.")]
        public int? telefono2 { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50)]
        [DisplayName("Dirección")]
        [RegularExpression("[0-9a-zA-Záéíóúñ,.# ]{1,80}", ErrorMessage = "Min. 1 y Max. 80 caracteres.")]
        public string direccion { get; set; }

        [StringLength(40)]
        [DisplayName("Especialidad")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("[a-zA-Záéíóúñ ]{1,40}", ErrorMessage = "Min. 1 y Max. 40 caracteres, solo letras.")]
        public string especialidad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(20)]
        [DisplayName("Contraseña")]
        [RegularExpression("[a-zA-Záéíóúñ ]{1,20}", ErrorMessage = "Min. 1 y Max. 20 caracteres, solo letras.")]
        public string contrasena { get; set; }

        [DisplayName("Deshabilitado")]
        public bool estado_eliminado { get; set; }

        public virtual ICollection<Detalle_docente_asignatura_> Detalle_docente_asignatura_ { get; set; }
    }
}
