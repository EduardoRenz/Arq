using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
namespace arq
{
	public class Conecta // Responsavel pela conexão, acessos e credenciais.
	{
		public Conecta (string dominio,string user, string senha)
		{
					ProcessStartInfo PInfo;
					Process P;
                    string comando = @"/c net use " + dominio + " " + senha + " /user:" + user + "";
					PInfo = new ProcessStartInfo ("cmd", comando);
                    Console.WriteLine ("Dando credenciais para "+dominio+" "+senha+" /user:"+user+"\n");
					PInfo.UseShellExecute = false; //use shell
                    PInfo.CreateNoWindow = true; //nowindow
					P = Process.Start (PInfo);
					P.WaitForExit (1000); //give it some time to finish                                
                   	P.Close ();         
		}

	}
}



