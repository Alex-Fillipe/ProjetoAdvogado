# ⚖️ Sistema Web para Cadastro de Advogados

Este projeto é um **sistema web desenvolvido em ASP.NET MVC 5 (.NET Framework 4.8)** para **cadastro e gerenciamento de advogados**, utilizando o **padrão de arquitetura em camadas** (Domain, ViewModel, Repositório e Web) e **MySQL** como banco de dados.

---

## 🚀 Instruções para rodar o sistema

### 🔹 Pré-requisitos

Antes de iniciar, instale as seguintes ferramentas:

- [Visual Studio 2022](https://visualstudio.microsoft.com/) (com suporte ao .NET Framework 4.8)  
- [MySQL Server 8+](https://dev.mysql.com/downloads/mysql/)  
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) (opcional, para gerenciar o banco)  
- [MySQL Connector/NET](https://dev.mysql.com/downloads/connector/net/)  

---

### 🔹 Clonando o repositório

```bash
git clone https://github.com/Alex-Fillipe/ProjetoAdvogado
cd ProjetoAdvogado

```
### 🔹 Configuração do banco de dados

Crie o banco de dados MySQL:

```bash
CREATE DATABASE DBAdvogado;
```

Execute o script SQL Script-DB.sql localizado na raiz do projeto para criar as tabelas necessárias:

```bash
mysql -u root -p DBAdvogado < Script-DB.sql

```

### 🔹 Configurando a conexão no Web.config

O projeto já vem com a string de conexão padrão configurada:
```bash
<connectionStrings>
  <add name="ProjetoAdvogadoDB"
       connectionString="server=localhost;database=DBAdvogado;uid=root;pwd=;"
       providerName="MySql.Data.MySqlClient" />
</connectionStrings>

```
Se necessário, ajuste uid (usuário) e pwd (senha) conforme sua instalação local.

## ▶️ Executando o sistema

1. Abra a solução **`ProjetoAdvogado.sln`** no **Visual Studio**
2. Defina o projeto **Web** como **Projeto de Inicialização**
3. Pressione **F5** para executar

O navegador abrirá automaticamente o sistema em:

```bash
 http://localhost:porta/
```

## 🛠️ Decisões Técnicas

- **Arquitetura:** em camadas  
  - 🧩 **Domain:** Entidades e regras de negócio  
  - 📦 **ViewModel:** Classes de transporte e validação  
  - 💾 **Repositorio:** Implementação de acesso ao MySQL  
  - 🌐 **Web (MVC):** Camada de apresentação  

- **Banco de Dados:** MySQL  
- **Conexão:** `MySql.Data.MySqlClient`  
- **Validação:** DataAnnotations  
- **Framework:** .NET Framework 4.8  
- **Padrão:** MVC (Model-View-Controller)

## 🌐 Funcionalidades Principais

🧾 **Cadastro de Advogados**  
✏️ **Edição e Exclusão de Registros**  
📋 **Listagem de Advogados**  
🔐 **Login e Autenticação Básica**  
⚙️ **Validação de Dados com Mensagens Personalizadas**  
🏗️ **Arquitetura Limpa e Organizada**


