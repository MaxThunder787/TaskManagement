# AGENTS.md

## Purpose

Build senior-level .NET projects from the supplied roadmap. Keep code short, practical, production-oriented, and concept-focused.

## Code Generation Rules

Before every generated code block, add a short comment using exactly one of these labels:

* `// Code follow: <concept>` — follow the current codebase concept/style.
* `// Improvement: <concept>` — improve the current approach without changing the core requirement.
* `// Alternate approach: <concept>` — show a different valid design/pattern.
* `// Why: <concept> — <when to use>` — explain why the concept is appropriate.


# AI Development Rules

## General

- Do not modify files unrelated to the requested task.
- Do not introduce dependencies without explaining why.
- Follow the existing architecture.
- Prefer simple solutions over unnecessary abstractions.
- Do not expose EF Core entities directly through API endpoints.
- Do not put business logic inside controllers.
- Do not introduce secrets into source code.
- Do not disable security checks to make code work.
- Do not suppress compiler warnings without explaining why.

## Before changing code

- Inspect relevant files first.
- Explain the proposed change.
- Identify risks.
- Make the smallest reasonable change.

## After changing code

- Build the solution.
- Run relevant tests.
- Report changed files.
- Report assumptions.
- Report any remaining issues.

## Performance

- Do not load entire database tables unnecessarily.
- Prefer server-side filtering and pagination.
- Avoid unnecessary allocations.
- Avoid premature optimization.
- Measure before making performance claims.

## Security

- Never request or expose secrets.
- Never connect to production systems.
- Validate external input.
- Do not trust client-supplied IDs or permissions.
- Do not disable authentication/authorization as a shortcut.

