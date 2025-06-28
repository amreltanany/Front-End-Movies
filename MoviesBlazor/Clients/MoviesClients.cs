using MoviesBlazor.Models;

namespace MoviesBlazor.Clients
{
    public class MoviesClients(HttpClient httpClient)
    {
        public async Task<Movie[]> GetMoviesAsync() => await httpClient.GetFromJsonAsync<Movie[]>("movies") ?? [];

        //get movie by id
        public async Task<Movie?> GetMovieByIdAsync(int id) => await httpClient.GetFromJsonAsync<Movie>($"movies/{id}");

        //add new movie
        public async Task AddMovieAsync(Movie movie) => await httpClient.PostAsJsonAsync("movies", movie);

        //update movie
        public async Task UpdateMovieAsync(Movie movie) => await httpClient.PutAsJsonAsync($"movies/{movie.Id}", movie);

        //delete movie 

        public async Task DeleteMovieAsync(int id) => await httpClient.DeleteAsync($"movies/{id}");






    }
}
