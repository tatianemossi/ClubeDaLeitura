using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Revista
    {
        public string Nome;
        public string TipoDeColecao;
        public int? NumeroDaEdicao;
        public int? AnoDaRevista;
        public Caixa Caixa;

        public Revista()
        {
            Caixa = new Caixa();
        }
    }
}
