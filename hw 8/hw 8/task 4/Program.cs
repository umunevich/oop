using System.Xml;
using System.Text;

namespace task_4 {
    class Program {
        public static void Main() {
            // 4
            createAndSaveXmlDocument();
            parsingXmlDocument();
            searchingXmlDocument();
            // 5
            parsingWithXmlTextReader();
        }

        public static void createAndSaveXmlDocument() {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement el;
            int childCounter;
            int grandChildCounter;

            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));

            el = xmlDoc.CreateElement("MyRoot");
            xmlDoc.AppendChild(el);

            for (childCounter = 1; childCounter <= 3; childCounter++) {
                XmlElement childEl;
                XmlAttribute childAttr;

                childEl = xmlDoc.CreateElement("MyChild");
                childAttr = xmlDoc.CreateAttribute("ID");

                childAttr.Value = childCounter.ToString();
                childEl.Attributes.Append(childAttr);

                el.AppendChild(childEl);

                for (grandChildCounter = 1; grandChildCounter <= 2; grandChildCounter++) {
                    XmlElement grandChildEl;
                    XmlAttribute grandChildAttr;

                    grandChildEl = xmlDoc.CreateElement("MyGrandChild");
                    grandChildAttr = xmlDoc.CreateAttribute("NAME");

                    grandChildAttr.Value = childCounter.ToString() + " " + grandChildCounter.ToString();
                    grandChildEl.Attributes.Append(grandChildAttr);

                    childEl.AppendChild(grandChildEl);
                }
            }

            xmlDoc.Save(getFilePath("task4.xml"));
            Console.WriteLine("task4.xml created. \n");
        }

        public static string getFilePath(string fileName) {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
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

        public static void searchingXmlDocument() {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(getFilePath("task4.xml"));

            int id; 
            Int32.TryParse(Console.ReadLine(), out id);
            try {
                var node = xmlDoc.SelectSingleNode(" //MyChild[@ID='" + id + "']");
                RecurseNodes(node);
            }
            catch (Exception ex) {
                Console.WriteLine($"{ex.Message}");
            }
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