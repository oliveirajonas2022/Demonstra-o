using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Models
{
    public static class Deseralize
    {

        [XmlRoot(ElementName = "C")]
        public class C
        {
            [XmlElement(ElementName = "D")]
            public List<string> D { get; set; }
        }

        [XmlRoot(ElementName = "R")]
        public class R
        {
            [XmlElement(ElementName = "D")]
            public List<string> D { get; set; }
        }

        [XmlRoot(ElementName = "ResponseData")]
        public class ResponseData
        {
            [XmlElement(ElementName = "C")]
            public C C { get; set; }
            [XmlElement(ElementName = "R")]
            public List<R> R { get; set; }
        }

        [XmlRoot(ElementName = "ResponseResult")]
        public class ResponseResult
        {
            [XmlElement(ElementName = "ResponseSuccess")]
            public string ResponseSuccess { get; set; }
        }

        [XmlRoot(ElementName = "Microvix")]
        public class Microvix
        {
            //public List<XmlElement>
            [XmlElement(ElementName = "ResponseData")]
            public ResponseData ResponseData { get; set; }

            [XmlElement(ElementName = "ResponseResult")]
            public ResponseResult ResponseResult { get; set; }
        }

        public static T DeserializeXml<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
