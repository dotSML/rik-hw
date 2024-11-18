# rik-hw Client Application Documentation

## Introduction

Welcome to the client application of rik-hw event management system.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Project Structure](#project-structure)
- [Domain Model](#domain-model)
- [Architecture Overview](#architecture-overview)
- [Usage](#usage)
- [API Interaction](#api-interaction)
- [Configuration](#configuration)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

## Prerequisites

Before setting up the project, ensure you have the following installed:

- **Node.js** (version 14.x or higher)
- **npm** or **Yarn** package manager
- A modern web browser (e.g., Chrome, Firefox)

## Installation

Follow these steps to set up the client application on your local machine:

1. **Clone the Repository**

   ```bash
   git clone https://github.com/dotsml/rik-hw.git

   ```

2. **Navigate to the Client Directory**

   ```bash
   cd rik-hw/client

   ```

3. **Install dependencies**

   ```bash
   npm install

   ```

4. **Start the development server**
   ```bash
   npm run dev
   Application should now be running at <a>http://localhost:5173</a>

## Project structure

client/
├── src/
│ ├── application/ # Application services
│ ├── domain/ # Domain models and logic
│ ├── infrastructure/ # API services and repositories
│ ├── presentation/ # UI components and views
│ ├── App.js
│ └── index.js
├── public/
│ └── index.html
├── package.json
└── README.md

- application/: Contains the services that coordinate domain operations.
- domain/: Holds the core business logic and domain models.
- infrastructure/: Manages communication with external services (e.g., API calls).
- presentation/: Includes React components and UI elements.

## License

This project is licensed under the MIT License.
