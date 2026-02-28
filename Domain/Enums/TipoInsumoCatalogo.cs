using Domain.Common.Entities;

namespace Domain.Enums
{
    public sealed record TipoInsumoCatalogo : BaseCatalogo<TipoInsumoCatalogo>
    {
        private TipoInsumoCatalogo(string codigo, string nombre, int numero) : base(codigo, nombre, numero) { }

        public static readonly TipoInsumoCatalogo FilamentoPLA = new("PLA", "Filamento PLA 1.75mm", 1);
        public static readonly TipoInsumoCatalogo ResinaStandard = new("RES-STD", "Resina Estándar UV", 2);
    }
}