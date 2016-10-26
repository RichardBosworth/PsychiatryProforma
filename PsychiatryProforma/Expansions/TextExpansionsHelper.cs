using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using YAXLib;

namespace PsychiatryProforma.Expansions
{
    public static class TextExpansionsHelper
    {
        public static TextExpansionLibrary LoadExpansions(string fileName)
        {
            var yaxSerializer = new YAXSerializer(typeof(TextExpansionLibrary));
            return yaxSerializer.DeserializeFromFile(fileName) as TextExpansionLibrary;
        }

        public static string ReplaceExpansions(string text, TextExpansionLibrary textExpansions)
        {
            foreach (var textExpansion in textExpansions)
            {
                var regexAfterSentence = new Regex($"(\\w\\s)\\b({textExpansion.ContractedText})\\b");
                text = regexAfterSentence.Replace(text, $"$1{textExpansion.ExportVariations.SelectVariation().ToLower()}");

                var regexAfterComma = new Regex($"(,\\s)\\b({textExpansion.ContractedText})\\b");
                text = regexAfterComma.Replace(text, $"$1{textExpansion.ExportVariations.SelectVariation().ToLower()}");

                var regex = new Regex($"\\b{textExpansion.ContractedText}\\b");
                text = regex.Replace(text, textExpansion.ExportVariations.SelectVariation());
            }

            return text;
        }
    }
}