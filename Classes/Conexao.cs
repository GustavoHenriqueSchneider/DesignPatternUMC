using System;
using MySql.Data.MySqlClient;

public class Conexao {

  private static MySqlConnection con;
  
  private static string cs = @"server=sql.freedb.tech;userid=freedb_Manager;password=9TNyneK@3G9J5Jg;database=freedb_dbo_University";

  public void Conectar() {

    con = new MySqlConnection(cs);
    
    con.Open();
  }

  public void Desconectar() {

    con.Close();
  }

  public MySqlCommand ExecutarBusca(string sql) {

    MySqlCommand cmd = new MySqlCommand(sql, con);

    return cmd;
  }

  public void InserirValor(string sql) {

    MySqlCommand cmd = new MySqlCommand();

    cmd.Connection = con;

    cmd.CommandText = sql;

    cmd.ExecuteNonQuery();

    Console.WriteLine("\nOperação realizada com sucesso!");
  }
}