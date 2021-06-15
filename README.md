[![CI](https://github.com/martinlandart/ml-challenge/actions/workflows/dotnet.yml/badge.svg)](https://github.com/martinlandart/ml-challenge/actions/workflows/dotnet.yml)

# ML Challenge

## How to run

Requires Docker, Docker Compose.

From project root, run:

`docker compose build`

`docker compose up`

## Hosted APIs

Note: The first few requests might be very slow due to warm-up time for the databases

```http
// MUTANT
POST https://mlchallengemartinlandart.azurewebsites.net/api/mutant HTTP/1.1
content-type: application/json

{
    "dna":["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"]
}
```

```http
// HUMAN
POST https://mlchallengemartinlandart.azurewebsites.net/api/mutant HTTP/1.1
content-type: application/json

{
    "dna":["ATGCGA","CCGTCA","TTATGA","AGAAGA","CGTCTC","TCACTG"]
}
```

```http
// STATS
GET https://mlchallengemartinlandart.azurewebsites.net/api/mutant/stats HTTP/1.1
```

## Hosting

The application is hosted in Azure, with the following infrastructure:

- WebApp Service
- Azure SQL
- Azure Cache for Redis (For api/mutant/stats)

## Architecture

- Constructed based on TDD, DDD and Clean Architecture principles, prioritizing maintainability and decoupling.
- Leveraged the [Clean Architecture template by Jason Taylor](https://github.com/jasontaylordev/CleanArchitecture). I've modified it and reduced it to be more appropriate for microservices, since it's designed for monolithic applications.
- POST /mutant will persist the DNA sequence in a SQL Server database.
- GET /mutant/stats will respond to the query by returning a cached result, Redis in this case. For the sake of time, I've made a few compromises:
  - The /mutant/stats service is not independently scalable, that could be achieved by extracting it into a new service by itself.
  - The stats cache is updated by an in-process event triggered after POST /mutants is called. This could be greatly improved by adding event sourcing infrastructure, using something like Kafka.

## Tests

Very high test coverage:

- Integration/Subcutaneous tests (just below the API layer)
  - All commands and queries covered
- Unit Tests
  - ml_challenge.Application: >90%
  - ml_challenge.Domain: >75%
- Load test ([here](https://github.com/martinlandart/ml-challenge/blob/master/tests/LoadTesting/script.js)) using [k6](https://k6.io/)

[BenchmarkDotnet](https://benchmarkdotnet.org/), a performance benchmark tool, was used during development to measure the performance of the IsMutant algorithm. These are the results for a quick test with a 2000x2000 DNA sequence.

```ini
BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1052 (21H1/May2021Update)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=5.0.301
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  DefaultJob : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
```

| Method   |     Mean |     Error |    StdDev |
| -------- | -------: | --------: | --------: |
| IsMutant | 1.420 ms | 0.0098 ms | 0.0087 ms |
