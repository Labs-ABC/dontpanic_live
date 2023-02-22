# estágio de compilação
FROM node:lts-alpine as build-stage
WORKDIR /App
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# estágio de produção
FROM nginx:stable-alpine as production-stage
RUN mkdir /App
COPY --from=build-stage /App/dist /App
COPY nginx.conf /etc/nginx/nginx.conf
CMD ["nginx", "-g", "daemon off;"]
