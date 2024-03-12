using System;
using MySql.Data.MySqlClient;

public class Aluno {

  private static string nome { get; set; }
  private static long rgm { get; set; }
  private static string dataNasc { get; set; }
  private static string curso { get; set; }
  private static int bolsista { get; set; }
  private static string rg { get; set; }
  private static string genero { get; set; }

  public static void CadastrarAluno(Conexao con) {

    Console.WriteLine("\nIniciando o cadastro de aluno...");

    Console.WriteLine("\nInsira o nome do aluno:");
    nome = Console.ReadLine();

    Console.WriteLine("\nPreencha o RGM do aluno:");
    rgm = long.Parse(Console.ReadLine());

    Console.WriteLine("\nInforme a data de nascimento do aluno no seguinte formado YYYY-MM-DD:");
    dataNasc = Console.ReadLine();

    Console.WriteLine("\nPreencha o nome do curso do aluno:");
    curso = Console.ReadLine();

    Console.WriteLine("\nInforme se o aluno é bolsista, informe SIM ou NÃO:");
    bolsista = Console.ReadLine() == "SIM" ? 1 : 0;

    Console.WriteLine("\nInsira o RG do aluno:");
    rg = Console.ReadLine();

    Console.WriteLine("\nInforme o genero do aluno, use M para masculino e F para feminino:");
    genero = Console.ReadLine();

    con.InserirValor($"INSERT INTO ALUNO (Nome, RGM, DataNascimento, Curso, Bolsista, RG, Genero) VALUES ('{nome}', {rgm}, '{dataNasc}' , '{curso}', {bolsista}, '{rg}', '{genero}')");
  }

  public static void ListarAlunos(Conexao con) {

    Console.WriteLine("\nListando alunos...");

    MySqlCommand cmd = con.ExecutarBusca("SELECT * FROM ALUNO");

    using MySqlDataReader rdr = cmd.ExecuteReader();

    while (rdr.Read()) {

        Console.WriteLine($"\nNome: {rdr.GetString(1)}\nRGM: {rdr.GetInt64(2)}\nData de Nascimento: {rdr.GetDateTime(3)}\nCurso: {rdr.GetString(4)}\nBolsista: {(rdr.GetInt32(5) == 0 ? "SIM" : "NÃO")}\nRG: {rdr.GetString(6)}\nGenero: {rdr.GetString(7)}");
    }
  }

  public static void AtualizarAluno(Conexao con) {

    Console.WriteLine("\nIniciando a atualização de aluno...");

    Console.WriteLine("\nInforme o RGM do aluno a ser atualizado:");
    rgm = Int64.Parse(Console.ReadLine());

    Console.WriteLine("\nInsira o nome do aluno:");
    nome = Console.ReadLine();

    Console.WriteLine("\nInforme a data de nascimento do aluno no seguinte formado YYYY-MM-DD:");
    dataNasc = Console.ReadLine();

    Console.WriteLine("\nPreencha o nome do curso do aluno:");
    curso = Console.ReadLine();

    Console.WriteLine("\nInforme se o aluno é bolsista, informe SIM ou NÃO:");
    bolsista = Console.ReadLine() == "SIM" ? 1 : 0;

    Console.WriteLine("\nInsira o RG do aluno:");
    rg = Console.ReadLine();

    Console.WriteLine("\nInforme o genero do aluno, use M para masculino e F para feminino:");
    genero = Console.ReadLine();

    con.InserirValor($"UPDATE ALUNO SET Nome = '{nome}', DataNascimento = '{dataNasc}', Curso = '{curso}', Bolsista = {bolsista}, RG = '{rg}', Genero = '{genero}' WHERE RGM = '{rgm}'");
  }

  public static void RemoverAluno(Conexao con) {

    Console.WriteLine("\nIniciando a remoção de aluno...");

    Console.WriteLine("\nInforme o RGM do aluno a ser removido:");
    rgm = long.Parse(Console.ReadLine());

    con.InserirValor($"DELETE FROM ALUNO WHERE RGM = '{rgm}'");
  }
}