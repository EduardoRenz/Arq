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
               //Console.WriteLine(texto + " Aletrado para:" + restring.ToString());
           }
           else
           {
              // Console.WriteLine("Não houve alterações em:"+texto);
           }
           return restring.ToString();
       }
        //========================================================================== AÇÔES =======================================================================
        public int numArquivos(string diretorio)
        {
            //DirectoryInfo directory = new DirectoryInfo(diretorio);
            string[] files = Directory.GetFiles(diretorio,"*",SearchOption.AllDirectories);

            return files.Length;
        }
    }
    }


