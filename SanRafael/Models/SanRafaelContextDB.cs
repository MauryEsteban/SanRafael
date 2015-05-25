namespace SanRafael.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SanRafaelContextDB : DbContext
    {
        public SanRafaelContextDB()
            : base("name=SanRafaelContextDB")
        {
        }

        public virtual DbSet<Alumno> Alumnoes { get; set; }
        public virtual DbSet<Anio_Semestre> Anio_Semestre { get; set; }
        public virtual DbSet<Asignatura> Asignaturas { get; set; }
        public virtual DbSet<Detalle_alumno_asignatura_> Detalle_alumno_asignatura_ { get; set; }
        public virtual DbSet<Detalle_docente_asignatura_> Detalle_docente_asignatura_ { get; set; }
        public virtual DbSet<Doc_Alumno> Doc_Alumno { get; set; }
        public virtual DbSet<Doc_Asignatura> Doc_Asignatura { get; set; }
        public virtual DbSet<Docente> Docentes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tipo_Doc_Alumno> Tipo_Doc_Alumno { get; set; }
        public virtual DbSet<Tipo_Doc_Asignatura> Tipo_Doc_Asignatura { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .Property(e => e.nombres)
                .IsFixedLength();

            modelBuilder.Entity<Alumno>()
                .Property(e => e.apellidos)
                .IsFixedLength();

            modelBuilder.Entity<Alumno>()
                .Property(e => e.direccion)
                .IsFixedLength();

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Detalle_alumno_asignatura_)
                .WithRequired(e => e.Alumno)
                .HasForeignKey(e => e.rut_alumno_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Doc_Alumno)
                .WithRequired(e => e.Alumno)
                .HasForeignKey(e => e.rut_alumno_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Anio_Semestre>()
                .HasMany(e => e.Detalle_alumno_asignatura_)
                .WithRequired(e => e.Anio_Semestre)
                .HasForeignKey(e => e.id_anio_semestre_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Anio_Semestre>()
                .HasMany(e => e.Detalle_docente_asignatura_)
                .WithRequired(e => e.Anio_Semestre)
                .HasForeignKey(e => e.id_anio_semestre_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Asignatura>()
                .Property(e => e.nombre_asignatura)
                .IsFixedLength();

            modelBuilder.Entity<Asignatura>()
                .Property(e => e.observacion)
                .IsFixedLength();

            modelBuilder.Entity<Asignatura>()
                .HasMany(e => e.Detalle_alumno_asignatura_)
                .WithRequired(e => e.Asignatura)
                .HasForeignKey(e => e.id_asignatura_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Asignatura>()
                .HasMany(e => e.Detalle_docente_asignatura_)
                .WithRequired(e => e.Asignatura)
                .HasForeignKey(e => e.id_asignatura_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Asignatura>()
                .HasMany(e => e.Doc_Asignatura)
                .WithRequired(e => e.Asignatura)
                .HasForeignKey(e => e.id_asignatura_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doc_Alumno>()
                .Property(e => e.observacion)
                .IsFixedLength();

            modelBuilder.Entity<Doc_Alumno>()
                .Property(e => e.path)
                .IsFixedLength();

            modelBuilder.Entity<Doc_Asignatura>()
                .Property(e => e.observacion)
                .IsFixedLength();

            modelBuilder.Entity<Doc_Asignatura>()
                .Property(e => e.path)
                .IsFixedLength();

            modelBuilder.Entity<Docente>()
                .Property(e => e.nombres)
                .IsFixedLength();

            modelBuilder.Entity<Docente>()
                .Property(e => e.apellidos)
                .IsFixedLength();

            modelBuilder.Entity<Docente>()
                .Property(e => e.direccion)
                .IsFixedLength();

            modelBuilder.Entity<Docente>()
                .Property(e => e.especialidad)
                .IsFixedLength();

            modelBuilder.Entity<Docente>()
                .Property(e => e.contrasena)
                .IsFixedLength();

            modelBuilder.Entity<Docente>()
                .HasMany(e => e.Detalle_docente_asignatura_)
                .WithRequired(e => e.Docente)
                .HasForeignKey(e => e.rut_docente_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Doc_Alumno>()
                .Property(e => e.nombre)
                .IsFixedLength();

            modelBuilder.Entity<Tipo_Doc_Alumno>()
                .HasMany(e => e.Doc_Alumno)
                .WithRequired(e => e.Tipo_Doc_Alumno)
                .HasForeignKey(e => e.id_tipo_doc_alumno_fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Doc_Asignatura>()
                .Property(e => e.nombre)
                .IsFixedLength();

            modelBuilder.Entity<Tipo_Doc_Asignatura>()
                .HasMany(e => e.Doc_Asignatura)
                .WithRequired(e => e.Tipo_Doc_Asignatura)
                .HasForeignKey(e => e.id_tipo_doc_asignatura_fk)
                .WillCascadeOnDelete(false);
        }
    }
}
