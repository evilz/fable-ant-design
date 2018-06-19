FROM fable-build-test

WORKDIR /app
COPY . .
RUN yarn install

WORKDIR /app/src/Docs
RUN dotnet restore

WORKDIR /app
RUN yarn build
