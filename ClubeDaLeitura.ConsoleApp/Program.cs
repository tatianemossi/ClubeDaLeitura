using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listaEmprestimo = new Emprestimo[10];
            Revista revista1 = new Revista("Especial", 12, 2018, true, "Rosa", "123", 1);
            Amigo amigo1 = new Amigo("Tatiane", "Thiago", "49991846942", "Rua São José, 239 - Apto 301 - Coral");

            if (revista1.Disponivel)
            {
                listaEmprestimo[0] = new Emprestimo(revista1, amigo1, new DateTime(2022, 3, 2), new DateTime(2022, 3, 12));
                revista1.Disponivel = false;
            }

            Revista revista2 = new Revista("Especial", 32, 2021, true, "Azul", "456", 2);
            Amigo amigo2 = new Amigo("Thiago", "Tatiane", "49999537888", "Rua São José, 239 - Apto 301 - Coral");

            if (revista2.Disponivel)
            {
                listaEmprestimo[1] = new Emprestimo(revista2, amigo2, new DateTime(2022, 3, 5), new DateTime(2022, 3, 15));
                revista2.Disponivel = false;
            }

            //teste para verificar se faz a criação do empréstimo com a revista indisponível
            if (revista2.Disponivel)
            {
                listaEmprestimo[2] = new Emprestimo(revista2, amigo2, new DateTime(2022, 3, 5), new DateTime(2022, 3, 15));
                revista2.Disponivel = false;
            }

            Revista revista3 = new Revista("Ediçao de Lançamento", 22, 2022, true, "Amarela", "789", 3);
            Amigo amigo3 = new Amigo("Vinicius", "Ademir", "49991262101", "Rua Lisandro Luiz Vieira, 37");

            if (revista3.Disponivel)
            {
                listaEmprestimo[3] = new Emprestimo(revista3, amigo3, new DateTime(2022, 3, 12), new DateTime(2022, 3, 22));
                revista3.Disponivel = false;
            }

            Revista revista4 = new Revista("Especial", 58, 2021, true, "Verde", "852", 4);
            Amigo amigo4 = new Amigo("Joao", "Maria", "4932332121", "Rua 1234, 23");

            if (revista4.Disponivel)
            {
                listaEmprestimo[4] = new Emprestimo(revista4, amigo4, new DateTime(2022, 3, 15), new DateTime(2022, 3, 25));
                revista4.Disponivel = false;
            }

            listaEmprestimo[1].ConcluirEmprestimo(DateTime.Today);
            revista2.Disponivel = true;

            if (revista2.Disponivel)
            {
                listaEmprestimo[1] = new Emprestimo(revista2, amigo2, new DateTime(2022, 3, 5), new DateTime(2022, 3, 15));
                revista2.Disponivel = false;
            }

            VisualizarEmprestimosDia(listaEmprestimo);
            Console.WriteLine();

            VisualizarEmprestimosMes(listaEmprestimo);           

            Console.ReadLine();
        }

        private static void VisualizarEmprestimosDia(Emprestimo[] listaEmprestimo)
        {            
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Empréstimos do Dia: ");
            Console.ResetColor();

            for (int i = 0; i < listaEmprestimo.Length; i++)
            {
                if (listaEmprestimo[i] != null && listaEmprestimo[i].DataEmprestimo == DateTime.Today)
                {                    
                    Console.WriteLine($"Amigo: {listaEmprestimo[i].Amigo.NomeDoAmigo} - Número da Edição da Revista: {listaEmprestimo[i].Revista.NumeroDaEdicao} - " +
                       $"Data Empréstimo: {listaEmprestimo[i].DataEmprestimo.ToString("dd/MM/yyyy")} - Data Limite Devolução: {listaEmprestimo[i].DataLimiteDevolucao.ToString("dd/MM/yyyy")}");
                }
            }
        }

        public static void VisualizarEmprestimosMes(Emprestimo[] listaEmprestimo)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Empréstimos do Mês: ", ConsoleColor.Magenta);
            Console.ResetColor();

            for (int i = 0; i < listaEmprestimo.Length; i++)
            {
                DateTime dataInicio = new DateTime(2022, 3, 1);
                DateTime dataFinal = new DateTime(2022, 3, 31);

                if (listaEmprestimo[i] != null && listaEmprestimo[i].DataEmprestimo >= dataInicio && listaEmprestimo[i].DataEmprestimo <= dataFinal)
                {                    
                    Console.WriteLine($"Amigo: {listaEmprestimo[i].Amigo.NomeDoAmigo} - Número da Edição da Revista: {listaEmprestimo[i].Revista.NumeroDaEdicao} - " +
                        $"Data Empréstimo: {listaEmprestimo[i].DataEmprestimo.ToString("dd/MM/yyyy")} - Data Limite Devolução: {listaEmprestimo[i].DataLimiteDevolucao.ToString("dd/MM/yyyy")}");
                }
            }
        }
    }
}
