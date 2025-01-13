# DotNetPWA
A repository for my future dotnet projects to assist me in configuration.

## Basic Usage
- Install dotnet 9 via [official source](https://dotnet.microsoft.com/en-us/download). 
- Install node/npm via [official source](https://nodejs.org/en).
- Open a terminal in a folder of your choosing.
- Clone the repository:
    - `git clone https://github.com/zackmorgs/DotNetPWA.git`
- Install the dependencies:
    - `npm install`
    - `dotnet restore`
- Instantiate the database by running a migration
    - `cd ./src/Data/; dotnet ef migrations add InitialCreate --startup-project ./../API;`
    - When it finishes: 
        - `dotnet ef database update --startup-project ./../API;`
- Return to the projects root folder:
    - `cd ./../..`
- Run the npm "watch" dev script:
    - `npm run watch`

This will launch the API server as well as the PWA server. Navigate to the weather page to test functionality.
