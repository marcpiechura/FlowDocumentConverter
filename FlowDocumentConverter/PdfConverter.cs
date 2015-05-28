using System;
using System.IO;
using System.Windows.Documents;
using Spire.Pdf;

namespace FlowDocumentConverter
{
    public static class PdfConverter
    {
        public static byte[] ConvertDoc(FlowDocument document)
        {
            var xpsFile = XpsConverter.ConverterDoc(document);
            var tmpXpsFileName = Path.Combine(Path.GetTempPath(), DateTime.Now.Ticks + ".xps");
            File.WriteAllBytes(tmpXpsFileName, xpsFile);

            var doc = new PdfDocument();
            doc.LoadFromXPS(tmpXpsFileName);
            byte[] pdfFile;
            using (var stream = new MemoryStream())
            {
                doc.SaveToStream(stream);
                pdfFile = stream.ToArray();
            }

            File.Delete(tmpXpsFileName);
            return pdfFile;
        }
    }
}
