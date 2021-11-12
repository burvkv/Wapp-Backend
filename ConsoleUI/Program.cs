


using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {


            using (WordprocessingDocument doc =
                      WordprocessingDocument.Open(@"C:\\users\\burak.arslan\\desktop\\twmpc-debit.docx", true))
            {
                var document = doc.MainDocumentPart.Document;
  
        foreach (var text in document.Descendants<Text>()) // <<< Here
                {
                    if (text.Text.Contains("xusernamex"))
                    {
                        text.Text = text.Text.Replace("xusernamex", "replaced-text");
                    }
                }
            }











            //using (WordprocessingDocument wordDoc = WordprocessingDocument.Open
            //(@"C:\\users\\burak.arslan\\desktop\\twmpc-debit.docx", true))
            //{
            //    string docText = null;
            //    string docText2 = null;
            //    string docText3 = null;
            //    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
            //    {
            //        docText = sr.ReadToEnd();
            //        docText2 = sr.ReadToEnd();
            //        docText3 = sr.ReadToEnd();
            //    }

            //    Regex regexText = new Regex("xdatex");
            //    docText = regexText.Replace(docText, DateTime.Now.ToString("dd/MM/yyyy"));
            //    Regex regexText2 = new Regex("xusernamex");
            //    docText2 = regexText2.Replace(docText2, "Burak Arslan");
            //    Regex regexText3 = new Regex("xreceivernamex");
            //    docText3 = regexText3.Replace(docText3, "B Arslan");

            //    using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
            //    {
            //        sw.Write(docText);
            //        sw.Write(docText2);
            //        sw.Write(docText3);
            //    }

            //}
        }
    }


}

