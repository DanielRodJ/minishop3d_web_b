using System.Reflection;

namespace Domain.Common.Entities
{
    public abstract record BaseCatalogo<T> where T : BaseCatalogo<T>
    {
        public string Codigo { get; init; }
        public string Nombre { get; init; }
        public int Numero { get; init; }

        protected BaseCatalogo(string codigo, string nombre, int numero)
        {
            Codigo = codigo;
            Nombre = nombre;
            Numero = numero;
        }

        // Obtiene automáticamente todos los elementos estáticos definidos en la clase hija
        private static readonly Lazy<IReadOnlyList<T>> _values = new(() =>
            typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>()
                .ToList()
                .AsReadOnly());

        public static IReadOnlyList<T> List => _values.Value;

        public static T? FromCodigo(string codigo) =>
            List.FirstOrDefault(s => string.Equals(s.Codigo, codigo, StringComparison.OrdinalIgnoreCase));

        public static T? FromNumero(int numero) =>
            List.FirstOrDefault(s => s.Numero == numero);

        public override string ToString() => Nombre;
    }
}