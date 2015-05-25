namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Rut")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("[0-9]{7,8}[0-9kK]{1}", ErrorMessage = "Min. 8 y Max. 9 caracteres, solo n�meros y letra 'k'.")]
        public int rut_alumno { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(30)]
        [DisplayName("Nombre")]
        [RegularExpression("[a-zA-Z������]{1,20}", ErrorMessage = "Min. 1 y Max. 20 caracteres, solo letras.")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(30)]
        [DisplayName("Apellidos")]
        [RegularExpression("[a-zA-Z������ ]{1,30}", ErrorMessage = "Min. 1 y Max. 30 caracteres, solo letras.")]
        public string apellidos { get; set; }

        [DisplayName("Tel�fono")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("[0-9]{1,10}", ErrorMessage = "Min. 1 y Max. 10 caracteres, solo n�meros.")]
        public int telefono { get; set; }

        [DisplayName("Tel�fono2 (opcional)")]
        [RegularExpression("[0-9]{0,10}", ErrorMessage = "Min. 0 y Max. 10 caracteres, solo n�meros.")]
        public int? telefono2 { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50)]
        [DisplayName("Direcci�n")]
        [RegularExpression("[0-9a-zA-Z������,.# ]{1,80}", ErrorMessage = "Min. 1 y Max. 80 caracteres.")]
        public string direccion { get; set; }

        public bool estado_eliminado { get; set; }

        public virtual ICollection<Detalle_alumno_asignatura_> Detalle_alumno_asignatura_ { get; set; }

        public virtual ICollection<Doc_Alumno> Doc_Alumno { get; set; }
    }
}
