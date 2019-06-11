using System;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TesteImposto.Shared.Xml
{
    public static class XmlShared
    {
        private static readonly string _pathXml = ConfigurationManager.AppSettings["pathXml"];

        public static void CreateXmlFile<T>(T entity) where T : class
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                using (MemoryStream xmlStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(xmlStream, entity);
                    xmlStream.Position = 0;
                    xmlDoc.Load(xmlStream);

                    using (XmlTextWriter writer = new XmlTextWriter(string.Concat(_pathXml, "\\", Guid.NewGuid().ToString(), ".xml"), null))
                    {
                        writer.Formatting = Formatting.Indented;
                        xmlDoc.Save(writer);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
