# Pull Request Template

### Merge: `{branch_origem}` → `{branch_destino}` — Tipo: `{tipo_merge}`

## 📋 Descrição

### Resumo das Mudanças
<!-- Forneça uma descrição clara e concisa das mudanças propostas -->

### Motivação e Contexto
<!-- Por que essa mudança é necessária? Que problema resolve? -->
<!-- Se corrige uma issue, inclua o link: "Fixes #123" -->

### Tipo de Issue
<!-- Se aplicável, indique o tipo de issue que este PR resolve -->
- [ ] Bug Report
- [ ] Feature Request
- [ ] Improvement
- [ ] Documentation
- [ ] Question

## 🔄 Tipo de Mudança

<!-- Marque com [x] todos os tipos que se aplicam -->

- [ ] 🐛 **Bug fix** (correção que resolve um problema)
- [ ] ✨ **Nova funcionalidade** (mudança que adiciona uma funcionalidade)
- [ ] 💥 **Breaking change** (mudança que quebra compatibilidade com versões anteriores)
- [ ] 🔧 **Refatoração** (mudança de código que não corrige bug nem adiciona funcionalidade)
- [ ] 📝 **Documentação** (mudanças apenas na documentação)
- [ ] 🎨 **Estilo** (formatação, espaços em branco, ponto e vírgula, etc)
- [ ] ⚡ **Performance** (mudança que melhora a performance)
- [ ] ✅ **Testes** (adição ou correção de testes)
- [ ] 🔨 **Chore** (mudanças no processo de build, dependências, ferramentas auxiliares, etc)
- [ ] 🔄 **Sync** (sincronização entre branches)
- [ ] 🔐 **Segurança** (correção de vulnerabilidade de segurança)
- [ ] ♿ **Acessibilidade** (melhoria de acessibilidade)
- [ ] 🌐 **Internacionalização** (i18n/l10n)

## 🎯 Escopo

<!-- Marque as áreas do projeto afetadas -->

### Frontend
- [ ] UI/UX
- [ ] Componentes
- [ ] Páginas/Views
- [ ] Estilos (CSS/SCSS/Styled Components)
- [ ] State Management (Redux/Context/etc)
- [ ] Roteamento
- [ ] Assets (imagens, ícones, etc)

### Backend
- [ ] API/Endpoints
- [ ] Controllers
- [ ] Services/Business Logic
- [ ] Models/Entities
- [ ] Middleware
- [ ] Authentication/Authorization
- [ ] Validators

### Banco de Dados
- [ ] Schema/Migrations
- [ ] Seeds/Fixtures
- [ ] Queries/ORM
- [ ] Índices
- [ ] Procedures/Functions

### Infraestrutura
- [ ] Docker/Containers
- [ ] CI/CD Pipelines
- [ ] Deploy Scripts
- [ ] Configurações de Servidor
- [ ] Cloud Services (AWS/Azure/GCP)
- [ ] Kubernetes/Orchestration
- [ ] Monitoramento/Logging

### DevOps/Tools
- [ ] Build Configuration
- [ ] Package Manager
- [ ] Linters/Formatters
- [ ] Git Hooks
- [ ] Scripts de Automação

### Outros
- [ ] Mobile (iOS/Android/React Native/Flutter)
- [ ] Desktop (Electron/Tauri)
- [ ] CLI Tools
- [ ] Bibliotecas/SDKs
- [ ] Testes (Unit/Integration/E2E)
- [ ] Documentação Técnica
- [ ] Configurações de Ambiente

## 🧪 Como Testar

### Pré-requisitos
<!-- Liste qualquer configuração especial necessária -->
- [ ] 
- [ ] 
- [ ] 

### Ambiente de Desenvolvimento
<!-- Informações sobre o ambiente necessário -->
```bash
# Versões necessárias (Node, Python, Ruby, Go, etc)
# Exemplo:
# Node: v18.x
# Python: 3.11+
# Docker: 20.x
```

