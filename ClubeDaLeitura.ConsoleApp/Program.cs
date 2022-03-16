using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gerenciadorClubeDaLeitura = new GerenciadorClubeDaLeitura();
            gerenciadorClubeDaLeitura.Gerenciar();
        }
    }
}
