using Domain.Common.Entities;

namespace Domain.Enums
{
    public sealed record EscalaCatalogo : BaseCatalogo<EscalaCatalogo>
    {
        private EscalaCatalogo(string codigo, string nombre, int numero) : base(codigo, nombre, numero) { }

        public static readonly EscalaCatalogo Wargame = new("32MM", "Escala 32mm (Wargame)", 1);
        public static readonly EscalaCatalogo Coleccionista = new("75MM", "Escala 75mm (Coleccionista)", 2);
        public static readonly EscalaCatalogo Busto = new("BST", "Busto", 3);
    }
}