using System.Text;
using System.Text.RegularExpressions;

namespace Astrolabio_Recaster.Services
{
    public class StatParser
    {
        public List<string> ParseStats(string ocrText)
        {
            var result = new List<string>();

            if (string.IsNullOrWhiteSpace(ocrText))
                return result;

            string normalized = NormalizeText(ocrText);

            // Insere separadores antes de "guia" e "destino"
            normalized = Regex.Replace(normalized, @"(?=guia|destino)", "|");

            var parts = normalized
                .Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .ToList();

            foreach (var part in parts)
            {
                string stat = DetectStat(part);
                if (!string.IsNullOrWhiteSpace(stat))
                    result.Add(stat);
            }

            return result;
        }

        private string DetectStat(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            // remove prefixos guia/destino para focar só no atributo
            text = text.Replace("-", " ");
            text = Regex.Replace(text, @"\s+", " ").Trim();
            text = Regex.Replace(text, @"\b(guia|destino)\b", " ").Trim();
            text = Regex.Replace(text, @"\s+", " ");

            // Ordem importa: os mais específicos primeiro

            // Pen. Física
            if (ContainsAny(text,
                "pen fisica", "pen fisico", "pen fica", "pen ficia", "pen fisca", "pen fiica", "pen. fisica"))
                return "Pen. Física";

            // Pen. Mágica
            if (ContainsAny(text,
                "pen magica", "pen magico", "pen megica", "pen megico", "pen. magica"))
                return "Pen. Mágica";

            // Atq Físico
            if (ContainsAny(text,
                "atq fisico", "atq fisica", "atq fiscio", "atq fisio", "atq fisco", "atg fisco", "atq fisco"))
                return "Atq Físico";

            // Atq Mágico
            if (ContainsAny(text,
                "atq magico", "atq magica", "atq megico", "atq megica", "atg megica", "atg magico", "atq mágico"))
                return "Atq Mágico";

            // Def Metal
            if (ContainsAny(text,
                "def metal", "defmetal"))
                return "Def Metal";

            // Def Madeira
            if (ContainsAny(text,
                "def madeira", "defmadeira"))
                return "Def Madeira";

            // Def Água
            if (ContainsAny(text,
                "def agua", "defagua"))
                return "Def Água";

            // Def Fogo
            if (ContainsAny(text,
                "def fogo", "deffogo"))
                return "Def Fogo";

            // Def Terra
            if (ContainsAny(text,
                "def terra", "defterra"))
                return "Def Terra";

            // Espírito
            if (ContainsAny(text,
                "espirito", "espirto", "espfito", "espfrito", "esp rito", "espiito", "espinto"))
                return "Espírito";

            // Precisão / Acerto
            if (ContainsAny(text,
                "acerto", "acerto", "precisao", "precisăo", "precisao"))
                return "Acerto";

            // Esquiva
            if (ContainsAny(text,
                "esquiva", "esqulva", "esq uiva"))
                return "Esquiva";

            // DefM (precisa vir antes de Def)
            if (text.Contains("defm") ||
            text.Contains("def m") ||
            text.Contains("defivi") ||
            text.Contains("defivl") ||
            text.Contains("defvi") ||
            text.Contains("def ml") ||
            text.Contains("deim") ||
            text.Contains("de fm"))
            {
                return "DefM";
            }

            // HP
            if (ContainsWordLike(text, "hp"))
                return "HP";

            // MP
            if (ContainsWordLike(text, "mp"))
                return "MP";

            // Def comum por último, para não capturar Def Água / Terra / Metal / etc.
            if (IsPlainDef(text))
                return "Def";

            return string.Empty;
        }

        private bool IsPlainDef(string text)
        {
            if (!text.Contains("def"))
                return false;

            if (ContainsAny(text,
                "def metal", "def madeira", "def agua", "def fogo", "def terra",
                "defm", "defivi", "defivl", "defvi", "def m", "def ml"))
                return false;

            return Regex.IsMatch(text, @"\bdef\b") || text.Trim() == "def";
        }

        private bool ContainsAny(string text, params string[] patterns)
        {
            foreach (var pattern in patterns)
            {
                if (text.Contains(pattern))
                    return true;
            }
            return false;
        }

        private bool ContainsWordLike(string text, string word)
        {
            return Regex.IsMatch(text, $@"\b{Regex.Escape(word)}\b");
        }

        private string NormalizeText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            string text = input.ToLowerInvariant();

            // remove acentos
            text = RemoveDiacritics(text);

            // padroniza separadores
            text = text.Replace("-", " ");
            text = text.Replace("_", " ");
            text = text.Replace("\r", " ");
            text = text.Replace("\n", " ");

            // mantém letras, números e espaços
            text = Regex.Replace(text, @"[^\w\s]", " ");

            // separa melhor casos como "AcertoGuia"
            text = Regex.Replace(text, @"(?<=[a-z])(?=guia|destino)", " ");

            // espaços múltiplos
            text = Regex.Replace(text, @"\s+", " ").Trim();

            return text;
        }

        private string RemoveDiacritics(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}