using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Notificador
    {
        public void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }
    }
}
