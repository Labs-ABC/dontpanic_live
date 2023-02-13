# DontPanicBaby

Esse projeto é um jogo tipo wordle em que você precisa adivinhar a equação escondida que resulta em 42
#
## Tecnologias utilizadas
- Angular
- .NET
- NGINX
- C#
- TypeScript
#

## Como jogar

O jogo consiste em adivinhar a equação escondida cujo resultado é 42

Para jogar insira um número ou operador em cada caixa
e depois que todos os espaços estiverem preenchidos clique no botão "Submit"

O programa retorna as dicas das posições de cada número, sendo:

- Vermelho: quando o caracter inserido não existe dentro da equação

- Verde: quando o caracter inserido existe na equação e está na posição correta

- Laranja: quando o caracter inserido existe na equação mas não está na posição correta

Caso o resultado da equação inserida não for 42 o programa não faz nada
#

## Como rodar

- Clonar o repositório
```txt
git clone https://github.com/42sp/42labs-dontpanic_baby-18404527.git
```
- Entrar no diretório DontPanicBaby
```txt
cd DontPanicBaby
```
- Instalar as dependências
```txt
npm i
```
- Build do Front
```txt
ng build
```
- Subir o Front
```txt
sudo nginx -c nginx.conf -p ./
```
- Entrar no diretório DontPanicBabyApi em outro terminal
```txt
cd DontPanicBabyApi
```
- Build do Back
```txt
dotnet publish -c Release -o out
```
- Subir o Back
```txt
dotnet out/DontPanicBabyApi.dll
```
