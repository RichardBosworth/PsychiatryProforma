using System.Collections.Generic;
using System.IO;
using YAXLib;

namespace PsychiatryProforma.Autocomplete
{
    public class AutocompleteList
    {
        [YAXCollection(YAXCollectionSerializationTypes.Recursive, EachElementName = "Autocomplete")]
        public List<string> AutocompleteItems { get; set; } = new List<string>();
    }
}