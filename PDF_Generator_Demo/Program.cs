using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Asn1.Ocsp;

namespace PDF_Generator_Demo {
    class Student
    {
        public string Name { get; set; } = "Leonardo Decaprio";
        public string University { get; set; } = "MIT";
        public string Department { get; set; } = "CSE";
        public int RegNo { get; set; } = 10001;
    }
    class Program {
        static void Main(string[] args)
        {
            //var student = new Student();
            //var strBuilder = new StringBuilder();
            //strBuilder.Append("Generated test string for pdf document \n");
            //strBuilder.Append("Student Name: " + student.Name + "\n");
            //strBuilder.Append("University: " + student.University + "\n");
            //strBuilder.Append("Department: " + student.Department + "\n");
            //strBuilder.Append("Registration No: " + student.RegNo);

            //Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("Demo.pdf", FileMode.Create));
            //document.Open();
            //Paragraph paragraph = new Paragraph(strBuilder.ToString());
            //document.Add(paragraph);
            //document.Close();

            /** HTML print to PDF using iTExtSharp **/
            String htmlText = "<font  " +
                              " color=\"#0000FF\"><b><i>Title One</i></b></font><font   " +
                              " color=\"black\"><br><br>Some text here<br><br><br><font   " +
                              " color=\"#0000FF\"><b><i>Another title here   " +
                              " </i></b></font><font   " +
                              " color=\"black\"><br><br>Text1<br>Text2<br><OL><LI><DIV Style='color:green'>Hello world</DIV></LI><LI>Test html</LI></OL><br/>" +
                              "<table border='1'><tr><td style='color:red;text-align:right;width:20%'>123456</td><td style='color:green;width:60%'>78910</td><td style='color:red;width:20%'>ASFAFA</td></tr><tr><td style='color:red;text-align:right'>123456</td><td style='color:green;width:60%'>78910</td><td style='color:red;width:20%'>DAFSDGAFW</td></tr></table><br/>" +
                              "<div><ol><li>123456</li><li>123456</li><li>123456</li><li>123456</li></ol></div>";
            HtmlToPdf(htmlText, "PDFfile.pdf");
        }

        public static void HtmlToPdf(string html, string filePath) {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();
            //Image pdfImage = Image.GetInstance(Server.MapPath("logo.png"));
            //pdfImage.ScaleToFit(100, 50);
            //pdfImage.Alignment = iTextSharp.text.Image.UNDERLYING; pdfImage.SetAbsolutePosition(180, 760);
            //document.Add(pdfImage);
            iTextSharp.text.html.simpleparser.StyleSheet styles = new iTextSharp.text.html.simpleparser.StyleSheet();
            iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
            hw.Parse(new StringReader(html));
            document.Close();
        }
    }
}
