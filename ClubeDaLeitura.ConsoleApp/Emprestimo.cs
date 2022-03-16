using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Emprestimo
    {
        public Amigo Amigo;
        public Revista Revista;
        public DateTime DataEmprestimo;
        public DateTime DataLimiteDevolucao;
        public DateTime? DataDevolucao;

        public Emprestimo()
        {
            Revista = new Revista();
            Amigo = new Amigo();
        }

        public void ConcluirEmprestimo()
        {
            DataDevolucao = DateTime.Today;
        }
    }
}
