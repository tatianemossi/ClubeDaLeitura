using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class GerenciadorEmprestimo
    {
        Emprestimo[] listaEmprestimos;
        int indiceEmprestimo;
        Revista[] listaRevista;
        Amigo[] listaAmigo;
        Notificador notificador = new Notificador();

        public GerenciadorEmprestimo(Emprestimo[] emprestimos, int indice, Revista[] revistas, Amigo[] amigos)
        {
            listaEmprestimos = emprestimos;
            indiceEmprestimo = indice;
            listaRevista = revistas;
            listaAmigo = amigos;
        }

        public string opcaoEmprestimo;

        public void GerenciarEmprestimo(Amigo[] listaAmigos, Revista[] listaRevistas)
        {
            while (true)
            {
                notificador.ApresentarMensagem("Menu Empréstimos: ", ConsoleColor.Magenta);

                Console.WriteLine("Digite 1 para Adicionar Empréstimos");

                Console.WriteLine("Digite 2 para Editar Empréstimos");

                Console.WriteLine("Digite 3 para Concluir Empréstimos");

                Console.WriteLine("Digite 4 para Visualizar Empréstimos em Aberto");

                Console.WriteLine("Digite 5 para Visualizar Empréstimos do Mês");

                Console.WriteLine("Digite s para sair");

                opcaoEmprestimo = Console.ReadLine();

                Console.Clear();


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

        public bool EhConcluirEmprestimos()
        {
            return opcaoEmprestimo == "3";
        }

        public bool EhVisualizarEmprestimosEmAberto()
        {
            return opcaoEmprestimo == "4";
        }

        public bool EhVisualizarEmprestimosMes()
        {
            return opcaoEmprestimo == "5";
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
                opcaoEmprestimo != "s")
            {
                return true;
            }
            return false;
        }

        public void Adicionar()
        {
            Emprestimo emprestimo = new Emprestimo();

            #region Adicionar Amigo
            Console.WriteLine("Digite o nome do Amigo que Pegou a Revista: ");
            string nomeAmigo = Console.ReadLine();
            int? indiceAmigo = null;

            for (int i = 0; i < listaAmigo.Length; i++)
            {
                if (nomeAmigo == listaAmigo[i]?.NomeDoAmigo)
                {
                    indiceAmigo = i;
                }
            }

            if (indiceAmigo == null)
            {
                notificador.ApresentarMensagem("Amigo não encontrado", ConsoleColor.DarkYellow);
                return;
            }

            for (int i = 0; i < listaAmigo.Length; i++)
            {
                if (listaAmigo[(int)indiceAmigo].Multa != 0)
                {
                    notificador.ApresentarMensagem("Não é possível emprestar para esse amigo, pois ele tem multa em aberto!", ConsoleColor.Red);
                    return;
                }
            }

            emprestimo.Amigo = listaAmigo[(int)indiceAmigo];
            #endregion

            #region Adicionar Revista
            Console.WriteLine("Digite o nome da Revista: ");
            string nomeRevista = Console.ReadLine();
            int? indiceRevista = null;

            for (int i = 0; i < listaRevista.Length; i++)
            {
                if (nomeRevista == listaRevista[i]?.Nome && listaRevista[i].Disponivel == true)
                    indiceRevista = i;
            }

            if (indiceRevista == null)
                notificador.ApresentarMensagem("Revista não encontrada ou não está disponível", ConsoleColor.Red);
            else
            {
                listaRevista[(int)indiceRevista].Disponivel = false;
                emprestimo.Revista = listaRevista[(int)indiceRevista];
            }
            #endregion

            #region Adicionar Data Empréstimo
            Console.WriteLine("Digite a Data do Empréstimo (dd/MM/AAAA): ");
            string dataDigitada = Console.ReadLine();
            DateTime dataEmprestimo;
            if (DateTime.TryParse(dataDigitada, out dataEmprestimo))
                emprestimo.DataEmprestimo = dataEmprestimo;

            else
                notificador.ApresentarMensagem("Insira uma Data Válida (dd/MM/YYYY): ", ConsoleColor.Red);
            #endregion

            VerificarDataLimiteDevolução(indiceRevista, emprestimo);

            listaEmprestimos[indiceEmprestimo] = emprestimo;
            indiceEmprestimo++;

            notificador.ApresentarMensagem("Empréstimo cadastrado!", ConsoleColor.Green);
        }

        public void VerificarDataLimiteDevolução(int? indiceRevista, Emprestimo emprestimo)
        {
            for (int i = 0; i < listaRevista.Length; i++)
            {
                emprestimo.DataLimiteDevolucao = (DateTime.Now.AddDays(listaRevista[(int)indiceRevista].Categoria.QuantidadeDiasEmprestimo));
            }

            notificador.ApresentarMensagem($"Data Limite para Devolução: {emprestimo.DataLimiteDevolucao}", ConsoleColor.DarkYellow);
        }

        public void Editar()
        {
            Console.WriteLine("Digite o Nome da Revista para localizar empréstimo");
            string nomeRevista = Console.ReadLine();

            var indiceEmprestimoEditar = BuscarIndiceEmprestimo(nomeRevista);

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

                Console.Clear();

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
                    listaEmprestimos[(int)indiceEmprestimoEditar].DataEmprestimo = Convert.ToDateTime(Console.ReadLine());
                }
                else if (opcaoEditarEmprestimo == "4")
                {
                    Console.WriteLine("Digite a nova Data Limite de Devolução");
                    listaEmprestimos[(int)indiceEmprestimoEditar].DataLimiteDevolucao = Convert.ToDateTime(Console.ReadLine());

                }

                notificador.ApresentarMensagem("Empréstimo Editado!", ConsoleColor.Green);
            }
        }

        public void ConcluirEmprestimo()
        {
            Console.WriteLine("Digite o Nome da Revista que será devolvida");
            string nomeRevistaDevolvida = Console.ReadLine();

            var indiceEmprestimoConcluir = BuscarIndiceEmprestimo(nomeRevistaDevolvida);

            if (indiceEmprestimoConcluir == null)
            {
                notificador.ApresentarMensagem("Item não encontrado", ConsoleColor.Red);
                return;
            }

            listaEmprestimos[(int)indiceEmprestimoConcluir].ConcluirEmprestimo();

            DisponibilizarRevista(nomeRevistaDevolvida);

            if (listaEmprestimos[(int)indiceEmprestimoConcluir].DataDevolucao < DateTime.Now)
            {
                listaEmprestimos[(int)indiceEmprestimoConcluir].Amigo.Multa = new decimal(10);
            }

            notificador.ApresentarMensagem("Devolução de revista concluída!", ConsoleColor.Green);
        }

        public void DisponibilizarRevista(string nomeRevistaDevolvida)
        {
            for (int i = 0; i < listaRevista.Length; i++)
            {
                if (nomeRevistaDevolvida == listaRevista[i]?.Nome)
                {
                    listaRevista[i].Disponivel = true;
                }
            }
        }

        public int? BuscarIndiceEmprestimo(string nomeRevistaDevolvida)
        {
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
            notificador.ApresentarMensagem("Empréstimos em Aberto: ", ConsoleColor.Magenta);
            for (int i = 0; i < listaEmprestimos.Length; i++)
            {
                if (listaEmprestimos[i] != null)
                {
                    if (listaEmprestimos[i]?.DataDevolucao == null &&
                        listaEmprestimos[i].Amigo.NomeDoAmigo != "" &&
                        listaEmprestimos[i].Revista.Nome != "")
                    {
                        Console.WriteLine($"Amigo: {listaEmprestimos[i].Amigo.NomeDoAmigo}, Revista: {listaEmprestimos[i].Revista.Nome}, " +
                            $"Data Empréstimo: {listaEmprestimos[i].DataEmprestimo}, Data Limite para Devolução: {listaEmprestimos[i].DataLimiteDevolucao}");
                    }
                    else
                        notificador.ApresentarMensagem("Não existem empréstimos em Aberto.", ConsoleColor.Green);
                }
            }
        }

        public void VisualizarEmprestimosMes()
        {
            Notificador notificador = new Notificador();
            notificador.ApresentarMensagem("Empréstimos do Mês: ", ConsoleColor.Magenta);

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
