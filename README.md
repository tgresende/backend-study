# backend-study

# adicionar migration

- Criar migration:
- executar script no na raiz da solucao
- dotnet ef --startup-project WebApi/ migrations add [migration-name] --project Infrasctructure/

- Aplicar mudancas no banco
- executar script no na raiz da solucao
- dotnet ef --startup-project WebApi/ database update --project Infrasctructure/

- Pendências
- testar usecases
