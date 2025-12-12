
# API Blog

Projeto de uma API básica para cadastro de blog e seus respectivos comentários.



## Documentação da API

#### Retorna todos os itens.

```http
  GET /api/posts
```

#### Retorna uma lista com o id, o título do post e o número de comentários de cada post.

```http
  GET /api/posts/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `Guid` | **Obrigatório**. O ID do item que você quer |

#### Retorna o post com o id informado, caso ele seja encontrado na base de dados.

```http
  POST /api/posts
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `titulo`      | `string` | **Obrigatório**. O título do post.|
| `conteudo`      | `string` | **Obrigatório**. O conteúdo do post.|

#### Cria um post

```http
  GET /api/posts/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `Guid` | **Obrigatório**. O ID do item que você quer. |

#### Retorna uma mensagem avisado que o Post foi criado.

```http
  POST /api/posts/{id}/comments
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `Guid` | **Obrigatório**. O título do post.|
| `comentario`      | `string` | **Obrigatório**. O comentário do post.|

#### Cria um comentário para o post



## Tecnologias Usadas

C#

Entity Framework Core 

Dapper

.Net 8.0

AutoMapper

FluentValidation

Sql Server

Swagger

## Boas Práticas

CleanCode

DDD

S.O.L.I.D.


