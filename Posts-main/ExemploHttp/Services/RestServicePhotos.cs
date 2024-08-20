using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ExemploHttp.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Collections.ObjectModel;
namespace ExemploHttp.Services
{
    public class RestServicePhoto
    {
        private HttpClient client;
        private Photo photo;
        public ObservableCollection<Photo> photos;
        private JsonSerializerOptions serializerOptions;
        public RestServicePhoto()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

        }

        public async Task<ObservableCollection<Photo>> getPhotoAsync()
        {

            Uri uriPhoto = new Uri("https://jsonplaceholder.typicode.com/photos");
            try
            {
                HttpResponseMessage responsePhoto = await client.GetAsync(uriPhoto);

                if (responsePhoto.IsSuccessStatusCode)
                {
                    string content = await responsePhoto.Content.ReadAsStringAsync();
                    photos = JsonSerializer.Deserialize<ObservableCollection<Photo>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return photos;
        }


    }
}
