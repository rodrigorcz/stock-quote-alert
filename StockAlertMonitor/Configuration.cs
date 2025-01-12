using System.IO;
using System.Text.Json;

public class Configuration{
    
    public string emailDestination { get; set; }
    public string smtpServer { get; set; }
    public int smtpPort { get; set; }
    public string smtpUser { get; set; }
    public string smtpPassword { get; set; }

    public static Configuration LoadConfigurations(string filePath){
        
        var configContent = File.ReadAllText(filePath);
        var configuration = JsonSerializer.Deserialize<Configuration>(configContent);

        return configuration;
    }
}
