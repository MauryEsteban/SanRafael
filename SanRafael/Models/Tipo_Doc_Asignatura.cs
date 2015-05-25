namespace SanRafael.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipo_Doc_Asignatura
    {
        public Tipo_Doc_Asignatura()
        {
            Doc_Asignatura = new HashSet<Doc_Asignatura>();
        }

        [Key]
        public int id_tipo_doc_asignatura { get; set; }

        [Required]
        [StringLength(20)]
        public string nombre { get; set; }

        public virtual ICollection<Doc_Asignatura> Doc_Asignatura { get; set; }
    }
}
