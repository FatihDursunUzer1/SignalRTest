using Microsoft.AspNetCore.SignalR.Client;

public static class Program
{
    static  HubConnection connection;
    public static async Task Main()
    {
        Console.WriteLine("First");
        bool test = true;

        connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7279/locationHub")
                .Build();
        Console.WriteLine(connection.State.ToString());
        await connection.StartAsync();
        connection.On<string, double, double>("location", (user, latitude, longitude) =>
        {
            var newMessage = $"{user}: {latitude.ToString()}";
            Console.WriteLine(user.ToString());
        });
        Console.Read();
    }
}

public class Location
{
    public double Latitude { get; set; }
    public double longitude { get; set; }
}