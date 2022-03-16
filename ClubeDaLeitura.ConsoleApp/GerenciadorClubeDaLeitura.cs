using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public class GerenciadorClubeDaLeitura
    {
        Revista[] listaRevistas = new Revista[10];
        int indiceRevista = 0;

        Amigo[] listaAmigos = new Amigo[10];
        int indiceAmigo = 0;

        Emprestimo[] listaEmprestimo = new Emprestimo[10];
        int indiceEmprestimo = 0;

        Caixa[] listaCaixa = new Caixa[10];
        int indiceCaixa = 0;

        Notificador notificador = new Notificador();

        public void Gerenciar()
        {
            GerenciadorRevista gerenciadorRevista = new GerenciadorRevista(listaRevistas, indiceRevista);
            GerenciadorCaixa gerenciadorCaixa = new GerenciadorCaixa(listaCaixa, indiceCaixa);      
            GerenciadorEmprestimo gerenciadorEmprestimo = new GerenciadorEmprestimo(listaEmprestimo, indiceEmprestimo);
            GerenciadorAmigo gerenciadorAmigo = new GerenciadorAmigo(listaAmigos, indiceAmigo);

            while (true)
            {
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.MostrarMenuOpcoes();

                if (menuPrincipal.EhSair())
                    break;

                else if (menuPrincipal.EhOpcaoInvalida())
                    notificador.ApresentarMensagem("Opção inválida", ConsoleColor.Red);

                else if (menuPrincipal.EhGerenciarRevistas())
                    gerenciadorRevista.GerenciarRevista();

                else if (menuPrincipal.EhGerenciarCaixas())
                    gerenciadorCaixa.GerenciarCaixa();

                else if (menuPrincipal.EhGerenciarAmigos())
                    gerenciadorAmigo.GerenciarAmigo();


                else if (menuPrincipal.EhGerenciarEmprestimos())
                    gerenciadorEmprestimo.GerenciarEmprestimo(listaAmigos, listaRevistas);

                
                Console.ReadLine();
            }
        }        
    }
}
