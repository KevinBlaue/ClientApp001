using De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects;
using Microsoft.Win32;
using System;
using System.Threading.Tasks;
using System.Xml;

namespace Services.XmlService
{
    public class XmlBuilder
    {
        public async Task<bool> ExportXmlTextToFile(BookCollection bookCollection)
        {
            try
            {
                await Task.Run(() =>
                {
                    SaveFileDialog dialog = new SaveFileDialog
                    {
                        FileName = "BookCollectionAsXml",
                        DefaultExt = ".xml",
                    };

                    dialog.ShowDialog();
                    string directory = dialog.FileName;

                    XmlWriter xmlWriter = XmlWriter.Create(directory);
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("books");

                    foreach (var book in bookCollection)
                    {
                        xmlWriter.WriteStartElement("book");
                        xmlWriter.WriteAttributeString("id", book.Id.ToString());
                        xmlWriter.WriteElementString("title", book.Title);
                        xmlWriter.WriteElementString("author", book.Author);
                        xmlWriter.WriteElementString("publisher", book.Publisher);
                        xmlWriter.WriteElementString("year", book.Year);
                        xmlWriter.WriteElementString("genre", book.Genre);
                        xmlWriter.WriteElementString("sites", book.Sites.ToString());
                        xmlWriter.WriteElementString("price", book.Price.ToString());
                        xmlWriter.WriteEndElement();
                    }
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Close();
                });
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
