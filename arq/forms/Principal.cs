﻿using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

//COISAS A FAZER
// Botão OK/Cancelar
// Localizador de arquivos como origem
// Corrigir copia de diretorio inteiro

namespace arq
{
    public partial class Principal : Form
    {
        //Declarações iniciais
        Funcoes f = new Funcoes();
        private FolderBrowserDialog fbd = new FolderBrowserDialog();
        private DialogResult dr;
        public  int percent = 0;
        private int currentArq = 0;
        public Principal()
        {
            InitializeComponent();
        }
//======================================================== RODA AO CLICAR NO BOTÂO ================================================
        private void button1_Click(object sender, EventArgs e)
        {
            if (!bgw.IsBusy)
            {
                ok.Enabled = false;
      
            if (File.Exists(selecionarArquivo.FileNames[0]) || Directory.Exists(selecionarPasta.SelectedPath))
            {
                bgw.RunWorkerAsync();
            }
            else
            {
                    ok.Enabled = true;
                MessageBox.Show("Não foi encontrado arquivo ou diretorio do caminho de origem");
            }

            }
            else
            {
                MessageBox.Show("Não é possivel copiar agora, programa está ocupado.");
            }

        }
    

        private string VerificaDestino(string destino, string nome)
        {
            if (destino[destino.Length -1] == '\\') {
                destino = destino + nome;
                
            }
            return destino;

        }

        //================================================================= THREAD ===============================================================================
        // Inicia a Thread -----------
        private void BgWork_copiar(object sender, DoWorkEventArgs e)
        {
            currentArq = 1;  
            string[] report = new string[] { "tipo", "mensagem" };
            if (radioArqs.Checked) // Se são arquvos
            {
                for (int x = 0; x < selecionarArquivo.FileNames.Length; x++)
                {
                    report =  new string[] { "","Copiando: " + selecionarArquivo.SafeFileNames[x] + " para " + VerificaDestino(destino.Text, selecionarArquivo.SafeFileNames[x]) + "\n"};
                    bgw.ReportProgress(0,report);
                    CopiaArquivos(selecionarArquivo.FileNames[x], VerificaDestino(destino.Text, selecionarArquivo.SafeFileNames[x]));
                    currentArq++;
                }
            }
            else // Se são diretórios
            {
                report = new string[] { "", "Copiando pasta:" + Path.GetFileName(selecionarPasta.SelectedPath) + " para " + VerificaDestino(destino.Text, Path.GetFileName(selecionarPasta.SelectedPath)) + " \n" };
            }
        }
        // Retorna mudanças no processo ------------
        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string[]   reports = e.UserState as string[];
            if(e.UserState != null)
            {

            
            switch (reports[0])
            {
                case "Sucesso":
                    f.sucess(log, reports[0] + reports[1]);
                    break;
                case "Erro":
                    f.erro(log, reports[0] + reports[1]);
                break;
                case "Alert":
                    f.alert(log, reports[0] + reports[1]);
                    break;
                default:
                    log.AppendText(reports[0] + reports[1]);
                    break;
            }
            }
            if (e != null)
            {
                barraProgresso.Value = e.ProgressPercentage;
                Console.WriteLine(e.ProgressPercentage);
            }

        }
        // Thread Terminada ----------
        public void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string[] reports = e.UserState as string[];
            log.AppendText(" Concluido \n");
            ok.Enabled = true;
        }
        private void btSeleciona_Click(object sender, EventArgs e)
        {
            
            if (radioArqs.Checked)
            {
                dr = this.selecionarArquivo.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if(selecionarArquivo.FileNames.Length > 1)
                    {
                        origem.Text = "Varios arquivos";
                    }
                    else
                    {
                         origem.Text = selecionarArquivo.FileName;
                    }
                }
            }
            else
            {
                dr = this.selecionarPasta.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Console.WriteLine(selecionarPasta.SelectedPath);
                    origem.Text = selecionarPasta.SelectedPath;
                }     
            }
        }

        // ============== GUARDADOR =============
        //   NetworkCredential myCred = new NetworkCredential(BoxUser.Text, BoxSenha.Text,newdestino);
        //    NetworkConnection n = new NetworkConnection(newdestino, myCred);
        // Conecta c = new Conecta(newdestino,BoxUser.Text, BoxSenha.Text);
        // bgw.RunWorkerAsync(manda);
        // bgw.DoWork += (obj, e) =>  f.copiar(origem, destino);
    }
}
