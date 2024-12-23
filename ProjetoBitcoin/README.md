# Projeto Bitcoin

Este projeto permite consultar o preço atual do Bitcoin e sua variação nas últimas 24 horas, utilizando a API CoinGecko, além de gravar os dados em um banco de dados SQL Server.

## Funcionalidades Principais

1. **Consulta de Preço e Variação do Bitcoin**: 
   - O sistema consulta a API CoinGecko para obter o preço atual do Bitcoin (BTC) em USD e sua variação nas últimas 24 horas.
   
2. **Exibição de Dados**:
   - Os dados são exibidos em uma interface gráfica usando um `DataGridView`, mostrando as seguintes informações:
     - **Data e Hora da Consulta**
     - **Preço Atual do Bitcoin**
     - **Preço Anterior do Bitcoin**
     - **Variação em porcentagem** entre o preço atual e o anterior.
     - **Status** indicando se o preço do Bitcoin aumentou ou diminuiu.

3. **Armazenamento de Dados**:
   - Os dados consultados podem ser gravados no banco de dados SQL Server para futuras consultas.
   - O sistema grava a data, preço atual, preço anterior e a variação de preço.

4. **Tecnologias Utilizadas**:
   - **C#**: A versão do .NET necessária é a 8.
   - **Windows Forms**: Para a criação da interface gráfica.
   - **API CoinGecko**: Para obter o preço e a variação do Bitcoin.
   - **SQL Server**: Para armazenamento dos dados.
   - **Newtonsoft.Json**: Para o tratamento de dados em formato JSON.

## Como Obter Credenciais da API CoinGecko

1. **Acesse o site da CoinGecko**:
   - Vá para [CoinGecko API](https://www.coingecko.com/en/api).
   
2. **Criação da chave de API**:
   - Clique em "Get Started" e crie uma conta.
   - Após a criação da conta, acesse sua dashboard e gere uma chave de API.
   
3. **Utilização da chave demo**:
   - CoinGecko fornece uma chave demo para testes, sem necessidade de um token pessoal.
   - Você pode usar essa chave diretamente na URL da API.

4. **Acessando os Endpoints da API**:
   - Para acessar os dados de preço e variação do Bitcoin, você deve usar o seguinte endpoint:
     ```bash
     https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd&include_24hr_change=true
     ```
   - Este endpoint retornará os dados de preço do Bitcoin em USD e a variação nas últimas 24 horas.

5. **Documentação da API**:
   - A documentação completa da API CoinGecko pode ser acessada [aqui](https://docs.coingecko.com/v3.0.1/reference/simple-price).

## Como Configurar a Conexão com o Banco de Dados

1. **Criação do Banco de Dados**:
   - Para armazenar os dados do Bitcoin, você precisa de um banco de dados SQL Server.
   - Crie um banco de dados no SQL Server, por exemplo, `CoinGeckoDb`.

2. **Criando a Tabela para Armazenar os Dados**:
   - No banco de dados, crie uma tabela para armazenar os dados consultados.
   - Execute o seguinte comando SQL para criar a tabela:

     ```sql
     USE CoinGeckoDb;

     CREATE TABLE dbo.BitcoinData
     (
      Id INT IDENTITY(1,1) PRIMARY KEY,
      Data DATETIME NOT NULL,
      PrecoAtual FLOAT NOT NULL,
      PrecoAnterior FLOAT NOT NULL,
      Variacao FLOAT NOT NULL
    );
     ```

3. **Configurando a Conexão no Código**:
   - No arquivo de configuração do seu projeto (no código), defina a string de conexão ao banco de dados SQL Server.
   - No exemplo do código, a string de conexão está configurada assim no arquivo 'Form1.cs':

     ```csharp
     var connectionString = "Server=MATEUS;Database=CoinGeckoDb;Integrated Security=True";
     ```

   - **Importante**: Substitua `MATEUS` pelo nome do seu servidor de banco de dados, e `CoinGeckoDb` pelo nome do banco de dados que você criou.

## Como Executar o Projeto

1. **Instale o .NET Framework**: 
   - Se não tiver o .NET Framework 4.7.2 ou superior, instale a versão necessária.

2. **Instale o Visual Studio**: 
   - Se você ainda não tem o Visual Studio, baixe e instale a versão mais recente.

3. **Configuração de Dependências**:
   - Abra o projeto no Visual Studio.
   - Instale o pacote **Newtonsoft.Json** via NuGet:
     ```bash
     Install-Package Newtonsoft.Json
     ```

4. **Executar o Projeto**:
   - Clique em **Iniciar** no Visual Studio para compilar e executar o projeto.
   - O sistema irá iniciar e você poderá consultar os dados do Bitcoin, visualizar a variação e gravar os dados no banco de dados.

5. **Consultando Dados**:
   - Clique no botão **Consultar Dados** para consultar o preço atual e a variação do Bitcoin.
   - A tabela será preenchida automaticamente com os dados de preço.

6. **Gravar Dados no Banco**:
   - Clique no botão **Gravar Dados** para salvar os dados no banco de dados SQL Server.
   - Se o DataGridView contiver dados, os mesmos serão salvos na tabela `BitcoinData`.