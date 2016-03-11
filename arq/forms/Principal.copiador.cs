

using System;
using System.IO;

namespace arq
{
    public partial class Principal
    {
        private void CopiaArquivos(string origem, string destino)
        {
            try
            {
                FileInfo origemInfo = new FileInfo(origem);
                if (Directory.Exists(destino))
                {
                    destino += '\\' + origemInfo.Name;
                }
                Console.WriteLine(origem + " para " + destino);
                File.Copy(origem, destino, true);
                string[] er = new string[] { "Sucesso", " : Arquivo Copiado \n" };
                // percent = (100 * currentArq) / selecionarArquivo.FileNames.Length;
                bgw.ReportProgress(barraProgresso.Value, er);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}", e.Message);
                string[] er = new string[] { "Erro", " : " + e.Message.ToString() + "\n" };
                bgw.ReportProgress(percent, er);
            }
        } //Executa a copia de fato
        private void PreCopiaDiretorios(string origem, string destino)
        {
            DirectoryInfo dirOrigem = new DirectoryInfo(origem);
            DirectoryInfo dirDestino = new DirectoryInfo(destino);
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
                PreCopiaDiretorios(diretorio.FullName, destino + "\\" + diretorio.Name);
            }
        } // Pre Copia de diretorios
        private void PreCopiaUnica(string destino) // Copia unica do arquvo
        {
            if (radioArqs.Checked) // Se são arquvos
            {
                for (int x = 0; x < selecionarArquivo.FileNames.Length; x++)
                {
                    Reportar("", "Copiando: " + selecionarArquivo.SafeFileNames[x] + "\n", (100 * x) / selecionarArquivo.FileNames.Length);
                    CopiaArquivos(selecionarArquivo.FileNames[x], VerificaDestino(destino, selecionarArquivo.SafeFileNames[x]));
                }
            }
            else // Se são diretórios
            {
                PreCopiaDiretorios(selecionarPasta.SelectedPath, destino);
                Reportar("", "Copiando pasta:" + Path.GetFileName(selecionarPasta.SelectedPath) + " para " + VerificaDestino(destino, Path.GetFileName(selecionarPasta.SelectedPath)) + " \n", barraProgresso.Value);
            }
        }
        private void PreMultiCopia() // Copia de vários
        {
            Console.WriteLine("Inicia a multicopia FF e PP");
            decimal ffMaximo;
            decimal ffMinimo;
            string[] report = new string[2];
            string novoDestino = "";

            if (f.verificaString("FF", destino.Text))
            {
                Console.WriteLine("setou para ter FF");
                ffMinimo = filMin.Value;
                ffMaximo = filMax.Value;
            }
            else
            {
                Console.WriteLine("não tera FF");
                ffMinimo = 1;
                ffMaximo = 1;
            }
            for (decimal ff = ffMinimo; ff <= ffMaximo; ff++)
            {
                novoDestino = f.subsituidor("FF", destino.Text, ff.ToString());
                if (f.verificaString("PP", novoDestino))
                {
                    for (int pp = 2; pp <= 5; pp++)
                    {
                        novoDestino = f.subsituidor("PP", novoDestino, pp.ToString());
                        Reportar("", " --> " + novoDestino + "\n", 100);
                        PreCopiaUnica(novoDestino);
                        novoDestino = destino.Text;
                        novoDestino = f.subsituidor("FF", destino.Text, ff.ToString());
                    }
                }
                else
                {
                    PreCopiaUnica(novoDestino);
                    Reportar("", "" + novoDestino + "\n", 100);
                    novoDestino = destino.Text;
                }
            }
            novoDestino = destino.Text;
        }

    }
}



