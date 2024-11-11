using System.Xml;
using System.Text;
using System.Runtime.ConstrainedExecution;

namespace task_5 {
    class Program {
        public static void Main() {
            parsingWithXmlTextReader();
            searchingXmlDocument();
        }

        public static string getFilePath(string fileName) {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
        }

        public static void parsingWithXmlTextReader() {
            var sb = new StringBuilder();
            var xmlReader = new XmlTextReader(getFilePath("task4.xml"));

            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                    case XmlNodeType.XmlDeclaration:
                    case XmlNodeType.Element:
                    case XmlNodeType.Comment:
                        sb.AppendFormat("{0}: {1} = {2}", xmlReader.NodeType, xmlReader.Name, xmlReader.Value);
                        sb.AppendLine();
                        break;
                    case XmlNodeType.Text:
                        sb.AppendFormat(" - Value: {0}", xmlReader.Value);
                        sb.AppendLine();
                        break;
                }
                if (xmlReader.HasAttributes) {
                    while (xmlReader.MoveToNextAttribute()) {
                        sb.AppendFormat(" - Attribute: {0} = {1}", xmlReader.Name, xmlReader.Value);
                        sb.AppendLine();
                    }
                }
            }
            xmlReader.Close();
            Console.WriteLine(sb.ToString());
        }

    }
}