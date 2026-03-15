# 📋 Issue Templates

Este repositório utiliza templates de issues para padronizar e organizar os reports. Escolha o template mais apropriado para sua situação.

## 📝 Templates Disponíveis

### 🐛 Bug Report
**Quando usar**: Quando algo não funciona como esperado

**Inclui**:
- Descrição do bug
- Passos para reproduzir
- Comportamento esperado vs atual
- Ambiente e versão
- Logs e screenshots
- Possível solução

**Exemplo**: "Login falha com erro 500 quando email contém caracteres especiais"

---

### ✨ Feature Request
**Quando usar**: Para sugerir novas funcionalidades ou melhorias

**Inclui**:
- Problema/necessidade que a feature resolve
- Solução proposta
- Casos de uso específicos
- Alternativas consideradas
- Categoria e prioridade
- Mockups/exemplos
- Critérios de aceitação

**Exemplo**: "Adicionar autenticação via Google OAuth"

---

### 📖 Documentation
**Quando usar**: Para melhorias ou correções na documentação

**Inclui**:
- Tipo de documentação (README, API, guias, etc.)
- Tipo de problema (faltando, incorreto, confuso, etc.)
- Localização específica
- Problema atual
- Melhoria sugerida
- Conteúdo proposto

**Exemplo**: "README não explica como configurar variáveis de ambiente"

---

### ❓ Question / Help
**Quando usar**: Quando você precisa de ajuda ou tem dúvidas

**Inclui**:
- Tipo de pergunta
- Descrição da questão
- O que você já tentou
- Contexto do que está fazendo
- Código/configuração relevante
- Mensagens de erro
- Ambiente

**Exemplo**: "Como integrar este projeto com Docker Compose?"

---

### 🔧 Task / Chore
**Quando usar**: Para tarefas técnicas, refatorações ou melhorias internas

**Inclui**:
- Tipo de tarefa (refatoração, deps, performance, etc.)
- Descrição e motivação
- Prioridade e complexidade
- Área afetada
- Escopo detalhado
- Critérios de aceitação
- Notas de implementação
- Riscos e considerações

**Exemplo**: "Refatorar módulo de autenticação para usar padrão Strategy"

---

## 🎯 Como Escolher o Template Certo

```
Algo não funciona? → 🐛 Bug Report
Quer uma nova feature? → ✨ Feature Request
Problema na documentação? → 📖 Documentation
Tem uma dúvida? → ❓ Question / Help
Tarefa técnica interna? → 🔧 Task / Chore
```

## ✅ Boas Práticas

### 1. **Título Descritivo**
```
✅ BOM: "[BUG] Login falha com erro 500 ao usar email com '+'"
❌ RUIM: "Login não funciona"
```

### 2. **Pesquise Antes**
Antes de criar uma issue:
- 🔍 Pesquise issues existentes
- 📖 Leia a documentação
- 💬 Verifique as discussões

### 3. **Seja Específico**
- Forneça versões exatas
- Inclua logs completos
- Descreva passos exatos
- Adicione screenshots quando útil

### 4. **Use Formatação Markdown**
```markdown
# Código
\`\`\`javascript
console.log('exemplo');
\`\`\`

# Comandos
\`npm install\`

# Lista
- Item 1
- Item 2
```

### 5. **Seja Respeitoso**
- Use linguagem educada
- Agradeça pela ajuda
- Seja paciente com as respostas
- Lembre-se: há pessoas reais ajudando você

## 🏷️ Labels Automáticas

Os templates aplicam labels automaticamente:

| Template | Labels |
|----------|--------|
| Bug Report | `bug`, `triage` |
| Feature Request | `enhancement`, `feature` |
| Documentation | `documentation` |
| Question | `question`, `help wanted` |
| Task | `task`, `chore` |

## 📞 Outros Recursos

### 💬 Discussões
Para perguntas abertas, ideias e discussões: [GitHub Discussions](https://github.com/daniloopinheiro/dopBase/discussions)

### 📚 Documentação
Consulte primeiro a documentação: [README](https://github.com/daniloopinheiro/dopBase#readme)

### 🔒 Segurança
Para vulnerabilidades de segurança: [Security Policy](https://github.com/daniloopinheiro/dopBase/security/policy)

### 🤝 Contribuir
Quer contribuir com código?: [Contributing Guide](https://github.com/daniloopinheiro/dopBase/blob/main/CONTRIBUTING.md)

## 🔄 Ciclo de Vida de uma Issue

```
1. Criada → 2. Triagem → 3. Em Progresso → 4. Em Revisão → 5. Fechada
```

### Estados Comuns

- **triage**: Aguardando triagem inicial
- **confirmed**: Problema confirmado
- **in progress**: Alguém está trabalhando nisso
- **needs feedback**: Precisa de mais informações
- **duplicate**: Issue duplicada (será linkada à original)
- **wontfix**: Não será corrigido/implementado (com justificativa)
- **invalid**: Issue inválida ou fora de escopo

## 💡 Dicas Rápidas

### Para Bugs
```markdown
1. Versão que você está usando
2. O que você fez (passo a passo)
3. O que aconteceu
4. O que você esperava
5. Logs/erros
```

### Para Features
```markdown
1. Qual problema isso resolve?
2. Como você imagina que funcione?
3. Por que é importante?
4. Exemplos de uso
```

### Para Perguntas
```markdown
1. O que você está tentando fazer?
2. O que você já tentou?
3. Onde está travado?
4. Código/config relevante
```

## 🎨 Exemplos de Boas Issues

### Exemplo de Bug
```markdown
[BUG] API retorna 500 ao criar usuário com email duplicado

**Versão**: v1.2.0
**Ambiente**: Node.js 20.x, PostgreSQL 14

**Passos**:
1. POST /api/users com email "test@example.com"
2. POST novamente com mesmo email
3. Recebo erro 500

**Esperado**: HTTP 409 Conflict

**Atual**: HTTP 500 Internal Server Error

**Logs**:
\`\`\`
Error: duplicate key value violates unique constraint
\`\`\`
```

### Exemplo de Feature
```markdown
[FEATURE] Adicionar autenticação via Google OAuth

**Problema**: Usuários precisam criar senha, o que reduz conversão

**Solução**: Implementar login via Google OAuth 2.0

**Casos de Uso**:
- Usuário clica em "Login with Google"
- Redireciona para Google
- Retorna autenticado

**Prioridade**: Alta - impacta conversão
```

## 📊 Templates vs Blank Issues

Este repositório **desabilita issues em branco** (`blank_issues_enabled: false`) para garantir que todas as issues sigam um padrão e contenham informações necessárias.

Se nenhum template se adequar, use o que mais se aproxima e explique no início.

## 🆘 Precisa de Ajuda com os Templates?

Se você está com dificuldade para escolher ou preencher um template:

1. Abra uma [Discussion](https://github.com/daniloopinheiro/dopBase/discussions)
2. Peça ajuda no template **Question**
3. Descreva sua situação e pediremos para abrir o template correto

---

**Obrigado por ajudar a melhorar o projeto! 🙏**

Suas contribuições, seja reportando bugs, sugerindo features ou apenas fazendo perguntas, são valiosas para a comunidade.

