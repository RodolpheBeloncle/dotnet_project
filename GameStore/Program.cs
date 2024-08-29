using GameStore.Dtos;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Build instance of the app
        var app = builder.Build();

        // defind endpoint names for games
        const string GetGameEndpointName = "GetGame";

        List<GameDto> games = [
            new (1, "Super Mario", "Platformer", 59.99m, new DateOnly(1985, 9, 13)),
            new (2, "The Legend of Zelda", "Action-adventure", 59.99m, new DateOnly(1986, 2, 21)),
            new (3, "Metroid", "Action-adventure", 59.99m, new DateOnly(1986, 8, 6)),
            new (4, "Final Fantasy", "Role-playing", 59.99m, new DateOnly(1987, 12, 18)),
        ];

        // Configure the GET endpoint for games
        app.MapGet("games", () => games);

        // Configure the GET endpoint for a specific game with custom slug
        app.MapGet("games/{id}", (int id) => games.FirstOrDefault(g => g.Id == id)).WithName(GetGameEndpointName);

        // Configure the POST endpoint for games and response if the getGame route is called
        app.MapPost("games", (GameDto game) =>
        {
            GameDto newGame = new GameDto(games.Count + 1, game.Name, game.Genre, game.Price, game.ReleaseDate);
            games.Add(newGame);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = newGame.Id }, newGame);
        });

        // Root endpoint
        app.MapGet("/", () => "Hello Rodolphe");

        app.Run();
    }
}
