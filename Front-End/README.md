# Dietbox e-Commerce

Desenvolvido por Leonardo Valcarenghi
<br/>
Última atualização: 05/07/2023

## Tecnologias

### **Back-End**

- Microsoft .NET 6
- Entity Framework Core
- AutoMapper
- JWT
- Cache

### **Front-End**

- React
- React Router DOM
- Bootstrap 5.3

### **DataBase**

- SQL Server Express

<br>

## Configuração

### **Configurando o Banco de Dados**

1. Instale o [_SQL Server Express_](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (se necessário) e reinicie o computador.
2. Instale o [_SQL Server Data Tools_](https://learn.microsoft.com/pt-br/sql/ssdt/download-sql-server-data-tools-ssdt?view=sql-server-ver16) (se necessário)  pelo _Visual Studio Installer_.

### **Configurando o Back-End**

1. Abra o projeto no Visual Studio.
2. Instale as dependências do NuGet (se necessárias).
3. Configure a solução para inicializar somente o projeto de **API**.
4. Execute!

> **LOCALHOST** > <br>
> Certifique-se de que o back-end esteja rodando na porta **3333**.
> <br> > _Essa é a porta que o front-end está configurado._

<br>

### **Configurando o Front-End**

### `npm install`

Execute esse comando para instalar todas as dependências do React.

### `npm start`

Após as depedências terem sido instaladas, execute o comando `npm start` para iniciar o servidor node local do front-end.

<br>

# Projeto

## Tela de Boas-Vindas

Ao iniciar o **Front-End**, você vai se deparar com a tela de boas vindas.
<br>
Nela contém duas ações, **Fazer Login** ou **Criar Conta**.

![Tela de Inicio](./readme-images/print-tela-inicio.png)

## Tela de Cadastro

Na tela de **cadastro** você tem a opção de criar uma conta como **cliente** ou **empresa**.

![Tela de Login](./readme-images/print-tela-cadastro.PNG)

## Tela de Login

Na tela de login você tem a opção de acessar o sistema como **Cliente** ou **Empresa**.

![Tela de Login](./readme-images/print-tela-login.PNG)

Alguns clientes e empresas já estão criados para fins de teste. Se quiser você pode experimentar qualquer um destes:

**Clientes**

- cliente01@email.com
- cliente02@email.com
- cliente03@email.com

**Empresas**

- empresa01@email.com
- empresa02@email.com
- empresa03@email.com
- empresa04@email.com
- empresa05@email.com

A senha para qualquer um destes e-mails é **123456789**.

## Tela de Início

A tela de início (depois de autenticado) é a tela que vai exibir os produtos cadastrados, porém dependendo do tipo de _entidade_ logada, a tela tem um padrão diferente.

Autenticado como **cliente** a _NavBar_ fica da cor azul e o botão de "comprar" fica disponível.

![Tela de Inicio (Cliente)](./readme-images/print-tela-produtos-como-cliente.PNG)

Autenticado como **empresa** a _NavBar_ fica da cor verde e o botão de "comprar" não é mostrado.

Note também que como **empresa** surge uma opção de "cadastrar produto".

![Tela de Inicio (Empresa)](./readme-images/print-tela-produtos-como-empresa.PNG)

## Tela de Cadastrar de Produto

Esta é a tela onde a empresa vai cadastrar seus **produtos** para ficar disponível para comprar pelos clientes.

![Tela de Login](./readme-images/print-tela-cadastrar-produto.PNG)

## Tela de Visualização do Produto

Esta tela é onde o cliente pode ver mais **detalhes** sobre o **produto**.

![Tela de Login](./readme-images/print-tela-visualizar-produto.PNG)
