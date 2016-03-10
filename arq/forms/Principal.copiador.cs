

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
                FileInfo origemInfo = new FileInfo(origem);
                if (Directory.Exists(destino))
                {
                    destino += '\\'+ origemInfo.Name;
              }
                Console.WriteLine(origem + " para " + destino);
                    File.Copy(origem, destino, true);
                Console.WriteLine("Copiado");
                string[] er = new string[] { "Sucesso", " : Arquivo Copiado \n" };
               // percent = (100 * currentArq) / selecionarArquivo.FileNames.Length;
                bgw.ReportProgress(barraProgresso.Value, er);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}", e.Message);
                string[] er = new string[] { "Erro"," : "+ e.Message.ToString() + "\n" };
                bgw.ReportProgress(percent, er);
            }
        } //Executa a copia de fato
        private void PreCopiaDiretorios(string origem,string destino)
        {
            DirectoryInfo dirOrigem = new DirectoryInfo(origem);
            DirectoryInfo dirDestino= new DirectoryInfo(destino);
            DirectoryInfo[] dirs = dirOrigem.GetDirectories();
            FileInfo[] files = dirOrigem.GetFiles();
           
            if (!Directory.Exists(destino)) // Cria os diretorios/subdiretorios
              {
                Directory.CreateDirectory(destino);
               }
            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                Console.Write("Origem é: " + origem + "\\" + file.Name + " Destino é:" + destino + "\\" + file.Name + " \n");
                CopiaArquivos(origem + "\\" + file.Name, destino + "\\" + file.Name);
            }
            foreach (DirectoryInfo diretorio in dirs)
            {
               Console.WriteLine(diretorio.FullName);
               PreCopiaDiretorios(diretorio.FullName, destino+"\\"+diretorio.Name);
            }    
        } // Pre Copia de diretorios
        private void PreCopiaUnica() // Copia unica do arquvo
        {
            string[] report = new string[2];
            Console.WriteLine("Copiando uma vez sem variavel");
            if (radioArqs.Checked) // Se são arquvos
            {
                for (int x = 0; x < selecionarArquivo.FileNames.Length; x++)
                {
                    report[0] = ""; report[1] = "Copiando: "+ selecionarArquivo.SafeFileNames[x]+"\n";
                    bgw.ReportProgress((100 * x) / selecionarArquivo.FileNames.Length, report);
                    CopiaArquivos(selecionarArquivo.FileNames[x], VerificaDestino(destino.Text, selecionarArquivo.SafeFileNames[x]));
                }
            }
            else // Se são diretórios
            {
                PreCopiaDiretorios(selecionarPasta.SelectedPath,destino.Text);
                report = new string[] { "", "Copiando pasta:" + Path.GetFileName(selecionarPasta.SelectedPath) + " para " + VerificaDestino(destino.Text, Path.GetFileName(selecionarPasta.SelectedPath)) + " \n" };
            }
        }
     }
  }

