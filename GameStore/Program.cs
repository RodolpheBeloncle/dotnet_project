using GameStore.Endpoints;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Build instance of the app
        var app = builder.Build();

        // Build the game endpoints
        app.BuildGameEndpoints();

        app.Run();
    }
}
