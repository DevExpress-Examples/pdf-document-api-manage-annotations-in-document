using System;
using DevExpress.Pdf;

namespace CreateMarkupAnnotation {
    class Program {
        static void Main(string[] args) {

            // Create a PDF Document Processor.
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor()) {

                // Load a document.
                processor.LoadDocument("..\\..\\Document.pdf");

                // Add a text markup annotation to the first page for a text corresponding to the specified page area.
                PdfTextMarkupAnnotationData annot = processor.AddTextMarkupAnnotation(1, new PdfRectangle(90, 100, 240, 230),
                                            PdfTextMarkupAnnotationType.Highlight);
                if (annot != null) {

                    // Specify the annotation properties.                    
                    annot.Author = "Bill Smith";
                    annot.Contents = "Note";
                    annot.Color = new PdfRGBColor(0.8, 0.2, 0.1);

                    // Save the result document.
                    processor.SaveDocument("..\\..\\Result.pdf");
                }
                else
                    Console.WriteLine("The annotation cannot be added to a page. Make sure, a specified page area corresponds to a text on the page.");
            }
        }
    }
}