# FastContacts

### Objetivo:
O projeto Fast Contacts tem como objetivo o gerenciamento completo da lista de contatos do usuário de uma forma simples e rápida.

### Ferramentas e Tecnologias utilizadas:
* Microsoft Visual Studio Enterprise 2019
* .NET Core 3.1
* E.F. Core 5.0.4
* Swashbuckle 6.1.1
* AutoMapper 6.1.1

### Premissas/Suposições:
1. O usuário poderá cadastrar um contato sendo ele Pessoa Física ou Jurídica.
2. O contato cadastrado possui um endereço e um documento sendo CPF ou CNPJ e o mesmo deve estar válido e será validado ao submeter o cadastro.
3. O documento do contato é obrigatório.
4. O endereço do contato é obrigatório, exceto o 'Address Two' que é entendido como complemento.
5. O cadastro completo do contato é validado no back-end.
6. Ao realizar o cadastro de um contato, o usuário informará o tipo de documento do contato, pois é a partir dele que é definido o tipo do contato.
7. É permitido o cadastro de mais de um contato com o mesmo número de documento.

### Iniciar Projeto - API:
1. Após realizar o clone do projeto, verificar se a porta *:5000 não está sendo utilizada na máquina em que o projeto foi baixado.
Caso a porta não esteja disponível, será necessário realizar a troca para uma porta disponível no arquivo launchSettings.json dentro da pasta 'Properties' no projeto.

2. Para a persistência dos dados, ficará a critério a utilização de um banco de dados SQL Server instalado na máquina ou
do banco de dados em memória já com a configuração disponível no projeto sendo somente necessário descomentar a opção escolhida na classe Startup.cs do projeto.
Caso opte por rodar a aplicação com banco de dados SQL Server instalado na máquina, será necessário rodar a migration inicial criada.
No Visual Studio ir até 'Tools' => 'NuGet Package Manager' => 'Package Manager Console' e rodar o comando 'Update-Database'.

3. Conferir se o projeto 'FastContacts.Api' está selecionado para ser inicializado.
Clicar com o botão direito no projeto 'FastContacts.Api' e selecionar a opção 'Set as Startup Project'.

4. Pronto! A API já está pronta para uso. Ao iniciar o projeto, você será levado para a página do Swagger da API, listando todos os endpoints disponíveis para uso.

### FastContacts.Web
1. Para utilização do projeto web, basta realizar o clone do mesmo pelo link https://github.com/rafaellmarcal/fast-contacts-web.
