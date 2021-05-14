using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace DellTest.Models
{
    public class Entity<T>
    {
        [JsonProperty("id")]
        public T Id { get; set; }
    }
}

