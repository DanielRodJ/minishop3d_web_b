using Domain.Common.Entities;

namespace Domain.Enums
{
    public sealed record EstadoPublicacionCatalogo : BaseCatalogo<EstadoProductoCatalogo>
    {
        public EstadoPublicacionCatalogo(string codigo, string nombre, int numero) 
            : base(codigo, nombre, numero) { }

        public static readonly EstadoPublicacionCatalogo Activa = new("ACT", "Activa", 1);
        public static readonly EstadoPublicacionCatalogo Inactiva = new("INA", "Inactiva", 2);
        public static readonly EstadoPublicacionCatalogo Borrador = new("BOR", "Borrador", 3);
    }
}