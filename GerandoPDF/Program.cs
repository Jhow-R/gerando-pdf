
using System;
using System.Text;
using System.IO;
using System.Diagnostics;

// Biblioteca iTextSharp com suas extensões
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

// 
using MessagingToolkit.QRCode.Codec;

namespace GerandoPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Caminho para o arquivo .pdf 
            string path = @"C:\teste.pdf";

            // Criando o doumento com tamanho de folha
            using (Document doc = new Document(PageSize.A4))
            {
                // Setando margens na sequência: esquerdo, em cima, direito e em baixo
                doc.SetMargins(40, 40, 40, 80);
                // Adicionando as configuracoes
                doc.AddCreationDate();

                // Criando o arquivo PDF em branco
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

                doc.Open();

                Paragraph paragraph = new Paragraph(String.Empty, new Font(Font.NORMAL, 14));
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph.Add("TESTE\n");

                paragraph.Font = new Font(Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold);
                paragraph.Add("TESTE negrito\n");

                Paragraph loremIpsum = new Paragraph(String.Empty, new Font(Font.NORMAL, 14));

                string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam tincidunt molestie eros. Integer elementum dolor ullamcorper velit sodales mollis. Sed bibendum nec justo non scelerisque. Donec volutpat nisi sed leo porta, at consequat purus mollis. Duis vel est metus. Suspendisse tincidunt sed eros at sollicitudin. Praesent ac diam vehicula lorem dignissim consequat in vel nibh. Ut in libero sit amet ligula sollicitudin mollis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam tincidunt molestie eros. Integer elementum dolor ullamcorper velit sodales mollis. Sed bibendum nec justo non scelerisque. Donec volutpat nisi sed leo porta, at consequat purus mollis. Duis vel est metus. Suspendisse tincidunt sed eros at sollicitudin. Praesent ac diam vehicula lorem dignissim consequat in vel nibh. Ut in libero sit amet ligula sollicitudin mollis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam tincidunt molestie eros. Integer elementum dolor ullamcorper velit sodales mollis. Sed bibendum nec justo non scelerisque. Donec volutpat nisi sed leo porta, at consequat purus mollis. Duis vel est metus. Suspendisse tincidunt sed eros at sollicitudin. Praesent ac diam vehicula lorem dignissim consequat in vel nibh. Ut in libero sit amet ligula sollicitudin mollis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam tincidunt molestie eros. Integer elementum dolor ullamcorper velit sodales mollis. Sed bibendum nec justo non scelerisque. Donec volutpat nisi sed leo porta, at consequat purus mollis. Duis vel est metus. Suspendisse tincidunt sed eros at sollicitudin. Praesent ac diam vehicula lorem dignissim consequat in vel nibh. Ut in libero sit amet ligula sollicitudin mollis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam tincidunt molestie eros. Integer elementum dolor ullamcorper velit sodales mollis. Sed bibendum nec justo non scelerisque. Donec volutpat nisi sed leo porta, at consequat purus mollis. Duis vel est metus. Suspendisse tincidunt sed eros at sollicitudin. Praesent ac diam vehicula lorem dignissim consequat in vel nibh. Ut in libero sit amet ligula sollicitudin mollis.";

                loremIpsum.Add(text);

                QRCodeEncoder encoder = new QRCodeEncoder();

                encoder.QRCodeBackgroundColor = System.Drawing.Color.White;
                encoder.QRCodeForegroundColor = System.Drawing.Color.Black;
                encoder.CharacterSet = "UTF-8";
                encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                encoder.QRCodeScale = 6;
                encoder.QRCodeVersion = 0;
                encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;

                System.Drawing.Bitmap QRCode = encoder.Encode("https://github.com/zJhol/gerando-pdf");

                Paragraph image = new Paragraph(String.Empty, new Font(Font.NORMAL, 14));
                image.Add(Image.GetInstance(QRCode, System.Drawing.Imaging.ImageFormat.Png));

                doc.Add(paragraph);
                doc.Add(image);
                doc.Add(loremIpsum);                     

                Console.WriteLine(" === PDF GERADO COM SUCESSO === ");

                //Abrindo o arquivo após cria-lo
                Process.Start(path);
            }

            // Convertendo PDF para texto
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    sb.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

                Console.WriteLine("\n\n === TEXTOS DO ARQUIVO === \n");
                Console.WriteLine(sb.ToString());
            }
            Console.ReadLine();
        }
    }
}
