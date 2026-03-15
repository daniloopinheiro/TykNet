# 📦 Guia de Releases

Este guia explica como criar releases automaticamente no GitHub usando o workflow de CD.

## 🎯 Como Criar uma Release

### Método 1: Usando Tags (Recomendado)

1. **Certifique-se que tudo está commitado**:
   ```bash
   git status
   ```

2. **Crie uma tag seguindo o Semantic Versioning**:
   ```bash
   # Para uma nova versão maior (breaking changes)
   git tag v2.0.0
   
   # Para uma nova funcionalidade (backward compatible)
   git tag v1.1.0
   
   # Para correções de bugs
   git tag v1.0.1
   
   # Para pre-releases
   git tag v1.0.0-alpha.1
   git tag v1.0.0-beta.1
   git tag v1.0.0-rc.1
   ```

3. **Envie a tag para o GitHub**:
   ```bash
   git push origin v1.0.0
   ```

4. **Aguarde o workflow executar**:
   - Acesse a aba `Actions` no GitHub
   - O workflow `CD - Deploy` será executado automaticamente
   - Uma release será criada automaticamente

### Método 2: Manual pelo GitHub

1. Vá em `Releases` no GitHub
2. Clique em `Draft a new release`
3. Clique em `Choose a tag` e crie uma nova tag (ex: `v1.0.0`)
4. Preencha o título e descrição
5. Clique em `Publish release`

## 📋 O que é Criado Automaticamente

Quando você cria uma tag no formato `v*`, o workflow de CD cria automaticamente:

### ✅ Release no GitHub contendo:

1. **Changelog Detalhado** categorizando os commits por tipo:
   - ✨ Novas Funcionalidades (`feat:`)
   - 🐛 Correções de Bugs (`fix:`)
   - 📝 Documentação (`docs:`)
   - 🔧 Outras Mudanças

2. **Estatísticas**:
   - Número total de commits
   - Número de contribuidores
   - Tag anterior

3. **Arquivos da Release**:
   - `VERSION.txt` - Informações sobre a versão
   - `source-code.zip` - Código fonte em ZIP
   - `source-code.tar.gz` - Código fonte em TAR.GZ
   - `LICENSE.md` - Arquivo de licença

4. **Instruções de Instalação**:
   - Comandos para clonar e usar a versão específica
   - Links para documentação
   - Link para reportar issues

5. **Comentários Automáticos**:
   - O workflow comenta automaticamente nas issues fechadas recentemente
   - Informa que a issue foi incluída na release

## 🏷️ Convenção de Versionamento

