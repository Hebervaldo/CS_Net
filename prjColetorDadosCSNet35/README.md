# Sistema de Gerenciamento

Sistema de gerenciamento desenvolvido em Java com Spring Boot, utilizando arquitetura em camadas para organização, escalabilidade e manutenção do código.

O projeto foi estruturado com foco em separação de responsabilidades, persistência de dados, segurança e suporte a versionamento/backup de entidades, servindo como base para aplicações corporativas e estudos avançados em desenvolvimento backend.

---

## ✨ Principais Recursos

- Arquitetura em camadas (`Controller`, `Service`, `Repository`, `Model`)
- Integração com Spring Boot e JPA/Hibernate
- Estrutura preparada para expansão modular
- Sistema de backup e rastreamento de alterações
- Camada de segurança com gerenciamento de chaves
- Organização voltada para manutenção e evolução do projeto
- Frontend utilizando Thymeleaf, HTML e JavaScript

---

## 🏗️ Arquitetura do Projeto

O sistema segue uma arquitetura tradicional em camadas:

```text
Controller → Service → Repository → Model
```

### Estrutura dos Pacotes

| Pacote | Responsabilidade |
|---|---|
| `controller` | Controle das requisições e fluxo da aplicação |
| `service` | Implementação das regras de negócio |
| `repository` | Acesso e persistência de dados |
| `model` | Entidades e modelos do sistema |
| `util` | Funções auxiliares e validações |
| `security` | Recursos de segurança e gerenciamento de chaves |
| `backup` | Controle de backup e histórico de entidades |

---

## 🔧 Tecnologias Utilizadas

- Java
- Spring Boot
- Spring Data JPA
- Hibernate
- Maven
- Thymeleaf
- HTML
- JavaScript

---

## 🔐 Segurança

O projeto possui uma implementação própria para gerenciamento de segurança e armazenamento de chaves.

> O arquivo `secret.key` não deve ser versionado em ambientes reais.

Melhorias futuras recomendadas:

- uso de variáveis de ambiente;
- integração com serviços de vault;
- revisão criptográfica completa;
- autenticação baseada em tokens.

---

## 💾 Sistema de Backup

O sistema inclui uma camada de backup para entidades da aplicação, permitindo:

- rastreabilidade;
- histórico de alterações;
- possibilidade de rollback;
- auditoria futura.

---

## 🚀 Melhorias Futuras

- Implementação completa de API REST
- Integração com frontend moderno (React/Vue)
- Testes automatizados com JUnit e Mockito
- Refatoração parcial para DDD
- Auditoria de segurança mais robusta
- Padronização de validações com Bean Validation
- Melhor separação de responsabilidades entre componentes

---

## 📊 Status do Projeto

| Item | Status |
|---|---|
| Estrutura base | ✔ Concluída |
| Arquitetura | ✔ Organizada |
| Segurança | ⚠ Em evolução |
| Expansão futura | 🚀 Preparado |

---

## 📄 Licença

Projeto desenvolvido para estudos, experimentação e evolução de aplicações Java utilizando Spring Boot.
