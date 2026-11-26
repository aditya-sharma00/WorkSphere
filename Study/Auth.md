# WorkSphere — Authentication & Authorization Study Plan

**Stack:** WorkHub (ASP.NET Core 9 Web API + EF Core + SQL Server Express) and WorkDesk (Expo / React Native + expo-router).

**Rule:** study a phase, then build it, then get it reviewed, then move to the next phase. Tick the boxes as you go.

---

## Phase 0: Database Setup

### Topics to study
- [ ] **SQL Server basics:** instances (`.\SQLEXPRESS`), databases, tables, primary keys, foreign keys, unique constraints, indexes
- [ ] **Tooling:** install SSMS or Azure Data Studio and learn to browse tables and data
- [ ] **Connection strings:** what `Server`, `Database`, `Trusted_Connection`, `TrustServerCertificate` and `MultipleActiveResultSets` mean
- [ ] **Windows Authentication vs SQL Authentication**
- [ ] **EF Core code-first:** entities, `DbContext`, `DbSet`, conventions vs configuration
- [ ] **Fluent API with `IEntityTypeConfiguration<T>`:** `AppDbContext` already calls `ApplyConfigurationsFromAssembly`, but the `Data/Configurations` folder doesn't exist yet
- [ ] **Migrations:** `migrations add`, `database update`, `migrations remove`, and what the model snapshot is for
- [ ] **Relationships:** one-to-many and many-to-many, navigation properties, delete behaviour (cascade or restrict)

### Tasks
- [ ] Confirm the SQL Server Express service is running (Services app or SQL Server Configuration Manager)
- [ ] Connect to `.\SQLEXPRESS` from SSMS
- [ ] Apply the existing migration and confirm `/api/health` returns `"database": "connected"`
- [ ] In SSMS, check that `WorkHubDb` and `__EFMigrationsHistory` exist
- [ ] **Design the auth tables on paper.** For each table, write down:
  - the columns and their types
  - which columns must be unique
  - which columns need an index
  - the relationships between tables
  - Tables to think about: Users, Roles, UserRoles, RefreshTokens
- [ ] If you use ASP.NET Core Identity, list the tables it creates for you so you don't duplicate them
- [ ] Decide on user IDs: `int` or `Guid`. Research guessable IDs and index fragmentation, then write down your choice and the reason
- [ ] **Get the table design reviewed before writing any entity classes**

---

## Phase 1: Auth Concepts (theory only)

- [ ] **Authentication vs authorization:** "Who are you?" vs "What are you allowed to do?"
- [ ] **Why HTTP is stateless**, and what that means for "staying logged in"
- [ ] **Sessions/cookies vs tokens:** why tokens fit a mobile app better
- [ ] **401 Unauthorized vs 403 Forbidden:** when to return each one
- [ ] **Write the main flows in your own words in this file:** register, login, calling a protected API, token expiry, logout

---

## Phase 2: Password Security

- [ ] **Hashing vs encryption:** passwords are hashed, never encrypted
- [ ] **Salt:** what it is and what attack it stops (rainbow tables)
- [ ] **Slow hashing algorithms:** PBKDF2, bcrypt, Argon2. Understand why plain SHA256 is wrong for passwords
- [ ] **ASP.NET Core Identity:** `UserManager`, `SignInManager`, `RoleManager`, `PasswordHasher`, lockout, password rules
- [ ] **Decide:** Identity with EF stores and JWTs you issue yourself (recommended), or a fully custom user table. Write down the reason for your choice

---

## Phase 3: JWT Access Tokens

- [ ] **JWT structure:** header, payload and signature. Paste a token into jwt.io and read it
- [ ] **A JWT is signed, not encrypted:** never put secrets in the payload
- [ ] **Standard claims:** `sub`, `exp`, `iat`, `iss`, `aud`, `jti`, and role claims
- [ ] **Signing algorithms:** HS256 (one shared secret) vs RS256 (a public/private key pair)
- [ ] **The JwtBearer authentication handler**
- [ ] **`TokenValidationParameters`:** what issuer, audience, lifetime and signing-key validation each protect against, and what `ClockSkew` does
- [ ] **Middleware order:** ⚠️ `Program.cs` currently has `UseAuthorization()` but no `UseAuthentication()`. Learn where it goes and why the order matters
- [ ] **Access token lifetime:** why access tokens should be short-lived (about 5–15 minutes)

---

## Phase 4: Refresh Tokens

