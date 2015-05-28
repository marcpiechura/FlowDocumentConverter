# FlowDocumentConverter
Converter to create PDF or XPS documents from a FlowDocument

You can install it via [Nuget](https://www.nuget.org/packages/FlowDocumentConverter/1.0.0)  
>Install-Package FlowDocumentConverter  

or download the DLL's from the [Releases](https://github.com/Silv3rcircl3/FlowDocumentConverter/releases)  
  
###Usage

If you want to create a XPS-Document
>XpsConverter.ConvertDoc(\<some FlowDocument>);  

If you want to create a PDF-Document
>PdfConverter.ConvertDoc(\<some FlowDocument>);  

both methods return a byte[], so you can write them into a file, if you want to. 

###FlowDocuments
I'm using this converter in my own project and couldn't find any errors, I have used the following elements in my FlowDocumennt
- Images from a resource
- Bindings with Run, ItemsControl, TextBlock as well as converters
- DataTemplates
- Controls like a Grid, Rectangle, ItemsControl, TextBlock, Border...
- Tables


###Notes
Internally the PdfConverter uses the XpsConverter to create a XPS-Document, writes it into the tempfolder and then uses [Free Spire.PDF for .NET](https://www.nuget.org/packages/FreeSpire.PDF/) to create a PDF from this XPS-Document. 
Unfortunately the Free Spire.PDF library can only create PDF-Documents from files, so we need to write the XPS-Document to disc.  
Another drawback of the Free Spire.PDF version is, that it allows only PDF's with a maximum of 10 pages.  
As you can see, there is no magic in this converter, it just brings the bits together so that you don't have to waste time to find them yourself.
