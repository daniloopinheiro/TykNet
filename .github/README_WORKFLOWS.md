# GitHub Actions Workflows

Este diretório contém os workflows de CI/CD e automações para o projeto.

## 📋 Índice

- [Workflows Disponíveis](#workflows-disponíveis)
- [Configuração de Secrets](#configuração-de-secrets)
- [Como Usar](#como-usar)
- [Tecnologias Suportadas](#tecnologias-suportadas)

## 🚀 Workflows Disponíveis

### 1. CI - Build & Test (`ci.yml`)

**Trigger:** Push e Pull Request para `main` e `develop`

**Funcionalidades:**
- ✅ Detecção automática de tecnologias (Node.js, Python, .NET, Java, Go)
- 🏗️ Build automático para cada tecnologia detectada
- 🧪 Execução de testes
- 📊 Análise de código (Linting)
- 🔒 Scan de segurança com Trivy
- 📈 Análise de qualidade com SonarCloud (opcional)
- 🐳 Build de imagens Docker (se existir Dockerfile)
- 📦 Upload de artefatos de build

**Matriz de Testes:**
- Node.js: versões 18.x e 20.x

**Jobs:**
1. `detect-and-build` - Detecta e builda todas as tecnologias
2. `security-scan` - Executa scan de vulnerabilidades
3. `code-quality` - Análise de qualidade de código
4. `notify` - Notifica o status da pipeline

### 2. CD - Deploy (`cd.yml`)

**Trigger:** 
- Push para `main`
- Tags com padrão `v*`
- Manual via workflow_dispatch

**Funcionalidades:**
- 🚀 Deploy automático de frontend (Vercel, Netlify, GitHub Pages)
- 🐳 Build e push de imagens Docker
- ☁️ Deploy para cloud (AWS, Heroku, Azure)
- 📝 Criação automática de releases
- 🏷️ Geração de changelog

**Ambientes Suportados:**
- Staging
- Production

**Plataformas de Deploy:**
- **Frontend:** Vercel, Netlify, GitHub Pages
- **Backend:** AWS (Serverless), Heroku, Azure
- **Container:** Docker Hub, GitHub Container Registry

### 3. Dependencies Check & Update (`dependencies.yml`)

**Trigger:**
- Agendado (toda segunda-feira às 9h)
- Push de arquivos de dependências
- Manual

**Funcionalidades:**
- 🔍 Verificação de vulnerabilidades em dependências
- 📦 Detecção de pacotes desatualizados
- 🔄 Atualização automática de dependências (agendada)
- 📄 Criação automática de PR com atualizações
- ⚖️ Verificação de licenças
- 📊 Análise de tamanho de bundle

**Tecnologias Cobertas:**
- Node.js (npm audit)
- Python (safety)
- .NET (dotnet list package)
- Java (Maven)
- Go (govulncheck)

### 4. PR Automation (`pr-automation.yml`)

**Trigger:** Eventos de Pull Request

**Funcionalidades:**
- 🏷️ Labeling automático por tipo de arquivo
- 📏 Labeling por tamanho do PR
- ✅ Validação de título semântico
- 📊 Estatísticas de mudanças
- 🔍 Detecção de TODOs e console.logs
- 🤖 Auto-merge de PRs do Dependabot
- 💬 Comandos via comentários

**Comandos Disponíveis nos Comentários:**
- `/review` - Solicitar revisão automática
- `/rebase` - Instruções para rebase
- `/help` - Mostrar comandos disponíveis

**Labels Automáticas:**
- Por tamanho: `size/xs`, `size/s`, `size/m`, `size/l`, `size/xl`
- Por tipo: `frontend`, `backend`, `testing`, `documentation`, etc.
- Status: `ready-to-merge`

## 🔐 Configuração de Secrets

Para utilizar todos os recursos dos workflows, configure os seguintes secrets no GitHub:

### Deploy - Frontend

```
VERCEL_TOKEN          # Token de autenticação da Vercel
VERCEL_ORG_ID         # ID da organização Vercel
VERCEL_PROJECT_ID     # ID do projeto Vercel

NETLIFY_AUTH_TOKEN    # Token de autenticação da Netlify
NETLIFY_SITE_ID       # ID do site Netlify
```

### Deploy - Backend

```
DOCKERHUB_USERNAME    # Usuário Docker Hub
DOCKERHUB_TOKEN       # Token Docker Hub

AWS_ACCESS_KEY_ID     # AWS Access Key
AWS_SECRET_ACCESS_KEY # AWS Secret Key
AWS_REGION            # AWS Region (ex: us-east-1)

HEROKU_API_KEY        # API Key do Heroku
HEROKU_APP_NAME       # Nome da aplicação no Heroku

AZURE_WEBAPP_NAME            # Nome da Web App no Azure
AZURE_WEBAPP_PUBLISH_PROFILE # Publish Profile do Azure
```

### Análise de Código

```
SONAR_TOKEN           # Token do SonarCloud (opcional)
```

### Como Adicionar Secrets

1. Vá em `Settings` > `Secrets and variables` > `Actions`
2. Clique em `New repository secret`
3. Adicione o nome e valor do secret
4. Clique em `Add secret`

## 📖 Como Usar

### Executando Workflows Manualmente

1. Acesse a aba `Actions` no GitHub
2. Selecione o workflow desejado
3. Clique em `Run workflow`
4. Selecione a branch e parâmetros (se houver)
5. Clique em `Run workflow`

### Criando um Pull Request

Os workflows de CI e PR Automation serão executados automaticamente quando você:

1. Criar um novo Pull Request
2. Fazer push de novos commits em um PR existente

### Deploy Manual

1. Vá em `Actions` > `CD - Deploy`
2. Clique em `Run workflow`
3. Selecione o ambiente (`staging` ou `production`)
4. Clique em `Run workflow`

### Criando uma Release

Para criar uma release automaticamente:

1. Crie uma tag com o padrão semântico:
   ```bash
   git tag v1.0.0
   git push origin v1.0.0
   ```
2. O workflow criará automaticamente a release com changelog

## 🛠️ Tecnologias Suportadas

### Frontend
- ✅ Node.js / JavaScript / TypeScript
- ✅ React / Vue / Angular / Svelte
- ✅ Next.js / Nuxt.js / Gatsby
- ✅ Vite / Webpack / Parcel

### Backend
- ✅ Node.js / Express / NestJS
- ✅ Python / Django / Flask / FastAPI
- ✅ .NET / ASP.NET Core
- ✅ Java / Spring Boot
- ✅ Go / Gin / Echo

### Gerenciadores de Pacotes
- ✅ npm
- ✅ yarn
- ✅ pnpm
- ✅ pip
- ✅ Maven
- ✅ Gradle
- ✅ NuGet
- ✅ Go modules

### Containers
- ✅ Docker
- ✅ Docker Compose

## 📝 Padrões Recomendados

### Nomenclatura de Branches

```
feature/nome-da-feature
bugfix/nome-do-bug
hotfix/nome-do-hotfix
release/versao
docs/nome-da-doc
refactor/nome-do-refactor
test/nome-do-teste
```

### Commits Semânticos

```
feat: adiciona nova funcionalidade
fix: corrige um bug
docs: atualiza documentação
style: formatação de código
refactor: refatoração de código
perf: melhoria de performance
test: adiciona testes
build: mudanças no sistema de build
ci: mudanças nos workflows de CI/CD
chore: tarefas gerais
revert: reverte um commit anterior
```

### Títulos de Pull Request

Use o padrão de commits semânticos:

```
feat: adiciona autenticação de usuário
fix: corrige erro no formulário de login
docs: atualiza README com instruções de instalação
```

## 🔧 Customização

### Modificando Triggers

Para alterar quando um workflow é executado, edite a seção `on:` do arquivo:

```yaml
on:
  push:
    branches: [ main, develop, staging ]
  pull_request:
    branches: [ main ]
```

### Adicionando Novos Jobs

```yaml
jobs:
  meu-novo-job:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - name: Executar algo
        run: echo "Olá Mundo"
```

### Desabilitando Workflows

Para desabilitar temporariamente um workflow sem deletá-lo:

1. Vá em `Actions`
2. Selecione o workflow
3. Clique no menu `...`
4. Selecione `Disable workflow`

## 🐛 Troubleshooting

### Build Falhando

1. Verifique os logs do workflow na aba `Actions`
2. Confirme que todas as dependências estão corretas
3. Execute o build localmente para reproduzir o erro
4. Verifique se os secrets estão configurados corretamente

### Deploy Falhando

1. Verifique se os secrets de deploy estão configurados
2. Confirme as permissões de acesso às plataformas
3. Verifique os logs do job de deploy

### PR Checks Não Passando

1. Revise os erros de lint
2. Execute os testes localmente
3. Verifique conflitos de merge
4. Certifique-se que o código está formatado corretamente

## 📚 Recursos Adicionais

- [GitHub Actions Documentation](https://docs.github.com/en/actions)
- [Workflow Syntax](https://docs.github.com/en/actions/reference/workflow-syntax-for-github-actions)
- [GitHub Actions Marketplace](https://github.com/marketplace?type=actions)

## 🤝 Contribuindo

Para melhorar estes workflows:

1. Crie uma branch: `git checkout -b melhoria/workflow-xyz`
2. Faça suas alterações
3. Teste localmente usando [act](https://github.com/nektos/act)
4. Crie um Pull Request
5. Aguarde a revisão

## 📄 Licença

Este projeto segue a licença do repositório principal.

---

**Última atualização:** Outubro 2025
**Mantido por:** Time de DevOps
