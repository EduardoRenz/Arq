using System;
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
        public int percent = 0;
        public Principal()
        {
            InitializeComponent();
        }

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

        } // Ao clickar no botão  e se o diretorio de origem existe
        private void BgWork_copiar(object sender, DoWorkEventArgs e) // Inicia a Thread da copia
        {
            string[] report = new string[] { "tipo", "mensagem" };
            string modoEnvio = setModoEnvio(destino.Text);
            string novoDestino = VerificaDestino(destino.Text, Path.GetFileName(selecionarPasta.SelectedPath));
            switch (modoEnvio)
            {
                case "one": // APENAS UMA COPIA DIRETAMENTE
                    PreCopiaUnica(destino.Text);
                    break;
                case "FFPP":
                    PreMultiCopia();
                    break;
                default:
                    break;
            }
        }
        private string VerificaDestino(string destino, string nome)
        {
            if (destino[destino.Length - 1] == '\\') {
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
        private void Reportar(string tipo, string mensagem, int porcentagem)
        {
            string[] report = new string[2];
            report[0] = tipo; report[1] = mensagem;
            bgw.ReportProgress(porcentagem, report);
        } // Reportador para o log
      // Verifica condição de envio, se é FF PP, unico ou FFPP
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
            }

        }  // Retorna mudanças no processo ------------      
        public void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string[] reports = e.UserState as string[];
            log.AppendText(" Concluido \n");
            barraProgresso.Value = 0;
            ok.Enabled = true;
        } // Thread Terminada ----------
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

    }
}
