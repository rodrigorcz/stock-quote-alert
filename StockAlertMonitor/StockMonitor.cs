using System;
using System.Threading;

public static class StockMonitor{

    public static void Monitor(string asset, decimal sellPrice, decimal buyPrice, Configuration config){

        while (true){
            decimal price = StockApi.GetPrice(asset);
            
            Console.WriteLine($"[{DateTime.Now}] {asset}: {price}");

            if(price == sellPrice){
                Email.SendEmail(config, $"Venda de Ativos {asset}", 
                                        $"O preço atual é de {price}, maior do que o preço de venda estipulado: {sellPrice}.");
            }else if(price == buyPrice){
                Email.SendEmail(config, $"Compra de Ativos {asset}",
                                        $"O preço atual é de {price}, menor do que o preço de compra estipulado: {buyPrice}.");
            }

            Thread.Sleep(30000); 
        }
    }
}