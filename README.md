# Stock Quote Alert

Este repositorio contém os códigos de um sistema de monitoramento de ativos que possui como objetivo, via e-mail, avisar caso a cotação de um ativo da B3 caia mais do que certo nível, ou suba acima de outro. O programa é um aplicação de console chamado via linha de comando com 3 parâmetros:

```
1. O ativo a ser monitorado
2. O preço de referência para venda
3. O preço de referência para compra
```
Ex:

```
$ stock-quote-alert.exe IBM 250.67 210.59
```

Toda vez que o ultimo preço de fechamento do ativo for maior que o preço de venda, um e-mail deve ser disparado aconselhando a venda. E toda vez que o preço de fechamento do ativo for menor que o preço de compra, um e-mail deve ser disparado aconselhando a compra.

# Funcionamento

Inicialmente, para o funcionamento do sistema algumas informações são necessárias:

Um arquivo 'config.json' é necessário para as configurações de acesso ao servidor de SMTP que irá enviar o e-mail. Para isso é necessário alterar os campos 'emailDestination', 'smtpUser' e 'smtpPassword', presentes na raiz do reposiorio.

> config.json

```
{
    "emailDestination": "destination@gmail.com", // Email de destino
    "smtpServer": "smtp.gmail.com",
    "smtpPort": 587,
    "smtpUser": "user.email@gmail.com",   // Email do usário que enviara o email
    "smtpPassword": "senha" // Senha de App Google
}
```

Este sistema utiliza a Api da Alpha Vantage para monitoramento dos stocks, que possui a documentação neste <a href="https://www.alphavantage.co/">link</a>. Dessa forma, é necessario a configuração de uma chave desta Api para o bom funcionamento do sistema. Para isso deve-se definir a chave da Api no arquivo StockApi.cs:

> StockAlertMonitor/StockApi.cs

```
10|
11| string apiKey = "...";
12|
```

Com isso é possivel rodar o programa a partir do executavel stock-alert-monitor.exe, informando o ativo a ser monitorado, o preço de venda e o preço de compra:


```
$ stock-quote-alert.exe IBM 250.67 210.59
```

Outra maneira de rodar a aplicação é a execução dos seguintes comando dentro da pasta StockAlertMonitor/ :

```
dotnet restore
dotnet build
dotnet run
```

