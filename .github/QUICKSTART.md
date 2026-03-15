# 🚀 Quick Start - GitHub Actions CI/CD

Guia rápido para começar a usar os workflows de CI/CD neste projeto.

## 🎯 Este é um Repositório Template

O **dopBase** é um repositório base que você pode usar como ponto de partida para novos projetos. Ele já vem com todos os workflows de CI/CD configurados e prontos para uso.

## 📋 Pré-requisitos

- Repositório no GitHub (você pode usar este como template)
- Código em alguma das tecnologias suportadas (Node.js, Python, .NET, Java, Go)

## ⚡ Início Rápido

### 1. Os Workflows Já Estão Configurados!

Os workflows já estão no diretório `.github/workflows/` e serão executados automaticamente quando você:

- ✅ Fizer push para `main` ou `develop`
- ✅ Criar um Pull Request
- ✅ Criar uma tag de versão (ex: `v1.0.0`)

### 2. Primeiro Push

```bash
# Adicione seus arquivos
git add .

# Commit com mensagem semântica
git commit -m "feat: adiciona nova funcionalidade"

# Push para main
git push origin main
```

### 3. Verificar Execução

1. Acesse a aba **Actions** no GitHub
2. Você verá os workflows em execução
3. Clique em um workflow para ver detalhes

## 🎯 Casos de Uso Comuns

### Criar um Pull Request

```bash
# Crie uma branch
git checkout -b feature/minha-feature

# Faça suas alterações
git add .
git commit -m "feat: adiciona minha feature"

# Push da branch
git push origin feature/minha-feature
```

Depois, crie o PR no GitHub. Os workflows de CI e PR Automation serão executados automaticamente.

### Fazer Deploy para Produção

**Opção 1: Deploy automático (push para main)**
```bash
git checkout main
git merge feature/minha-feature
git push origin main
```

**Opção 2: Deploy manual**
1. Vá em `Actions` > `CD - Deploy`
2. Clique em `Run workflow`
3. Selecione `production`
4. Clique em `Run workflow`

### Criar uma Release

```bash
# Crie e publique uma tag
git tag v1.0.0
git push origin v1.0.0
```

O workflow criará automaticamente a release no GitHub com changelog.

## 🔧 Configuração Inicial por Tecnologia

### Node.js / JavaScript / TypeScript

Seu `package.json` deve ter os scripts:

```json
{
  "scripts": {
    "build": "...",
    "test": "...",
    "lint": "..."
  }
}
```

### Python

Crie um `requirements.txt`:

```txt
flask==3.0.0
pytest==7.4.3
```

### .NET

Tenha um arquivo `.sln` ou `.csproj` no repositório.

### Java

Tenha um `pom.xml` (Maven) ou `build.gradle` (Gradle).

### Go

Tenha um `go.mod` no repositório.

## 📦 Arquivos de Configuração Opcionais

Os workflows detectam automaticamente se você tem arquivos de configuração específicos. Crie-os **apenas se necessário** para seu projeto:

- `k6-test.js` - Testes de performance com k6 (opcional)
- `.pa11yci.json` - Testes de acessibilidade (opcional)
- `sonar-project.properties` - Configuração do SonarCloud (opcional)
- `Dockerfile` - Para build de containers (opcional)
- `.lighthouserc.json` - Configuração do Lighthouse (opcional)

> **Nota**: Este repositório template **não** inclui esses arquivos por padrão. Os workflows funcionam sem eles e você pode adicioná-los conforme necessário.

## 🔐 Configurar Deploys (Opcional)

Para habilitar deploys automáticos, configure os secrets necessários:

### Deploy Frontend (escolha um)

**Vercel:**
```
VERCEL_TOKEN
VERCEL_ORG_ID
VERCEL_PROJECT_ID
```

**Netlify:**
```
NETLIFY_AUTH_TOKEN
NETLIFY_SITE_ID
```

**GitHub Pages:**
Nenhuma configuração necessária! Funciona automaticamente.

### Deploy Backend (escolha um)

**Heroku:**
```
HEROKU_API_KEY
HEROKU_APP_NAME
```

**AWS:**
```
AWS_ACCESS_KEY_ID
AWS_SECRET_ACCESS_KEY
AWS_REGION
```

**Azure:**
```
AZURE_WEBAPP_NAME
AZURE_WEBAPP_PUBLISH_PROFILE
```

### Como Adicionar Secrets

1. Vá em `Settings` > `Secrets and variables` > `Actions`
2. Clique em `New repository secret`
3. Adicione nome e valor
4. Salve

## 📊 Monitoramento

### Ver Status dos Builds

Badge no README (adicione ao seu README.md):

```markdown
![CI](https://github.com/SEU-USUARIO/SEU-REPO/workflows/CI%20-%20Build%20%26%20Test/badge.svg)
```

### Ver Logs

1. Acesse `Actions`
2. Clique no workflow
3. Clique no job
4. Expanda os steps para ver logs detalhados

## 🎨 Customização Básica

### Mudar Branches de CI

Edite `.github/workflows/ci.yml`:

```yaml
on:
  push:
    branches: [ main, develop, staging ]  # Adicione suas branches
```

### Desabilitar um Workflow

1. Vá em `Actions`
2. Selecione o workflow
3. Menu `...` > `Disable workflow`

### Adicionar Variáveis de Ambiente

Edite o workflow e adicione:

```yaml
env:
  NODE_ENV: production
  API_URL: https://api.example.com
```

## 🐛 Troubleshooting

### Build Falhando?

1. **Verifique os logs** na aba Actions
2. **Reproduza localmente** com os mesmos comandos
3. **Verifique dependências** em package.json, requirements.txt, etc.

### Workflow Não Executou?

1. Verifique se o arquivo está em `.github/workflows/`
2. Verifique a sintaxe YAML (use um validador online)
3. Verifique os triggers (branches, eventos)

### Testes Falhando?

1. Execute os testes localmente primeiro
2. Verifique se todas as dependências estão instaladas
3. Verifique variáveis de ambiente necessárias

## 📚 Próximos Passos

1. ✅ **Configurar Secrets** para deploys automáticos
2. ✅ **Adicionar Badge** de CI no README
3. ✅ **Configurar SonarCloud** (opcional) para análise de código
4. ✅ **Personalizar workflows** conforme necessário
5. ✅ **Configurar ambientes** no GitHub (staging, production)

## 💡 Dicas

- **Use commits semânticos**: `feat:`, `fix:`, `docs:`, etc.
- **Crie PRs pequenos**: Mais fáceis de revisar e testar
- **Teste localmente**: Antes de fazer push
- **Use branches**: `feature/`, `bugfix/`, `hotfix/`
- **Adicione testes**: Quanto mais cobertura, melhor

## 🆘 Precisa de Ajuda?

- 📖 [Documentação Completa](./.github/README.md)
- 🐛 [Reportar Problema](../issues)
- 💬 [Discussões](../discussions)

## 📋 Checklist Inicial

Use este checklist para configurar seu projeto:

- [ ] Workflows estão em `.github/workflows/`
- [ ] Build local funciona
- [ ] Testes locais passam
- [ ] Package.json (ou equivalente) está configurado
- [ ] README tem informações sobre o projeto
- [ ] Secrets necessários estão configurados
- [ ] Badge de CI adicionado ao README
- [ ] Primeiro PR criado e passou nos checks
- [ ] Deploy teste realizado com sucesso

---

**Pronto!** Seu CI/CD está configurado e funcionando! 🎉

Para informações mais detalhadas, consulte o [README completo](./.github/README.md).

