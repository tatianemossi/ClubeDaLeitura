using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Revista
    {
        public string Nome;
        public string TipoDeColecao;
        public int? NumeroDaEdicao;
        public int? AnoDaRevista;
        public bool Disponivel;
        public Caixa Caixa;        

        public Revista()
        {
            Disponivel = true;
            Caixa = new Caixa();
        }
    }
}
