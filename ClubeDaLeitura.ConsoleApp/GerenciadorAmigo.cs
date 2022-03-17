using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class GerenciadorAmigo
    {
        Amigo[] listaAmigos;
        int indiceAmigo;
        Notificador notificador = new Notificador();

        public GerenciadorAmigo(Amigo[] amigos, int indice)
        {
            listaAmigos = amigos;
            indiceAmigo = indice;
        }

        public string opcaoAmigo;

        public void GerenciarAmigo()
        {
            while (true)
            {
                notificador.ApresentarMensagem("Menu Amigos: ", ConsoleColor.Magenta);

                Console.WriteLine("Digite 1 para Adicionar Amigos");

                Console.WriteLine("Digite 2 para Editar Amigos");

                Console.WriteLine("Digite 3 para Excluir Amigos");

                Console.WriteLine("Digite 4 para Visualizar Amigos");

                Console.WriteLine("Digite s para sair");

                opcaoAmigo = Console.ReadLine();

                if (EhSair())
                {
                    break;
                }
                if (EhAdicionarAmigo())
                {
                    Adicionar();
                }
                else if (EhEditarAmigo())
                {
                    Visualizar();
                    Editar();
                }
                else if (EhExcluirAmigos())
                {
                    Visualizar();
                    Excluir();
                }
                else if (EhVisualizarAmigos())
                {
                    Visualizar();
                }
                else if (EhOpcaoInvalida())
                {
                    notificador.ApresentarMensagem("Opção Inválida", ConsoleColor.Red);
                }
            }
        }

        public void Visualizar()
        {
            notificador.ApresentarMensagem("Amigos Cadastrados: ", ConsoleColor.Magenta);
            for (int i = 0; i < listaAmigos.Length; i++)
            {
                if (listaAmigos[i] != null)
                {
                    Console.WriteLine($"Nome: {listaAmigos[i].NomeDoAmigo}, Responsável: {listaAmigos[i].NomeDoResponsavel}, " +
                        $"Telefone: {listaAmigos[i].Telefone}, Endereço: {listaAmigos[i].Endereco}");
                }
                else
                {
                    return;
                }
            }
        }

        public void Excluir()
        {
            var indiceAmigoExcluir = BuscarIndiceAmigo();

            if (indiceAmigoExcluir == null)
            {
                notificador.ApresentarMensagem("Amigo não localizado!", ConsoleColor.Red);
            }
            else
            {
                listaAmigos[(int)indiceAmigoExcluir].NomeDoAmigo = null;
                listaAmigos[(int)indiceAmigoExcluir].NomeDoResponsavel = null;
                listaAmigos[(int)indiceAmigoExcluir].Telefone = null;
                listaAmigos[(int)indiceAmigoExcluir].Endereco = null;
            }
            notificador.ApresentarMensagem("Amigo excluído!", ConsoleColor.Green);
        }

        public void Editar()
        {
            var indiceAmigoEditar = BuscarIndiceAmigo();

            if (indiceAmigoEditar == null)
            {
                notificador.ApresentarMensagem("Amigo não localizado!", ConsoleColor.Red);
            }
            else
            {
                notificador.ApresentarMensagem("Menu Edição Amigos", ConsoleColor.Magenta);

                Console.WriteLine("Digite 1 para Editar o Nome");

                Console.WriteLine("Digite 2 para Editar o Nome do Responsável");

                Console.WriteLine("Digite 3 para Editar o Telefone");

                Console.WriteLine("Digite 4 para Editar o Endereço");

                Console.WriteLine("Digite s para sair");

                string opcaoEditarAmigo = Console.ReadLine();

                if (opcaoEditarAmigo == "1")
                {
                    Console.WriteLine("Digite o novo Nome");
                    listaAmigos[(int)indiceAmigoEditar].NomeDoAmigo = Console.ReadLine();
                }
                else if (opcaoEditarAmigo == "2")
                {
                    Console.WriteLine("Digite o novo Nome do Responsável");
                    listaAmigos[(int)indiceAmigoEditar].NomeDoResponsavel = Console.ReadLine();
                }
                else if (opcaoEditarAmigo == "3")
                {
                    Console.WriteLine("Digite o novo Telefone");
                    listaAmigos[(int)indiceAmigoEditar].Telefone = Console.ReadLine();
                }
                else if (opcaoEditarAmigo == "4")
                {
                    Console.WriteLine("Digite o novo Endereço");
                    listaAmigos[(int)indiceAmigoEditar].Endereco = Console.ReadLine();

                }

                notificador.ApresentarMensagem("Amigo Editado!", ConsoleColor.Green);
            }
        }

        public void Adicionar()
        {
            Amigo amigo = new Amigo();

            Console.WriteLine("Digite o nome do Amigo: ");
            amigo.NomeDoAmigo = Console.ReadLine();

            Console.WriteLine("Digite o nome do Responsável do Amigo: ");
            amigo.NomeDoResponsavel = Console.ReadLine();

            Console.WriteLine("Digite o Telefone do Amigo: ");
            amigo.Telefone = Console.ReadLine();

            Console.WriteLine("Digite o Endereço do Amigo: ");
            amigo.Endereco = Console.ReadLine();

            listaAmigos[indiceAmigo] = amigo;
            indiceAmigo++;

            notificador.ApresentarMensagem("Amigo cadastrado!", ConsoleColor.Green);
        }

        public int? BuscarIndiceAmigo()
        {
            Console.WriteLine("Digite o Nome do Amigo que será editado/excluído");
            string nomeAmigo = Console.ReadLine();

            for (int i = 0; i < listaAmigos.Length; i++)
            {
                if (nomeAmigo == listaAmigos[i]?.NomeDoAmigo)
                {
                    return i;
                }
            }
            return null;
        }

        public bool EhAdicionarAmigo()
        {
            return opcaoAmigo == "1";
        }

        public bool EhEditarAmigo()
        {
            return opcaoAmigo == "2";
        }

        public bool EhExcluirAmigos()
        {
            return opcaoAmigo == "3";
        }

        public bool EhVisualizarAmigos()
        {
            return opcaoAmigo == "4";
        }

        public bool EhSair()
        {
            return opcaoAmigo == "s";
        }

        public bool EhOpcaoInvalida()
        {
            if (opcaoAmigo != "1" &&
                opcaoAmigo != "2" &&
                opcaoAmigo != "3" &&
                opcaoAmigo != "4" &&
                opcaoAmigo != "s")
            {
                return true;
            }
            return false;
        }      
    }
}
