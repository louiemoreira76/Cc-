using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        // Exemplos de Coleções
        List<string> nomes = new List<string> { "Bea", "Juju", "Kkaukau" };

        Console.WriteLine("Lista de Nomes:");
        foreach (var nome in nomes)
        {
            Console.WriteLine(nome);
        }

        Dictionary<string, int> idadePorNome = new Dictionary<string, int>
        {
            { "Bea", 27 },
            { "Juju", 30 },
            { "Kkaukau", 60 }
        };

        Console.WriteLine("\nIdades por Nome:");
        foreach (var item in idadePorNome)
        {
            Console.WriteLine($"{item.Key}: {item.Value} anos");
        }

        // Exemplos de LINQ
        var nomesComLinq = from nome in nomes
                           where nome.StartsWith("J")
                           select nome;

        Console.WriteLine("\nNomes que começam com 'J':");
        foreach (var nome in nomesComLinq)
        {
            Console.WriteLine(nome);
        }

        // Exemplos de Tratamento de Exceções
        try
        {
            int divisor = 0;
            int resultado = 10 / divisor; // Isso causará uma exceção
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("\nNão é possível dividir por zero.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Bloco finally sempre é executado.");
        }

        // Exemplos de Trabalhar com Arquivos e Dados
        string caminhoArquivo = "exemplo.txt";
        string conteudo = "Este é um exemplo de texto.";

        try
        {
            // Gravação de Arquivo
            File.WriteAllText(caminhoArquivo, conteudo);
            Console.WriteLine("\nTexto gravado com sucesso.");

            // Leitura de Arquivo
            if (File.Exists(caminhoArquivo))
            {
                string conteudoLido = File.ReadAllText(caminhoArquivo);
                Console.WriteLine("Conteúdo do arquivo:");
                Console.WriteLine(conteudoLido);
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao acessar o arquivo: " + ex.Message);
        }

        // Serialização e Desserialização de Dados
        Me eu = new Me
        {
            name = "Luis",
            idade = 20,
            salario = 1400,
            inicial = 'L',
            ativo = true
        };

        // Serialização para JSON
        string json = JsonSerializer.Serialize(eu);
        Console.WriteLine("\nJSON:");
        Console.WriteLine(json);

        // Desserialização do JSON
        Me euDesserializado = JsonSerializer.Deserialize<Me>(json);
        Console.WriteLine("\nDados desserializados do JSON:");
        Console.WriteLine($"{euDesserializado.name}\n{euDesserializado.idade}\n{euDesserializado.salario}\n{euDesserializado.inicial}\n{euDesserializado.ativo}");

        // Serialização e Desserialização XML
        XmlSerializer serializer = new XmlSerializer(typeof(Me));

        // Serializar para XML
        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, eu);
            string xml = writer.ToString();
            Console.WriteLine("\nXML:");
            Console.WriteLine(xml);
        }

        // Desserializar do XML
        string xmlInput = "<Me><name>Luis</name><idade>20</idade><salario>1400</salario><inicial>L</inicial><ativo>true</ativo></Me>";
        using (StringReader reader = new StringReader(xmlInput))
        {
            Me euDesserializadoXml = (Me)serializer.Deserialize(reader);
            Console.WriteLine("\nDados desserializados do XML:");
            Console.WriteLine($"{euDesserializadoXml.name}\n{euDesserializadoXml.idade}\n{euDesserializadoXml.salario}\n{euDesserializadoXml.inicial}\n{euDesserializadoXml.ativo}");
        }
    }
}
