<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/180363092/17.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T545395)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to add a text markup annotation to PDF

<p>This example shows how to create a text markup annotation that highlights a text in a PDF document and specify the annotation properties.</p>

<p>To add a text markup annotation to a page, call one of <a href="https://documentation.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.AddTextMarkupAnnotation.method(sbaKFQ)"><u>PdfDocumentProcessor.AddTextMarkupAnnotation</u></a> overload methods, where specify the page number and a page area  corresponding to a text that should be annotated on this page.  Note that if a specified page area does not correspond to a text on the page, the annotation is not created and <strong>PdfDocumentProcessor.AddTextMarkupAnnotation</strong> overload methods return <strong>null</strong>.</p>
<br/>
