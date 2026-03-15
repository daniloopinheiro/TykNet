# Guia de Contribuição

Obrigado por considerar contribuir para este projeto! Sua ajuda é muito bem-vinda e valorizada. Este documento fornece diretrizes e informações sobre como contribuir de forma efetiva.

## Código de Conduta

Este projeto e todos os participantes estão sujeitos ao nosso [Código de Conduta](CODE_OF_CONDUCT.md). Ao participar, você concorda em cumprir estes termos. Por favor, reporte comportamentos inaceitáveis para [INSERIR_EMAIL_AQUI].

## Como Posso Contribuir?

Existem várias maneiras de contribuir para este projeto:

### 🐛 Reportando Bugs

Encontrou um bug? Ajude-nos a corrigi-lo:

1. **Verifique se já existe** uma issue similar
2. **Use o template** de bug report ao criar uma nova issue
3. **Seja específico** - inclua detalhes sobre o ambiente e passos para reproduzir
4. **Adicione capturas de tela** se aplicável

### 💡 Sugerindo Melhorias

Tem uma ideia para melhorar o projeto?

1. **Abra uma issue** com o label "enhancement"
2. **Descreva claramente** o que você gostaria de ver
3. **Explique por que** seria útil para a comunidade
4. **Considere implementar** a melhoria você mesmo

### 🔧 Contribuindo com Código

#### Primeiro, configure o ambiente de desenvolvimento:

```bash
# Clone o repositório
git clone https://github.com/[USUARIO]/[REPOSITORIO].git
cd [REPOSITORIO]

# Instale as dependências
npm install
# ou
pip install -r requirements.txt
# ou
[COMANDO_DE_INSTALACAO_ESPECIFICO]

# Execute os testes para garantir que tudo está funcionando
npm test
# ou
pytest
# ou
[COMANDO_DE_TESTE_ESPECIFICO]
```

#### Processo de Desenvolvimento

1. **Fork** o repositório
2. **Crie uma branch** para sua feature (`git checkout -b feature/nova-funcionalidade`)
3. **Faça suas alterações** seguindo as diretrizes de código
4. **Adicione testes** para cobrir suas alterações
5. **Execute os testes** e certifique-se de que passam
6. **Faça commit** seguindo nosso padrão de mensagens
7. **Push** para sua branch (`git push origin feature/nova-funcionalidade`)
8. **Abra um Pull Request**

### 📝 Melhorando a Documentação

A documentação sempre pode ser melhorada:

- Corrigir erros de digitação ou gramática
- Adicionar exemplos
- Melhorar explicações
- Traduzir conteúdo
- Adicionar tutoriais

### 🎨 Design e UX

Contribuições de design são bem-vindas:

- Melhorias na interface do usuário
- Ícones e ilustrações
- Experiência do usuário
- Acessibilidade

## Diretrizes de Desenvolvimento

### Padrões de Código

- **Siga o style guide** do projeto (use o linter configurado)
- **Mantenha consistência** com o código existente
- **Comente código complexo** quando necessário
- **Use nomes descritivos** para variáveis e funções
- **Mantenha funções pequenas** e focadas

#### Exemplo de estrutura de código:

```javascript
// ✅ Bom
function calcularPrecoTotal(items, desconto = 0) {
    const subtotal = items.reduce((acc, item) => acc + item.preco, 0);
    return subtotal * (1 - desconto);
}

// ❌ Evite
function calc(i, d) {
    let t = 0;
    for (let x of i) t += x.p;
    return t * (1 - d);
}
```

### Padrão de Commits

