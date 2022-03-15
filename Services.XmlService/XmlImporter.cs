using De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Services.XmlService
{
    public class XmlImporter
    {
        public bool ImportXmlFileToBookCollection(BookCollection bookCollection)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.DefaultExt = "xml";
                dialog.Filter = "XML Files|*.xml";
                dialog.ShowDialog();

                string path = dialog.FileName;
                string xml = File.ReadAllText(path);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    Book book = new Book()
                    {
                        Id = int.Parse(node.Attributes["id"]?.InnerText),
                        Title = node.SelectSingleNode("title").InnerText,
                        Author = node.SelectSingleNode("author").InnerText,
                        Year = node.SelectSingleNode("year").InnerText,
                        Publisher = node.SelectSingleNode("author").InnerText,
                        Sites = int.Parse(node.SelectSingleNode("sites").InnerText),
                        Genre = node.SelectSingleNode("genre").InnerText,
                        Price = double.Parse(node.SelectSingleNode("author").InnerText)
                    };
                    bookCollection.Add(book);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }                        
        }
    }
}
