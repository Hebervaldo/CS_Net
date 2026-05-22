# Conversão de Guias Patrimoniais para Base Digital

Aplicação desenvolvida em C# utilizando .NET Framework para leitura, interpretação e conversão de formulários físicos de Movimentação de Bens Patrimoniais (MBP/MBPI) em registros digitais estruturados.

O sistema foi criado para automatizar o processo de extração de informações contidas em guias patrimoniais impressas e escaneadas em PDF, permitindo transformar documentos físicos em dados manipuláveis eletronicamente.

Após a leitura e interpretação dos documentos, as informações extraídas eram processadas e cadastradas automaticamente em tabelas Microsoft Access, facilitando consultas, pesquisas, conferências e exportação para planilhas eletrônicas.

A solução reduzia significativamente o trabalho manual de digitação, acelerando processos administrativos e melhorando a organização dos registros patrimoniais.

---

## ✨ Principais Recursos

- Leitura de formulários patrimoniais em PDF
- Conversão de documentos físicos para dados digitais
- Extração estruturada de informações
- Processamento automatizado de guias MBP/MBPI
- Cadastro automático em banco Microsoft Access
- Apoio a pesquisas patrimoniais
- Integração com planilhas eletrônicas
- Redução de digitação manual
- Processamento documental em C#
- Estrutura modular para manipulação de dados

---

## 📦 Funcionalidades

O sistema permite:

- leitura automatizada de documentos PDF;
- interpretação de formulários patrimoniais;
- extração de informações estruturadas;
- processamento automatizado de registros;
- cadastro automático em tabelas Access;
- organização digital de dados patrimoniais;
- apoio à pesquisa e conferência de registros;
- integração futura com sistemas corporativos;
- exportação e manipulação dos dados processados.

---

## 🏗️ Arquitetura do Projeto

O projeto foi estruturado de forma modular para facilitar manutenção, expansão e reutilização dos componentes.

### Componentes Principais

| Componente | Função |
|---|---|
| `Program.cs` | Inicialização da aplicação |
| `LeitorPDF.cs` | Leitura dos documentos PDF |
| `ExtracaoDados.cs` | Interpretação e extração de informações |
| `PersistenciaAccess.cs` | Cadastro em banco Microsoft Access |
| `Configuracao.cs` | Configurações da aplicação |
| `Util.cs` | Funções auxiliares |

---

## 🔧 Tecnologias Utilizadas

- C#
- .NET Framework
- Microsoft Access
- ADO.NET
- Manipulação de PDF
- Processamento Textual
- Manipulação de Arquivos
- Programação Orientada a Objetos
- Persistência Relacional

---

## 📂 Fluxo de Processamento

O sistema executa o seguinte fluxo operacional:

1. leitura dos formulários patrimoniais em PDF;
2. interpretação textual das informações;
3. extração dos dados relevantes;
4. estruturação das informações;
5. cadastro automático no banco Access;
6. disponibilização dos dados para pesquisa e exportação.

---

## 📊 Objetivos do Projeto

O projeto foi desenvolvido para:

- automatizar digitalização de registros patrimoniais;
- reduzir trabalho manual de digitação;
- estruturar informações provenientes de documentos físicos;
- facilitar pesquisas patrimoniais;
- acelerar cadastros administrativos;
- melhorar organização e recuperação de informações.

---

## 🚀 Melhorias Futuras

- OCR avançado integrado
- API REST para processamento remoto
- Dashboard administrativo
- Exportação automática para Excel
- Integração com SQL Server
- Processamento paralelo de documentos
- Classificação automática de formulários
- Integração com IA para interpretação documental

---

## 📄 Licença

Projeto desenvolvido para automação documental, digitalização patrimonial e processamento estruturado de informações utilizando C# e .NET Framework.
