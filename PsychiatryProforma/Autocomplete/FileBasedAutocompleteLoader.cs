using System.IO;
using YAXLib;

namespace PsychiatryProforma.Autocomplete
{
    public class FileBasedAutocompleteLoader : IAutocompleteLoader
    {
        private readonly string _filePath;

        public FileBasedAutocompleteLoader(string filePath)
        {
            _filePath = filePath;
        }

        public AutocompleteList LoadList()
        {
            if (File.Exists(_filePath))
            {
                var serializer = new YAXSerializer(typeof(AutocompleteList));
                var autocompleteList = serializer.DeserializeFromFile(_filePath) as AutocompleteList;
            }
            return null;
        }
    }
}