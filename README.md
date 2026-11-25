# WorkSphere – Smart Workplace & Workforce Management Platform

**One Workplace. Everything Connected.**

WorkSphere is an all-in-one workplace management platform designed to simplify how organizations manage employees, attendance, shifts, communication, meetings, tasks, and daily operations.

The platform aims to bring essential workplace activities into a single connected ecosystem, helping businesses improve workforce efficiency, team collaboration, and organizational productivity.

## Overview

Managing employees and daily office operations across multiple applications can become complicated. WorkSphere aims to solve this by providing a unified platform where employees, managers, HR teams, and administrators can work together seamlessly.

From GPS-based attendance and shift scheduling to team messaging and meeting management, WorkSphere brings everything together in one place.

## Key Features

### 1. Employee & Organization Management
- Employee profiles and directory.
- Department and designation management.
- Organization hierarchy.
- Employee onboarding and offboarding.
- Role-based access and permissions.

### 2. Smart Attendance Management
- GPS-based check-in and check-out.
- Location-based attendance verification.
- Geofencing.
- QR code-based attendance.
- Break and working-hour tracking.
- Late arrival and early departure tracking.
- Attendance history and reports.

### 3. Shift & Workforce Scheduling
- Create and manage employee shifts.
- Assign employees to shifts.
- Rotational shift scheduling.
- Weekly and monthly shift calendars.
- Shift swap requests.
- Shift conflict detection.
- Manager approvals.

### 4. Team Communication
- One-to-one messaging.
- Group conversations.
- Department-based channels.
- Company-wide announcements.
- Image and document sharing.
- Message replies and reactions.
- Real-time messaging and notifications.

### 5. Meetings & Calendar Management
- Schedule and manage meetings.
- Invite employees and teams.
- Meeting reminders.
- Meeting agendas.
- Meeting notes and action items.
- Meeting attendance tracking.
- Calendar management.

### 6. Task & Work Management
- Create and assign tasks.
- Task priorities and deadlines.
- Subtasks and attachments.
- Task status tracking.
- Team task boards.
- Progress monitoring.

### 7. Leave & Holiday Management
- Employee leave applications.
- Leave balance tracking.
- Leave approval workflows.
- Holiday calendar.
- Compensatory leave management.
- Leave history and reports.

### 8. Notifications & Analytics
- Real-time notifications.
- Push notifications.
- Attendance analytics.
- Workforce reports.
- Department-wise statistics.
- Shift coverage reports.
- Task completion insights.

## Technology Stack

| Component | Technology |
|---|---|
| Web Application | Angular |
| Mobile Application | Ionic + Angular + Capacitor |
| Backend | ASP.NET Core Web API |
| Programming Language | C# |
| Framework | .NET 10 |
| Database | Microsoft SQL Server |
| ORM | Entity Framework Core |
| Authentication | JWT & Refresh Tokens |
| Real-time Communication | SignalR |
| Push Notifications | Firebase Cloud Messaging |
| Cloud Storage | Azure Blob Storage |
| API Documentation | Swagger / OpenAPI |
| Version Control | Git & GitHub |
| Containerization | Docker |

## System Architecture

```text
                  WorkSphere Platform
                          |
             +------------+------------+
             |                         |
       Admin Web Portal          Employee Mobile App
          (Angular)              (Ionic + Angular)
             |                         |
             +------------+------------+
                          |
                 ASP.NET Core Web API
                          |
          +---------------+----------------+
          |               |                |
      Authentication   Business Logic    SignalR
          |               |                |
          +---------------+----------------+
                          |
                   Entity Framework Core
                          |
                    SQL Server
                          |
              Cloud Storage & Services
```

## Project Structure

```text
WorkSphere/
│
├── backend/
│   ├── WorkSphere.API/
│   ├── WorkSphere.Domain/
│   ├── WorkSphere.Application/
│   ├── WorkSphere.Infrastructure/
│   ├── Modules/
│   │   ├── Identity/
│   │   ├── Organization/
│   │   ├── Employees/
│   │   ├── Attendance/
│   │   ├── Shifts/
│   │   ├── Leave/
│   │   ├── Messaging/
│   │   ├── Meetings/
│   │   ├── Tasks/
│   │   ├── Notifications/
│   │   └── Reports/
│   └── WorkSphere.Tests/
│
├── web/
│   └── worksphere-admin/
│
├── mobile/
│   └── worksphere-mobile/
│
├── docs/
│
└── README.md
```

## User Roles

| Role | Responsibilities |
|---|---|
| Super Admin | Platform and organization management |
| Company Admin | Company configuration and employee management |
| HR | Attendance, shifts, leave and employee operations |
| Manager | Team scheduling, approvals and task management |
| Employee | Attendance, messaging, meetings, tasks and leave |

## Development Approach

WorkSphere is being developed using a modular architecture, with independent business modules sharing a common backend and database.

Development will follow an incremental approach:

- **Phase 1:** Authentication, organization, employee management, attendance, shifts and leave.
- **Phase 2:** Real-time messaging, groups, announcements and notifications.
- **Phase 3:** Meetings, calendar, tasks and collaboration.
- **Phase 4:** Advanced analytics, automation and integrations.

## Getting Started

Development setup instructions will be added as the backend, web and mobile applications become available.

Planned prerequisites:

- .NET 10 SDK
- Node.js and npm
- Angular CLI
- Ionic CLI
- SQL Server
- Visual Studio / VS Code
- Android Studio (for Android development)

## Project Vision

Our vision is to build a unified digital workplace where organizations can manage their entire workforce and daily operations through a single platform.

WorkSphere aims to reduce operational complexity, improve employee collaboration, and create a more connected working environment.

## Contributors

Built collaboratively by two software developers with experience in .NET and Angular.

## Project Status

**Status:** In Development 🚧

This project is under active development. Features, architecture, and documentation will evolve as the platform grows.

---

*WorkSphere – Bringing the entire workplace together.*
