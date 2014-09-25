namespace MusicCatalog.ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using MusicCatalog.ConsoleApp.Models;
    using Newtonsoft.Json;

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("\t Run the ASP.NET server first, Please!!!! Connection string \".\"");
            Console.WriteLine();
            Console.WriteLine();

            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:51634/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            AddArtist(client, "Opeth", "Sweden", "Progressive death metal");
            AddArtist(client, "Dark Tranquillity", "Sweden", "Melodic death metal");

            AddAlbum(client, "Blackwater Park", "Steven Wilson", 2001);
            AddAlbum(client, "Damnation", "Steven Wilson", 2003);
            AddAlbum(client, "Damage Done", "Fredrik Nordström", 2002);
            AddAlbum(client, "Fiction", "Tue Madsen", 2007);
            AddAlbum(client, "Construct", "Jens Bogren", 2013);


            AddAlbumToArtists(client, 1, 1);
            AddAlbumToArtists(client, 1, 2);
            AddAlbumToArtists(client, 2, 3);
            AddAlbumToArtists(client, 2, 4);
            AddAlbumToArtists(client, 2, 5);

            Console.WriteLine();
            PrintAllArtists(client);

            Console.WriteLine();
            PrintAllAlbums(client);

            Console.WriteLine();
            GetAllAlbums(client, 1);
            GetAllAlbums(client, 2);
        }

        private static void AddArtist(HttpClient client, string name, string country, string genre)
        {

            var newArtist = new ArtistModel()
            {
                Name = name,
                Country = country,
                MusicGenre = genre,

            };

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(newArtist));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = client.PostAsync("api/artists/create", postContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void PrintAllArtists(HttpClient client)
        {
            var response = client.GetAsync("api/artists/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<ArtistModel>>().Result;
                Console.WriteLine("Artists:");
                foreach (var artist in artists)
                {
                    Console.WriteLine("{0}: {1} - {2} - {3}", artist.Id, artist.Name, artist.Country, artist.MusicGenre);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void AddAlbum(HttpClient client, string name, string produser, int year)
        {

            var newArtist = new AlbumModel()
            {
                Name = name,
                Producer = produser,
                ReleaseDateYear = year,
            };

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(newArtist));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = client.PostAsync("api/albums/create", postContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void PrintAllAlbums(HttpClient client)
        {
            var response = client.GetAsync("api/albums/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<AlbumModel>>().Result;

                Console.WriteLine("Albums:");
                foreach (var album in albums)
                {
                    Console.WriteLine("{0}: {1} - {2} - {3}", album.Id, album.Name, album.ReleaseDateYear, album.Producer);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void AddAlbumToArtists(HttpClient client, int artistId, int albumId)
        {

            string route = string.Format("api/artists/AddAlbum/{0}?AlbumId={1}", artistId, albumId);

            var response = client.PostAsync(route, null).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added to artist!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void GetAllAlbums(HttpClient client, int artistId)
        {
            string route = string.Format("api/artists/getAlbums/{0}", artistId);
            var response = client.GetAsync(route).Result;
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<AlbumModel>>().Result;

                Console.WriteLine("Artist {0} -> Albums: {1}", artistId, string.Join(", ",albums.Select(a => a.Name)));
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
