namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Doc_Asignatura
    {
        [Key]
        public int id_doc_asignatura { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Fecha")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime fecha { get; set; }

        [StringLength(500)]
        [DisplayName("Observacion")]
        [RegularExpression("[a-zA-Zαινσϊρ0-9 ]{1,500}", ErrorMessage = "Min. 1 y Max. 500 caracteres.")]
        public string observacion { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Ruta")]
        public string path { get; set; }

        public bool estado_eliminado { get; set; }

        [DisplayName("Asignatura")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int id_asignatura_fk { get; set; }

        [DisplayName("Tipo Documento")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int id_tipo_doc_asignatura_fk { get; set; }

        public virtual Asignatura Asignatura { get; set; }

        public virtual Tipo_Doc_Asignatura Tipo_Doc_Asignatura { get; set; }
    }
}
