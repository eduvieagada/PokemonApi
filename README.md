# Pokemon API
This is an Api service to retrieve pokemon data


#### Requirements to run
- .NET 5 or higher
- Docker
- Terminal


#### How to run application
- Without Docker
	1. clone the github project
	2. Navigate to the PokemonApi folder using the terminal
	3. enter the command `dotnet run` and press enter

- With Docker
	1. clone the github project
	2. Navigate to the PokemonApi folder using the terminal
	3. build the docker image: `docker build -t pokemonapi .`
	4. run the docker image in the terminal: `docker run -d -p 5000:5000`


#### Running Tests
	1. clone the github project
	2. Navigate to the PokemonApi.Tests folder using the terminal
	3. enter the command `dotnet test` and press enter