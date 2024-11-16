using System.Xml;
using System.Text;
using System.Xml.Linq;

namespace task_6 {
    class Program {
        public static void Main() {
            parsingXmlDocument();
            LinqQuerry();
        }

        public static string getFilePath(string fileName) {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
        }

        public static void LinqQuerry() {
            var XmlDoc = XDocument.Load(getFilePath("task4.xml"));

            string id = Console.ReadLine();

            var result =
                from child in XmlDoc.Descendants("Child")
                where child.Attribute("ID").Value == id
                from grandChild in child.Descendants("GrandChild")
                select new {
                    Name = grandChild.Name,
                    Value = grandChild.Value
                };

            Console.WriteLine(result[0].Name);

        }

        public static void parsingXmlDocument() {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(getFilePath("task4.xml"));

            RecurseNodes(xmlDoc.DocumentElement);
        }

        public static void RecurseNodes(XmlNode node) {
            var sb = new StringBuilder();
            RecurseNodes(node, 0, sb);
            Console.WriteLine(sb.ToString());
        }

        public static void RecurseNodes(XmlNode node, int level, StringBuilder sb) {
            sb.AppendFormat("{0,-2} Type:{1,-9} Name:{2, -13} Attr:", level, node.NodeType, node.Name);

            foreach (XmlAttribute attr in node.Attributes) {
                sb.AppendFormat("{0} = {1} ", attr.Name, attr.Value);
            }
            sb.AppendLine();

            foreach (XmlNode child in node.ChildNodes) {
                RecurseNodes(child, level + 1, sb);
            }
        }
    }
}

/*new {
    childID = child.Attribute("ID").Value,
    grandChildName = child.GetCh
}*/