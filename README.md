# DontPanicDaily

Esse projeto é um jogo tipo [Wordle](https://www.nytimes.com/games/wordle/index.html) ou [Termo](https://term.ooo), em que você precisa adivinhar a equação escondida cujo resultado é 42.
#
## Tecnologias utilizadas
- Angular
- .NET
- NGINX
- C#
- TypeScript
- Docker
- SQL Server
#

## Como jogar

O jogo consiste em adivinhar a equação escondida cujo resultado é 42.

Para jogar, insira um número ou operador aritmético em cada caixa
e, depois que todos os espaços estiverem preenchidos, clique no botão "Submit".

O programa retorna as dicas das posições de cada número, sendo:

- Vermelho: quando o caracter inserido não existe dentro da equação

- Verde: quando o caracter inserido existe na equação e está na posição correta

- Laranja: quando o caracter inserido existe na equação mas não está na posição correta

Caso o resultado da equação inserida não for, 42 o programa não faz nada.

A equação é trocada todos os dias à meia-noite, mas seu resultado sempre deve ser 42.
#

## Como rodar

A aplicação é containerizada, ou seja, é necessário ter o Docker instalado na sua máquina.

- Clone o repositório:
```sh
git clone https://github.com/42sp/42labs-dontpanic_baby-18404527.git
```
- Na raíz do diretório onde o repositório foi clonado, execute o seguinte comando:
```sh
docker-compose up --build
```
- Para acessar a página web da aplicação, basta acessar o endereço `http://localhost:5014` no seu navegador.
