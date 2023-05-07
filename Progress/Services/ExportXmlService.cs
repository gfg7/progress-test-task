using System.Xml;
using System.Xml.Serialization;
using Progress.Interfaces;

namespace Progress.Services
{
    public class ExportXmlService<T> : IExport<string, T>
    {
        public Task<string> Export(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            var xml = string.Empty;

            using (var stringWriter = new StringWriter())
            {
                using (var stream = XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(stream, obj);
                    xml = stringWriter.ToString();
                }
            }

            return Task.FromResult(xml);
        }
    }
}