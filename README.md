---

# 📋 Clients Management API

API desenvolvida em **.NET 9** para gerenciar clientes, seu endereço e contato, com integração à API externa **ViaCEP** para validação de CEP.

---

## 🚀 Tecnologias utilizadas

* **ASP.NET Core 8**
* **Entity Framework Core**
* **SQLite** (banco de dados local)
* **AutoMapper** (mapeamento de objetos)
* **HttpClient** (requisição externa para ViaCEP)
* **Scalar** – (Teste de endpoints)

---

## 🛠️ Como rodar o projeto localmente

### ✅ Pré-requisitos:

* .NET SDK 9 ou superior
* Postman ou outra ferramenta para testar a API (opcional)

### ✅ Passos:

1. Clone o repositório:

```bash
git clone https://github.com/beckmanz/ClientsManagement-Api.git
```

2. Navegue até a pasta do projeto:

```bash
cd ClientsManagement-Api
```

3. Restaure os pacotes:

```bash
dotnet restore
```

4. Rode as migrations e crie o banco:

```bash
dotnet ef database update
```

5. Rode o projeto:

```bash
dotnet run
```

6. Acesse a documentação Scalar no navegador:

```
https://localhost:{porta}/Scalar
```

---

## 📌 Endpoints disponíveis

| Método     | Rota                               | Descrição                    |
| ---------- | ---------------------------------- | ---------------------------- |
| **POST**   | `/api/cliente`                     | Registra um novo cliente     |
| **GET**    | `/api/cliente`                     | Lista todos os clientes      |
| **GET**    | `/api/cliente/{id}`                | Busca um cliente por ID      |
| **GET**    | `/api/cliente/obterpornome/{nome}` | Busca clientes pelo nome     |
| **PUT**    | `/api/cliente/{id}`                | Edita os dados de um cliente |
| **DELETE** | `/api/cliente/{id}`                | Deleta um cliente por ID     |

---

## ✅ Funcionalidades principais:

* Cadastro de clientes com validação automática de CEP via API externa (**ViaCEP**)
* Atualização parcial dos dados do cliente (não precisa enviar todos os campos ao editar)
* Integração com banco SQLite usando EF Core
* Teste de endpoints via Scalar UI

---

## ✅ Sobre a integração com ViaCEP:

A cada registro ou atualização de CEP, a aplicação faz uma consulta em tempo real na **[API ViaCEP](https://viacep.com.br/)** para preencher os campos de **Logradouro** e **Cidade**, garantindo que o CEP informado seja válido.

---

Se quiser, posso gerar um exemplo de JSON de requisição para cada endpoint (exemplo de body para POST e PUT). Quer?
