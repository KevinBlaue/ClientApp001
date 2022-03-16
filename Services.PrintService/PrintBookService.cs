using De.HsFlensburg.ClientApp001.Business.Model.BusinessObjects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Services.PrintService
{
    public class PrintBookService
    {
        public FlowDocument flowDocument;

        public PrintBookService(BookCollection bookCollection)
        {
            flowDocument = new FlowDocument();
            flowDocument.PagePadding = new Thickness(15);
            flowDocument.ColumnGap = 0;
            BookDocument(bookCollection);
        }

        private FlowDocument BookDocument(BookCollection bookCollection)
        {
            // Define Fonts
            FontFamily arial = new FontFamily("Arial");
            FontFamily consolas = new FontFamily("Consolas");

            // Add Header to Document
            flowDocument.Blocks.Add(CreateHeader(bookCollection.Count));
            foreach (var book in bookCollection)
            {
                Table contentTable = CreateTable(2, 7);
                string[] headers = { "Title", "Author", "Genre", "Preis", "Publisher", "Year", "Sites" };
                SetRowContent(contentTable.RowGroups[0].Rows[0], headers, arial, FontWeights.Bold);

                string[] content = { book.Title, book.Author, book.Genre, book.Price.ToString(), book.Publisher, book.Year, book.Sites.ToString() };
                SetRowContent(contentTable.RowGroups[0].Rows[1], content, consolas, FontWeights.Normal);

                AddBorder(contentTable);

                Section sec = new Section();
                sec.Blocks.Add(contentTable);

                flowDocument.Blocks.Add(sec);
            }
            return flowDocument;
        }

        // Execute Printing
        public void Printing()
        {
            PrintDialog printDialog = new PrintDialog();
            IDocumentPaginatorSource idpSource = flowDocument;

            bool? print = printDialog.ShowDialog();
            if (print == true)
            {
                // Set FlowDocument Width to Page Settings
                flowDocument.ColumnWidth = printDialog.PrintableAreaWidth;
                flowDocument.PageWidth = printDialog.PrintableAreaWidth;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "BookPrint");
            }
        }

        private void AddBorder(Table mainTable)
        {
            mainTable.Padding = new Thickness(15);
            mainTable.BorderBrush = Brushes.Gray;
            mainTable.BorderThickness = new Thickness(2);
        }

        private void SetRowContent(TableRow tableRow, string[] contents, FontFamily fontFamily, FontWeight fontWeight)
        {
            tableRow.FontFamily = fontFamily;
            tableRow.FontWeight = fontWeight;
            foreach (string param in contents)
            {
                tableRow.Cells.Add(new TableCell(new Paragraph(new Run(param))));
            }
        }

        private Table CreateTable(int rows, int columns)
        {
            Table table = new Table();
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add(new TableColumn());
            }
            table.RowGroups.Add(new TableRowGroup());
            for (int i = 0; i < rows; i++)
            {
                table.RowGroups[0].Rows.Add(new TableRow());
            }
            return table;
        }

        private Block CreateHeader(int bookCollectionSize)
        {
            Run header = new Run("Print BookList of " + bookCollectionSize + " Books");
            header.FontFamily = new FontFamily("Arial");
            header.FontSize = 24;
            return new Paragraph(header);
        }
    }
}