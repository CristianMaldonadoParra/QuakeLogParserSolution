# Quake Log Parser API (.NET 9)

## Descrição

Esta aplicação é uma **API RESTful** desenvolvida em **.NET 9**, utilizando o padrão arquitetural **DDD (Domain-Driven Design)**. Ela foi criada para **processar e interpretar arquivos de log do jogo Quake 3 Arena**, gerando relatórios detalhados de cada partida registrada.

### Exemplo de Registro no Log
```
21:42 Kill: 1022 2 22: <world> killed Isgalamido by MOD_TRIGGER_HURT
2:22 Kill: 3 2 10: Isgalamido killed Dono da Bola by MOD_RAILGUN
```

### Resultado esperado por jogo
```json
{
  "name": "game_1",
  "totalKills": 45,
  "players": ["Dono da bola", "Isgalamido", "Zeh"],
  "kills": {
    "Dono da bola": 5,
    "Isgalamido": 18,
    "Zeh": 20
  }
}
```

## Estrutura do Projeto
- **QuakeLogParser.Domain**: Entidades e contratos (Interfaces).
- **QuakeLogParser.Application**: DTOs, serviços de aplicação e regras de transformação.
- **QuakeLogParser.Infrastructure**: Implementação do parser que lê e interpreta o arquivo de log.
- **QuakeLogParser.CrossCutting**: Configuração de injeção de dependências.
- **QuakeLogParser.API**: API RESTful com endpoint para consulta dos relatórios.
- **QuakeLogParser.Tests**: Testes unitários e de integração (xUnit).

---

## Como Executar Localmente

### Pré-Requisitos
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022

### Setup

1. Clone o repositório:
```bash
git clone hhttps://github.com/CristianMaldonadoParra/QuakeLogParserSolution.git
```

2. Acesse o diretório do projeto:
```bash
cd QuakerLogParse.Api
```

3. Compile a solução:
```bash
dotnet build
```

4. Execute a API:
```bash
dotnet run --project QuakeLogParser.API
```

### Endpoint Disponível
**Método:** `GET`  
**URL:**
```
http://localhost:5000/api/Games/parse-log
```

Você pode também testar diretamente pelo arquivo:
```
QuakerLogParser.API.http
```
Incluído na raiz do projeto QuakeLogParser.API para facilitar testes via Visual Studio.

---

## Testes

Para rodar os testes unitários e de integração:

```bash
dotnet test
```

- Testes unitários das regras de parser e serviços de aplicação.
- Testes de integração para validar o endpoint e retornos completos.

---

## Tecnologias Utilizadas
- ASP.NET Core 9
- DDD (Domain Driven Design)
- xUnit para testes

---

## Autor
Desenvolvido por Freddy Parra.
