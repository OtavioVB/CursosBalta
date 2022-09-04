# Curso Balta

Esse é um projeto dedicado ao processo seletivo de admissão do [Balta](https://balta.io). Basicamente, a ideia do processo é criar uma aplicação em `ASP.NET 6` utilizando `Entity Framework Core` e `SQLite` para o desenvolvimento de uma **plataforma de cursos**, contendo cursos, módulos e aulas. Além disso, era necessário criar um sistema de login/registro de usuários utilizando `ASP.NET Identity`. No geral funciona dessa forma:

1. A plataforma conterá uma página de visualização dos cursos.
2. Cada curso terá um ou mais módulos.
3. Cada módulo conterá mais que uma aula.
4. As aulas conterão informações como Título da Aula, Descrição da Aula.
5. O usuário poderá cadastrar e visualizar novas aulas, módulos e cursos.

Vale ressaltar que a grande pretensão do teste é verificar a capacidade em desenvolver uma aplicação do começo ao fim, assim sendo, é necessário o deployment da aplicação no `Azure`.

## Autor
- Otávio Villas Boas Simoncini Carmanini

## Tecnologias Utilizadas
- Entity Framework Core;
- ASP.NET 6 Web Model-View-Controller;
- SQLite;

## Principais dificuldades encontradas

- Implementação do ASP. NET Identity para o SQLite.
- Compreensão da Regra de Negócios para implementação das páginas de visualização.
- Relacionamento entre Tabelas com Entity Framework Core.