### Instalação e Configuração
<!-- Passos para configurar o ambiente -->
```bash
# Clonar e instalar dependências
git clone [url]
cd [projeto]

# Instalar dependências
# npm install / yarn / pip install -r requirements.txt / composer install / etc

# Configurar variáveis de ambiente
# cp .env.example .env

# Executar migrations/seeds
# npm run migrate / python manage.py migrate / etc
```

### Passos para Testar
1. 
2. 
3. 
4. 
5. 

### Cenários de Teste
<!-- Liste os cenários que devem ser testados -->
- [ ] **Cenário 1:** 
  - Pré-condição: 
  - Passos: 
  - Resultado esperado: 

- [ ] **Cenário 2:** 
  - Pré-condição: 
  - Passos: 
  - Resultado esperado: 

- [ ] **Cenário 3:** 
  - Pré-condição: 
  - Passos: 
  - Resultado esperado: 

### Casos Extremos/Edge Cases
<!-- Cenários específicos que devem ser testados -->
- [ ] 
- [ ] 
- [ ] 

## 📊 Impacto da Mudança

### Áreas do Sistema Afetadas
<!-- Descreva quais partes do sistema são impactadas -->
- 
- 
- 

### Compatibilidade
- [ ] **Backward Compatible** (compatível com versões anteriores)
- [ ] **Breaking Changes** (quebra compatibilidade - requer atenção especial)

### Dependências
<!-- Esta mudança depende de outros PRs, issues ou mudanças externas? -->
- [ ] Depende de: #
- [ ] Bloqueia: #
- [ ] Relacionado a: #

### Impacto de Performance
<!-- Esta mudança afeta a performance? -->
- [ ] Melhora performance
- [ ] Sem impacto significativo
- [ ] Pode impactar performance (explicar abaixo)
- [ ] Requer testes de performance

**Detalhes:**

### Impacto em Usuários
<!-- Como esta mudança afeta os usuários finais? -->
- [ ] Não afeta usuários
- [ ] Melhora experiência do usuário
- [ ] Requer ação do usuário
- [ ] Pode causar inconveniência temporária

**Descrição do impacto:**

## 📸 Screenshots/GIFs/Vídeos

<!-- Se aplicável, adicione evidências visuais das mudanças -->

### Antes
<!-- Screenshot/descrição/vídeo do estado anterior -->

### Depois
<!-- Screenshot/descrição/vídeo do estado atual -->

### Demo
<!-- Link para demo, se disponível -->

## ✅ Checklist

### Código
- [ ] Meu código segue o style guide e padrões do projeto
- [ ] Realizei uma auto-revisão cuidadosa do meu código
- [ ] Comentei partes complexas do código quando necessário
- [ ] Minhas mudanças não geram novos warnings ou erros
- [ ] Removi código comentado, console.logs e debuggers desnecessários
- [ ] Segui os princípios SOLID/DRY/KISS quando aplicável
- [ ] Tratei adequadamente possíveis erros e exceções
- [ ] Validei entradas de usuário e sanitizei dados quando necessário

### Testes
- [ ] Adicionei testes que comprovam que minha correção/funcionalidade funciona
- [ ] Testes unitários novos e existentes passam localmente
- [ ] Testes de integração passam (se aplicável)
- [ ] Testes E2E passam (se aplicável)
- [ ] Cobertura de testes foi mantida ou melhorada
- [ ] Testei cenários de erro e edge cases
- [ ] Testei em diferentes ambientes (dev/staging)

### Compatibilidade (se aplicável)
- [ ] Testei em diferentes navegadores (Chrome, Firefox, Safari, Edge)
- [ ] Testei em diferentes dispositivos (Desktop, Tablet, Mobile)
- [ ] Testei em diferentes resoluções de tela
- [ ] Testei em diferentes sistemas operacionais
- [ ] Verifiquei compatibilidade com versões antigas (se necessário)

