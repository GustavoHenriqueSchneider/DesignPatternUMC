using System;
using static Conexao;
using static Aluno;
using static Livro;

// Gustavo Henrique Schneider - 11232400224
// Nathan Tavares da Silva - 11221101977

class Program {
  public static void Main (string[] args) {

    Conexao banco = new Conexao();

    banco.Conectar();

    int opcao;

    Console.WriteLine("Escolha qual opção deseja realizar:\n");

    do {

      Console.WriteLine("1 - Cadastrar Livro");
      Console.WriteLine("2 - Listar Livros");
      Console.WriteLine("3 - Atualizar Livro");
      Console.WriteLine("4 - Remover Livro");
      Console.WriteLine("5 - Cadastrar Aluno");
      Console.WriteLine("6 - Listar Alunos");
      Console.WriteLine("7 - Atualizar Aluno");
      Console.WriteLine("8 - Remover Aluno");
      Console.WriteLine("9 - Sair");

      Console.WriteLine("\n");
      
      opcao = int.Parse(Console.ReadLine());

      switch(opcao) {
        
        case 1:
          Livro.CadastrarLivro(banco);
          break;
        
        case 2:
          Livro.ListarLivros(banco);
          break;
        
        case 3:
          Livro.AtualizarLivro(banco);
          break;
        
        case 4:
          Livro.RemoverLivro(banco);
          break;
        
        case 5:
          Aluno.CadastrarAluno(banco);
          break;
        
        case 6:
          Aluno.ListarAlunos(banco);
          break;
        
        case 7:
          Aluno.AtualizarAluno(banco);
          break;
        
        case 8:
          Aluno.RemoverAluno(banco);
          break;
        
        case 9:
          Console.WriteLine("\nEncerrando a aplicação...");
          return;
        
        default:
            Console.WriteLine("\nOpção invalida!");
          break;
      }

      Console.WriteLine("\nDeseja realizar outra ação?\n");
      
    } while(opcao != 9);
  }
} 