using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class GerenciadorCaixa
    {
        Caixa[] listaCaixas;
        int indiceCaixa;
        Notificador notificador = new Notificador();

        public GerenciadorCaixa(Caixa[] caixas, int indice)
        {
            listaCaixas = caixas;
            indiceCaixa = indice;
        }

        public string opcaoCaixa;

        public void GerenciarCaixa()
        {
            while (true)
            {
                notificador.ApresentarMensagem("Menu Caixas: ", ConsoleColor.Magenta);

                Console.WriteLine("Digite 1 para Adicionar Caixa");

                Console.WriteLine("Digite 2 para Editar Caixa");

                Console.WriteLine("Digite 3 para Excluir Caixa");

                Console.WriteLine("Digite 4 para Visualizar Caixa");

                Console.WriteLine("Digite s para sair");

                opcaoCaixa = Console.ReadLine();

                Console.Clear();

                if (EhSair())
                {
                    break;
                }
                if (EhAdicionarCaixa())
                {
                    Adicionar();
                }
                else if (EhEditarCaixa())
                {
                    Visualizar();
                    Editar();
                }
                else if (EhExcluirCaixa())
                {
                    Visualizar();
                    Excluir();
                }
                else if (EhVisualizarCaixas())
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
            notificador.ApresentarMensagem("Caixas Cadastradas: ", ConsoleColor.Magenta);
            for (int i = 0; i < listaCaixas.Length; i++)
            {
                if (listaCaixas[i] != null)
                {
                    Console.WriteLine($"Cor: {listaCaixas[i].Cor}, Etiqueta: {listaCaixas[i].Etiqueta}, Número: {listaCaixas[i].Numero}");
                }
                else
                {
                    return;
                }
            }
        }        

        public void Excluir()
        {
            var indiceCaixaExcluir = BuscarIndiceCaixa();

            if (indiceCaixaExcluir == null)
            {
                notificador.ApresentarMensagem("Caixa não localizada!", ConsoleColor.Red);
            }
            else
            {
                listaCaixas[(int)indiceCaixaExcluir].Cor = null;
                listaCaixas[(int)indiceCaixaExcluir].Etiqueta = null;
                listaCaixas[(int)indiceCaixaExcluir].Numero = null;
            }
            notificador.ApresentarMensagem("Caixa excluída!", ConsoleColor.Green);
        }        

        public void Editar()
        {
            var indiceCaixaEditar = BuscarIndiceCaixa();

            if (indiceCaixaEditar == null)
            {
                notificador.ApresentarMensagem("Caixa não localizada!", ConsoleColor.Red);
            }
            else
            {
                notificador.ApresentarMensagem("Menu Editar Caixas", ConsoleColor.Magenta);

                Console.WriteLine("Digite 1 para Editar a Cor");

                Console.WriteLine("Digite 2 para Editar a Etiqueta");

                Console.WriteLine("Digite 3 para Editar o Número");

                Console.WriteLine("Digite s para sair");

                string opcaoEditarCaixa = Console.ReadLine();

                Console.Clear();

                if (opcaoEditarCaixa == "1")
                {
                    Console.WriteLine("Digite a nova Cor da Caixa: ");
                    listaCaixas[(int)indiceCaixa].Cor = Console.ReadLine();
                }
                else if (opcaoEditarCaixa == "2")
                {
                    Console.WriteLine("Digite a nova Etiqueta da Caixa: ");
                    listaCaixas[(int)indiceCaixa].Etiqueta = Console.ReadLine();
                }
                else if (opcaoEditarCaixa == "3")
                {
                    Console.WriteLine("Digite o novo Número da Caixa: ");
                    listaCaixas[(int)indiceCaixa].Numero = Convert.ToInt32(Console.ReadLine());
                }

                notificador.ApresentarMensagem("Caixa Editada!", ConsoleColor.Green);
            }
        }

        public void Adicionar()
        {
            Caixa caixa = new Caixa();

            Console.WriteLine("Digite o Cor da Caixa: ");
            caixa.Cor = Console.ReadLine();

            Console.WriteLine("Digite Etiqueta da Caixa: ");
            caixa.Etiqueta = Console.ReadLine();

            Console.WriteLine("Digite o número da Caixa: ");
            caixa.Numero = Convert.ToInt32(Console.ReadLine());

            listaCaixas[indiceCaixa] = caixa;
            indiceCaixa++;

            notificador.ApresentarMensagem("Caixa cadastrada!", ConsoleColor.Green);
        }

        public int? BuscarIndiceCaixa()
        {
            Console.WriteLine("Digite o número da Caixa que será editada/excluída");
            int numeroCaixa = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < listaCaixas.Length; i++)
            {
                if (numeroCaixa == listaCaixas[i]?.Numero)
                {
                    return i;
                }
            }
            return null;
        }

        public bool EhOpcaoInvalida()
        {
            if (opcaoCaixa != "1" &&
                opcaoCaixa != "2" &&
                opcaoCaixa != "3" &&
                opcaoCaixa != "4" &&
                opcaoCaixa != "s")
            {
                return true;
            }
            return false;
        }

        public bool EhVisualizarCaixas()
        {
            return opcaoCaixa == "4";
        }

        public bool EhExcluirCaixa()
        {
            return opcaoCaixa == "3";
        }

        public bool EhEditarCaixa()
        {
            return opcaoCaixa == "2";
        }

        public bool EhAdicionarCaixa()
        {
            return opcaoCaixa == "1";
        }

        public bool EhSair()
        {
            return opcaoCaixa == "s";
        }
    }
}
