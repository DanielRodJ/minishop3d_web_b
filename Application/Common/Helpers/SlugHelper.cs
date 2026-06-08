
namespace Application.Common.Helpers
{
    public class SlugHelper
    {
        public static string Generate(string texto)
        {
            texto = texto.ToLowerInvariant();

            texto = texto.Normalize(System.Text.NormalizationForm.FormD);
            var chars = texto.Where(c => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark);
            texto = new string(chars.ToArray());

            texto = System.Text.RegularExpressions.Regex.Replace(texto, @"[^a-z0-9\s-]", "");
            texto = System.Text.RegularExpressions.Regex.Replace(texto, @"\s+", "-").Trim('-');

            return texto;
        }
    }
}