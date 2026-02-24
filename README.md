<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/180363092/17.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T545395)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# How to Add a Text Markup Annotation to a PDF

This example shows how to create a text markup annotation that highlights text in a PDF document and how to specify the annotation properties.

To add a text markup annotation to a page, call one of the  
[PdfDocumentProcessor.AddTextMarkupAnnotation](https://documentation.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.AddTextMarkupAnnotation.method\(sbaKFQ\))  
overload methods, specifying the page number and a page area corresponding to the text that should be annotated on this page.

Note that if the specified page area does not correspond to text on the page, the annotation is **not** created, and the `PdfDocumentProcessor.AddTextMarkupAnnotation` overload methods return **null**.

## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=pdf-document-api-manage-annotations-in-document&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=pdf-document-api-manage-annotations-in-document&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
