using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace SFDA_PRODUCTION.DTO
{
    public class PackageDownloadResponse
    {
        public string MD5CHECKSUM { get; set; }
        public List<FILE> FILES { get; set; }
    }

    public class FILE
    {
        public string  NAME { get; set; }

        [XmlIgnore]
        public string CONTENT { get; set; }

        [DataMember]
        [XmlText]
        public XmlNode[] CdataContent
        {
            get => new XmlNode[] { new XmlDocument().CreateCDataSection(CONTENT) };
            set => CONTENT = value[0].Value;
        }
    }
}
