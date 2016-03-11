﻿

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
                percent = (100 * arqAtual) / numArqs;
                bgw.ReportProgress(percent);
                File.Copy(origem, destino, true);
                string[] er = new string[] { "Sucesso", " : Arquivo Copiado \n" };

                bgw.ReportProgress(percent, er);
                arqAtual++;
            }
            catch (Exception e)
            {
                string[] er = new string[] { "Erro", " : " + e.Message.ToString() + "\n" };
                bgw.ReportProgress(100, er);
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
                PreCopiaDiretorios(diretorio.FullName, destino + "\\" + diretorio.Name);
            }
        } // Pre Copia de diretorios
        private void PreCopiaUnica(string destino) // Copia unica do arquvo
        {
            if (radioArqs.Checked) // Se são arquvos
            {
                numArqs = selecionarArquivo.FileNames.Length;
                for (int x = 0; x < selecionarArquivo.FileNames.Length; x++)
                {
                    Reportar("", "Copiando: " + selecionarArquivo.SafeFileNames[x] + "\n", barraProgresso.Value);
                    CopiaArquivos(selecionarArquivo.FileNames[x], VerificaDestino(destino, selecionarArquivo.SafeFileNames[x]));
                   
                }
            }
            else // Se são diretórios
            {
                numArqs = f.numArquivos(selecionarPasta.SelectedPath);
                Reportar("", "Copiando pasta:" + Path.GetFileName(selecionarPasta.SelectedPath) + " para " + VerificaDestino(destino, Path.GetFileName(selecionarPasta.SelectedPath)) + " \n", barraProgresso.Value);
                PreCopiaDiretorios(selecionarPasta.SelectedPath, destino);     
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
            decimal ff = ffMinimo;
            do
            {
                arqAtual = 1;
                novoDestino = f.subsituidor("FF", destino.Text, ff.ToString());
                Reportar("", " FF : " + ff + " ====================== \n", 100);
                if (f.verificaString("PP", novoDestino))
                {
                    for (int pp = 2; pp <= 5; pp++)
                    {
                        arqAtual = 1;
                        novoDestino = f.subsituidor("PP", novoDestino, pp.ToString());
                        Reportar("", " -- PP : " + pp + " ---------------------\n", barraProgresso.Value);
                        PreCopiaUnica(novoDestino);
                        novoDestino = destino.Text;
                        novoDestino = f.subsituidor("FF", destino.Text, ff.ToString());
                    }
                }
                else
                {
                    PreCopiaUnica(novoDestino);
                    novoDestino = destino.Text;
                }
                ff++;
            } while (ff <= ffMaximo);

            novoDestino = destino.Text;
        }
        private string VerificaDestino(string destino, string nome)
        {
            if (destino[destino.Length - 1] == '\\')
            {
                destino = destino + nome;
            }
            return destino;

        } // Ajusta arquivo no destino, baseado na variavel de destino 
        private string setModoEnvio(string destino)
        {
            if (!f.verificaString("FF", destino) && (!f.verificaString("PP", destino))) // Se não tiver var de Filial
            {
                return "one";
            }
            else
            {
                return "FFPP";
            }
        }
    }
}



