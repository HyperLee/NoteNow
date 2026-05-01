# Repository Guidelines

## Project Structure & Module Organization
`NoteNow.sln` is the solution entrypoint. The application itself lives in `NoteNow/`, with `Program.cs` containing the current console app logic and `NoteNow.csproj` defining the .NET 10 target. Ignore generated output in `NoteNow/bin/` and `NoteNow/obj/`. Contributor automation and review guidance live under `.github/`, and local editor tasks are in `.vscode/`.

## Build, Test, and Development Commands
Run commands from the repository root.

- `dotnet restore NoteNow.sln`: restore NuGet packages.
- `dotnet build NoteNow.sln`: compile the solution and catch build errors.
- `dotnet run --project NoteNow/NoteNow.csproj`: run the console app locally.
- `dotnet test NoteNow.sln`: execute the standard verification entrypoint. The solution currently has no dedicated test project, so this is mainly a forward-compatible CI check.

## Coding Style & Naming Conventions
Follow `.editorconfig` exactly. Use 4 spaces for C# and 2 spaces for XML. Keep types, methods, and public members in `PascalCase`; use `camelCase` for parameters, locals, and private fields. Prefer explicit types over `var` unless the type is obvious. Keep braces and spacing consistent with the existing C# formatting rules, and write XML doc comments for public APIs when you add them.

## Testing Guidelines
There is no `*.Tests` project yet. When adding meaningful logic, create a sibling test project such as `NoteNow.Tests` and include it in `NoteNow.sln`. Mirror production names in test files, keep tests deterministic, and ensure `dotnet test NoteNow.sln` passes before opening a PR.

## Commit & Pull Request Guidelines
Recent history favors short, imperative commit subjects, often in Chinese, with occasional prefixes like `feat:`. Keep commits focused on one change. For pull requests, include a concise description, link the related issue or PR thread when applicable, and add sample console output or screenshots if behavior changes. Do not commit generated `bin/` or `obj/` artifacts.
