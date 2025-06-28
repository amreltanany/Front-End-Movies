using MoviesBlazor.Models;
namespace MoviesBlazor.Clients
{
    public class GenresClients(HttpClient httpClient)
    {
        public async Task<Genre[]> GetGenresAsync() => await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];
    }
}
