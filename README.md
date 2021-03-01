# TestVolvo.Net


## Banco de Dados
Foi Utilizado "Microsoft SQL Server Express LocalDB"

caso não tenha instalado, alterar a Connection String no arquivo "appsettings.json"


## Instruções

Abrir a solution com o visual studio e rodar o projeto "App.Volvo.Site"

Ou 

acessar a pasta "~\src\App.Volvo.Site" pelo prompt de comando (cmd) rodar o comando 

```bash
dotnet run
```

Após rodar o comando poderá acessar o app pelo link

```
https://localhost:5001
```

## Code Coverage

Para gerar o o code coverage utilizei a ferramente Coverlet
```
https://github.com/coverlet-coverage/coverlet
```


Há um relatório pronto sobre o code coverage na pasta
```
~\coveragereport\index.html
```

Para gerar o relatorio novamente abra o diretorio utilizando o Prompt De Comando do Windows

```bash
~\test\App.Volvo.Business.Test
```

Execute o comando
```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
```

O resultado será parecido com isso:

```
  Generating report '~\test\App.Volvo.Business.Test\coverage.cobertura.xml'

+--------------------+--------+--------+--------+
| Module             | Line   | Branch | Method |
+--------------------+--------+--------+--------+
| App.Volvo.Business | 77.16% | 100%   | 63.63% |
+--------------------+--------+--------+--------+

+---------+--------+--------+--------+
|         | Line   | Branch | Method |
+---------+--------+--------+--------+
| Total   | 77.16% | 100%   | 63.63% |
+---------+--------+--------+--------+
| Average | 77.16% | 100%   | 63.63% |
+---------+--------+--------+--------+
```


Repare que foi gerado um arquivo XML
``
~\test\App.Volvo.Business.Test\coverage.cobertura.xml
``

Com este arquivo podemos gerar o relatorio rodando o seguinte comando

```bash
reportgenerator "-reports:~\test\App.Volvo.Business.Test\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html
```

