﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PruebaTalycapGlobalAPI
{
    public class LogisticaTerrestre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número debe tener 10 dígitos numéricos.")]
        public int NumeroGuia { get; set; }
        public int IdCliente { get; set; }

        [StringLength(20)]
        public string TipoProducto { get; set; } = string.Empty;

        public int CantidadProducto { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime FechaEntrega { get; set; }
        [AllowNull]
        public double PrecioEnvio { get; set; }
        [AllowNull]
        public double PrecioEnvioNormal { get; set; }
        [AllowNull]
        public double Descuento { get; set; }

        [RegularExpression(@"^[A-Za-z]{3}\d{3}$", ErrorMessage = "El formato no es válido. Debe ser 3 letras seguidas de 3 números.")]
        public string PlacaVehiculo { get; set; } = string.Empty;
    }
}
