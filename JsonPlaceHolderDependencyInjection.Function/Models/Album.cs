using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonPlaceHolderDependencyInjection.Function.Models
{
    public class Album
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }
    }
}
