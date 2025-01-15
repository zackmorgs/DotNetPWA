# DotNetPWA
A repository for my future dotnet PWA projects to assist me in a boilerplate fashion.

## Features
- Blazor WASM PWA Client
- API Server
- TailwindCSS support
- Webpack bundling
- CSSNano minfication
- Lightweight authorization handling
- IndexedDb support (in-progress)
- Online/Offline sync support (in the works..)

## Basic Installation/DX
### Install Global Dependencies
- Install dotnet 9 via [official source](https://dotnet.microsoft.com/en-us/download). 
- Install node/npm via [official source](https://nodejs.org/en).

### 1. dotnet/npm dependency installation
- Open a terminal in a folder of your choosing.
- Clone the repository:
    - `git clone https://github.com/zackmorgs/DotNetPWA.git`
- Install the dependencies:
    - `npm install`
    - `dotnet restore`

### 2. Microsoft SQL Server Initiation
- Instantiate the database by running a migration
    - `cd ./src/Data/; dotnet ef migrations add InitialCreate --startup-project ./../API;`
    - When it finishes: 
        - `dotnet ef database update --startup-project ./../API;`
- Return to the projects root folder:
    - `cd ./../..`

### 3. Development Tutorial
- Run the npm "watch" dev script:
    - `npm run watch`

This will launch the API server as well as the PWA server. Navigate to the weather page to test functionality.

### 4. Building
- Run the npm "build" command
    - `npm run build`

This will bundle javacript, efficiently build TailwindCSS, minify the css, and build out the dotnet application to "./dist"