### Documentação
- [ ] Documentei código complexo com comentários apropriados
- [ ] Atualizei documentação técnica (se necessário)
- [ ] Atualizei README.md (se necessário)
- [ ] Atualizei CHANGELOG.md (se necessário)
- [ ] Atualizei documentação de API (Swagger/OpenAPI/etc)
- [ ] Adicionei/atualizei JSDoc/docstrings/comentários de tipo
- [ ] Criei/atualizei diagramas (se necessário)
- [ ] Documentei variáveis de ambiente necessárias

### Segurança
- [ ] Não expus informações sensíveis (senhas, tokens, keys)
- [ ] Implementei validação e sanitização de inputs
- [ ] Verifiquei vulnerabilidades conhecidas em dependências
- [ ] Segui práticas de segurança (OWASP quando aplicável)
- [ ] Implementei rate limiting quando necessário
- [ ] Adicionei logs de auditoria quando apropriado

### Performance
- [ ] Otimizei queries de banco de dados
- [ ] Implementei cache quando apropriado
- [ ] Considerei lazy loading e code splitting (frontend)
- [ ] Otimizei assets (imagens, fonts, etc)
- [ ] Evitei N+1 queries
- [ ] Implementei paginação quando necessário
- [ ] Verifiquei não há memory leaks

### Acessibilidade (se aplicável)
- [ ] Implementei navegação por teclado
- [ ] Adicionei labels e ARIA attributes apropriados
- [ ] Mantive contraste adequado de cores
- [ ] Testei com screen readers
- [ ] Implementei text alternatives para conteúdo não-textual

### Code Quality
- [ ] Executei linter e corrigi todos os problemas
- [ ] Executei formatter (Prettier/Black/etc)
- [ ] Passei análise estática de código (SonarQube/ESLint/etc)
- [ ] Não há code smells significativos
- [ ] Complexidade ciclomática aceitável
- [ ] Não há duplicação desnecessária de código

### Git
- [ ] Fiz commits atômicos com mensagens descritivas
- [ ] Segui convenção de commits (Conventional Commits se aplicável)
- [ ] Rebase/merge com branch base está atualizado
- [ ] Resolvi todos os conflitos de merge
- [ ] Não há commits de merge desnecessários

### CI/CD
- [ ] Todos os checks do CI passaram
- [ ] Build está passando
- [ ] Testes automatizados passando
- [ ] Análise de código estática passou
- [ ] Não há warnings críticos

## 🔗 Issues e PRs Relacionados

<!-- Use palavras-chave para auto-linking -->
<!-- Fixes: Fecha a issue automaticamente quando o PR for merged -->
<!-- Closes: Mesmo que Fixes -->
<!-- Resolves: Mesmo que Fixes -->
<!-- Relates to: Apenas relaciona, não fecha -->

**Resolve/Fecha:**
- Fixes #
- Closes #

**Relacionado:**
- Relates to #
- Part of #
- Depends on #
- Blocks #

**PRs Relacionados:**
- Depends on PR #
- Follow-up de PR #

## 🚀 Deploy e Rollout

### Estratégia de Deploy
- [ ] Deploy direto
- [ ] Feature flag/toggle
- [ ] Canary deployment
- [ ] Blue-green deployment
- [ ] Rolling deployment
- [ ] A/B testing

### Impacto no Deploy
- [ ] Requer migração de banco de dados
- [ ] Requer novas variáveis de ambiente
- [ ] Requer atualização de dependências
- [ ] Requer mudanças em infraestrutura
- [ ] Requer restart de serviços
- [ ] Requer limpeza de cache
- [ ] Requer comunicação aos usuários
- [ ] Requer janela de manutenção
- [ ] Sem impacto especial no deploy

### Variáveis de Ambiente
<!-- Liste novas variáveis de ambiente necessárias -->
```bash
# Development
# VARIABLE_NAME=default_value

# Staging
# VARIABLE_NAME=staging_value

# Production
# VARIABLE_NAME=production_value
```