Usamos o padrão [Conventional Commits](https://www.conventionalcommits.org/):

```
tipo(escopo): descrição breve

Descrição mais detalhada se necessário.

Refs: #123
```

**Tipos permitidos:**
- `feat`: nova funcionalidade
- `fix`: correção de bug
- `docs`: alterações na documentação
- `style`: formatação, ponto e vírgula, etc
- `refactor`: refatoração de código
- `test`: adição ou correção de testes
- `chore`: mudanças no processo de build, dependências, etc

**Exemplos:**
```
feat(auth): adicionar login social com Google

fix(api): corrigir erro de timeout na requisição de usuários

docs(readme): atualizar instruções de instalação

test(utils): adicionar testes para função de validação
```

### Testes

- **Escreva testes** para todas as novas funcionalidades
- **Mantenha alta cobertura** de testes (mínimo 80%)
- **Use nomes descritivos** nos testes
- **Teste casos extremos** e cenários de erro

```javascript
// Exemplo de teste bem estruturado
describe('calcularPrecoTotal', () => {
    it('deve calcular o preço total sem desconto', () => {
        const items = [{ preco: 10 }, { preco: 20 }];
        expect(calcularPrecoTotal(items)).toBe(30);
    });

    it('deve aplicar desconto corretamente', () => {
        const items = [{ preco: 100 }];
        expect(calcularPrecoTotal(items, 0.1)).toBe(90);
    });

    it('deve retornar 0 para lista vazia', () => {
        expect(calcularPrecoTotal([])).toBe(0);
    });
});
```

## Pull Request Guidelines

### Antes de Abrir um PR

- [ ] Verifique se sua branch está atualizada com a main
- [ ] Execute todos os testes localmente
- [ ] Execute o linter e corrija todos os problemas
- [ ] Adicione/atualize testes se necessário
- [ ] Atualize a documentação se necessário

### Template de Pull Request

```markdown
## Descrição
Breve descrição das mudanças.

## Tipo de Mudança
- [ ] Bug fix (mudança que corrige um problema)
- [ ] Nova funcionalidade (mudança que adiciona funcionalidade)
- [ ] Breaking change (mudança que quebra compatibilidade)
- [ ] Documentação

## Como Testar
Passos para testar as mudanças:
1. ...
2. ...
3. ...

## Checklist
- [ ] Meu código segue o style guide do projeto
- [ ] Fiz uma auto-revisão do meu código
- [ ] Comentei partes complexas do código
- [ ] Fiz mudanças correspondentes na documentação
- [ ] Minhas mudanças não geram novos warnings
- [ ] Adicionei testes que provam que minha correção/funcionalidade funciona
- [ ] Testes novos e existentes passam localmente

## Screenshots (se aplicável)
[Adicione screenshots aqui]

## Issues Relacionadas
Fixes #123
```

### Processo de Review

1. **Automated checks** devem passar (CI/CD, testes, linting)
2. **Pelo menos um maintainer** deve aprovar
3. **Todas as conversas** devem ser resolvidas
4. **Documentação** deve estar atualizada
5. **Testes** devem cobrir as mudanças

## Configuração do Ambiente

### Pré-requisitos

- [Node.js](https://nodejs.org/) versão 16+
- [Git](https://git-scm.com/)
- [VS Code](https://code.visualstudio.com/) (recomendado)

### Extensões Recomendadas para VS Code

- ESLint
- Prettier
- GitLens
- Thunder Client (para testes de API)

### Variáveis de Ambiente

Copie o arquivo `.env.example` para `.env` e configure:

```bash
cp .env.example .env
```

Edite o arquivo `.env` com suas configurações locais.

### Comandos Úteis

```bash
# Executar em modo de desenvolvimento
npm run dev

# Executar testes
npm test

# Executar testes com coverage
npm run test:coverage

# Executar linting
npm run lint

# Corrigir problemas de lint automaticamente
npm run lint:fix

# Build para produção
npm run build
```

## Estrutura do Projeto

```
├── src/                    # Código fonte
│   ├── components/         # Componentes reutilizáveis
│   ├── pages/             # Páginas da aplicação
│   ├── services/          # Lógica de negócio
│   ├── utils/             # Funções utilitárias
│   └── types/             # Definições de tipos
├── tests/                 # Testes
├── docs/                  # Documentação
├── public/                # Arquivos estáticos
├── .github/               # Templates e workflows
└── package.json           # Dependências e scripts
```

## Reportando Issues

### Template de Bug Report

```markdown
**Descreva o bug**
Descrição clara e concisa do problema.

**Para Reproduzir**
Passos para reproduzir o comportamento:
1. Vá para '...'
2. Clique em '....'
3. Role para baixo até '....'
4. Veja o erro

**Comportamento Esperado**
Descrição clara do que você esperava que acontecesse.

**Screenshots**
Se aplicável, adicione screenshots para explicar o problema.

**Ambiente:**
 - OS: [ex: iOS]
 - Browser: [ex: chrome, safari]
 - Versão: [ex: 22]

**Informações Adicionais**
Qualquer outra informação sobre o problema.
```

### Template de Feature Request

```markdown
**A sua feature request está relacionada a um problema? Descreva.**
Descrição clara e concisa do problema.

**Descreva a solução que você gostaria**
Descrição clara e concisa do que você quer que aconteça.

**Descreva alternativas consideradas**
Descrição clara e concisa de soluções alternativas consideradas.

**Informações adicionais**
Qualquer outra informação ou screenshot sobre a feature request.
```

## Recursos e Ajuda

- **Documentação:** [link para documentação]
- **Issues:** [link para issues]
- **Discussions:** [link para discussions]
- **Discord/Slack:** [link para chat da comunidade]
- **Wiki:** [link para wiki se houver]

## Reconhecimento

Contribuidores são listados em nosso [README.md](README.md) e no arquivo [CONTRIBUTORS.md](CONTRIBUTORS.md).

## Licença

Ao contribuir para este projeto, você concorda que suas contribuições serão licenciadas sob a [MIT License](LICENSE).

## Perguntas?

Não hesite em abrir uma issue com a tag "question" se você tiver dúvidas sobre como contribuir!

---

**Obrigado por contribuir! 🎉**
