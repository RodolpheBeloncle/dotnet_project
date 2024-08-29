namespace GameStore.Endpoints;
using GameStore.Dtos;


public static class GameEndpoints
{

    // defind endpoint names for games
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = [
            new (1, "Super Mario", "Platformer", 59.99m, new DateOnly(1985, 9, 13)),
            new (2, "The Legend of Zelda", "Action-adventure", 59.99m, new DateOnly(1986, 2, 21)),
            new (3, "Metroid", "Action-adventure", 59.99m, new DateOnly(1986, 8, 6)),
            new (4, "Final Fantasy", "Role-playing", 59.99m, new DateOnly(1987, 12, 18)),
        ];

    // router for game endpoints
    public static WebApplication BuildGameEndpoints(this WebApplication app)
    {
        // Configure the GET endpoint for games
        app.MapGet("games", () => games);

        // Configure the GET endpoint for a specific game with custom slug
        app.MapGet("games/{id}", (int id) =>
        {
            // find the game with the id
            GameDto? game = games.FirstOrDefault(g => g.Id == id);
            // return the game if it exists, otherwise return a 404
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName(GetGameEndpointName);

        // Configure the POST endpoint for games and response if the getGame route is called
        app.MapPost("games", (GameDto game) =>
        {
            GameDto newGame = new GameDto(games.Count + 1, game.Name, game.Genre, game.Price, game.ReleaseDate);
            games.Add(newGame);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = newGame.Id }, newGame);
        });

        // Configure the PUT endpoint for a specific game
        app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            GameDto game = games.FirstOrDefault(g => g.Id == id);

            if (game is null)
            {
                return Results.NotFound();
            }

            GameDto updatedGameDto = game with
            {
                Name = updatedGame.Name,
                Genre = updatedGame.Genre,
                Price = updatedGame.Price,
                ReleaseDate = updatedGame.ReleaseDate
            };

            games[games.IndexOf(game)] = updatedGameDto;

            return Results.Ok(updatedGameDto);
        });

        // Configure the DELETE endpoint for a specific game
        app.MapDelete("games/{id}", (int id) =>
        {
            GameDto game = games.FirstOrDefault(g => g.Id == id);

            if (game is null)
            {
                return Results.NotFound();
            }

            games.Remove(game);

            return Results.NoContent();
        });

        return app;
    }
}