using System;
using System.IO;

class Program{
    static void Main(string[] args){

        string configPath = "config.json";
        if (!File.Exists(configPath)){
            Console.WriteLine("Arquivo JSON nao encontrado!");
            return;
        }

        var config = Configuration.LoadConfigurations(configPath);

        Console.WriteLine("\nTestando leitura de dados:");
        Console.WriteLine(config.email);
        Console.WriteLine(config.smtpServer);
        Console.WriteLine(config.smtpPort);
        Console.WriteLine(config.smtpUser);
        Console.WriteLine(config.smtpPassword);
    }
}