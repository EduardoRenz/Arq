

using System;
using System.IO;

namespace arq
{
   public partial class Principal
    {
        private void CopiaArquivos(string origem,string destino)
        {
            try
            {
                File.Copy(origem, destino, true);
                Console.WriteLine("Copiado");
                string[] er = new string[] { "Sucesso", " : Arquivo Copiado \n" };
                percent = (100 * currentArq) / selecionarArquivo.FileNames.Length;
                bgw.ReportProgress(percent, er);

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}", e.Message);
                string[] er = new string[] { "Erro"," : "+ e.Message.ToString() + "\n" };
                bgw.ReportProgress(percent, er);
            }
        }
     }
  }

