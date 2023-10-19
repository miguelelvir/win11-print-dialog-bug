namespace Win11Print
{
    using System.Printing;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;

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

        private FixedDocument CreateSomeContent()
        {
            var doc = new FixedDocument();
            doc.Pages.Add(
                new PageContent
                {
                    Child = new FixedPage
                    {
                        Children =
                        {
                            new TextBlock { Text = "Hello world!" }
                        }
                    }
                });

            return doc;
        }

        private void Print()
        {
            var localPrintServer = new LocalPrintServer();
            var printQueue = localPrintServer.DefaultPrintQueue;
            var printTicket = printQueue.DefaultPrintTicket;
            printTicket.PageOrientation = this.PrintSettings.Landscape ? PageOrientation.Landscape : PageOrientation.Portrait;

            var dialog = new PrintDialog
            {
                PageRangeSelection = PageRangeSelection.AllPages,
                UserPageRangeEnabled = false,
                PrintQueue = printQueue
            };

            dialog.PrintTicket = dialog.PrintQueue.MergeAndValidatePrintTicket(dialog.PrintQueue.DefaultPrintTicket, printTicket).ValidatedPrintTicket;

            var allowPrint = dialog.ShowDialog().Value;
            if (allowPrint)
            {
                this.PrintSettings.PrinterName = dialog.PrintQueue.FullName;
                var xpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);
                xpsDocumentWriter.Write(CreateSomeContent(), dialog.PrintTicket);
            }
        }
    }
}
