using System.Text;
using System.Xml;

namespace StudentSuccess.Models {
    internal class SaxAnalizeStrategy : IAnalizeStrategy{
        public string Search(string filePath, Attribute attribute, string value) {
            var sb = new StringBuilder();
            var xmlReader = new XmlTextReader(filePath);
            bool isMatching = false;

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                    case XmlNodeType.Element:
                        var currentElement = xmlReader.Name;
                        if (currentElement == Enum.GetName(typeof(Attribute), attribute) && xmlReader.GetAttribute("Name") == value) {
                            isMatching = true;
                            break;
                        }
                        else if (isMatching && currentElement == Enum.GetName(typeof(Attribute), attribute + 1)) {
                            sb.AppendFormat($"{currentElement} : {xmlReader.GetAttribute("Name")}");
                            if (currentElement == Enum.GetName(typeof(Attribute), 3)) {
                                sb.AppendFormat($" Grade: {xmlReader.GetAttribute("Grade")}");
                            }
                            sb.AppendLine();
                        }
                        if (currentElement == Enum.GetName(typeof(Attribute), attribute))
                            isMatching = false;
                        break;
                    default:
                        break;

                }
            }
            return sb.ToString();
        }
    }
}
