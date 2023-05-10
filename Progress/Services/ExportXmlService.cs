using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Progress.Interfaces;

namespace Progress.Services
{
    public class ExportXmlService<T> : IExport<string>
    {
        public Task<string> Export<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            var xml = string.Empty;
            var settings = new XmlWriterSettings()
            {
                Encoding = Encoding.UTF8
            };

            using (var stringWriter = new StringWriter())
            {
                using (var stream = XmlWriter.Create(stringWriter, settings))
                {
                    serializer.Serialize(stream, obj);
                    xml = stringWriter.ToString();
                }
            }

            return Task.FromResult(xml);
        }
    }
}