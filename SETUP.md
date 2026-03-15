# 🚀 Guia de Configuração e Execução - TykNet

Este guia fornece instruções detalhadas para configurar e executar o projeto TykNet localmente.

## 📋 Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) ou superior
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (Windows/Mac) ou [Docker Engine](https://docs.docker.com/engine/install/) (Linux)
- [Docker Compose](https://docs.docker.com/compose/install/) (geralmente incluído com Docker Desktop)
- [Git](https://git-scm.com/downloads)

### Verificando as Instalações

```bash
# Verificar .NET SDK
dotnet --version
# Deve retornar: 10.0.x ou superior

# Verificar Docker
docker --version
docker compose version

# Verificar Git
git --version
```

## 📁 Estrutura do Projeto

```
TykNet/
├── src/
│   ├── ProductApi/      # API de Produtos
│   ├── UserApi/         # API de Usuários
│   └── OrderApi/        # API de Pedidos
├── tyk/
│   ├── tyk.conf         # Configuração do Tyk Gateway
│   └── apps/            # Definições das APIs no Tyk
│       ├── product-api.json
│       ├── user-api.json
│       └── order-api.json
├── docker-compose.yml   # Orquestração dos containers
└── tyknet.sln          # Solution do Visual Studio
```

## 🏃 Executando o Projeto

### Opção 1: Executar com Docker Compose (Recomendado)

Esta é a forma mais simples e recomendada para executar todo o ambiente.

#### 1. Clone o repositório (se ainda não fez)

```bash
git clone https://github.com/daniloopinheiro/TykNet.git
cd TykNet
```

#### 2. Execute o Docker Compose

```bash
docker compose up --build
```

Este comando irá:
- Construir as imagens Docker das três APIs (.NET 10)
- Iniciar os containers das APIs
- Iniciar o Tyk Gateway
- Configurar a rede entre os serviços

#### 3. Aguarde os serviços iniciarem

Você verá logs de inicialização de cada serviço. Aguarde até ver mensagens indicando que todos os serviços estão prontos.

#### 4. Verifique se os serviços estão rodando

```bash
docker compose ps
```

Você deve ver 4 containers rodando:
- `tyknet-product-api`
- `tyknet-user-api`
- `tyknet-order-api`
- `tyknet-gateway`

### Opção 2: Executar Localmente (Sem Docker)

Se preferir executar as APIs localmente sem Docker:

#### 1. Restaure as dependências

```bash
dotnet restore
```

#### 2. Execute cada API em terminais separados

**Terminal 1 - ProductApi:**
```bash
cd src/ProductApi
dotnet run --urls "http://localhost:5001"
```

**Terminal 2 - UserApi:**
```bash
cd src/UserApi
dotnet run --urls "http://localhost:5002"
```

**Terminal 3 - OrderApi:**
```bash
cd src/OrderApi
dotnet run --urls "http://localhost:5003"
```

#### 3. Execute o Tyk Gateway com Docker

```bash
docker run -d \
  -p 8080:8080 \
  -v $(pwd)/tyk/tyk.conf:/opt/tyk-gateway/tyk.conf \
  -v $(pwd)/tyk/apps:/opt/tyk-gateway/apps \
  --name tyknet-gateway \
  tykio/tyk-gateway:v5.3.0 \
  /opt/tyk-gateway/tyk --conf=/opt/tyk-gateway/tyk.conf
```

**Nota para Windows PowerShell:**
```powershell
docker run -d `
  -p 8080:8080 `
  -v ${PWD}/tyk/tyk.conf:/opt/tyk-gateway/tyk.conf `
  -v ${PWD}/tyk/apps:/opt/tyk-gateway/apps `
  --name tyknet-gateway `
  tykio/tyk-gateway:v5.3.0 `
  /opt/tyk-gateway/tyk --conf=/opt/tyk-gateway/tyk.conf
```

**Importante:** Se executar localmente, você precisará ajustar as URLs no Tyk para apontar para `host.docker.internal:5001`, `host.docker.internal:5002`, etc.

## 🧪 Testando as APIs

### Testando Diretamente nas APIs (sem Gateway)

**ProductApi:**
```bash
# Listar produtos
curl http://localhost:5001/products

# Obter produto por ID
curl http://localhost:5001/products/1
```

**UserApi:**
```bash
# Listar usuários
curl http://localhost:5002/users

# Obter usuário por ID
curl http://localhost:5002/users/1
```

**OrderApi:**
```bash
# Listar pedidos
curl http://localhost:5003/orders

# Obter pedido por ID
curl http://localhost:5003/orders/1
```

### Testando através do Tyk Gateway

**ProductApi via Gateway:**
```bash
# Listar produtos
curl http://localhost:8080/products/

# Obter produto por ID
curl http://localhost:8080/products/1
```

**UserApi via Gateway:**
```bash
# Listar usuários
curl http://localhost:8080/users/

# Obter usuário por ID
curl http://localhost:8080/users/1
```

**OrderApi via Gateway:**
```bash
# Listar pedidos
curl http://localhost:8080/orders/

# Obter pedido por ID
curl http://localhost:8080/orders/1
```

### Usando Postman ou Insomnia

1. Importe as coleções ou crie requisições para:
   - `http://localhost:8080/products/`
   - `http://localhost:8080/users/`
   - `http://localhost:8080/orders/`

2. Ou teste diretamente nas APIs:
   - `http://localhost:5001/products`
   - `http://localhost:5002/users`
   - `http://localhost:5003/orders`

## 📊 Endpoints Disponíveis

### ProductApi

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/products` | Lista todos os produtos |
| GET | `/products/{id}` | Obtém produto por ID |
| POST | `/products` | Cria um novo produto |
| DELETE | `/products/{id}` | Remove um produto |
| GET | `/health` | Health check |
| GET | `/` | Informações do serviço |

### UserApi

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/users` | Lista todos os usuários |
| GET | `/users/{id}` | Obtém usuário por ID |
| POST | `/users` | Cria um novo usuário |
| PUT | `/users/{id}` | Atualiza um usuário |
| DELETE | `/users/{id}` | Remove um usuário |
| GET | `/health` | Health check |
| GET | `/` | Informações do serviço |

### OrderApi

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/orders` | Lista todos os pedidos |
| GET | `/orders/{id}` | Obtém pedido por ID |
| GET | `/orders/user/{userId}` | Lista pedidos de um usuário |
| POST | `/orders` | Cria um novo pedido |
| PUT | `/orders/{id}/status` | Atualiza status do pedido |
| DELETE | `/orders/{id}` | Remove um pedido |
| GET | `/health` | Health check |
| GET | `/` | Informações do serviço |

## 🔧 Comandos Úteis

### Docker Compose

```bash
# Iniciar serviços
docker compose up

# Iniciar em background
docker compose up -d

# Parar serviços
docker compose down

# Parar e remover volumes
docker compose down -v

# Ver logs
docker compose logs -f

# Ver logs de um serviço específico
docker compose logs -f product-api

# Reconstruir imagens
docker compose build --no-cache

# Reiniciar um serviço específico
docker compose restart product-api
```

### Desenvolvimento

```bash
# Restaurar dependências
dotnet restore

# Compilar solution
dotnet build

# Executar testes (se houver)
dotnet test

# Limpar build
dotnet clean
```

## 🐛 Solução de Problemas

### Porta já em uso

Se receber erro de porta em uso:

1. **Verifique processos usando as portas:**
   ```bash
   # Windows
   netstat -ano | findstr :8080
   
   # Linux/Mac
   lsof -i :8080
   ```

2. **Altere as portas no docker-compose.yml** se necessário

### Tyk Gateway não encontra as APIs

1. Verifique se as APIs estão rodando:
   ```bash
   docker compose ps
   ```

2. Verifique os logs do Tyk:
   ```bash
   docker compose logs tyk-gateway
   ```

3. Verifique se os arquivos de configuração estão corretos em `tyk/apps/`

### Erro de build das imagens Docker

1. Limpe o cache do Docker:
   ```bash
   docker system prune -a
   ```

2. Reconstrua as imagens:
   ```bash
   docker compose build --no-cache
   ```

### Health checks falhando

Os health checks podem falhar inicialmente enquanto as APIs estão iniciando. Aguarde alguns segundos e verifique novamente:

```bash
docker compose ps
```

## 📚 Documentação Adicional

- [Documentação do Tyk](https://tyk.io/docs/)
- [Documentação do .NET 10](https://learn.microsoft.com/dotnet/core/)
- [Documentação do Docker Compose](https://docs.docker.com/compose/)

## 🆘 Suporte

Se encontrar problemas:

1. Verifique os logs: `docker compose logs`
2. Abra uma [Issue no GitHub](https://github.com/daniloopinheiro/TykNet/issues)
3. Consulte a [documentação do README.md](README.md)

---

**Desenvolvido com ❤️ por [Danilo O. Pinheiro](https://www.linkedin.com/in/daniloopinheiro/)**