- [ ] **The access + refresh token pattern:** why you need both
- [ ] **Generating a refresh token:** use a random value, not a JWT
- [ ] **Storing refresh tokens in the database:** store a hash of the token, plus its expiry, creation time, revoked time and replacement token
- [ ] **Refresh token rotation:** every refresh issues a new refresh token and invalidates the old one
- [ ] **Reuse detection:** what to do when someone uses an old refresh token
- [ ] **Logout with JWTs:** revoke the refresh token. Understand why the access token can't truly be "killed"
- [ ] **Multiple devices:** one refresh token per device or session

---

## Phase 5: Authorization

- [ ] **`[Authorize]` and `[AllowAnonymous]`**, plus global fallback policies ("secure by default")
- [ ] **Role-based authorization:** define the WorkSphere roles (for example Admin, Manager, Employee) and what each can do
- [ ] **Claims-based authorization**
- [ ] **Policy-based authorization:** requirements and handlers
- [ ] **Resource-based authorization:** for example "a user can only edit their own data" or "a manager can only see their own team." This is the most important kind for WorkSphere
- [ ] **Permission matrix:** write a role × action table in this file before you build anything

---

## Phase 6: Configuration & Secrets

- [ ] **User Secrets (`dotnet user-secrets`)** for local development
- [ ] **Environment variables** for deployment
- [ ] ⚠️ **Never commit the JWT signing key.** `appsettings.json` is in git
- [ ] **The Options pattern:** bind a `Jwt` config section to a strongly typed settings class
- [ ] **Signing key length:** what the minimum is for HS256, and why

---

## Phase 7: API Design Around Auth

- [ ] **DTOs:** request and response models. Never return the User entity, because it carries the password hash
- [ ] **Input validation:** Data Annotations or FluentValidation
- [ ] **ProblemDetails** for consistent error responses
- [ ] **Safe login errors:** don't reveal whether it was the email or the password that was wrong
- [ ] **Swagger with Bearer auth,** so you can test protected endpoints from Swagger UI
- [ ] **Plan the endpoints:** register, login, refresh, logout, and "me" (current user)

---

## Phase 8: Frontend (Expo / WorkDesk)

- [ ] **Token storage:** `expo-secure-store` vs AsyncStorage. Learn why secure storage matters
- [ ] **Global auth state:** React Context + `useReducer`, or Zustand
- [ ] **Protected routes in expo-router:** route groups, redirects, and protected screens
- [ ] **An API client** that attaches the access token to every request
- [ ] **Automatic token refresh on a 401,** and how to avoid several refresh calls at the same time
- [ ] **Restoring the session on app start:** splash screen while the token is being checked
- [ ] ⚠️ **Networking:** a phone or emulator can't reach `localhost`. Learn about your PC's LAN IP, `10.0.2.2` for the Android emulator, and HTTPS dev-certificate problems with `UseHttpsRedirection`
- [ ] ⚠️ **CORS only applies to Expo web.** Native apps ignore it

---

## Phase 9: Hardening (later)

- [ ] **Account lockout** after failed logins
- [ ] **Rate limiting** on login and register (the .NET built-in rate limiter)
- [ ] **Email confirmation** flow
- [ ] **Forgot / reset password** flow
- [ ] **HTTPS everywhere** in production
- [ ] **OWASP Top 10,** focusing on Broken Access Control and Identification & Authentication Failures
- [ ] **Logging security events** (logins, failures, lockouts) without logging passwords or tokens

---

## Corrections Found in Current Code

| Where | Issue | What to learn |
|---|---|---|
| `WorkHub/Program.cs` | `UseAuthentication()` is missing | Middleware pipeline order |
| `WorkHub/appsettings.json` | Committed to git, so it can't hold secrets | User Secrets / environment variables |
| `WorkHub/Data/AppDbContext.cs` | Calls `ApplyConfigurationsFromAssembly`, but no configuration classes exist yet | `IEntityTypeConfiguration<T>` |
| CORS config | Only matters for Expo web, not native | How CORS works |
| `UseHttpsRedirection` + mobile | Can break calls from a device during development | Dev certificates, LAN networking |

---

## Official Docs

- EF Core: https://learn.microsoft.com/en-us/ef/core/
- ASP.NET Core Security overview: https://learn.microsoft.com/en-us/aspnet/core/security/
- ASP.NET Core Identity: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity
- ASP.NET Core Authorization: https://learn.microsoft.com/en-us/aspnet/core/security/authorization/introduction
- Safe storage of app secrets: https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets
- JWT debugger: https://jwt.io
- OWASP Top 10: https://owasp.org/Top10/
- Expo SecureStore: https://docs.expo.dev/versions/latest/sdk/securestore/
- Expo Router authentication: https://docs.expo.dev/router/advanced/authentication/

---

## My Notes

> Write your own explanations, decisions and table designs here as you study each phase.