### Migrações de Banco de Dados
<!-- Se aplicável, descreva as migrações necessárias -->
```sql
-- Exemplo de migration necessária
```

**Rollback da migration:**
```sql
-- Exemplo de rollback
```

### Ordem de Deploy
<!-- Se houver ordem específica ou passos necessários -->
1. 
2. 
3. 

### Verificações Pós-Deploy
<!-- Lista de verificações a serem feitas após deploy -->
- [ ] 
- [ ] 
- [ ] 

### Plano de Rollback
<!-- Descreva como reverter esta mudança se necessário -->
**Passos para rollback:**
1. 
2. 
3. 

**Tempo estimado para rollback:**

**Impacto do rollback:**

## 📝 Notas Adicionais

### Contexto Adicional
<!-- Qualquer informação adicional que os revisores devem saber -->

### Decisões Técnicas
<!-- Explique decisões técnicas importantes tomadas -->
**Por que esta abordagem?**


**Alternativas consideradas:**
1. 
   - Prós: 
   - Contras: 
   
2. 
   - Prós: 
   - Contras: 

### Débito Técnico
<!-- Esta mudança introduz ou resolve débito técnico? -->
- [ ] Resolve débito técnico existente
- [ ] Não introduz débito técnico
- [ ] Introduz débito técnico (explicar e criar issue de acompanhamento)

**Detalhes:**

### Trade-offs
<!-- Quais trade-offs foram feitos? -->

### Limitações Conhecidas
<!-- Existem limitações conhecidas nesta implementação? -->
- 
- 

### Trabalho Futuro
<!-- Trabalhos relacionados que virão no futuro -->
- [ ] 
- [ ] 
- [ ] 

### Breaking Changes
<!-- Se marcou breaking change acima, detalhe aqui -->
**O que quebra?**


**Como migrar?**


**Versão afetada:**

## 🔍 Revisão de Código

### Áreas que Precisam de Atenção Especial
<!-- Indique áreas específicas onde você quer feedback -->
1. 
2. 
3. 

### Perguntas para Revisores
<!-- Perguntas específicas que você tem -->
1. 
2. 
3. 

### Checklist para Revisores
<!-- Checklist para ajudar os revisores -->
- [ ] Lógica de negócio está correta
- [ ] Código é legível e bem estruturado
- [ ] Não há vulnerabilidades de segurança óbvias
- [ ] Performance é aceitável
- [ ] Testes cobrem casos importantes
- [ ] Documentação é adequada
- [ ] Não há código duplicado desnecessário
- [ ] Variáveis e funções têm nomes significativos

## 👀 Reviewers Sugeridos

<!-- Marque pessoas ou times específicos -->
<!-- @username -->
<!-- @team-name -->

### Por Especialidade
- **Frontend:** 
- **Backend:** 
- **DevOps:** 
- **Security:** 
- **QA:** 
- **Design:** 
- **Product:** 

### Critérios de Aprovação
- [ ] Mínimo de aprovações necessárias: 
- [ ] Aprovação obrigatória de: 
- [ ] CI/CD passando (todos os checks verdes)
- [ ] Sem conflitos pendentes
- [ ] Todas as conversas resolvidas

## 🏷️ Labels e Metadata

### Labels Sugeridas
<!-- Sugira labels que devem ser aplicadas -->

### Milestone
<!-- Se faz parte de uma milestone específica -->
- Milestone: 

### Projects
<!-- Se faz parte de um project board -->
- Project: 

### Prioridade
- [ ] 🔴 Crítica (hotfix, blocker)
- [ ] 🟠 Alta (importante, mas não urgente)
- [ ] 🟡 Média (normal)
- [ ] 🟢 Baixa (nice to have)

