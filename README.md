# exemploBlog
Aplicação de exemplo de um blog utilizando WPF e WebApi .Net Core com algumas das boas práticas do mercado.

Organização da solução:

- Blog.Data
  - Modelos de dados;
  - Interfaces dos repositórios;
  - Contexto de acesso a dados;
  
  Este projeto separado possibilita a criação de plugins que implementem os repositórios separadamente.
  
- Blog.Data.Components:
  - Implementações dos repositórios;
  
- Blog.Data.IoC:
  - Inversão de controle para os repositórios;
  
- Blog.Business:
  - Exceções de negócio;
  - Modelos de negócio;
  - Interfaces para os serviços;
  
  Este projeto separado possibilita a criação de plugins que implementem os serviços separadamente.
  
- Blog.Business.Components:
  - Implementação dos serviços;
  
- Blog.Business.IoC:
  - Inversão de controle para os serviços;
  
- Blog.WebApi:
  - WebApi em .Net Core para acesso às funcionalidades do blog;
  - Pode ser testado via Swagger (incluso);
  
- Blog.Web:
  - Projeto Web de testes para visualizar os posts do blog, por meio da WebApi;
  - Cache: Implementação de cache em lista para possibilitar navegação offline.
    Para simular o serviço fora do ar, basta alternar o valor da variável "IsOnline" no arquivo "appsettings.json" durante a execução do Blog.Web.

Execução:
1. Executar o projeto Blog.WebApi para rodar o serviço;
2. Rodar o projeto Blog.Web
