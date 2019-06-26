using JsonPlaceHolderDependencyInjection.Function.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonPlaceHolderDependencyInjection.Tests.Models
{
    public class TestFactory
    {
        public static List<Album> GetTestAlbums()
        {
            var albums = new List<Album>();
            albums.Add(new Album()
            {
                UserId = 1,
                Id = 1,
                Title = "Test Album 2019",
                Photos = new List<Photo>()
                {
                    {
                        new Photo()
                        {
                            AlbumId = 1,
                            Id = 1,
                            Title = "Test Photo 1",
                            Url = new Uri("https://photo-1.com"),
                            ThumbnailUrl = new Uri("https://thumbnail-1.com")
                        }
                    },
                    {
                        new Photo()
                        {
                            AlbumId = 1,
                            Id = 2,
                            Title = "Test Photo 2",
                            Url = new Uri("https://photo-2.com"),
                            ThumbnailUrl = new Uri("https://thumbnail-2.com")
                        }
                    }
                }
            });

            albums.Add(new Album()
            {
                UserId = 1,
                Id = 2,
                Title = "Test Album 2020",
                Photos = new List<Photo>()
                {
                    {
                        new Photo()
                        {
                            AlbumId = 2,
                            Id = 3,
                            Title = "Test Photo 3",
                            Url = new Uri("https://photo-3.com"),
                            ThumbnailUrl = new Uri("https://thumbnail-3.com")
                        }
                    },
                    {
                        new Photo()
                        {
                            AlbumId = 2,
                            Id = 4,
                            Title = "Test Photo 4",
                            Url = new Uri("https://photo-4.com"),
                            ThumbnailUrl = new Uri("https://thumbnail-4.com")
                        }
                    }
                }
            });

            return albums;
        }

        public static Album GetTestAlbums(int id)
        {
            var album = new Album()
            {
                UserId = 1,
                Id = id,
                Title = "Test Album 2019",
                Photos = new List<Photo>()
                {
                    {
                        new Photo()
                        {
                            AlbumId = id,
                            Id = 1,
                            Title = "Test Photo 1",
                            Url = new Uri("https://photo-1.com"),
                            ThumbnailUrl = new Uri("https://thumbnail-1.com")
                        }
                    },
                    {
                        new Photo()
                        {
                            AlbumId = id,
                            Id = 2,
                            Title = "Test Photo 2",
                            Url = new Uri("https://photo-2.com"),
                            ThumbnailUrl = new Uri("https://thumbnail-2.com")
                        }
                    }
                }
            };

            return album;
        }

        public static List<Photo> GetTestPhotos()
        {
            var photos = new List<Photo>();
            photos = new List<Photo>()
            {
                {
                    new Photo()
                    {
                        AlbumId = 1,
                        Id = 1,
                        Title = "Test Photo 1",
                        Url = new Uri("https://photo-1.com"),
                        ThumbnailUrl = new Uri("https://thumbnail-1.com")
                    }
                },
                {
                    new Photo()
                    {
                        AlbumId = 1,
                        Id = 2,
                        Title = "Test Photo 2",
                        Url = new Uri("https://photo-2.com"),
                        ThumbnailUrl = new Uri("https://thumbnail-2.com")
                    }
                },
                {
                    new Photo()
                    {
                        AlbumId = 2,
                        Id = 3,
                        Title = "Test Photo 3",
                        Url = new Uri("https://photo-3.com"),
                        ThumbnailUrl = new Uri("https://thumbnail-3.com")
                    }
                },
                {
                    new Photo()
                    {
                        AlbumId = 2,
                        Id = 4,
                        Title = "Test Photo 4",
                        Url = new Uri("https://photo-4.com"),
                        ThumbnailUrl = new Uri("https://thumbnail-4.com")
                    }
                }
            };

            return photos;
        }

        public static List<Photo> GetTestPhotos(int id)
        {
            var photos = new List<Photo>();
            photos = new List<Photo>()
            {
                {
                    new Photo()
                    {
                        AlbumId = id,
                        Id = 1,
                        Title = "Test Photo 1",
                        Url = new Uri("https://photo-1.com"),
                        ThumbnailUrl = new Uri("https://thumbnail-1.com")
                    }
                },
                {
                    new Photo()
                    {
                        AlbumId = id,
                        Id = 2,
                        Title = "Test Photo 2",
                        Url = new Uri("https://photo-2.com"),
                        ThumbnailUrl = new Uri("https://thumbnail-2.com")
                    }
                }
            };

            return photos;
        }

        private static Dictionary<string, StringValues> CreateDictionary(string key, string value)
        {
            var qs = new Dictionary<string, StringValues>
            {
                { key, value }
            };
            return qs;
        }

        public static DefaultHttpRequest CreateHttpRequest(string queryStringKey, string queryStringValue)
        {
            var request = new DefaultHttpRequest(new DefaultHttpContext())
            {
                Query = new QueryCollection(CreateDictionary(queryStringKey, queryStringValue))
            };
            return request;
        }

        public static DefaultHttpRequest CreateHttpRequest()
        {
            var request = new DefaultHttpRequest(new DefaultHttpContext());

            return request;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;

            if (type == LoggerTypes.List)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            }

            return logger;
        }
    }
}
