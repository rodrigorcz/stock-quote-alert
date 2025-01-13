using System;
using RestSharp;
using System.Net;
using Newtonsoft.Json.Linq;

public static class StockApi{

    public static decimal GetPrice(string symbol){

        // parametros para requisição dos dados do Ativo
        string apiKey = "..."; // configure com a sua chave de API AlphaVantage : https://www.alphavantage.co
        string interval = "5min"; 
        string QUERY_URL = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval={interval}&apikey={apiKey}";

        // configuração da requisição HTTP utilizando a URL de consulta QUERY_URL
        var client = new RestClient(QUERY_URL);
        var request = new RestRequest(); 

        // execução da requisição
        var response = client.Execute(request);

        if(response.IsSuccessful){
            try{
                // extrai o objeto que contém as informações de preços no intervalo definido
                JObject json = JObject.Parse(response.Content);
                var timeSeries = json[$"Time Series ({interval})"];

                if(timeSeries != null && timeSeries.First != null){
                    var latestEntry = timeSeries.First as JProperty;
                    
                    string timestamp = latestEntry.Name; // extrai o timestamp da entrada mais recente 
                    var data = latestEntry.Value;

                    string close = data["4. close"].ToString(); // extrai o fechamento do ativo
                    decimal price = decimal.Parse(close);

                    return price;
                }else{ 
                    // dados incoerentes
                    Console.WriteLine("Erro ao processar os dados."); 
                }
            }catch(Exception){
                Console.WriteLine("Erro ao analisar a resposta.");
            }
        }
        else{
            Console.WriteLine("Falha em obter dados da API!");
        }

        return 0;  // retorna 0 se houver erro
    }
}
