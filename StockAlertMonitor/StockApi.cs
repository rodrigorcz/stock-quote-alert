using System;
using RestSharp;
using Newtonsoft.Json.Linq;

public static class StockApi{

    public static decimal GetPrice(string symbol){

        string apiKey = "-";
        string interval = "5min"; 
        string QUERY_URL = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval={interval}&apikey={apiKey}";

        
        var client = new RestClient(QUERY_URL);
        var request = new RestRequest(); 

        var response = client.Execute(request);

        if(response.IsSuccessful){
            try{
                if(string.IsNullOrEmpty(response.Content)){
                    Console.WriteLine("Resposta vazia ou nula da API.");
                    return 0m;
                }

                
                JObject json = JObject.Parse(response.Content);
                var timeSeries = json[$"Time Series ({interval})"];

                if(timeSeries != null && timeSeries.First != null){
                    var latestEntry = timeSeries.First as JProperty;
                    
                    string timestamp = latestEntry.Name;  
                    var data = latestEntry.Value;

                    string close = data["4. close"].ToString(); 
                    decimal closePrice = decimal.Parse(close);

                    return closePrice;
                }else{
                    Console.WriteLine("Erro ao processar os dados. Verifique a chave API.");
                }
            }catch(Exception){
                Console.WriteLine("Erro ao analisar a resposta.");
            }
        }
        else{
            Console.WriteLine("Falha em obter dados da API!");
        }

        return 0;  
    }
}
