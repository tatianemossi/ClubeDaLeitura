using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Revista
    {
        public string TipoDeColecao;
        public int NumeroDaEdicao;
        public int AnoDaRevista;
        public bool Disponivel;
        public Caixa Caixa;

        public Revista(string tipoDeColecao, int numeroDaEdicao, int anoDaRevista, bool disponivel, string corCaixa, string etiquetaCaixa, int numeroCaixa)
        {
            TipoDeColecao = tipoDeColecao;
            NumeroDaEdicao = numeroDaEdicao;
            AnoDaRevista = anoDaRevista;
            Disponivel = disponivel;

            Caixa = new Caixa
            {
                Cor = corCaixa,
                Etiqueta = etiquetaCaixa,
                Numero = numeroCaixa
            };
        }
    }
}
