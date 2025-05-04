# Beer Collection API

A simple API for managing a beer collection.

## Features

- Add beers with name, type, and optional rating (1-5)
- List all beers
- Search beers by name
- Update ratings (calculates average)

## Setup

1. Install .NET SDK
2. Run `dotnet run`
3. API runs on http://localhost:5031

## Endpoints

- GET /api/beers - Get all beers
- GET /api/beers/search?term={term} - Search beers
- POST /api/beers - Create beer
- PUT /api/beers/{id}/rating - Update rating
