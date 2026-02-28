using Domain.Common.Entities;

namespace Domain.Enums
{
    public sealed record EstadoProductoCatalogo : BaseCatalogo<EstadoProductoCatalogo>
    {
        private EstadoProductoCatalogo(string codigo, string nombre, int numero) : base(codigo, nombre, numero) { }

        public static readonly EstadoProductoCatalogo Disponible = new("DISP", "Disponible", 1);
        public static readonly EstadoProductoCatalogo Agotado = new("AGOT", "Agotado", 2);
        public static readonly EstadoProductoCatalogo BajoPedido = new("ON_D", "Bajo Petición", 3);
        public static readonly EstadoProductoCatalogo InactivoTemporal = new("INACT", "Inactivo Temporalmente", 4);
        public static readonly EstadoProductoCatalogo NoDisponible = new("NO_DISP", "No Disponible", 5);
    }
}