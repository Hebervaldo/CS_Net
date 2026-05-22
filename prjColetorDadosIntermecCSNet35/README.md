# Coletor de Dados Mobile - Windows Mobile 6.5

Sistema desenvolvido em C# utilizando .NET Framework 3.5 para dispositivos móveis com Windows Mobile 6.5, voltado para coleta de dados em campo através de leitura de código de barras e processamento local das informações.

O projeto foi desenvolvido para execução em coletores industriais móveis, permitindo automação operacional em ambientes de logística, patrimônio, inventário, almoxarifado e controle corporativo.

---

## ✨ Principais Recursos

- Coleta de dados em dispositivos móveis
- Leitura de código de barras
- Armazenamento local das informações
- Integração com SQL Server Compact Edition
- Interface otimizada para Windows Mobile
- Controle e manipulação de registros
- Rotinas auxiliares para operação em campo
- Estrutura modular em C#

---

## 🏗️ Arquitetura do Projeto

O sistema foi estruturado em módulos responsáveis pela interface, persistência de dados e utilidades da aplicação.

```text
Interface Mobile → Regras de Negócio → Persistência Local
```

### Componentes Principais

| Arquivo / Classe | Função |
|---|---|
| `clsBancoDados.cs` | Operações de banco de dados |
| `clsBDSQLServerCE.cs` | Integração com SQL Server CE |
| `clsConexaoBancoDados.cs` | Controle de conexão |
| `clsImplementacaoBancoDados.cs` | Implementação de persistência |
| `clsUtilitarios.cs` | Funções auxiliares |
| `DistanceCalculator.cs` | Cálculos auxiliares |
| `frmAlterarItem.cs` | Manipulação de registros |
| `frmBatteryStatus.cs` | Monitoramento de bateria |

---

## 🔧 Tecnologias Utilizadas

- C#
- .NET Framework 3.5
- Windows Mobile 6.5
- SQL Server Compact Edition
- Programação Orientada a Objetos
- Windows Forms Mobile
- Manipulação de Arquivos

---

## 📦 Funcionalidades

O sistema permite:

- coleta de dados em campo;
- leitura de códigos de barras;
- armazenamento local das informações;
- alteração e exclusão de registros;
- monitoramento de status do dispositivo;
- processamento de informações para sincronização futura.

---

## 📱 Ambiente de Execução

O projeto foi desenvolvido para:

- coletores móveis industriais;
- dispositivos com Windows Mobile 6.5;
- operações logísticas;
- inventários corporativos;
- ambientes industriais e empresariais.

---

## 🚀 Melhorias Futuras

- Sincronização online em tempo real
- Integração com APIs corporativas
- Compatibilidade com Android
- Dashboard administrativo
- Criptografia de dados
- Logs avançados de operação
- Backup automático das coletas

---

## 📄 Licença

Projeto desenvolvido para automação corporativa, coleta de dados móvel e aplicações industriais utilizando C# e Windows Mobile.
