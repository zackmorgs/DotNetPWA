# DotNetPWA
A repository for my future dotnet PWA projects to assist me in a efficient creation of a dotnet PWA.

## Features
- Blazor WASM PWA Client
- API Server
- Offical TailwindCSS support
- Webpack bundling
- CSSNano CSS minfication
- Lightweight authorization handling with Identity Framework Core
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
- Install the app's dependencies:
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
#### Either
- Run the npm "watch" dev script:
    - `npm run watch`
#### or
- Hit the "Play" button in VisualStudio

This will launch the API server, the PWA server, TailwindCSS's watch script (with css tree-shaking and autoprefixing for vendors), a Webpack bundling service, and quick and efficient css minification with PostCSS/CSSNano plugin.

It should pop up a pwa client on your default browser.

### 4. Building out the whole thing
- Run the npm "build" command
    - `npm run build`

This will bundle JavaScript, efficiently build TailwindCSS, minify the css, and build out the `dotnet` application to `"./dist"`

If you have errors, they should appear in the terminal.

## Todo:
- Identity scaffolding/code
    - Setup role-based authentication
    - Allow users to register
    - Allow users to login
    - Seed an "Admin" user safely
- Offline Sync Support
    - Setup offline sync support to sync IndexedDb with MS SQL Server correctly.
    - Integrate [Background Sync API](https://developer.mozilla.org/en-US/docs/Web/API/Background_Synchronization_API) with service workers.
    - Create custom framework for the above for rock-solid DX, consistent performance