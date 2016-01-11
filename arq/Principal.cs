using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private bool botaoOk = true;
        public Principal()
        {
            InitializeComponent();
        }
//======================================================== RODA AO CLICAR NO BOTÂO ================================================
        private void button1_Click(object sender, EventArgs e)
        {

            if(botaoOk){
                switchBotao();
                if (!bgw.IsBusy)
                {
                    barraProgresso.Value = 0;
                    if (Directory.Exists(origem.Text) || File.Exists(origem.Text))
                    {
                        bgw.RunWorkerAsync();
                    }
                    else
                    {
                        log = f.alert(log, "Não Existe o Diretorio ou arquivo de Origem \n");
                        switchBotao();
                    }
                }
                else
                {
                    log = f.alert(log, "Existe outra ação em andamento! \n");
                }
            }
            else{
                bgw.CancelAsync();
                Console.WriteLine("Pedido de cancelamento:"+ bgw.CancellationPending+"\n");
                string[] reportador = new string[2];
                reportador[0] = "Cancelar";
                reportador[1] = "Operação cancelada pelo usuário.";
                bgw.ReportProgress(0, reportador);
            }

         
        }
//================================================================= THREAD ===============================================================================
        // Inicia a Thread -----------
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            copy(origem.Text, destino.Text);
        }
        // Retorna mudanças no processo ------------
        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string[] retorno = e.UserState as string[];
           barraProgresso.Value = e.ProgressPercentage;
           switch (retorno[0])
           {    case"Erro":
                   log = f.erro(log, retorno[1] + "\n");
                 break;
               case"Alerta":
                 log = f.alert(log, retorno[1] + "\n");
               break;
               case "Sucesso":
               log = f.sucess(log, retorno[1] + "\n");
               break;
               case"Cancelar":
               log = f.alert(log, retorno[1] + "\n");
               break;
               default:
                     log.AppendText(retorno[0]+""+retorno[1]+"\n");
               break;
           }

        }
        // Thread Terminada ----------
        public void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          Console.WriteLine("Concluido: {0}", e.Result);
          log.AppendText("Concluido!\n");
          switchBotao();
        }
// ====================================================================== CODIGO DA COPIA ========================================================================
        public void copy(string origem,string destino)
        {
            string[] reportador = new string[2];
            string newdestino = destino;          
            bool copiando = true;
            int copiaAtual = Convert.ToInt32(filMin.Value);
            Console.WriteLine("Copy iniciado...\n");

            if (!f.verificaString("FF", destino) && (!f.verificaString("PP", destino))) // Se não tiver var de Filial
            {
              Conecta c = new Conecta(destino, BoxUser.Text, BoxSenha.Text);
              reportador[0] = "";
              reportador[1] = "Copiando para -> "+destino; 
              bgw.ReportProgress(100,reportador);
              string[] copiado = f.copiar(origem, destino);
              bgw.ReportProgress(100, copiado);
              copiando = false;
            }
            else if (!f.verificaString("FF", destino) && (f.verificaString("PP", destino))) // SE não tiver FF mas tiver PP
            {
                Conecta c = new Conecta(destino, BoxUser.Text, BoxSenha.Text);
                string destip = newdestino;
                for (int pdvIp = 2; pdvIp <= 5; pdvIp++)
                {
                    destip = f.subsituidor("PP", newdestino, pdvIp.ToString());
                    Console.WriteLine("PDV >> :" + destip + "\n");
                    reportador[0] = "Copiando para:";
                    reportador[1] = destip;
                    int percent = Convert.ToInt32(Math.Round(((100.00 / Convert.ToDouble(5)) * pdvIp)));
                    bgw.ReportProgress(percent, reportador);
                    string[] copiado = f.copiar(origem, destip);
                    bgw.ReportProgress(100, copiado);
                }
            }
            else  // ======= com variaveis ========
            {
                do
                {
                    newdestino = f.subsituidor("FF", destino, copiaAtual.ToString());
                    Conecta c = new Conecta(newdestino, BoxUser.Text, BoxSenha.Text);
 // ============================================================= SE TIVER PP =====================================================================
                    if (f.verificaString("PP", destino)) 
                    {
                        string destip = newdestino;
                        for (int pdvIp = 2; pdvIp <= 5; pdvIp++)
                        {
                            destip = f.subsituidor("PP", newdestino, pdvIp.ToString());
                            Console.WriteLine("PDV >> :" + destip + "\n");
                            reportador[0] = "Copiando para:";
                            reportador[1] = destip;
                            int percent = Convert.ToInt32(Math.Round(((100.00 / Convert.ToDouble(5)) * pdvIp)));
                            bgw.ReportProgress(percent, reportador);
                            string[] copiado =  f.copiar(origem, destip);
                            bgw.ReportProgress(100, copiado);
                        }
                    }
 // ============================================================= SE FOR APENAS FF =====================================================================
                    else
                    {
                            Console.WriteLine("Copiando para:" + newdestino + "\n");
                            // ** poem em lista para mandar para o dowork **
                            reportador[0] = "Copiando para";
                            reportador[1] = newdestino;
                            int percent = Convert.ToInt32(Math.Round(((100.00 / Convert.ToDouble(filMax.Value))*copiaAtual)));
                            bgw.ReportProgress(percent, reportador);
                            // *********************************************
                              string[] copiado =  f.copiar(origem,newdestino);
                              bgw.ReportProgress(percent, copiado);
                    }
                                  
                    copiaAtual++;
                } while ((copiando == true) && (copiaAtual <= filMax.Value));
            }  
       }
// ========================================================================== FUNCOES ============================================================================
        void switchBotao()
        {
            botaoOk = !botaoOk;
            ok.Enabled = !ok.Enabled;
            if (botaoOk== true)
            {
                ok.Text = "OK";
            }
            else
            {
                ok.Text = "Cancelar";
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
