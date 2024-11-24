
using System.Xml.Xsl;

namespace StudentSuccess.Models {
    internal class Transform {
        public static void TransformTo(string xsl_file, string input_file, string output_file) {
            var xslt = new XslCompiledTransform();
            xslt.Load(xsl_file);
            xslt.Transform(input_file, output_file);
        }
    }
}
