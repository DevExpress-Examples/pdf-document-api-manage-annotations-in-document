Imports System
Imports DevExpress.Pdf

Namespace CreateMarkupAnnotation
    Friend Class Program
        Shared Sub Main(ByVal args() As String)

            ' Create a PDF Document Processor.
            Using processor As New PdfDocumentProcessor()

                ' Load a document.
                processor.LoadDocument("..\..\Document.pdf")

                ' Add a text markup annotation to the first page for a text corresponding to the specified page area.
                Dim annot As PdfTextMarkupAnnotationData = processor.AddTextMarkupAnnotation(1, New PdfRectangle(90, 100, 240, 230), PdfTextMarkupAnnotationType.Highlight)
                If annot IsNot Nothing Then

                    ' Specify the annotation properties.                    
                    annot.Author = "Bill Smith"
                    annot.Contents = "Note"
                    annot.Color = New PdfRGBColor(0.8, 0.2, 0.1)

                    ' Save the result document.
                    processor.SaveDocument("..\..\Result.pdf")
                Else
                    Console.WriteLine("The annotation cannot be added to a page. Make sure, a specified page area corresponds to a text on the page.")
                End If
            End Using
        End Sub
    End Class
End Namespace