Use [Semantic Versioning](https://semver.org/):

```
v[MAJOR].[MINOR].[PATCH][-PRERELEASE]
```

### Exemplos:

- `v1.0.0` - Primeira release estável
- `v1.1.0` - Nova funcionalidade
- `v1.1.1` - Correção de bug
- `v2.0.0` - Mudança com breaking change
- `v1.0.0-alpha.1` - Pre-release alpha
- `v1.0.0-beta.1` - Pre-release beta
- `v1.0.0-rc.1` - Release candidate

### Quando incrementar cada parte:

- **MAJOR** (v**X**.0.0): Mudanças incompatíveis com versões anteriores
- **MINOR** (v1.**X**.0): Novas funcionalidades compatíveis com versões anteriores
- **PATCH** (v1.0.**X**): Correções de bugs

## 📝 Commits Semânticos

Para gerar changelogs organizados, use commits semânticos:

```bash
# Novas funcionalidades
git commit -m "feat: adiciona autenticação com JWT"
git commit -m "feat(api): adiciona endpoint de usuários"

# Correções
git commit -m "fix: corrige erro no login"
git commit -m "fix(auth): corrige validação de token"

# Documentação
git commit -m "docs: atualiza README com instruções de instalação"

# Refatoração
git commit -m "refactor: melhora estrutura de pastas"

# Performance
git commit -m "perf: otimiza queries do banco de dados"

# Testes
git commit -m "test: adiciona testes para controller de usuários"

# Build/CI
git commit -m "build: atualiza dependências"
git commit -m "ci: adiciona workflow de deploy"

# Outros
git commit -m "chore: atualiza .gitignore"
git commit -m "style: formata código com prettier"
```

## 🔄 Fluxo Completo de Release

```bash
# 1. Criar uma branch de release
git checkout -b release/v1.0.0

# 2. Atualizar versão em arquivos (se houver)
# package.json, pyproject.toml, etc.

# 3. Atualizar CHANGELOG.md (opcional, o workflow gera automaticamente)
echo "## [1.0.0] - $(date +%Y-%m-%d)" >> CHANGELOG.md

# 4. Commit das mudanças
git add .
git commit -m "chore: prepare release v1.0.0"

# 5. Merge para main
git checkout main
git merge release/v1.0.0

# 6. Criar e enviar a tag
git tag v1.0.0
git push origin main
git push origin v1.0.0

# 7. Aguardar o workflow criar a release
```

## 🎨 Personalizando o Changelog

O changelog é gerado automaticamente, mas você pode personalizar editando o arquivo `.github/workflows/cd.yml` na seção `create-release`.

### Adicionar novas categorias:

```yaml
# Exemplo: adicionar categoria "Performance"
PERF=$(git log $PREVIOUS_TAG..HEAD --pretty=format:"- %s (%h)" --no-merges | grep -i "perf:" || echo "")
if [ -n "$PERF" ]; then
  echo "### ⚡ Performance" >> changelog.md
  echo "$PERF" | sed 's/perf: //' >> changelog.md
  echo "" >> changelog.md
fi
```

## 🚨 Pre-releases

Para marcar uma release como pre-release, use tags com sufixos:

```bash
# Alpha
git tag v1.0.0-alpha.1

# Beta
git tag v1.0.0-beta.1

# Release Candidate
git tag v1.0.0-rc.1
```

Releases com esses sufixos serão automaticamente marcadas como "pre-release" no GitHub.

## 📊 Verificar Releases

### Via GitHub:
- Acesse `https://github.com/SEU-USUARIO/SEU-REPO/releases`

### Via API:
```bash
# Listar todas as releases
curl -H "Accept: application/vnd.github.v3+json" \
  https://api.github.com/repos/SEU-USUARIO/SEU-REPO/releases

# Obter a última release
curl -H "Accept: application/vnd.github.v3+json" \
  https://api.github.com/repos/SEU-USUARIO/SEU-REPO/releases/latest
```

### Via Git:
```bash
# Listar todas as tags
git tag -l

# Ver detalhes de uma tag
git show v1.0.0

# Checkout de uma versão específica
git checkout v1.0.0
```

## 🔧 Troubleshooting

### A release não foi criada

1. **Verifique se a tag tem o formato correto** (`v*`):
   ```bash
   git tag  # deve mostrar tags como v1.0.0
   ```

2. **Verifique o workflow no Actions**:
   - Acesse a aba `Actions`
   - Procure pelo workflow `CD - Deploy`
   - Verifique os logs de erro

3. **Verifique as permissões**:
   - O workflow precisa de permissão `contents: write`
   - Verifique se está configurado em `cd.yml`

### O changelog está vazio

1. **Use commits semânticos**:
   ```bash
   git commit -m "feat: minha funcionalidade"
   ```

2. **Certifique-se que há commits desde a última tag**:
   ```bash
   git log $(git describe --tags --abbrev=0)..HEAD
   ```

### Erro de permissão

Se aparecer erro de permissão ao criar a release:

1. Vá em `Settings` > `Actions` > `General`
2. Em `Workflow permissions`, selecione `Read and write permissions`
3. Salve e execute o workflow novamente

## 📚 Recursos Adicionais

- [Semantic Versioning](https://semver.org/)
- [Conventional Commits](https://www.conventionalcommits.org/)
- [GitHub Releases](https://docs.github.com/en/repositories/releasing-projects-on-github)
- [Keep a Changelog](https://keepachangelog.com/)

---

## ✅ Checklist de Release

Use este checklist antes de criar uma release:

- [ ] Todos os testes passam
- [ ] Documentação está atualizada
- [ ] CHANGELOG foi revisado (ou será gerado automaticamente)
- [ ] Versão foi incrementada corretamente
- [ ] Breaking changes estão documentados (se houver)
- [ ] Commits seguem o padrão semântico
- [ ] Branch está sincronizada com main
- [ ] Tag segue o formato `v*.*.*`
- [ ] Workflow de CI passou com sucesso

**Pronto para criar a release!** 🚀

