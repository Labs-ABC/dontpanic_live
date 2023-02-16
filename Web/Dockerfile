# Primeira estágio usado para compilar a aplicação
FROM ubuntu:20.04 as build-stage

# Cria e vai pra pasta /App
WORKDIR /App

# instala o node e nginx
RUN apt-get update && DEBIAN_FRONTEND=noninteractive  apt-get install -y nodejs npm nginx

# instalar curl
RUN apt-get update && \
  apt-get install -y curl

# Atualizar o node pra versão mais recente
RUN curl -o node-v18.10.0-linux-x64.tar.gz https://nodejs.org/dist/v18.10.0/node-v18.10.0-linux-x64.tar.gz && \
  tar xzf node-v18.10.0-linux-x64.tar.gz && \
  rm node-v18.10.0-linux-x64.tar.gz && \
  mv node-v18.10.0-linux-x64 /usr/local/node && \
  ln -s /usr/local/node/bin/node /usr/local/bin/node && \
  ln -s /usr/local/node/bin/npm /usr/local/bin/npm

# copia os arquivos pacgkage.json pra dentro do container na pasta /App
COPY package*.json .

# Instala as dependências (npm install)
RUN npm install

# Copia todos os arquivos para a pasta app
COPY . .

# Faz o build da aplicação
RUN npm run build

# Segundo estágio usado para executar a aplicação
FROM ubuntu:20.04 as production-stage

WORKDIR /App

RUN apt-get update && apt-get install -y nginx

COPY --from=build-stage /App/dist /App

# copiar o arquivo do nginx pra pasta correta
COPY nginx.conf /etc/nginx/nginx.conf

# executa apenas quando iniciamos a imagem (docker run ou docker-compose up)
CMD ["nginx", "-g", "daemon off;"]
