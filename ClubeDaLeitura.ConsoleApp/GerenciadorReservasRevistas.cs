using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class GerenciadorReservasRevistas
    {
        ReservaRevista[] ListaReservaRevistas;
        int IndiceReservas;
        Revista[] ListaRevista;
        Amigo[] ListaAmigo;        
        Notificador notificador = new Notificador();
        GerenciadorEmprestimo gerenciadorDeEmprestimo;
                        
        public GerenciadorReservasRevistas(ReservaRevista[] reservaRevistas, int indice, Revista[] revistas,
            Amigo[] amigos, GerenciadorEmprestimo gerenciadorEmprestimo)
        {
            ListaReservaRevistas = reservaRevistas;
            IndiceReservas = indice;
            ListaRevista = revistas;
            ListaAmigo = amigos;      
            gerenciadorDeEmprestimo = gerenciadorEmprestimo;
        }

        public string opcaoReserva;

        public void GerenciarReservaRevista()
        {
            while (true)
            {
                notificador.ApresentarMensagem("Menu Reservas: ", ConsoleColor.Magenta);

                Console.WriteLine("Digite 1 para Adicionar Reserva");

                Console.WriteLine("Digite 2 para Editar Reserva");

                Console.WriteLine("Digite 3 para Excluir Reserva");

                Console.WriteLine("Digite 4 para Visualizar Reservas");

                Console.WriteLine("Digite 5 para adicionar Empréstimo");

                Console.WriteLine("Digite s para sair");

                opcaoReserva = Console.ReadLine();

                Console.Clear();

                if (EhSair())
                    break;

                if (EhAdicionarReserva())
                    Adicionar();

                else if (EhEditarReserva())
                {
                    Visualizar();
                    Editar();
                }
                else if (EhVisualizarReservas())
                    Visualizar();

                else if (EhAdicionarEmprestimo())
                {
                    AdicionarEmprestimo();
                }

                else if (EhOpcaoInvalida())
                    notificador.ApresentarMensagem("Opção Inválida", ConsoleColor.Red);
            }
        }

        public void AdicionarEmprestimo()
        {
            gerenciadorDeEmprestimo.Adicionar();
        }

        public void Adicionar()
        {
            ReservaRevista reservaRevista = new ReservaRevista();

            #region Adicionar Amigo
            Console.WriteLine("Digite o nome do Amigo que fará a Reserva a Revista: ");
            string nomeAmigo = Console.ReadLine();
            int? indiceAmigo = null;

            for (int i = 0; i < ListaAmigo.Length; i++)
            {
                if (nomeAmigo == ListaAmigo[i]?.NomeDoAmigo)
                {
                    indiceAmigo = i;
                }
            }

            if (indiceAmigo == null)
            {
                notificador.ApresentarMensagem("Amigo não encontrado", ConsoleColor.DarkYellow);
                return;
            }

            for (int i = 0; i < ListaAmigo.Length; i++)
            {
                if (ListaAmigo[(int)indiceAmigo].Multa != 0)
                {
                    notificador.ApresentarMensagem("Não é possível reservar para esse amigo, pois ele tem multa em aberto!", ConsoleColor.Red);
                    return;
                }
            }

            reservaRevista.Amigo = ListaAmigo[(int)indiceAmigo];
            #endregion

            #region Adicionar Revista
            Console.WriteLine("Digite o nome da Revista: ");
            string nomeRevista = Console.ReadLine();
            int? indiceRevista = null;

            for (int i = 0; i < ListaRevista.Length; i++)
            {
                if (ListaRevista[i] != null)
                {
                    if (nomeRevista == ListaRevista[i].Nome && ListaRevista[i].Disponivel == true)
                        indiceRevista = i;
                }
            }

            if (indiceRevista == null)
                notificador.ApresentarMensagem("Revista não encontrada ou não está disponível", ConsoleColor.Red);
            else
            {
                ListaRevista[(int)indiceRevista].Disponivel = false;
                reservaRevista.Revista = ListaRevista[(int)indiceRevista];
            }
            #endregion

            #region Adicionar Data Reserva
            Console.WriteLine("Digite a Data da Reserva (dd/MM/AAAA): ");
            string dataDigitada = Console.ReadLine();
            DateTime dataReserva;
            if (DateTime.TryParse(dataDigitada, out dataReserva))
                reservaRevista.DataReserva = dataReserva;

            else
                notificador.ApresentarMensagem("Insira uma Data Válida (dd/MM/YYYY): ", ConsoleColor.Red);
            #endregion

            ListaReservaRevistas[IndiceReservas] = reservaRevista;
            IndiceReservas++;

            notificador.ApresentarMensagem("Reserva cadastrada!", ConsoleColor.Green);
        }

        public void Editar()
        {
            Console.WriteLine("Digite o Nome da Revista para localizar reserva");
            string nomeRevista = Console.ReadLine();

            var indiceReservaEditar = BuscarIndiceReserva(nomeRevista);

            if (indiceReservaEditar == null)
            {
                notificador.ApresentarMensagem("Reserva não localizada!", ConsoleColor.Red);
            }
            else
            {
                notificador.ApresentarMensagem("Menu Edição Reservas", ConsoleColor.Magenta);

                Console.WriteLine("Digite 1 para Editar o Amigo");

                Console.WriteLine("Digite 2 para Editar a Revista");

                Console.WriteLine("Digite 3 para Editar a Data da Reserva");

                Console.WriteLine("Digite s para sair");

                string opcaoEditarReserva = Console.ReadLine();

                Console.Clear();

                if (opcaoEditarReserva == "1")
                {
                    Console.WriteLine("Digite o novo Amigo");
                    ListaReservaRevistas[(int)IndiceReservas].Amigo.NomeDoAmigo = Console.ReadLine();
                }
                else if (opcaoEditarReserva == "2")
                {
                    Console.WriteLine("Digite a nova Revista");
                    ListaReservaRevistas[(int)IndiceReservas].Revista.Nome = Console.ReadLine();
                }
                else if (opcaoEditarReserva == "3")
                {
                    Console.WriteLine("Digite a nova Data do Empréstimo");
                    ListaReservaRevistas[(int)IndiceReservas].DataReserva = Convert.ToDateTime(Console.ReadLine());
                }
                else
                    return;

                notificador.ApresentarMensagem("Empréstimo Editado!", ConsoleColor.Green);
            }
        }

        public int? BuscarIndiceReserva(string nomeRevista)
        {
            for (int i = 0; i < ListaReservaRevistas.Length; i++)
            {
                if (ListaReservaRevistas[i] == null)
                {
                    return null;
                }
                if (nomeRevista == ListaReservaRevistas[i].Revista?.Nome)
                {
                    return i;
                }
            }
            return null;
        }

        public void Visualizar()
        {
            notificador.ApresentarMensagem("Reservas: ", ConsoleColor.Magenta);
            for (int i = 0; i < ListaReservaRevistas.Length; i++)
            {
                if (ListaReservaRevistas[i] != null)
                {
                    Console.WriteLine($"Amigo: {ListaReservaRevistas[i].Amigo.NomeDoAmigo}, " +
                        $"Revista: {ListaReservaRevistas[i].Revista.Nome}, " +
                        $"Data da Reserva: {ListaReservaRevistas[i].DataReserva}");
                }
            }
        }
                
        public bool EhAdicionarReserva()
        {
            return opcaoReserva == "1";
        }

        public bool EhEditarReserva()
        {
            return opcaoReserva == "2";
        }

        public bool EhVisualizarReservas()
        {
            return opcaoReserva == "4";
        }

        public bool EhAdicionarEmprestimo()
        {
            return opcaoReserva == "5";
        }

        public bool EhSair()
        {
            return opcaoReserva == "s";
        }

        public bool EhOpcaoInvalida()
        {
            return (opcaoReserva != "1" &&
                opcaoReserva != "2" &&
                opcaoReserva != "3" &&
                opcaoReserva != "4" &&
                opcaoReserva != "5" &&
                opcaoReserva != "s");
        }
    }
}
