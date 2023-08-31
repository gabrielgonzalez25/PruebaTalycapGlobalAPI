using System.ComponentModel.DataAnnotations;

namespace PruebaTalycapGlobalAPI
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }

        [StringLength(20)]
        public string Nombres { get; set; } = string.Empty;

        [StringLength(20)]
        public string Apellidos { get; set; } = string.Empty;

        public int Celular { get; set; }

        [StringLength(20)]
        public string Correo { get; set; } = string.Empty;
    }
}
