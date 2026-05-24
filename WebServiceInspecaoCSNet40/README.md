# WebServiceInspecaoCSNet40

## Visão Geral

O projeto `WebServiceInspecaoCSNet40` é uma aplicação ASP.NET Web Forms desenvolvida em C# para .NET Framework 4.0, com foco em serviços de manipulação, consulta e persistência de dados relacionados a inspeções.

A arquitetura do sistema demonstra uma tentativa de abstração de múltiplos mecanismos de banco de dados, permitindo que a aplicação opere sobre diferentes SGBDs utilizando classes especializadas para cada tecnologia.

---

# Tecnologias Utilizadas

- C#
- ASP.NET Web Forms
- .NET Framework 4.0
- Visual Studio 2010

## Bancos de Dados

- MySQL
- SQL Server
- SQL Server Compact Edition
- Microsoft Access
- ODBC
- OLE DB

---

# Estrutura do Projeto

## Camada Web

- Default.aspx
- About.aspx
- Site.Master
- Global.asax
- Web.config

## Camada de Banco

- clsBDMySQL
- clsBDSQLServer
- clsBDSQLServerCE
- clsBDAccess
- clsBDOleDb
- clsBDOdbc

---

# Funcionalidades

- Conexão dinâmica com múltiplos bancos
- Execução de SQL
- Criação automática de tabelas
- Manipulação de inspeções
- Manipulação de endereços
- Integração com Excel
- Utilitários diversos

---

# Tabelas Identificadas

- tblInspecao
- tblEndereco

---

# Compatibilidade

## Framework

- .NET Framework 4.0

## IDE

- Visual Studio 2010+

## MySQL

Recomendado:
- MySQL 5.5
- MySQL 5.7

---

# String de conexão exemplo

```txt
Server=localhost;
Port=3307;
Database=dbinspecao;
Uid=root;
Pwd=SENHA;
SslMode=None;
Connection Timeout=5;
```

---

# Problemas Identificados

## SQL Dinâmico

Foi identificado SQL inválido sendo montado dinamicamente:

```sql
SELECT  FROM tblInspecao
WHERE  LIKE '%'
GROUP BY
ORDER BY
```

## NullReferenceException

Principalmente em:

- mtdFecharLeitorDados
- mtdProximoRegistro

Correção sugerida:

```csharp
if (objLeitor != null)
{
    objLeitor.Close();
}
```

---

# Estrutura Geral

```text
WebServiceInspecaoCSNet40/
├── Banco de Dados
├── Infraestrutura
├── Web
├── Utilitarios
└── Configuração
```

---

# Considerações

O projeto representa uma arquitetura típica de sistemas corporativos ASP.NET Web Forms desenvolvidos entre 2008–2013, com forte foco em abstração de banco de dados e compatibilidade entre múltiplos SGBDs.
