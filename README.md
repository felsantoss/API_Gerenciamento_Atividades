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

## Criando nova atividade

O método POST nos permite criar uma nova atividade no banco de dados. 
Utilizando a URL abaixo será possível criar uma nova atividade no banco de dados.

URL: POST https://localhost:7258/api/Atividades

Abaixo está o passo a passo para criar uma nova atividade dentro da plataforma, estarei utilizando a plataforma Postman como exemplo: 

- selecione o método POST e coloque a URl: https://localhost:7258/api/Atividades

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/b5e66319-a450-47db-8b8c-b565b2cf6ab1)

- selecione a opção Body e preencha conforme abaixo:

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/df7d256f-1aac-4beb-9a6f-803af7d74234)

- feito isso deixamos o ID zerado e preenchemos os demais campos

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/74e84dae-9f0c-4755-872b-3f0dc268a9e9)

- mudamos o tipo do arquivo para JSON

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/643d0f5a-ba3e-4786-b161-332f0397c099)

- com todas informações preenchidas podemos clicar em "Send"

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/68386c9b-2950-40b8-bee3-e83025508057)

- é criado um novo ID com as informações fornecidas

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/f7e5c6fb-39e1-4979-9158-5d96d7d8a1f9)

## Atulizando uma atividade existente 

Com o método POST também é possível alterar alguma atividade cadastrada no banco de dados. 
Utilizando a URL abaixo será possível alterar uma atividade no banco de dados.

URL: POST https://localhost:7258/api/Atividades

Iremos usar como exemplo a última atividade cadastrada com o ID 14. Para isso vamos utilizar o Postman para exemplo: 

- Mudamos o método para POST e digitamos a URL https://localhost:7258/api/Atividades

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/c8cc3a89-3f65-4c9e-9eb9-58e87bf89f96)

- selecione a opção body e preencha com as informações do ID

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/54b3952b-966c-4514-a676-3ad1b298de23)

- Como exemplo vamos mudar o status de Pendente para Conluido

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/20a4ac42-bbcd-4b23-b886-2a8e48738fbc)

- Mudamos o tipo de arquivo para JSON

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/e1438111-57c8-40ff-be87-3bb3909678c3)

- Feito isso clicamos em "Send"

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/a83875ce-9178-4ff2-9d5b-1259ce86e85d)

- Recebemos a mensagem com código 200 informando que o ID foi atualizado

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/17147bee-763c-4ebb-aab9-e23515f4dc75)

- GET do ID 14 atualizado

![image](https://github.com/felsantoss/API_Gerenciamento_Atividades/assets/92893574/c924bf6e-9ead-47a8-b13c-8fbd0d840b2b)
