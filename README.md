Processo Seletivo Arquiteto de Sistemas da Ewave/TJMT
=====================

![GitHub](https://img.shields.io/github/license/fernandovictorti/processo-seletivo-ewave-arquiteto-fev-2021?logoColor=%20)
![GitHub last commit](https://img.shields.io/github/last-commit/fernandovictorti/processo-seletivo-ewave-arquiteto-fev-2021)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=fernandovictorTI_processo-seletivo-ewave-arquiteto-fev-2021&metric=alert_status)](https://sonarcloud.io/dashboard?id=fernandovictorTI_processo-seletivo-ewave-arquiteto-fev-2021)


| Branch        | Master UI           | Master API  |
| ------------- |:-------------:| -----:|
| Status CI      | ![Pipeline UI](https://github.com/fernandovictorTI/processo-seletivo-ewave-arquiteto-fev-2021/actions/workflows/angular-tests.yml/badge.svg?branch=master) | ![Pipeline API](https://github.com/fernandovictorTI/processo-seletivo-ewave-arquiteto-fev-2021/actions/workflows/dotnet-tests.yml/badge.svg?branch=master) |

### O Desafio

Ajude o restaurante &quot;Favo de Mel&quot; a gerenciar o atendimento ao cliente, pois o mesmo está tendo sérios problemas com isso. Os problemas são: pedidos são feitos e muitas vezes o mesmo não chega a cozinha, clientes cancelam pedido e a cozinha não recebe o aviso e acaba preparando o mesmo, os pedidos estão demorando para serem entregues ou muitas vezes estão entregando pedido fora de ordem sem priorização.

Como esse fluxo hoje é manual e devido a correria dos funcionários para tentar atender os clientes, a comunicação entre eles acaba sendo ineficiente, causando esses gargalos.

Para resolver os principais problemas foi solicitado a criação de uma nova ferramenta que atenda no mínimo os requisitos abaixo:

- Garçom: visualizar comandas abertas, abrir comanda, adicionar pedido a comanda, cancelar pedido da comanda, acompanhar o status de um pedido na cozinha e fechar a comanda;
- Cozinha: visualizar, receber e entregar o pedido pronto para o garçom.

Além dos requisitos mínimos acima, deixamos por opção livre a implementação de alguns requisitos que seriam interessantes para o restaurante, são eles:

-  Notificação ativa entre o garçom e a cozinha ou vice-versa;
-  Garçom poder visualizar o andamento de preparo dos pedidos de uma comanda;
-  Repriorização de ordem de preparo dos pedidos pela cozinha.

## Requisitos

- Docker

## Rodar Aplicação

    docker-compose -f 'docker-compose.yml' -f 'docker-compose.override.yml' up -d --build

## Documentação da API

    http://localhost:32767/swagger

## Sobre

Foi criado uma aplicação com API, UI e DB  com docker-compose para orquestrar a aplicação inteira.

#### API

Foi criado uma API em .NET Core com C# contendo as funcionalidades para Gerenciar a cozinha da Favo de Mel.

### Tecnologias Implementadas:

- .NET5
- Entity Framework Core
- MediatR
- AutoMapper
- .NET Core Native DI
- Dapper
- Flunt
- FluentValidation
- Swagger UI
- MassTransit
- RabbitMQ
- XUnit
- Moq

### Architecture:

- CQRS
- Arquitetura completa com preocupações de separação de responsabilidades, SOLID e Clean Code
- Domain Driven Design
- Unit of Work
- Repository and Generic Repository
- Docker-Compose

#### SPA

Foi criado um spa com Angular para se comunicar com a API em real time utilizando wsockets com ngrx.

    http://localhost:8081

### Tecnologias Implementadas:

- Angular
- Stomp
- Ngrx(store, reducer, selector e effects)

# Obrigado

## Sobre:
O projeto foi desenvolvido por [Fernando Victor](https://github.com/fernandovictorTI) sob a [MIT license](LICENSE).
