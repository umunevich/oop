using System.Text;
using System.Xml;
using StudentSuccess.Models.AnalizeStrategy;

namespace StudentSuccess.Models.AnalizeStrategy
{
    internal class DomAnalizeStrategy : IAnalizeStrategy {
        public string Search(string filePath, Attribute attribute, string value) {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            var sb = new StringBuilder();

            XmlNodeList nodes = xmlDoc.GetElementsByTagName(Enum.GetName(typeof(Attribute), attribute));
            foreach (XmlNode node in nodes) {
                if (node.Attributes["Name"]?.Value == value) {
                    foreach (XmlNode child in node.ChildNodes) {
                        sb.AppendFormat($"{child.Name} : {child.Attributes["Name"].Value}");
                        if (child.Name == Enum.GetName(typeof(Attribute), 3)) {
                            sb.AppendFormat($" Grade: {child.Attributes["Grade"]?.Value}");
                        }
                        sb.AppendLine();
                    }
                }
            }
            return sb.ToString();
        }
    }
}
