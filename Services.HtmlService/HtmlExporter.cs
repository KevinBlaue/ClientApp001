using De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Services.HtmlService
{
    public class HtmlExporter
    {
        private BookCollection books;
        public bool ExportToHtmlFile(BookCollection bookCollection)
        {
            try
            {
                books = bookCollection;
                string content = BuildHtmlString();
                return ExportHtmlTextToFile(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private string BuildHtmlString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<html>");
            builder.Append("<head>");
            builder.Append("</head>");
            builder.Append("<body>");


            foreach (var book in books)
            {
                builder.Append($"<ul>");
                builder.Append($"<li>ID: {book.Id}</li>");
                builder.Append($"<li>Title: {book.Title}</li>");
                builder.Append($"<li>Author: {book.Author}</li>");
                builder.Append($"<li>Publisher: {book.Publisher}</li>");
                builder.Append($"<li>Genre: {book.Genre}</li>");
                builder.Append($"<li>Sites: {book.Sites}</li>");
                builder.Append($"<li>Price: {book.Price}</li>");
                builder.Append($"<li>Year: {book.Year}</li>");
                builder.Append($"</ul>");
            }

            builder.Append("</body>");
            builder.Append("</html>");
            return builder.ToString();
        }

        private bool ExportHtmlTextToFile(string content)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    FileName = "BookCollectionAsHtml",
                    DefaultExt = ".html",
                    Filter = "HTML Files|*.html"
                };

                dialog.ShowDialog();
                string directory = dialog.FileName;

                using (StreamWriter writer = new StreamWriter(directory))
                {
                    writer.WriteLine(content);
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
