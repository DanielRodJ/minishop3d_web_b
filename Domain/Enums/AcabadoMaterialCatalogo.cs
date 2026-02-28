using Domain.Common.Entities;

namespace Domain.Enums
{
    public sealed record AcabadoMaterialCatalogo : BaseCatalogo<AcabadoMaterialCatalogo>
    {
        private AcabadoMaterialCatalogo(string codigo, string nombre, int numero) : base(codigo, nombre, numero) { }

        public static readonly AcabadoMaterialCatalogo Matte = new("MAT", "Matte / Mate", 1);
        public static readonly AcabadoMaterialCatalogo Silk = new("SLK", "Silk / Seda", 2);
        public static readonly AcabadoMaterialCatalogo Glossy = new("GLS", "Brillante", 3);
        public static readonly AcabadoMaterialCatalogo Translucido = new("TRN", "Translúcido", 4);
    }
}