namespace Win11Print
{
    using System.Drawing.Printing;

    public static class ReportPrintSettingsExtensions
    {
        public static Margins Margins(this ReportPrintSettings printSettings) =>
            new Margins(printSettings.LeftMargin, printSettings.RightMargin, printSettings.TopMargin, printSettings.BottomMargin);

        public static PaperSource PaperSource(this ReportPrintSettings printSettings) =>
            new PaperSource
            {
                SourceName = printSettings.PaperSourceName,
                RawKind = printSettings.PaperSourceKind
            };
    }
}
