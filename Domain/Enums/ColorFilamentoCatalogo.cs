using Domain.Common.Entities;

namespace Domain.Enums
{
    public sealed record ColorFilamentoCatalogo : BaseCatalogo<ColorFilamentoCatalogo>
    {
        private ColorFilamentoCatalogo(string codigo, string nombre, int numero) : base(codigo, nombre, numero) { }

        public static readonly ColorFilamentoCatalogo Negro = new("BLK", "Negro Mate", 1);
        public static readonly ColorFilamentoCatalogo Blanco = new("WHT", "Blanco Mate", 2);
        public static readonly ColorFilamentoCatalogo Gris = new("GRY", "Gris Mate", 3);
        public static readonly ColorFilamentoCatalogo Beige = new("BGE", "Beige Mate", 4);
    }
}