using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JsonPlaceHolderDependencyInjection.Function.Models.Clients
{
    public interface IJsonPlaceholderClient
    {
        Task<List<Album>> GetAlbums();

        Task<Album> GetAlbumById(int id);

        Task<List<Photo>> GetPhotos();

        Task<Photo> GetPhotoById(int id);

        Task<List<Photo>> GetPhotosByAlbumId(int id);
    }

    public class JsonPlaceholderClient : HttpClient, IJsonPlaceholderClient
    {
        public JsonPlaceholderClient(string baseAddress)
        {
            this.BaseAddress = new Uri(baseAddress);
        }

        public async Task<List<Album>> GetAlbums()
        {
            HttpResponseMessage response = await this.GetAsync("albums");

            List<Album> albums = await response.Content.ReadAsAsync<List<Album>>();

            return albums;
        }

        public async Task<Album> GetAlbumById(int id)
        {
            HttpResponseMessage response = await this.GetAsync(String.Format("albums/{0}", id.ToString()));

            Album album = await response.Content.ReadAsAsync<Album>();

            return album;
        }

        public async Task<List<Photo>> GetPhotos()
        {
            HttpResponseMessage response = await this.GetAsync("photos");

            List<Photo> photos = await response.Content.ReadAsAsync<List<Photo>>();

            return photos;
        }

        public async Task<Photo> GetPhotoById(int id)
        {
            HttpResponseMessage response = await this.GetAsync(String.Format("photos/{0}", id.ToString()));

            Photo photo = await response.Content.ReadAsAsync<Photo>();

            return photo;
        }

        public async Task<List<Photo>> GetPhotosByAlbumId(int id)
        {
            HttpResponseMessage response = await this.GetAsync(String.Format("photos?albumId={0}", id.ToString()));

            List<Photo> photos = await response.Content.ReadAsAsync<List<Photo>>();

            return photos;
        }
    }
}
