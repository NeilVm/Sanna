using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCrypt.Net;

namespace registrosanna.Models
{
    [Table("registro")]
    public class Registro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [Column("apepater")]
        public string ApellidoPaterno { get; set; }

        [Column("apemater")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [Column("sexo")]
        public string sexo { get; set; }

        [Required]
        [Column("contrasena")]
        public string ContrasenaHash { get; set; }

        [NotMapped]
        public string ConfirmarContrasena { get; set; }

        [Required]
        [Column("tipodoc")]
        public string TipoDocumento { get; set; }

        [Required]
        [Column("documento")]
        public string Documento { get; set; }

        [Required]
        [Column("plansalud")]
        public string PlanSalud { get; set; }

        public bool VerificarContrasena(string contrasena)
        {
            return BCrypt.Net.BCrypt.Verify(contrasena, ContrasenaHash);
        }
    }
}
