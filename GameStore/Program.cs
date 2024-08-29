using GameStore.Api.Dtos;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Build instance of the app
        var app = builder.Build();

        List<GameDto> games = [
            new (1, "Super Mario", "Platformer", 59.99m, new DateOnly(1985, 9, 13)),
            new (2, "The Legend of Zelda", "Action-adventure", 59.99m, new DateOnly(1986, 2, 21)),
            new (3, "Metroid", "Action-adventure", 59.99m, new DateOnly(1986, 8, 6)),
            new (4, "Final Fantasy", "Role-playing", 59.99m, new DateOnly(1987, 12, 18)),
        ];

        // Configure the GET endpoint for games
        app.MapGet("games", () => games);

        // Root endpoint
        app.MapGet("/", () => "Hello Rodolphe");

        app.Run();
    }
}
