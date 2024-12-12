## Color Palettes Mock API

A simple `C#` and `.NET Core` <ins>mock API</ins> using `EF Core` for managing color palettes with CRUD support.

### Getting Started

1. Clone the repository and navigate to the project directory.
```sh
git clone https://github.com/otegecmis/color-palettes-mock-api.git
```

2. Navigate to the MockAPI directory.
```sh
cd color-palettes-mock-api/MockAPI
```

3. Restore dependencies.
```sh
dotnet restore
```

4. Run the application.
```sh
dotnet run
```

### Database Configuration

You can enable the option to recreate the database on each run by setting `RecreateDatabaseOnStart` to `true` in `launchSettings.json`.

Example:
```json
{
  "profiles": {
    "http": {
      "environmentVariables": {
        "RecreateDatabaseOnStart": true
      }
    }
  }
}
```

By default, this option is `false`.

### API Documentation

Access `Swagger UI` at `/swagger` to test the API.

<div style="float: left;">
    <img src="Assets/Swagger.png" style="width: 80%;" />
</div>
