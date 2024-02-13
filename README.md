# CRUD LOJA

Este é um projeto independente no qual utilizei C# e Asp.Net Core na construção de uma API, e utilizei Entity Framework para as operações no banco de dados SQL Server.

## Instalação

1. Por questões práticas, tenha instalado o Visual Studio e o SQL Server. (att: Não é o Visual Studio Code)
2. Baixe o repositório ou clone o mesmo.
3. Abra o projeto no Visual Studio.
4. Abra o Console de Gerenciameto de Pacotes e coloque os seguintes comandos:
-   Install-Package Microsoft.EntityFrameworkCore
-   Install-Package Microsoft.EntityFrameworkCore.Design
-   Install-Package Microsoft.EntityFrameworkCore.Tools
-   Install-Package Microsoft.EntityFrameworkCore.SqlServer
-   Install-Package Swashbuckle.AspNetCore
6. No Gerenciador de Soluções, procure o arquivo appsettings.json
7. Já no arquivo, no campo a seguir Troque o Server "DAVI" para o seu Server do seu SQL Server.
-    "ConnectionStrings": {
-    "Database": "Server=DAVI;Database=Banco_De_Dados;Trusted_Connection=True;TrustServerCertificate=True"}
-    (!help: Caso não saiba qual servidor do SQL Server, abra o SQL Server Managment Studio, no campo Server Name, caso tenha somente <browse> clique nele e em Database Engine estará seu Server)
-    (att: Caso possua um Banco de Dados chamado:"Banco_De_Dados" já criado no seu Server, Mude o Nome para um de seu Gosto! Caso contrário ele será alterado nos próximos passos!)
8. Abra o Gerenciador de Pacotes Novamente e Insira os Seguintes comandos em sequência:
-   Add-Migration FinalDb -Context Contexto
-   Update-Database -Context Contexto
9. Configuração Terminada, Aperte F5 para iniciar a aplicação.  

