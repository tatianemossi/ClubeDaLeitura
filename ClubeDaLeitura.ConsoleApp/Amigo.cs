namespace ClubeDaLeitura.ConsoleApp
{
    internal class Amigo
    {
        public string NomeDoAmigo;
        public string NomeDoResponsavel;
        public string Telefone;
        public string Endereco;

        public Amigo(string nome, string nomeDoResponsavel, string telefone, string endereco)
        {
            NomeDoAmigo = nome;
            NomeDoResponsavel = nomeDoResponsavel;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
