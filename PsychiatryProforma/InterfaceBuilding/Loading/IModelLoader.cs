using PsychiatryProforma.InterfaceBuilding.Model;
using YAXLib;

namespace PsychiatryProforma.InterfaceBuilding.Loading
{
    /// <summary>
    ///     Provides functionality to load a model.
    /// </summary>
    public interface IModelLoader
    {
        GroupElement LoadModel();
    }

    public class XmlModelLoader : IModelLoader
    {
        private readonly string _fileName;

        public XmlModelLoader(string fileName)
        {
            _fileName = fileName;
        }

        public GroupElement LoadModel()
        {
            YAXSerializer yaxSerializer = new YAXSerializer(typeof(Element));
            GroupElement deserializeFromFile = yaxSerializer.DeserializeFromFile(_fileName) as GroupElement;
            return deserializeFromFile;
        }
    }
}