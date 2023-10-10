namespace Win11Print
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ReportPrintSettings PrintSettings = new ReportPrintSettings();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = PrintSettings;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
            => this.Print();

        private void Print()
        {
            var dialog = new PrintDialog { PageRangeSelection = PageRangeSelection.AllPages, UserPageRangeEnabled = false };
            var allowPrint = dialog.ShowDialog().Value;

            if (!allowPrint)
            {
                return;
            }

            var printDoc = new PrintDocument { PrinterSettings = { PrinterName = this.PrintSettings.PrinterName } };
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }

            printDoc.DefaultPageSettings = new PageSettings
            {
                Landscape = this.PrintSettings.Landscape,
                PaperSource = this.PrintSettings.PaperSource(),
                PaperSize = this.PrintSettings.PaperSize,
                Margins = this.PrintSettings.Margins(),
                PrinterSettings = printDoc.PrinterSettings
            };

            printDoc.PrintPage += (s, a) => this.PrintText(a, "Here is some text to print.");
            printDoc.Print();
        }

        private void PrintText(PrintPageEventArgs ev, string textToPrint)
        {
            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);
            ev.Graphics.DrawString(textToPrint, new Font(new FontFamily("Calibri"), 12), Brushes.HotPink, ev.MarginBounds, StringFormat.GenericTypographic);
        }
    }
}
