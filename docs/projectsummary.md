# TaskManagement — Project Summary

## Overview

A Clean Architecture task management API built with .NET 8. Users own projects; projects contain tasks; tasks can be assigned to users with status and priority.

## Tech Stack

- .NET 8 (`net8.0`), ASP.NET Core Web API
- xUnit for tests
- SDK pinned via `global.json` (`8.0.100` + `latestFeature`)

## Solution Structure

| Project | Layer | Role |
|---|---|---|
| `src/TaskManagement.Domain` | Domain | Entities + enums; no dependencies |
| `src/TaskManagement.Application` | Application | Use cases / ports (empty) |
| `src/TaskManagement.Infrastructure` | Infrastructure | Persistence / EF (empty) |
| `src/TaskManagement.Api` | Presentation | Web API host |
| `tests/TaskManagement.UnitTests` | Tests | Domain unit tests |
| `tests/TaskManagement.IntegrationTests` | Tests | Integration tests (empty) |

## Architecture Flow (project references)

`Domain` ← `Application` ← `Infrastructure` ← `Api`, with tests referencing the layers under test.

## Phase Status

### Phase 1 — Solution scaffold ✅
Solution, 4-layer structure, references, SDK pinning, build passing.

### Phase 2 — Domain model ✅
`BaseEntity` (Guid identity + audit), `User`, `Project`, `TaskItem`, `TaskStatus` (NotStarted/InProgress/Completed/Cancelled), `TaskPriority` (Low/Medium/High/Critical). Encapsulated: private setters, behavior methods, constructor guards. Unit tests cover creation, ownership, assignment, defaults.

### Phase 3+ — Pending
- Application layer (use cases, repository port)
- Infrastructure layer (EF Core, persistence)
- API endpoints (controllers/minimal APIs) for tasks
- Integration tests

## Known Issues / Open Items

- `TaskStatus` collides with BCL `System.Threading.Tasks.TaskStatus`; consumers outside Domain must use a using alias.
- `Application` / `Infrastructure` projects exist but are empty.
- Api still serves only the template `/weatherforecast` endpoint; no task endpoints yet.
- Domain review findings (duplicate task adds, `Guid.Empty` FK acceptance) open for Phase 3.
