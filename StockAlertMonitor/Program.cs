using System;
using System.IO;

class Program{
    static void Main(string[] args){

        // verifica a existencia do arquivo json com as configurações do sistema
        string configPath = "config.json";
        if(!File.Exists(configPath)){
            Console.WriteLine("Arquivo json nao encontrado!");
            return;
        }

        // realiza a configuração das informações com base no arquivo json indicado
        var config = Configuration.LoadConfigurations(configPath);

        string symbol = args[0];                    // nome do ativo
        decimal sellPrice = decimal.Parse(args[1]); // valor de venda
        decimal buyPrice = decimal.Parse(args[2]);  // valor de compra

        // inicia a rotina de monitoramento
        StockMonitor.Monitor(symbol, sellPrice, buyPrice, config);
    }
}