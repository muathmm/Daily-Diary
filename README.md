# Daily Diary Manager

This console application manages daily diary entries, allowing users to read, add, delete, count, and search entries. It provides a simple interface for managing personal diary records.

## Features

- **Single-Player Mode**: Manage diary entries for personal use.
- **Functionality**:
  - Read diary entries from a text file.
  - Add new diary entries with a specified date and content.
  - Delete diary entries based on date.
  - Count total entries in the diary file.
  - Search entries by date or keyword.
- **Exception Handling**: Manages errors such as invalid input formats.
- **Program Structure**:
  - `Program.cs`: Entry point, manages the application flow.
  - `DailyDiary.cs`: Class handling diary operations.
  - `Entry.cs`: Represents a diary entry with date and content.
- **Usage**:
  - Clone the repository: [GitHub Repo](https://github.com/your-username/Daily-Diary-Manager)
  - Navigate to the project directory: `cd Daily-Diary-Manager`
  - Build and run the application: `dotnet run`
- **Unit Tests**:
  - Run tests: `dotnet test`
  - Coverage:
    - Diary entry operations: add, delete, count, search.
    - Error handling for invalid inputs.
  
## Getting Started

### Prerequisites

- .NET SDK installed on your machine.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/muathmm/Daily-Diary
