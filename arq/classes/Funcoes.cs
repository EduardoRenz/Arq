using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arq
{
   public class Funcoes
    {
        //========================================================================== MENSAGENS ====================================================================
            public RichTextBox sucess( RichTextBox objeto,string valor)
            {
                objeto.AppendText(valor);
                objeto.SelectionStart = objeto.TextLength - valor.Length ;
                objeto.SelectionLength = valor.Length;
                objeto.SelectionColor = Color.Green;
                Console.WriteLine("Concluido: {0}", valor);
                return objeto;
            }
            public RichTextBox erro(RichTextBox objeto, string valor)
            {
                objeto.AppendText(valor);
                objeto.SelectionStart = objeto.TextLength - valor.Length;
                objeto.SelectionLength = valor.Length;
                objeto.SelectionColor = Color.Red;
                return objeto;
            }
            public RichTextBox alert(RichTextBox objeto, string valor)
            {
                objeto.AppendText(valor);
                objeto.SelectionStart = objeto.TextLength - valor.Length;
                objeto.SelectionLength = valor.Length;
                objeto.SelectionColor = System.Drawing.Color.FromArgb(221, 245, 65);
                Console.WriteLine("Alertando: {0}",valor);
                return objeto;     
            }

       //========================================================================== CHECKERS =====================================================================
       public bool verificaDiretorio(string caminho){ // Verifica se o caminho representa um diretorio ou um arquivo
           if ((File.GetAttributes(caminho) & FileAttributes.Directory) == FileAttributes.Directory)
           {
               Console.WriteLine(caminho + " É um diretorio!");
               return true;
           }
           else
           {
               Console.WriteLine(caminho + " É um arquivo!");
               return false;
           }
       }
       public bool verificaString(string busca, string texto) {
           var restring = new StringBuilder(texto);
           if (texto.Contains(busca))
           {
               Console.WriteLine("Encontrado:" + busca + " em " + texto);
               return true;         
           }
           else
           {
               return false;
           }
       }
        //========================================================================== ALTERADORES =================================================================
       public string subsituidor(string busca, string texto,string substitui) // altera partes de uma string para outro valor
       {
           var restring = new StringBuilder(texto);
           if (texto.Contains(busca))
           {
               restring.Replace(busca, substitui);
               Console.WriteLine(texto + " Aletrado para:" + restring.ToString());
           }
           else
           {
               Console.WriteLine("Não houve alterações em:"+texto);
           }
           return restring.ToString();
       }
        //========================================================================== AÇÔES =======================================================================
       public string[] copiar(string origem,string destino)
       {
           if (this.verificaDiretorio(origem))
           {
               string[] last = origem.Split(Path.DirectorySeparatorChar);
               Console.WriteLine("A ultima é: " + last[last.Length -1]);
               try
               {
                    //====================== copia se for Diretorios
                     Console.WriteLine("Iniciado copia de diretorio");
                     //Now Create all of the directories
                    foreach (string dirPath in Directory.GetDirectories(origem, "*",
                         SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(origem, destino));
                     //Copy all the files & Replaces any files with the same name
                     foreach (string newPath in Directory.GetFiles(origem, "*.*",
                         SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(origem, destino), true);
                     Console.WriteLine("Copiado");
                     string[] er = new string[] { "Sucesso", "Arquivo Copiado" };
                     return er;

               }
               catch (Exception e)
               {
                   Console.WriteLine("Erro: {0}", e.Message);
                   string[] er = new string[] { "Erro", e.Message.ToString() };
                   return er;

               }           
           }

// ============================================================================= ARQUIVO UNIVO ====================================================================
           else{
               Console.WriteLine("Iniciado copia de arquivo");
               try
               {
                   File.Copy(origem, destino, true);
                   Console.WriteLine("Copiado");
                   string[] er = new string[] { "Sucesso", "Arquivo Copiado" };
                   return er;
               }
               catch (Exception e)
               {
                   Console.WriteLine("Erro: {0}", e.Message);
                   string[] er = new string[]{"Erro",e.Message.ToString()};
                   return er;                      
               }
           }
       }
    }
    }


