using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonPlaceHolderDependencyInjection.Function.Models
{
    public class Photo
    {
        [JsonProperty("albumId")]
        public int AlbumId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("thumbnailUrl")]
        public Uri ThumbnailUrl { get; set; }
    }
}
