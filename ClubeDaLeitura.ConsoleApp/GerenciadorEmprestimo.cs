using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class GerenciadorEmprestimo
    {
        Emprestimo[] listaEmprestimos;
        int indiceEmprestimo;
        Notificador notificador = new Notificador();

        public GerenciadorEmprestimo(Emprestimo[] emprestimos, int indice)
        {
            listaEmprestimos = emprestimos;
            indiceEmprestimo = indice;
        }

        public string opcaoEmprestimo;

        public void GerenciarEmprestimo(Amigo[] listaAmigos, Revista[] listaRevistas)
        {
            while (true)
            {
                notificador.ApresentarMensagem("Menu Empréstimos: ", ConsoleColor.Magenta);

                Console.WriteLine("Digite 1 para Adicionar Empréstimos");

                Console.WriteLine("Digite 2 para Editar Empréstimos");

                Console.WriteLine("Digite 3 para Excluir Empréstimos");

                Console.WriteLine("Digite 4 para Concluir Empréstimos");

                Console.WriteLine("Digite 5 para Visualizar Empréstimos em Aberto");

                Console.WriteLine("Digite 6 para Visualizar Empréstimos do Mês");

                Console.WriteLine("Digite s para sair");

                opcaoEmprestimo = Console.ReadLine();


                if (EhSair())
                {
                    break;
                }
                if (EhAdicionarEmprestimos())
                {
                    Adicionar();
                }
                else if (EhEditarEmprestimos())
                {
                    VisualizarEmprestimosEmAberto();
                    Editar();
                }
                else if (EhExcluirEmprestimos())
                {
                    VisualizarEmprestimosEmAberto();
                    Excluir();
                }
                else if (EhConcluirEmprestimos())
                {
                    ConcluirEmprestimo();
                }
                else if (EhVisualizarEmprestimosEmAberto())
                {
                    VisualizarEmprestimosEmAberto();
                }
                else if (EhVisualizarEmprestimosMes())
                {
                    VisualizarEmprestimosMes();
                }

                else if (EhOpcaoInvalida())
                {
                    notificador.ApresentarMensagem("Opção Inválida", ConsoleColor.Red);
                }
            }
            
        }

        public bool EhAdicionarEmprestimos()
        {
            return opcaoEmprestimo == "1";
        }

        public bool EhEditarEmprestimos()
        {
            return opcaoEmprestimo == "2";
        }

        public bool EhExcluirEmprestimos()
        {
            return opcaoEmprestimo == "3";
        }

        public bool EhConcluirEmprestimos()
        {
            return opcaoEmprestimo == "4";
        }

        public bool EhVisualizarEmprestimosEmAberto()
        {
            return opcaoEmprestimo == "5";
        }

        public bool EhVisualizarEmprestimosMes()
        {
            return opcaoEmprestimo == "6";
        }

        public bool EhSair()
        {
            return opcaoEmprestimo == "s";
        }

        public bool EhOpcaoInvalida()
        {
            if (opcaoEmprestimo != "1" &&
                opcaoEmprestimo != "2" &&
                opcaoEmprestimo != "3" &&
                opcaoEmprestimo != "4" &&
                opcaoEmprestimo != "5" &&
                opcaoEmprestimo != "6" &&
                opcaoEmprestimo != "s")
            {
                return true;
            }
            return false;
        }

        public void Adicionar()
        {
            Emprestimo emprestimo = new Emprestimo();

            Console.WriteLine("Digite o nome do Amigo que Pegou a Revista: ");
            string nomeAmigoEmprestimo = Console.ReadLine();
            emprestimo.Amigo.NomeDoAmigo = Console.ReadLine();

            Console.WriteLine("Digite o nome da Revista: ");
            emprestimo.Revista.Nome = Console.ReadLine();

            Console.WriteLine("Digite a Data do Empréstimo (dd/MM/AAAA): ");
            emprestimo.DataEmprestimo = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite a Data limite para devolução da Revista (dd/MM/AAAA): ");
            emprestimo.DataLimiteDevolucao = Convert.ToDateTime(Console.ReadLine());

            listaEmprestimos[indiceEmprestimo] = emprestimo;
            indiceEmprestimo++;

            notificador.ApresentarMensagem("Empréstimo cadastrado!", ConsoleColor.Green);
        }

        public void Editar()
        {
            var indiceEmprestimoEditar = BuscarIndiceEmprestimo();

            if (indiceEmprestimoEditar == null)
            {
                notificador.ApresentarMensagem("Empréstimo não localizado!", ConsoleColor.Red);
            }
            else
            {
                notificador.ApresentarMensagem("Menu Edição Empréstimos", ConsoleColor.Magenta);

                Console.WriteLine("Digite 1 para Editar o Amigo");

                Console.WriteLine("Digite 2 para Editar a Revista");

                Console.WriteLine("Digite 3 para Editar a Data do Empréstimo");

                Console.WriteLine("Digite 4 para Editar a Data Limite de Devolução");

                Console.WriteLine("Digite s para sair");

                string opcaoEditarEmprestimo = Console.ReadLine();

                if (opcaoEditarEmprestimo == "1")
                {
                    Console.WriteLine("Digite o novo Amigo");
                    listaEmprestimos[(int)indiceEmprestimoEditar].Amigo.NomeDoAmigo = Console.ReadLine();
                }
                else if (opcaoEditarEmprestimo == "2")
                {
                    Console.WriteLine("Digite a nova Revista");
                    listaEmprestimos[(int)indiceEmprestimoEditar].Revista.Nome = Console.ReadLine();
                }
                else if (opcaoEditarEmprestimo == "3")
                {
                    Console.WriteLine("Digite a nova Data do Empréstimo");
                    //listaEmprestimos[(int)indiceEmprestimoEditar].DataEmprestimo = Console.ReadLine();
                }
                else if (opcaoEditarEmprestimo == "4")
                {
                    Console.WriteLine("Digite a nova Data Limite de Devolução");
                    //listaEmprestimos[(int)indiceEmprestimoEditar].DataLimiteDevolucao = Console.ReadLine();

                }

                notificador.ApresentarMensagem("Revista Editada!", ConsoleColor.Green);
            }
        }

        public void Excluir()
        {
            throw new NotImplementedException();
        }

        public void ConcluirEmprestimo()
        {
            var indiceEmprestimoConcluir = BuscarIndiceEmprestimo();

            if (indiceEmprestimoConcluir == null)
            {
                notificador.ApresentarMensagem("Item não encontrado", ConsoleColor.Red);
            }
            else if (indiceEmprestimoConcluir != null)
            {
                listaEmprestimos[(int)indiceEmprestimoConcluir].ConcluirEmprestimo();

            }

            notificador.ApresentarMensagem("Devolução de revista concluída!", ConsoleColor.Green);
        }

        public int? BuscarIndiceEmprestimo()
        {
            Console.WriteLine("Digite o Nome da Revista que será devolvida");
            string nomeRevistaDevolvida = Console.ReadLine();

            for (int i = 0; i < listaEmprestimos.Length; i++)
            {
                if (listaEmprestimos[i] == null)
                {
                    return null;
                }
                if (nomeRevistaDevolvida == listaEmprestimos[i].Revista?.Nome && listaEmprestimos[i].DataDevolucao == null)
                {
                    return i;
                }
            }

            return null;
        }

        public void VisualizarEmprestimosEmAberto()
        {
            Notificador notificador = new Notificador();
            notificador.ApresentarMensagem("Empréstimos em Aberto", ConsoleColor.Magenta);

            for (int i = 0; i < listaEmprestimos.Length; i++)
            {
                if (listaEmprestimos[i] != null && listaEmprestimos[i].DataEmprestimo == DateTime.Today)
                {
                    Console.WriteLine($"Amigo: {listaEmprestimos[i].Amigo.NomeDoAmigo} - Número da Edição da Revista: {listaEmprestimos[i].Revista.NumeroDaEdicao} - " +
                       $"Data Empréstimo: {listaEmprestimos[i].DataEmprestimo.ToString("dd/MM/yyyy")} - Data Limite Devolução: {listaEmprestimos[i].DataLimiteDevolucao.ToString("dd/MM/yyyy")}");
                }
            }
        }

        public void VisualizarEmprestimosMes()
        {
            Notificador notificador = new Notificador();
            notificador.ApresentarMensagem("Empréstimos do Mês", ConsoleColor.Magenta);

            for (int i = 0; i < listaEmprestimos.Length; i++)
            {
                DateTime dataInicio = new DateTime(2022, 3, 1);
                DateTime dataFinal = new DateTime(2022, 3, 31);

                if (listaEmprestimos[i] != null && listaEmprestimos[i].DataEmprestimo >= dataInicio && listaEmprestimos[i].DataEmprestimo <= dataFinal)
                {
                    Console.WriteLine($"Amigo: {listaEmprestimos[i].Amigo.NomeDoAmigo} - Número da Edição da Revista: {listaEmprestimos[i].Revista.NumeroDaEdicao} - " +
                        $"Data Empréstimo: {listaEmprestimos[i].DataEmprestimo.ToString("dd/MM/yyyy")} - Data Limite Devolução: {listaEmprestimos[i].DataLimiteDevolucao.ToString("dd/MM/yyyy")}");
                }
            }
        }
    }
    
}
