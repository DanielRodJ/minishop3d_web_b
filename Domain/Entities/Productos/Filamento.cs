
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Productos
{
    public class Filamento
    {
        public long FilamentoId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string TipoMaterial { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Acabado { get; set; } = string.Empty;
        public decimal PrecioPorKg { get; set; }
        [NotMapped]
        public decimal PrecioPorGramo => PrecioPorKg / 1000m;
        public bool Activo { get; set; } = true;
    }
}