# API_Gerenciamento_Atividades

Objetivo: Desenvolvimento de uma API para gerenciamento de atividades diversas utilizando .NET Core e armazenando informações em um banco de dados MySQL.

Tecnonologias Utilizadas: C#, .NET Core, Entity Framework Core, MySQL, Postman, Git, Github.

A API conta com o método GET para obter todos os dados armazenados no banco de dados, outro método GET para obter uma informação específica e o método POST para conseguir criar a atualizar informações no banco de dados. 

## Obtendo todas as atividades do banco de dados

O método GET permite consultar informações da base de dados, sendo possível visualizar todas as atividades criadas na base de dados.
Utilizando a URL abaixo será possível visualizar todas as atividades armazenadas no banco de dados.

URL: GET https://localhost:7258/api/atividades

Resposta:

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/d8228309-7f34-4139-8603-1fd45af0412b)

## Obtendo uma atividade específica do banco de dados

O método GET também nos permite visualizar uma única atividade cadastrada no banco de dados.
Utilizando a URL abaixo será possível visualizar uma única atividade armazenada no banco de dados.

Após api/atividades/ você digitando o ID da atividade será possível ter a visualização completa desta atividade. No exemplo usei a atividade cadastrada com o ID 10. 

URL: GET https://localhost:7258/api/atividades/10

Resposta:

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/57289333-d8f9-4ba1-a99d-085fd8f44ff5)
