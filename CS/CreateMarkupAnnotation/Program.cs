using DevExpress.Pdf;
using System.Linq;

namespace PdfMarkupAnnotations
{
    class Program
    {


        static void Main(string[] args)
        {
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
            {
                //Load a document:
                processor.LoadDocument("..\\..\\Document.pdf");
                CreateAnnotations(processor);
                EditAnnotations(processor);
                DeleteAnnotations(processor);

                //Save the result:
                processor.SaveDocument("..\\..\\Result.pdf");
            }
            System.Diagnostics.Process.Start("..\\..\\Result.pdf");
        }



        private static void CreateAnnotations(PdfDocumentProcessor processor)
        {
            //Add a text markup annotation at the first page:
            PdfDocumentPosition startPosition = new PdfDocumentPosition(1, new PdfPoint(113, 224));
            PdfDocumentPosition endPosition = new PdfDocumentPosition(1, new PdfPoint(272, 207));

            PdfTextMarkupAnnotationData textMarkupAnnotation = processor.AddTextMarkupAnnotation(startPosition,endPosition,
                                        PdfTextMarkupAnnotationType.Highlight);
            if (textMarkupAnnotation != null)
            {
                //Specify the annotation properties:
                textMarkupAnnotation.Author = "Bill Smith";
                textMarkupAnnotation.Subject = "Important!";
                textMarkupAnnotation.Contents = "Please, fact-check this diagram";
                textMarkupAnnotation.Color = new PdfRGBColor(0.10, 0.85, 1.00);
                AddAnnotationComments(textMarkupAnnotation);
            }

            //Add a sticky note at the first page:
            PdfTextAnnotationData textAnnotation = processor.AddTextAnnotation(1, new PdfPoint(64, 65));

            //Specify the annotation parameters:
            textAnnotation.Author = "Nancy Davolio";
            textAnnotation.Color = new PdfRGBColor(0.8, 0.2, 0.1);
            textAnnotation.Contents = "Please proofread this document";
            textAnnotation.IconName = PdfTextAnnotationIconName.Check;
            AddAnnotationComments(textAnnotation);

        }
        private static void EditAnnotations(PdfDocumentProcessor processor)
        {
            //Retrieve annotations made by the specified author:
            var textMarkups =
                processor.GetMarkupAnnotationData(1).Where(annotation => annotation.Author.Contains("Cardle Anita L"));
            foreach (PdfMarkupAnnotationData markup in textMarkups)
            {
                //Get all text markup annotations from the retrieved list:
                PdfTextMarkupAnnotationData pdfTextMarkup = markup.AsTextMarkupAnnotation();
                if (pdfTextMarkup != null)
                    //Change the annotation's markup type:
                    pdfTextMarkup.MarkupType = PdfTextMarkupAnnotationType.Squiggly;
            }

            var annotations = processor.GetMarkupAnnotationData(1);
            foreach (PdfMarkupAnnotationData annotation in annotations)
            {
                //Get all text annotations:
                PdfTextAnnotationData textAnnotation = annotation.AsTextAnnotation();
                if (textAnnotation != null)

                    //Change the annotation icon:
                    textAnnotation.IconName = PdfTextAnnotationIconName.Note;
            }
            annotations[0].AddReview("Borman Aaron Lewis", PdfAnnotationReviewStatus.Completed);
        }


        private static void AddAnnotationComments(PdfMarkupAnnotationData annotation)
        {
            //Add a comment for the specified annotation:
            PdfMarkupAnnotationComment comment = annotation.AddReply("Reviewer", "Done");
            comment.Subject = "Proofread";

            //Create a nested comment and add a review:
            PdfMarkupAnnotationComment nestedComment = comment.AddReply(annotation.Author, "Thanks");
            nestedComment.Subject = "Reviewed";
            nestedComment.AddReview("Reviewer", PdfAnnotationReviewStatus.Accepted);
        }

        private static void DeleteAnnotations(PdfDocumentProcessor processor)
        {
            for (int i = 0; i <= processor.Document.Pages.Count; i++)
            {
                //Borman Aaron Lewis's markup annotations from a page.
                processor.DeleteMarkupAnnotations(processor.GetMarkupAnnotationData(i)
                .Where(annotation => annotation.Author.Contains("Borman Aaron Lewis")));
            }
        }
    }
}