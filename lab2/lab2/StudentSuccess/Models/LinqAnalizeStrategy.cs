using System.Text;
using System.Xml.Linq;

namespace StudentSuccess.Models {
    internal class LinqAnalizeStrategy :IAnalizeStrategy {
        public string Search(string filePath, Attribute attribute, string value) {
            var xmlDoc = XDocument.Load(filePath);
            var sb = new StringBuilder();

            var elements = xmlDoc.Descendants(Enum.GetName(typeof(Attribute), attribute)).
                Where(el => (string)el.Attribute("Name") == value);

            foreach (var element in elements) {
                var childElements = element.Elements();
                foreach (var child in childElements) {
                    sb.AppendFormat($"{child.Name} : {child.Attribute("Name")?.Value}");
                    if (child.Name == Enum.GetName(typeof(Attribute), 3)) {
                        sb.AppendFormat($"Grade: {child.Attribute("Grade")?.Value}");
                    }
                    sb.AppendLine();
                }
            }

            return sb.ToString();

        }
    }
}
