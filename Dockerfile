FROM evilz/node-mono-dotnet

WORKDIR /app
COPY . .
RUN yarn install

WORKDIR /app/src/Docs
RUN dotnet restore

WORKDIR /app
RUN yarn build
