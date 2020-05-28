
using System;
using System.Diagnostics;
using System.IO;

// Biblioteca iTextSharp com suas extensões
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GerandoPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando o coumento com de folha usada
            using (Document doc = new Document(PageSize.A4))
            {

                // Setando margens na sequência: esquerdo, em cima, direito e em baixo
                doc.SetMargins(40, 40, 40, 80);
                // Adicionando as configuracoes
                doc.AddCreationDate();

                // Caminho para criação do aqrquivo .pdf 
                string path = @"C:\teste.pdf";

                // Criando o arquivo PDF em branco
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

                doc.Open();

                Paragraph paragraph = new Paragraph(String.Empty, new Font(Font.NORMAL, 14));
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph.Add("=== TESTE === \n");

                paragraph.Font = new Font(Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold);
                paragraph.Add("=== TESTE negrito === \n");

                Paragraph loremIpsum = new Paragraph(String.Empty, new Font(Font.NORMAL, 14));

                string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam tincidunt molestie eros. Integer elementum dolor ullamcorper velit sodales mollis. Sed bibendum nec justo non scelerisque. Donec volutpat nisi sed leo porta, at consequat purus mollis. Duis vel est metus. Suspendisse tincidunt sed eros at sollicitudin. Praesent ac diam vehicula lorem dignissim consequat in vel nibh. Ut in libero sit amet ligula sollicitudin mollis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam tincidunt molestie eros. Integer elementum dolor ullamcorper velit sodales mollis. Sed bibendum nec justo non scelerisque. Donec volutpat nisi sed leo porta, at consequat purus mollis. Duis vel est metus. Suspendisse tincidunt sed eros at sollicitudin. Praesent ac diam vehicula lorem dignissim consequat in vel nibh. Ut in libero sit amet ligula sollicitudin mollis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam tincidunt molestie eros. Integer elementum dolor ullamcorper velit sodales mollis. Sed bibendum nec justo non scelerisque. Donec volutpat nisi sed leo porta, at consequat purus mollis. Duis vel est metus. Suspendisse tincidunt sed eros at sollicitudin. Praesent ac diam vehicula lorem dignissim consequat in vel nibh. Ut in libero sit amet ligula sollicitudin mollis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam tincidunt molestie eros. Integer elementum dolor ullamcorper velit sodales mollis. Sed bibendum nec justo non scelerisque. Donec volutpat nisi sed leo porta, at consequat purus mollis. Duis vel est metus. Suspendisse tincidunt sed eros at sollicitudin. Praesent ac diam vehicula lorem dignissim consequat in vel nibh. Ut in libero sit amet ligula sollicitudin mollis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam tincidunt molestie eros. Integer elementum dolor ullamcorper velit sodales mollis. Sed bibendum nec justo non scelerisque. Donec volutpat nisi sed leo porta, at consequat purus mollis. Duis vel est metus. Suspendisse tincidunt sed eros at sollicitudin. Praesent ac diam vehicula lorem dignissim consequat in vel nibh. Ut in libero sit amet ligula sollicitudin mollis.";

                loremIpsum.Add(text);

                doc.Add(paragraph);
                doc.Add(loremIpsum);

                //Abrindo o arquivo após cria-lo
                Process.Start(path);
            }
        }
    }
}
