using System;
using System.Threading;

public static class StockMonitor{

    // monitora o preço do ativo e envia e-mails com base nos preços de compra e venda
    public static void Monitor(string symbol, decimal sellPrice, decimal buyPrice, Configuration config){

        while (true){
            decimal price = StockApi.GetPrice(symbol); // obtem o ultimo preco de fechamento
            
            Console.WriteLine($"[{DateTime.Now}] {symbol}: {price}");

            // compara com os valores de compra e venda estipulados 

            if(price > sellPrice){
                Email.SendEmail(config, $"Venda de Ativos {symbol}", 
                                        $"O preço atual do ativo {symbol} equivale à {price}! \nEste valor é maior do que o preço de venda estipulado: {sellPrice}.");
            }else if(price < buyPrice){
                Email.SendEmail(config, $"Compra de Ativos {symbol}",
                                        $"O preço atual do ativo {symbol} equivale à {price}! \nEste valor é menor do que o preço de compra estipulado: {buyPrice}.");
            }

            Thread.Sleep(30000); // espera 30 segundos
        }
    }
}