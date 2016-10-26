using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PsychiatryProforma.InterfaceBuilding.Model;
using YAXLib;

namespace PsychiatryProforma.InterfaceBuilding.Loading
{
    public interface IModelSaver
    {
        void SaveModel(GroupElement baseElement);
    }

    public class XmlModelSaver : IModelSaver
    {
        private readonly string _fileName;

        public XmlModelSaver(string fileName)
        {
            _fileName = fileName;
        }

        public void SaveModel(GroupElement baseElement)
        {
            YAXSerializer serializer = new YAXSerializer(typeof(Element));
            serializer.SerializeToFile(baseElement, _fileName);
        }
    }
}