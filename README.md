# Sistema de Gerenciamento de Biblioteca

## Descrição Geral
Este projeto envolve o desenvolvimento de um microserviço em C# para gerenciar uma biblioteca. O serviço permitirá operações como adicionar, buscar, atualizar e excluir registros de livros e usuários. Além disso, administrará o empréstimo e a devolução de livros, juntamente com a aplicação de multas por atrasos e restrições para usuários com históricos de atrasos recorrentes.

## Integrantes do Grupo
- ESMERALDA STEPHANY FREIRE NASCIMENTO
- LUIS VINICIUS FRANCISCO DA SILVA
- BEATRIZ DOS SANTOS SOUSA
- HELDHMA LUIZA PAIVA FERREIRA
- YAGO RAIMON XAVIER CAVALCANTI SILVA
- VICTÓRIA PRISCILA FEITOSA LINDOSO

## Requisitos Funcionais
- **CRUD de Livros**: Criação, leitura, atualização e exclusão de livros no sistema.
- **CRUD de Usuários**: Criação, leitura, atualização e exclusão de usuários.
- **Empréstimos**: Capacidade de emprestar livros aos usuários, com a restrição de não mais que 3 livros por usuário ao mesmo tempo.
- **Devoluções**: Funcionalidade para a devolução de livros.
- **Pesquisa de Livros**: Capacidade de pesquisar livros por título, autor ou categoria.
- **Registro de Atividades**: Registro de todas as atividades de empréstimo e devolução.

## Requisitos Não Funcionais
- **API RESTful**: Exposição de uma API RESTful.
- **Segurança**: Implementação de autenticação JWT para proteger a API.
- **Banco de Dados**: Utilização do Entity Framework Core para integração com um banco de dados SQL.
- **Validação de Dados**: Validação de dados de entrada para garantir precisão e integridade.
- **Testes Unitários**: Desenvolvimento de testes unitários para assegurar a corretude do código.

## Desafios Adicionais
- **Documentação da API**: Uso do Swagger para documentar a API, facilitando seu uso por outros desenvolvedores.
- **Relatórios Avançados**: Geração de relatórios sobre livros mais populares, usuários mais ativos, histórico de atrasos, etc.
- **Funcionalidade de multa Progressiva por Atraso**: Multas incrementais por dia de atraso na devolução, não excedendo o dobro do valor do livro.
- **Funcionalidade de penalidades para Atrasos Recorrentes**: Restrições como limitar o empréstimo a um livro por vez para usuários com histórico de atrasos.

## Tecnologias Utilizadas
- **Linguagem de Programação**: C#
- **Framework**: .NET Core
- **Banco de Dados**: SQL Server
- **ORM**: Entity Framework Core
- **Autenticação**: JWT (JSON Web Tokens)
- **Documentação da API**: Swagger

## Requisitos para Execução
Para executar este projeto, você precisará das seguintes ferramentas e tecnologias instaladas em seu ambiente de desenvolvimento:
- .NET Core SDK (versão compatível com o projeto)
- SQL Server (ou outro banco de dados compatível com Entity Framework Core)
- Um editor de código ou IDE que suporte C# (Recomendado: Visual Studio, Visual Studio Code)
- Postman ou qualquer cliente API para testar os endpoints da API RESTful

## Configuração do Ambiente de Desenvolvimento
1. Clone o repositório do projeto para sua máquina local.
2. Abra o projeto no seu editor de código ou IDE.
3. Restaure os pacotes NuGet necessários para o projeto.
4. Configure a string de conexão para o banco de dados no arquivo `appsettings.json`.
5. Execute as migrações do Entity Framework Core para criar o esquema do banco de dados.
6. Inicie o projeto e teste os endpoints da API utilizando um cliente API.
