using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Emprestimo
    {
        public Amigo Amigo;
        public Revista Revista;
        public DateTime DataEmprestimo;
        public DateTime DataLimiteDevolucao;
        public DateTime? DataDevolucao;
               
        public Emprestimo(Revista revista, Amigo amigo, DateTime dataEmprestimo, DateTime dataLimiteDevolucao)
        {
            Revista = revista;
            Amigo = amigo;
            DataEmprestimo = dataEmprestimo;
            DataLimiteDevolucao = dataLimiteDevolucao;
        }

        public void ConcluirEmprestimo(DateTime dataDevolucao)
        {
            DataDevolucao = dataDevolucao;
        }        
    }
}
