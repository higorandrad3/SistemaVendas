🛒 Sistema de Vendas (PDV) - Em Desenvolvimento
Este projeto é um sistema de Ponto de Venda (PDV) desenvolvido do zero para atender às necessidades reais de uma pequena loja de cosméticos. O objetivo principal é oferecer um controle de estoque e vendas simplificado, focado na usabilidade para pequenos empreendedores.

Status do Projeto: ⚠️ Em desenvolvimento (WIP)

🚀 Funcionalidades Atuais
Gestão de Produtos: Registo de itens com controlo de estoque.

Carrinho de Compras Dinâmico: Cálculos em tempo real utilizando JavaScript para melhorar a performance.

Autocomplete Inteligente: Pesquisa rápida de produtos por nome ou parte dele.

Validação de Segurança: Conferência de preços no back-end no momento da finalização da venda para evitar manipulações no lado do cliente.

🛠️ Tecnologias Utilizadas
Back-end: ASP.NET Core (C#)

Padrão de Projeto: MVC (Model-View-Controller)

ORM: Entity Framework Core

Base de Dados: SQL Server

Front-end: JavaScript (Vanilla), HTML5, CSS3

🏗️ Arquitetura e Boas Práticas
Para garantir um código sustentável e profissional, apliquei os seguintes conceitos:

Camada de Serviço (Service Layer): Toda a lógica de negócio foi isolada dos Controladores, facilitando a manutenção e a futura implementação de testes unitários.

Performance com EF Core: Utilização do método .AsNoTracking() em consultas de leitura para reduzir o consumo de memória e acelerar as respostas da aplicação.

Princípio da Responsabilidade Única (SRP): Divisão clara de pastas e responsabilidades dentro do projeto.

Segurança de Dados: Validação rigorosa no servidor para garantir a integridade das transações financeiras.

📝 Próximas Implementações

-[ ] Evolução da interface (UI/UX).

-[ ] Relatórios de vendas mensais com gráficos.

-[ ] Implementação de autenticação e autorização via Identity.
