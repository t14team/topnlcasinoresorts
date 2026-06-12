# Top NL Casino Resorts

A modern ASP.NET Core 8 MVC website for [topnlcasinoresorts.com](https://topnlcasinoresorts.com) — the Netherlands' premier casino hotel guide.

## Features

- **Home** — Hero section, featured Dutch casino resorts, destination highlights
- **About Us** — Company story, mission, responsible gaming
- **Contact Us** — Contact form with validation
- **Privacy Policy** — GDPR-compliant privacy policy

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Run Locally

```bash
dotnet run
```

Open [http://localhost:5000](http://localhost:5000) in your browser.

## Project Structure

```
FinlandCasinoHotels/
├── Controllers/HomeController.cs
├── Models/
├── Views/
│   ├── Home/          # Index, About, Contact, Privacy
│   └── Shared/        # Layout, partials
└── wwwroot/
    ├── css/site.css   # Navy & gold luxury theme
    └── js/site.js     # Animations & interactions
```
