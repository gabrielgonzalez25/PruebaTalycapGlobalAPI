using System.ComponentModel.DataAnnotations;

namespace PruebaTalycapGlobalAPI
{
    public class EnviosModel
    {
        [Key]
        public int IdEnvio { get; set; }

        public int IdCliente { get; set; }

        [StringLength(10)]
        public int NumeroGuia { get; set; }

    }
}
