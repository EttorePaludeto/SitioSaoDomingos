using SaoDomingos.Business;
using SaoDomingos.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using System.Collections;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Diagnostics;
using NFe.Classes;
using DFe.Utils;

namespace SaoDomingos.App.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {

            //LerEFDContribuicoes();

            AgruparPDFs();
        }

        private static void AgruparPDFs()
        {
            // Get some file names
            string[] files = GetFiles();

            // Open the output document
            PdfDocument outputDocument = new PdfDocument();

            // Iterate files
            foreach (string file in files)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);

                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // Get the page from the external document...
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add it to the output document.
                    outputDocument.AddPage(page);
                }
            }

            // Save the document...
            string filename = @"C:\Users\adm_3\Desktop\Trabalhos em Andamento\Advocacia - Ações PisCofins\Ação Recuperação PIS-COFINS sobre ICMS - Doces\Documentos Processo\Guias_COFINS_06.2015_a_02.2020";
            outputDocument.Save(filename);
            // ...and start a viewer.
           // Process.Start(filename);

        }

        private static string[] GetFiles()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\adm_3\Desktop\Trabalhos em Andamento\Advocacia - Ações PisCofins\Ação Recuperação PIS-COFINS sobre ICMS - Doces\COFINS");
            FileInfo[] fileInfos = dirInfo.GetFiles("*.pdf", SearchOption.AllDirectories);
            ArrayList list = new ArrayList();
            foreach (FileInfo info in fileInfos)
            {
                // HACK: Just skip the protected samples file...
                if (info.Name.IndexOf("protected") == -1)
                    list.Add(info.FullName);
            }
            return (string[])list.ToArray(typeof(string));
        }

        private static void LerEFDContribuicoes()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\adm_3\Desktop\Trabalhos em Andamento\Advocacia - Ações PisCofins\Ação Recuperação PIS-COFINS sobre ICMS - Grupo\Arquivos e Documentos Brutos\EFD Arquivos\");

            FileInfo[] files = dir.GetFiles("*.txt", SearchOption.AllDirectories);

            string linha;

            foreach (var item in files)
            {
                using (StreamReader arquivo = new StreamReader(item.FullName))
                {
                    while ((linha = arquivo.ReadLine()) != null)
                    {
                        if (linha.Substring(0, 6) == "|0000|")
                        {
                            Console.WriteLine("----------------------------------------------------------------------------------------------------");
                            Console.WriteLine(linha.ToString());
                            Console.WriteLine("                  ");
                        }
                        if (linha.Substring(0, 6) == "|M205|")
                        {
                            Console.WriteLine(linha.ToString());
                            Console.WriteLine("                  ");

                        }
                        if (linha.Substring(0, 6) == "|M605|")
                        {
                            Console.WriteLine(linha.ToString());
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                            Console.WriteLine("                  ");
                            break;
                        }
                      
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
