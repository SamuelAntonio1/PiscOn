** Projeto PsicOn **

A PsicOn é um projeto que visa auxiliar uma clínica de psicologia no gerenciamento de sua lista de contatos. Através da PsicOn, é possível criar, visualizar, editar e excluir contatos, permitindo assim uma organização mais eficiente das informações dos pacientes da clínica.
A PsicOn é composta por duas partes principais: a API e a aplicação web. A API, desenvolvida em C# utilizando ASP.NET Core, fornece os endpoints necessários para acessar e manipular os dados dos contatos. Ela utiliza pacotes como DbUp e Dapper para controle de versionamento e acesso ao banco de dados, respectivamente. Além disso, a API também utiliza o pacote DbUp.Postgresql para suporte ao banco de dados PostgreSQL, e o pacote Swashbuckle.AspNetCore para geração automática de documentação da API com o Swagger.
Já a aplicação web, desenvolvida em C# utilizando ASP.NET Web Forms, utiliza MasterPage e JQuery para se comunicar com a API de dados. Ela oferece funcionalidades como visualização da lista de contatos da clínica, adição de novos contatos e edição/remoção de contatos existentes.
Em resumo, a PsicOn é uma solução completa para clínicas de psicologia que desejam ter um controle mais eficiente de sua lista de contatos. Com sua API RESTful e sua aplicação web intuitiva, a PsicOn facilita o gerenciamento dos contatos, contribuindo para um atendimento mais organizado e eficaz aos pacientes da clínica.

PsicOn.Api
É um projeto do tipo API seguindo o padrão RESTFull
Pacotes
- DbUp - 5.0.40
- Dapper - 2.1.28
- dbup-postgresql - 5.0.40
- Npgsq - 8.0.2
- Swashbuckle.AspnetCore - 6.5.0

PsicOn.Web
É um projeto do tipo AspNet Web utilizando MasterPage e JQuery para comunicação com a API de dados
Pacotes
- .Net Framework 4.8
