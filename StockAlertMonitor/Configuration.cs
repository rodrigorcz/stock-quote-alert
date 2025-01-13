using System.IO;
using System.Text.Json;

public class Configuration{
    
    // atributos referentes as configurações de e-mail
    public string emailDestination { get; set; }
    public string smtpServer { get; set; }
    public int smtpPort { get; set; } = 587;
    public string smtpUser { get; set; }
    public string smtpPassword { get; set; }

    // carrega as configurações a partir de um arquivo JSON
    public static Configuration LoadConfigurations(string filePath){
        
        var configContent = File.ReadAllText(filePath);
        var configuration = JsonSerializer.Deserialize<Configuration>(configContent);

        if (configuration == null || 
            string.IsNullOrWhiteSpace(configuration.emailDestination) ||
            string.IsNullOrWhiteSpace(configuration.smtpServer) ||
            string.IsNullOrWhiteSpace(configuration.smtpUser) ||
            string.IsNullOrWhiteSpace(configuration.smtpPassword))
        {
            throw new InvalidDataException("Arquivo de Configuração invalido!");
        }

        return configuration;
    }
}
