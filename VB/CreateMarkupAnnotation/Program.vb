Imports DevExpress.Pdf
Imports System.Linq

Namespace PdfMarkupAnnotations

    Friend Class Program

        Shared Sub Main(ByVal args As String())
            Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                'Load a document:
                processor.LoadDocument("..\..\Document.pdf")
                CreateAnnotations(processor)
                EditAnnotations(processor)
                DeleteAnnotations(processor)
                'Save the result:
                processor.SaveDocument("..\..\Result.pdf")
            End Using

            System.Diagnostics.Process.Start("..\..\Result.pdf")
        End Sub

        Private Shared Sub CreateAnnotations(ByVal processor As PdfDocumentProcessor)
            'Add a text markup annotation at the first page:
            Dim startPosition As PdfDocumentPosition = New PdfDocumentPosition(1, New PdfPoint(113, 224))
            Dim endPosition As PdfDocumentPosition = New PdfDocumentPosition(1, New PdfPoint(272, 207))
            Dim textMarkupAnnotation As PdfTextMarkupAnnotationData = processor.AddTextMarkupAnnotation(startPosition, endPosition, PdfTextMarkupAnnotationType.Highlight)
            If textMarkupAnnotation IsNot Nothing Then
                'Specify the annotation properties:
                textMarkupAnnotation.Author = "Bill Smith"
                textMarkupAnnotation.Subject = "Important!"
                textMarkupAnnotation.Contents = "Please, fact-check this diagram"
                textMarkupAnnotation.Color = New PdfRGBColor(0.10, 0.85, 1.00)
                AddAnnotationComments(textMarkupAnnotation)
            End If

            'Add a sticky note at the first page:
            Dim textAnnotation As PdfTextAnnotationData = processor.AddTextAnnotation(1, New PdfPoint(64, 65))
            'Specify the annotation parameters:
            textAnnotation.Author = "Nancy Davolio"
            textAnnotation.Color = New PdfRGBColor(0.8, 0.2, 0.1)
            textAnnotation.Contents = "Please proofread this document"
            textAnnotation.IconName = PdfTextAnnotationIconName.Check
            AddAnnotationComments(textAnnotation)
        End Sub

        Private Shared Sub EditAnnotations(ByVal processor As PdfDocumentProcessor)
            'Retrieve annotations made by the specified author:
            Dim textMarkups = processor.GetMarkupAnnotationData(1).Where(Function(annotation) annotation.Author.Contains("Cardle Anita L"))
            For Each markup As PdfMarkupAnnotationData In textMarkups
                'Get all text markup annotations from the retrieved list:
                Dim pdfTextMarkup As PdfTextMarkupAnnotationData = markup.AsTextMarkupAnnotation()
                'Change the annotation's markup type:
                If pdfTextMarkup IsNot Nothing Then pdfTextMarkup.MarkupType = PdfTextMarkupAnnotationType.Squiggly
            Next

            Dim annotations = processor.GetMarkupAnnotationData(1)
            For Each annotation As PdfMarkupAnnotationData In annotations
                'Get all text annotations:
                Dim textAnnotation As PdfTextAnnotationData = annotation.AsTextAnnotation()
                'Change the annotation icon:
                If textAnnotation IsNot Nothing Then textAnnotation.IconName = PdfTextAnnotationIconName.Note
            Next

            annotations(0).AddReview("Borman Aaron Lewis", PdfAnnotationReviewStatus.Completed)
        End Sub

        Private Shared Sub AddAnnotationComments(ByVal annotation As PdfMarkupAnnotationData)
            'Add a comment for the specified annotation:
            Dim comment As PdfMarkupAnnotationComment = annotation.AddReply("Reviewer", "Done")
            comment.Subject = "Proofread"
            'Create a nested comment and add a review:
            Dim nestedComment As PdfMarkupAnnotationComment = comment.AddReply(annotation.Author, "Thanks")
            nestedComment.Subject = "Reviewed"
            nestedComment.AddReview("Reviewer", PdfAnnotationReviewStatus.Accepted)
        End Sub

        Private Shared Sub DeleteAnnotations(ByVal processor As PdfDocumentProcessor)
            For i As Integer = 0 To processor.Document.Pages.Count
                'Borman Aaron Lewis's markup annotations from a page.
                processor.DeleteMarkupAnnotations(processor.GetMarkupAnnotationData(i).Where(Function(annotation) annotation.Author.Contains("Borman Aaron Lewis")))
            Next
        End Sub
    End Class
End Namespace
