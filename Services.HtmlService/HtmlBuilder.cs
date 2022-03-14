using De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Services.HtmlService
{
    public class HtmlBuilder
    {
        private BookCollection books;
        public async Task<bool> ExportToHtmlFile(BookCollection bookCollection)
        {
            try
            {
                books = bookCollection;
                string content = await BuildHtmlString();
                return await ExportHtmlTextToFile(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private async Task<string> BuildHtmlString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<html>");
            builder.Append("<head>");
            builder.Append("</head>");
            builder.Append("<body>");

            foreach (var book in books)
            {
                builder.Append($"<h2>{book.Title}</h2>");
                builder.Append($"<p>Author: {book.Author}</p>");
                builder.Append($"<p>Publisher: {book.Publisher}</p>");
                builder.Append($"<p>Genre: {book.Genre}</p>");
                builder.Append($"<p>Sites: {book.Sites}</p>");
                builder.Append($"<p>Price: {book.Price}</p>");
                builder.Append($"<p>Year: {book.Year}</p>");
            }

            builder.Append("</body>");
            builder.Append("</html>");
            return builder.ToString();
        }

        private async Task<bool> ExportHtmlTextToFile(string content)
        {
            try
            {
                await Task.Run(() =>
                {

                    SaveFileDialog dialog = new SaveFileDialog
                    {
                        FileName = "BookCollectionAsHtml",
                        DefaultExt = ".html"
                    };

                    dialog.ShowDialog();
                    string directory = dialog.FileName;

                    using (StreamWriter writer = new StreamWriter(directory))
                    {
                        writer.WriteLine(content);
                    }
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
