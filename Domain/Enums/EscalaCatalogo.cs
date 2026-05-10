using Domain.Common.Entities;

namespace Domain.Enums
{
    public sealed record EscalaCatalogo : BaseCatalogo<EscalaCatalogo>
    {
        private EscalaCatalogo(string codigo, string nombre, int numero)
            : base(codigo, nombre, numero) { }

        public static readonly EscalaCatalogo Heroic28mm = new("Heroic28mm", "Heroic Scale (28–32 mm)", 1);
        public static readonly EscalaCatalogo Display75mm = new("Display75mm", "Display Scale (70–75 mm)", 2);
    }
}