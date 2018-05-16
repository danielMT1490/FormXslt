using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace FormXslt
{
    public partial class Form1 : Form
    {
        private const string archivoXml = "archivo.xml";
        private const string conversionXslt = "transform.xslt";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            var xslt = new XslTransform();
            xslt.Load("docs/transform.xslt");
            xslt.Transform("docs/archivo.xml", "index.html");

            var xmlDoc = new XmlDocument();
            xmlDoc.Load("docs/archivo.xml");
            var list =xmlDoc.SelectNodes("catalog/cd[title[starts-with(text(),'S')]]");
            
            using (var wt = XmlWriter.Create("docs/archivofiltrado.xml"))
            {
                wt.WriteStartElement("catalog");
                foreach (XmlNode item in list)
                {
                    item.WriteTo(wt);
                }
            }

            xslt.Transform("docs/archivofiltrado.xml", "indexfiltrado.html");
           
        }
    }
}
