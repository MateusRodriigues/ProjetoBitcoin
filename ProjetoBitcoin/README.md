# Projeto Bitcoin

Este projeto permite consultar o pre�o atual do Bitcoin e sua varia��o nas �ltimas 24 horas, utilizando a API CoinGecko, al�m de gravar os dados em um banco de dados SQL Server.

## Funcionalidades Principais

1. **Consulta de Pre�o e Varia��o do Bitcoin**: 
   - O sistema consulta a API CoinGecko para obter o pre�o atual do Bitcoin (BTC) em USD e sua varia��o nas �ltimas 24 horas.
   
2. **Exibi��o de Dados**:
   - Os dados s�o exibidos em uma interface gr�fica usando um `DataGridView`, mostrando as seguintes informa��es:
     - **Data e Hora da Consulta**
     - **Pre�o Atual do Bitcoin**
     - **Pre�o Anterior do Bitcoin**
     - **Varia��o em porcentagem** entre o pre�o atual e o anterior.
     - **Status** indicando se o pre�o do Bitcoin aumentou ou diminuiu.

3. **Armazenamento de Dados**:
   - Os dados consultados podem ser gravados no banco de dados SQL Server para futuras consultas.
   - O sistema grava a data, pre�o atual, pre�o anterior e a varia��o de pre�o.

4. **Tecnologias Utilizadas**:
   - **C#**: A vers�o do .NET necess�ria � a 8.
   - **Windows Forms**: Para a cria��o da interface gr�fica.
   - **API CoinGecko**: Para obter o pre�o e a varia��o do Bitcoin.
   - **SQL Server**: Para armazenamento dos dados.
   - **Newtonsoft.Json**: Para o tratamento de dados em formato JSON.

## Como Obter Credenciais da API CoinGecko

1. **Acesse o site da CoinGecko**:
   - V� para [CoinGecko API](https://www.coingecko.com/en/api).
   
2. **Cria��o da chave de API**:
   - Clique em "Get Started" e crie uma conta.
   - Ap�s a cria��o da conta, acesse sua dashboard e gere uma chave de API.
   
3. **Utiliza��o da chave demo**:
   - CoinGecko fornece uma chave demo para testes, sem necessidade de um token pessoal.
   - Voc� pode usar essa chave diretamente na URL da API.

4. **Acessando os Endpoints da API**:
   - Para acessar os dados de pre�o e varia��o do Bitcoin, voc� deve usar o seguinte endpoint:
     ```bash
     https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd&include_24hr_change=true
     ```
   - Este endpoint retornar� os dados de pre�o do Bitcoin em USD e a varia��o nas �ltimas 24 horas.

5. **Documenta��o da API**:
   - A documenta��o completa da API CoinGecko pode ser acessada [aqui](https://docs.coingecko.com/v3.0.1/reference/simple-price).

## Como Configurar a Conex�o com o Banco de Dados

1. **Cria��o do Banco de Dados**:
   - Para armazenar os dados do Bitcoin, voc� precisa de um banco de dados SQL Server.
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

3. **Configurando a Conex�o no C�digo**:
   - No arquivo de configura��o do seu projeto (no c�digo), defina a string de conex�o ao banco de dados SQL Server.
   - No exemplo do c�digo, a string de conex�o est� configurada assim no arquivo 'Form1.cs':

     ```csharp
     var connectionString = "Server=MATEUS;Database=CoinGeckoDb;Integrated Security=True";
     ```

   - **Importante**: Substitua `MATEUS` pelo nome do seu servidor de banco de dados, e `CoinGeckoDb` pelo nome do banco de dados que voc� criou.

## Como Executar o Projeto

1. **Instale o .NET Framework**: 
   - Se n�o tiver o .NET Framework 4.7.2 ou superior, instale a vers�o necess�ria.

2. **Instale o Visual Studio**: 
   - Se voc� ainda n�o tem o Visual Studio, baixe e instale a vers�o mais recente.

3. **Configura��o de Depend�ncias**:
   - Abra o projeto no Visual Studio.
   - Instale o pacote **Newtonsoft.Json** via NuGet:
     ```bash
     Install-Package Newtonsoft.Json
     ```

4. **Executar o Projeto**:
   - Clique em **Iniciar** no Visual Studio para compilar e executar o projeto.
   - O sistema ir� iniciar e voc� poder� consultar os dados do Bitcoin, visualizar a varia��o e gravar os dados no banco de dados.

5. **Consultando Dados**:
   - Clique no bot�o **Consultar Dados** para consultar o pre�o atual e a varia��o do Bitcoin.
   - A tabela ser� preenchida automaticamente com os dados de pre�o.

6. **Gravar Dados no Banco**:
   - Clique no bot�o **Gravar Dados** para salvar os dados no banco de dados SQL Server.
   - Se o DataGridView contiver dados, os mesmos ser�o salvos na tabela `BitcoinData`.