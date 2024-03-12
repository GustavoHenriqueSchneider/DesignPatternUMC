using System;
using MySql.Data.MySqlClient;

public class Livro {
  
  private static int isbn { get; set; }
  private static string titulo { get; set; }
  private static string autor { get; set; }
  private static int ano { get; set; }
  private static string genero { get; set; }
  private static int edicao { get; set; }
  private static int quantidade { get; set; }


  public static void CadastrarLivro(Conexao con) {

    Console.WriteLine("\nIniciando o cadastro de livro...");

    Console.WriteLine("\nInsira o ISBN do livro:");
    isbn = int.Parse(Console.ReadLine());

    Console.WriteLine("\nPreencha o titulo do livro:");
    titulo = Console.ReadLine();

    Console.WriteLine("\nInforme o autor do livro:");
    autor = Console.ReadLine();

    Console.WriteLine("\nPreencha o ano do livro:");
    ano = int.Parse(Console.ReadLine());

    Console.WriteLine("\nInforme o genero do livro:");
    genero = Console.ReadLine();

    Console.WriteLine("\nInsira a edição do livro:");
    edicao = int.Parse(Console.ReadLine());

    Console.WriteLine("\nInforme a quantidade de livros disponiveis:");
    quantidade = int.Parse(Console.ReadLine());

    con.InserirValor($"INSERT INTO LIVRO (ISBN, Titulo, Autor, Ano, Genero, Edicao, Quantidade) VALUES ({isbn}, '{titulo}', '{autor}' , {ano}, '{genero}', {edicao}, {quantidade})");
  }

  public static void ListarLivros(Conexao con) {

    Console.WriteLine("\nListando livros...");

    MySqlCommand cmd = con.ExecutarBusca("SELECT * FROM LIVRO");

    using MySqlDataReader rdr = cmd.ExecuteReader();

    while (rdr.Read()) {

      Console.WriteLine($"\nISBN: {rdr.GetInt32(1)}\nTitulo: {rdr.GetString(2)}\nAutor: {rdr.GetString(3)}\nAno: {rdr.GetInt32(4)}\nGenero: {rdr.GetString(5)}\nEdicao: {rdr.GetInt32(6)}\nQuantidade: {rdr.GetInt32(7)}");
    }
  }

  public static void AtualizarLivro(Conexao con) {

    Console.WriteLine("\nIniciando a atualização de livro...");

    Console.WriteLine("\nInsira o ISBN do livro a ser atualizado:");
    isbn = int.Parse(Console.ReadLine());

    Console.WriteLine("\nPreencha o titulo do livro:");
    titulo = Console.ReadLine();

    Console.WriteLine("\nInforme o autor do livro:");
    autor = Console.ReadLine();

    Console.WriteLine("\nPreencha o ano do livro:");
    ano = int.Parse(Console.ReadLine());

    Console.WriteLine("\nInforme o genero do livro:");
    genero = Console.ReadLine();

    Console.WriteLine("\nInsira a edição do livro:");
    edicao = int.Parse(Console.ReadLine());

    Console.WriteLine("\nInforme a quantidade de livros disponiveis:");
    quantidade = int.Parse(Console.ReadLine());

    con.InserirValor($"UPDATE LIVRO SET Titulo = '{titulo}', Autor = '{autor}', Ano = {ano}, Genero = '{genero}', Edicao = {edicao}, Quantidade = {quantidade} WHERE ISBN = {isbn}");
  }

  public static void RemoverLivro(Conexao con) {

    Console.WriteLine("\nIniciando a remoção de livro...");

    Console.WriteLine("\nInforme o ISBN do livro a ser removido:");
    isbn = int.Parse(Console.ReadLine());

    con.InserirValor($"DELETE FROM LIVRO WHERE ISBN = {isbn}");
  }
}