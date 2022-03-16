using De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects;
using HtmlAgilityPack;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.HtmlService
{
    public class HtmlImporter
    {
        public bool ImportHtmlFileToBookCollection(BookCollection bookCollection)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.DefaultExt = "html";
                dialog.Filter = "HTML Files|*.html";
                dialog.ShowDialog();

                string path = dialog.FileName;
                string html = File.ReadAllText(path);

                string[] lists = html.Split(new string[] { "ul" }, StringSplitOptions.None);                
                foreach(string list in lists)
                {
                    string[] parts = Regex.Split(list, @"<\s*li[^>]*>(.*?)<\s*/\s*li>");

                    if(parts.Length > 1)
                    {
                        Book book = new Book();
                        foreach (string part in parts)
                        {
                            string[] tag = part.Split(':');
                            if (tag.Length > 1)
                            {
                                string name = tag[0];
                                string value = tag[1];

                                if (name.Contains("ID"))
                                {
                                    book.Id = int.Parse(value);
                                }
                                else if (name.Contains("Title"))
                                {
                                    book.Title = value;
                                }
                                else if (name.Contains("Author"))
                                {
                                    book.Author = value;
                                }
                                else if (name.Contains("Genre"))
                                {
                                    book.Genre = value;
                                }
                                else if (name.Contains("Publisher"))
                                {
                                    book.Publisher = value;
                                }
                                else if (name.Contains("Sites"))
                                {
                                    book.Sites = int.Parse(value);
                                }
                                else if (name.Contains("Price"))
                                {
                                    book.Price = double.Parse(value);
                                }
                                else if (name.Contains("Year"))
                                {
                                    book.Year = value;
                                }
                            }
                        }
                        bookCollection.Add(book);
                    }
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
