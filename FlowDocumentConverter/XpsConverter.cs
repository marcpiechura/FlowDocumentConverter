using System.IO;
using System.IO.Packaging;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using System.Windows.Xps.Serialization;

namespace FlowDocumentConverter
{
    public static class XpsConverter
    {
        public static byte[] ConverterDoc(FlowDocument document)
        {
            using (var stream = new MemoryStream())
            {
                using (var package = Package.Open(stream, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (var xpsDoc = new XpsDocument(package, CompressionOption.Maximum))
                    {
                        var rsm = new XpsSerializationManager(new XpsPackagingPolicy(xpsDoc), false);
                        var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;
                        rsm.SaveAsXaml(paginator);
                        rsm.Commit();
                    }
                }

                return stream.ToArray();
            }
        }
    }
}
