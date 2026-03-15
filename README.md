<div align="center">
   <h1>
      TykNet - API Gateway com .NET 10
   </h1>
  
  ![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet)
  ![Tyk](https://img.shields.io/badge/Tyk-Gateway-FF6B6B?style=flat)
  ![License](https://img.shields.io/github/license/daniloopinheiro/TykNet)
  ![Status](https://img.shields.io/badge/status-active-success)

   **Implementação de API Gateway utilizando Tyk com APIs construídas em .NET 10**  
   Projeto demonstrando arquitetura moderna de microserviços com gateway centralizado para segurança, monitoramento e controle de tráfego.
</div>
</br>


## 📑 Índice

1. [Visão Geral](#visão-geral)
2. [O que é um API Gateway?](#o-que-é-um-api-gateway)
3. [Arquitetura da Solução](#arquitetura-da-solução)
4. [Instalação](#instalação)
5. [Como Usar](#como-usar)
6. [Configuração do Tyk](#configuração-do-tyk)
7. [Segurança e Autenticação](#segurança-e-autenticação)
8. [Observabilidade](#observabilidade)
9. [Testando a Integração](#testando-a-integração)
10. [Quando Utilizar um API Gateway](#quando-utilizar-um-api-gateway)
11. [Contribuições](#contribuições)
12. [Artigos & Conteúdos](#artigos--conteúdos)
13. [Licença](#licença)
14. [Contato](#contato)

## Visão Geral

No desenvolvimento de arquiteturas modernas baseadas em microserviços e APIs, o uso de um **API Gateway** tornou-se praticamente essencial. Ele atua como uma camada intermediária entre clientes e serviços, centralizando segurança, autenticação, monitoramento, versionamento e controle de tráfego.

O **TykNet** é um projeto demonstrativo que explora como implementar um API Gateway utilizando **[Tyk](https://tyk.io/)** com APIs construídas em **.NET 10**, apresentando os conceitos arquiteturais, configuração do gateway e integração prática.

### ✨ Recursos Principais

- 🔐 **Autenticação e Autorização**: Controle centralizado de acesso
- 📊 **Monitoramento e Métricas**: Observabilidade completa das APIs
- ⚡ **Rate Limiting**: Controle de tráfego e prevenção de abuso
- 🔁 **Balanceamento de Carga**: Distribuição inteligente de requisições
- 🔄 **Versionamento de APIs**: Gerenciamento de múltiplas versões
- 🧩 **Transformação de Requests/Responses**: Manipulação de dados em trânsito
- 🚀 **Escalabilidade**: Arquitetura preparada para crescimento

## O que é um API Gateway?

Um API Gateway é um componente responsável por atuar como ponto único de entrada para múltiplos serviços.

Ele pode oferecer funcionalidades como:

- 🔐 **Autenticação e autorização**
- 📊 **Monitoramento e métricas**
- ⚡ **Rate limiting**
- 🔁 **Balanceamento de carga**
- 🔄 **Versionamento de APIs**
- 🧩 **Transformação de requests/responses**

Em vez de o cliente chamar diretamente vários serviços, ele interage com o gateway, que encaminha as requisições para os serviços corretos.

📌 **Documentação oficial do Tyk**: [https://tyk.io/docs/](https://tyk.io/docs/)

## Arquitetura da Solução

Uma arquitetura simples com **.NET 10 + Tyk** pode ser representada assim:

```
    Cliente
       │
       ▼
    API Gateway (Tyk)
       │
       ├── API .NET 10 - Usuários
       ├── API .NET 10 - Produtos
       └── API .NET 10 - Pedidos
```

**Benefícios da abordagem:**

- ✅ Centralização de segurança
- ✅ Governança de APIs
- ✅ Observabilidade unificada
- ✅ Escalabilidade independente

## Instalação

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker](https://www.docker.com/get-started) (para executar o Tyk Gateway)
- [Git](https://git-scm.com/)

### Clonando o Repositório

```bash
git clone https://github.com/daniloopinheiro/TykNet.git
cd TykNet
```

## Como Usar

### ⚙️ Criando a API com .NET 10

Primeiro, vamos criar uma API simples utilizando o CLI do .NET.

📌 **Documentação oficial**: [https://learn.microsoft.com/dotnet/core/tools/](https://learn.microsoft.com/dotnet/core/tools/)

```bash
dotnet new webapi -n ProductApi
cd ProductApi
```

Execute a aplicação:

```bash
dotnet run
```

**Endpoint de exemplo:**

```csharp
app.MapGet("/products", () =>
{
    var products = new[]
    {
        new { Id = 1, Name = "Notebook", Price = 3500 },
        new { Id = 2, Name = "Mouse", Price = 120 }
    };

    return products;
});
```

A API estará disponível em:

👉 `http://localhost:5000/products`

### 🧩 Instalando o Tyk API Gateway

A maneira mais simples de executar o gateway é utilizando Docker.

📌 **Documentação oficial do Tyk Gateway**: [https://tyk.io/docs/tyk-gateway/](https://tyk.io/docs/tyk-gateway/)

```bash
docker run -d \
  -p 8080:8080 \
  tykio/tyk-gateway
```

Após subir o container, o gateway já estará pronto para configuração.

## Configuração do Tyk

### 📦 Criando uma Definição de API no Tyk

O Tyk utiliza arquivos JSON para definir APIs.

**Exemplo de configuração:**

```json
{
  "name": "Product API",
  "api_id": "product-api",
  "org_id": "default",
  "use_keyless": true,
  "proxy": {
    "listen_path": "/products/",
    "target_url": "http://host.docker.internal:5000/",
    "strip_listen_path": true
  }
}
```

### Explicando os principais campos:

| Campo         | Descrição                   |
| ------------- | --------------------------- |
| `name`        | Nome da API                 |
| `api_id`      | Identificador único         |
| `use_keyless` | Permite acesso sem chave    |
| `listen_path` | Endpoint exposto no gateway |
| `target_url`  | URL da API real             |

### 🔄 Fluxo da Requisição

```
    Cliente
       │
       ▼
    http://localhost:8080/products
       │
       ▼
    Tyk API Gateway
       │
       ▼
    API .NET 10
```

Ou seja: **o cliente não acessa diretamente a API**.

## Segurança e Autenticação

### 🔐 Adicionando Segurança com API Key

Para proteger sua API:

```json
"use_keyless": false
```

Agora cada requisição deve enviar:

```
Authorization: Bearer API_KEY
```

Isso permite:

- ✅ Controle de acesso
- ✅ Limite de requisições
- ✅ Monitoramento por cliente

📌 **Documentação**: [Authentication](https://tyk.io/docs/nightly/api-management/authentication/basic-authentication#configuring-your-api-to-use-basic-authentication)

## Observabilidade

### 📊 Monitoramento e Métricas

O Tyk oferece:

- 📝 **Logs centralizados**
- 📈 **Métricas de consumo**
- ⚡ **Rate limiting**
- 📊 **Analytics de API**

Esses dados são essenciais em ambientes com:

- Múltiplos microserviços
- Alto volume de requisições
- Integrações com terceiros

## Testando a Integração

### 🧪 Testando a Integração

Após configurar o gateway, basta chamar:

```bash
GET http://localhost:8080/products
```

**Resposta esperada:**

```json
[
  { "id": 1, "name": "Notebook", "price": 3500 },
  { "id": 2, "name": "Mouse", "price": 120 }
]
```

Mesmo resultado da API original — porém agora **gerenciado pelo gateway**.

### ⚡ Benefícios de Usar Tyk com .NET

- 🔹 **Escalabilidade**: Preparado para crescer
- 🔹 **Segurança centralizada**: Um ponto de controle
- 🔹 **Observabilidade robusta**: Visibilidade completa
- 🔹 **Governança e versionamento**: Controle total das APIs

## Quando Utilizar um API Gateway

Use um gateway quando:

- ✅ Há múltiplos microserviços
- ✅ Há integração com sistemas externos
- ✅ É necessário controle de segurança centralizado
- ✅ Existe alto volume de chamadas de API

> **Nota**: Em aplicações pequenas, pode ser exagero. Avalie a complexidade do seu cenário antes de implementar.

## Contribuições

Contribuições são bem-vindas! Este projeto está aberto para melhorias e novas funcionalidades.

### Como Contribuir

1. **Fork o projeto**
2. **Crie uma branch para sua feature** (`git checkout -b feature/AmazingFeature`)
3. **Commit suas mudanças** (`git commit -m 'feat: Add some AmazingFeature'`)
4. **Push para a branch** (`git push origin feature/AmazingFeature`)
5. **Abra um Pull Request**

### Reportar Bugs

Se encontrar algum bug, por favor:
- Abra uma [Issue](https://github.com/daniloopinheiro/TykNet/issues) descrevendo o problema
- Inclua passos para reproduzir o erro
- Adicione logs ou screenshots quando relevante

### Solicitar Funcionalidades

Tem uma ideia? Abra uma [Issue](https://github.com/daniloopinheiro/TykNet/issues) com a tag `enhancement` descrevendo a funcionalidade desejada.

## Artigos & Conteúdos

Se você trabalha com .NET moderno e quer evoluir em temas como arquitetura, C#, DevOps, APIs e interoperabilidade:

* 💼 [LinkedIn](https://www.linkedin.com/in/daniloopinheiro)
* 💻 [DEV Community](https://dev.to/daniloopinheiro)
* ✍️ [Medium](https://daniloopinheiro.medium.com/)
* 📰 [Substack](https://substack.com/@daniloopinheiro)
* 📧 [Email](mailto:daniloopinheiro@dopme.io)

## Licença

MIT License © 2025 [LICENSE.md](LICENSE.md) — por [Danilo O. Pinheiro](https://www.linkedin.com/in/daniloopinheiro/)

## Contato

### 💬 Suporte Técnico
Para questões técnicas, problemas ou sugestões:
- **Issues**: [GitHub Issues](https://github.com/daniloopinheiro/TykNet/issues)
- **Discussions**: [GitHub Discussions](https://github.com/daniloopinheiro/TykNet/discussions)

### 👨‍💻 Autor
**Danilo O. Pinheiro**  
Especialista em .NET, Clean Architecture, API Gateway e Arquitetura de Microserviços

- **Email Pessoal**: [daniloopro@gmail.com](mailto:daniloopro@gmail.com)
- **Email Empresarial**: [devsfree@devsfree.com.br](mailto:devsfree@devsfree.com.br)
- **Consultoria**: [contato@dopme.io](mailto:contato@dopme.io)
- **LinkedIn**: [Danilo O. Pinheiro](https://www.linkedin.com/in/daniloopinheiro/)

### 🏢 Empresas
- **[DevsFree](https://devsfree.com.br)**: Desenvolvimento de Software
- **[dopme.io](https://dopme.io)**: Consultoria e Soluções Tecnológicas

---

## 🔮 O Futuro das APIs no .NET

Com a evolução do .NET e da arquitetura baseada em APIs, ferramentas como API Gateways tendem a se tornar cada vez mais comuns.

Plataformas modernas buscam:

- ✅ Padronização de integração
- ✅ Segurança centralizada
- ✅ Observabilidade completa
- ✅ Redução da complexidade do cliente

O Tyk é uma das opções mais poderosas nesse ecossistema.

## ✅ Conclusão

A integração entre **.NET 10 e o Tyk API Gateway** demonstra como arquiteturas modernas podem ser construídas de forma escalável e organizada.

Centralizando segurança, monitoramento e controle de tráfego, o gateway simplifica o desenvolvimento e melhora a governança em ambientes de APIs.

Para equipes que trabalham com microserviços ou integrações complexas, essa abordagem oferece ganhos expressivos de produtividade e confiabilidade.

---

<div align="center">

**⭐ Se este projeto foi útil, deixe uma estrela no GitHub! ⭐**

<p>
Feito com ❤️ por <strong>Danilo O. Pinheiro</strong><br/>  
<a href="https://devsfree.com.br" target="_blank">DevsFree</a> • <a href="https://dopme.io" target="_blank">dopme.io</a>  
</p>

> O norte e o sul tu os criaste; Tabor e Hermom jubilam em teu nome.  
> Tu tens um braço poderoso; forte é a tua mão, e alta está a tua destra.  
> **Salmos 89:12,13**

</div>
