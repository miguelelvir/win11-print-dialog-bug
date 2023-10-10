namespace Win11Print
{
    using System.Drawing.Printing;

    public class ReportPrintSettings
    {
        private string printerName;
        public string PrinterName
        {
            get => printerName;
            set => printerName = value;
        }

        private int leftMargin;
        public int LeftMargin
        {
            get => leftMargin;
            set => leftMargin = value;
        }

        private int rightMargin;
        public int RightMargin
        {
            get => rightMargin;
            set => rightMargin = value;
        }

        private int topMargin;
        public int TopMargin
        {
            get => topMargin;
            set => topMargin = value;
        }

        private int bottomMargin;
        public int BottomMargin
        {
            get => bottomMargin;
            set => bottomMargin = value;
        }

        private PaperSize paperSize;
        public PaperSize PaperSize
        {
            get => paperSize;
            set => paperSize = value;
        }

        private string paperSourceName;
        public string PaperSourceName
        {
            get => paperSourceName;
            set => paperSourceName = value;
        }

        private int paperSourceKind;
        public int PaperSourceKind
        {
            get => paperSourceKind;
            set => paperSourceKind = value;
        }

        private bool landscape;
        public bool Landscape
        {
            get => landscape;
            set => landscape = value;
        }

        private int? dpi;
        public int? Dpi
        {
            get => dpi;
            set => dpi = value;
        }
    }
}