### Tamanho Estimado
- [ ] XS (< 1h)
- [ ] S (1-4h)
- [ ] M (4-8h / 1 dia)
- [ ] L (1-3 dias)
- [ ] XL (> 3 dias)

## 📊 Métricas e Análise

### Estatísticas do PR
<!-- Será preenchido automaticamente ou manualmente -->
- **Arquivos alterados:** 
- **Linhas adicionadas:** +
- **Linhas removidas:** -
- **Commits:** 
- **Tempo de desenvolvimento:** 

### Complexidade
<!-- Avalie a complexidade da mudança -->
- [ ] Simples (mudança direta, baixo risco)
- [ ] Moderada (requer alguma análise)
- [ ] Complexa (requer revisão cuidadosa)
- [ ] Muito complexa (múltiplos revisores recomendados)

### Impacto
<!-- Quantas pessoas/sistemas são afetados? -->
- [ ] Mínimo (feature isolada)
- [ ] Moderado (alguns módulos)
- [ ] Significativo (múltiplos módulos)
- [ ] Crítico (core do sistema)

## 🔐 Compliance e Governança

### Regulamentações
<!-- Se aplicável, marque regulamentações relevantes -->
- [ ] GDPR/LGPD
- [ ] HIPAA
- [ ] PCI-DSS
- [ ] SOC 2
- [ ] ISO 27001
- [ ] Outra: 

### Auditoria
- [ ] Requer revisão de segurança
- [ ] Requer revisão legal
- [ ] Requer aprovação de arquitetura
- [ ] Requer documentação de compliance

### Dados Sensíveis
- [ ] Esta mudança processa/armazena dados sensíveis
- [ ] Implementa criptografia adequada
- [ ] Segue políticas de retenção de dados
- [ ] Implementa logs de auditoria

---

## 📋 Checklist para Maintainers

<!-- Esta seção é para os maintainers do projeto -->

### Revisão Técnica
- [ ] Arquitetura e design revisados e aprovados
- [ ] Código revisado e aprovado
- [ ] Segurança verificada
- [ ] Performance analisada
- [ ] Escalabilidade considerada
- [ ] Manutenibilidade adequada

### Qualidade
- [ ] Code review completo realizado
- [ ] Todos os checks de CI/CD passando
- [ ] Cobertura de testes adequada (mínimo: %)
- [ ] Sem regressões detectadas
- [ ] Análise de código estática passou
- [ ] Vulnerabilidades de segurança verificadas

### Documentação
- [ ] Documentação técnica adequada
- [ ] CHANGELOG.md atualizado
- [ ] README.md atualizado (se necessário)
- [ ] API docs atualizadas (se aplicável)
- [ ] Migration guide criado (se breaking change)
- [ ] Release notes preparadas

### Conformidade
- [ ] Segue padrões do projeto
- [ ] Segue guidelines de contribuição
- [ ] License headers corretos (se aplicável)
- [ ] Não viola propriedade intelectual
- [ ] Atende requisitos de compliance

### Deploy
- [ ] Estratégia de deploy definida
- [ ] Plano de rollback validado
- [ ] Comunicação preparada (se necessário)
- [ ] Monitoramento configurado
- [ ] Alertas configurados (se necessário)

### Finalização
- [ ] Pronto para merge ✅
- [ ] Estratégia de merge definida:
  - [ ] Merge commit (mantém histórico completo)
  - [ ] Squash and merge (commits limpos)
  - [ ] Rebase and merge (linear history)
- [ ] Versão/tag definida (se aplicável)
- [ ] Release notes finalizadas
- [ ] Stakeholders notificados
- [ ] Documentação de deploy preparada

---

**📅 Informações do PR**
- **Criado em:** 
- **Última atualização:** 
- **Branch de origem:** 
- **Branch de destino:** 
- **Autor:** @
- **Reviewers atribuídos:** 
- **Status:** 🟡 Em Revisão / 🟢 Aprovado / 🔴 Mudanças Solicitadas