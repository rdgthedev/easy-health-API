# 🏥 Easy Health

Este projeto é um sistema de gerenciamento de saúde desenvolvido com Clean Architecture, implementando conceitos de DDD, CQRS, JWT Token, FluentValidation, Entity Framework e PostgreSQL. O sistema consiste no gerenciamento das operações de uma unidade de saúde, visando facilitar as tarefas diárias que são feitas, como: agendamentos de consultas e exames, gerenciamento de pacientes, gerenciamento de funcionários, gerenciamento de consultas e exames.

## 🏗️ Estrutura do Projeto

O projeto está organizado em várias camadas para garantir a separação de responsabilidades e a escalabilidade:

1. **Domain**: Contém as entidades do domínio, interfaces, e lógica de negócios.
2. **Application**: Inclui casos de uso, manipuladores de comandos/consultas, e validações.
3. **Infrastructure**: Implementações de acesso a dados, configurações de banco de dados e integrações com serviços externos.
4. **Cross Cutting**: Componentes e serviços transversais como log, autenticação e injeção de dependências.
5. **Tests**: Testes unitários para garantir a qualidade do código.
6. **API**: Exposição de endpoints para interação com o sistema.

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core**: Framework principal para a construção da API.
- **Entity Framework Core**: ORM para interação com o banco de dados PostgreSQL.
- **PostgreSQL**: Banco de dados relacional utilizado no projeto.
- **FluentValidation**: Biblioteca para validação de dados.
- **CQRS**: Implementação do padrão Command Query Responsibility Segregation.
- **DDD**: Utilização de Domain-Driven Design para modelagem do domínio.
- **Unit of Work**: Gerenciamento de transações.
- **Repository Pattern**: Abstração de acesso a dados.

## ✨ Funcionalidades

O sistema permite gerenciar as seguintes entidades:

- **Appointment**: Agendamentos de consultas.
- **Category**: Categorias das entidades do sistema.
- **Consultation**: Consultas médicas.
- **Doctor**: Informações sobre os médicos.
- **Employee**: Funcionários do sistema.
- **Exam**: Exames médicos.
- **Patient**: Informações dos pacientes.
- **Role**: Papéis e permissões dos usuários.
- **Specialty**: Especialidades médicas.

## Mais atualizações em breve...
