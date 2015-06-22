using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWILL.PrintService
{
    class Program
    {
        static void Main(string[] args)
        {
            var label = new PrintDocument();
            var printer = PrinterSettings.InstalledPrinters.Cast<string>().FirstOrDefault(p => p.ToLowerInvariant().Contains("dymo"));

            label.PrinterSettings.PrinterName = printer;
            label.PrintPage += LabelOnPrintPage;

            label.Print();
        }

        private static void LabelOnPrintPage(object sender, PrintPageEventArgs args)
        {
            var brush = new SolidBrush(Color.Black);
            var font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold);

            //var g = Graphics.FromImage(new Bitmap(@"e:\gir.png"));

            //args.Graphics.DrawString("SWILL", font, brush, 0, 0);
            args.Graphics.DrawImage(new Bitmap(@"e:\gir.png"), new Rectangle(0, 0, 300, 150));
            
        }
    }
}
