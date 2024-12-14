using System;
using Microsoft.Data.SqlClient;
internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "Server=DESKTOP-9LK813Q;Database=Funcionarios;Trusted_Connection=True;TrustServerCertificate=True";
        //ID, ativo, nome, idade, sexo, cargo, salario, departamento

        //Ativo?
        Console.WriteLine("Olá! Seja bem-vindo a nosso programa de armazenamento de dados! Você está empregado? 1 para sim / 0 para não");
        string ativo = Console.ReadLine();

        //Nome?
        Console.WriteLine("Por gentileza, nos informe seu nome: ");
        string nome = Console.ReadLine();

        //Idade?
        Console.WriteLine("Por gentileza, nos informe sua idade: ");
        int idade;
        if (int.TryParse(Console.ReadLine(), out idade))
        {
            if (idade >= 18)
            {
                Console.WriteLine("Idade validada com sucesso.");
            }
        }
        else
        {
            Console.WriteLine("Idade inválida! Você precisa de mais de 18 anos para trabalhar.");
        }

        //Sexo?
        Console.WriteLine("Por favor, escolha seu sexo: m para Masculino e f para Feminino ");
        string sexo = Console.ReadLine();

        //Cargo?
        Console.WriteLine("Por favor, nos informe seu cargo atual: ");
        string cargo = Console.ReadLine();

        //Salário
        Console.WriteLine("Por gentileza, nos informe seu salário:");

        if (double.TryParse(Console.ReadLine(), out double salario))
        {
            Console.WriteLine("Salário salvo com sucesso!");
        }
        else
        {
            Console.WriteLine("Valor informado é inválido.");
        }
        //Departamento?
        Console.WriteLine("Por favor, nos informe seu departamento atual: ");
        string departamento = Console.ReadLine();
        // Conexão e inserção
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Conexão criada com sucesso.");

                string query = "INSERT INTO Funcionarios (ativo, nome, idade, sexo, cargo, salario, departamento) VALUES (@Ativo, @Nome, @Idade, @Sexo, @Cargo, @Salario, @Departamento)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Ativo", ativo);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Idade", idade);
                    command.Parameters.AddWithValue("@Sexo", sexo);
                    command.Parameters.AddWithValue("@Cargo", cargo);
                    command.Parameters.AddWithValue("@Salario", salario);
                    command.Parameters.AddWithValue("@Departamento", departamento);


                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Dados inseridos com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao inserir os dados.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na operação: {ex.Message}");
        }
    }
}
