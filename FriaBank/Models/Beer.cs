using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FriaBank.Models
{
    public partial class Beer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("first_brewed")]
        public string FirstBrewed { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        public ImageSource Image { get; set; }

        [JsonProperty("abv")]
        public double Abv { get; set; }

        [JsonProperty("ibu")]
        public long Ibu { get; set; }

        [JsonProperty("target_fg")]
        public long TargetFg { get; set; }

        [JsonProperty("target_og")]
        public long TargetOg { get; set; }

        [JsonProperty("ebc")]
        public long Ebc { get; set; }

        [JsonProperty("srm")]
        public long Srm { get; set; }

        [JsonProperty("ph")]
        public double Ph { get; set; }

        [JsonProperty("attenuation_level")]
        public long AttenuationLevel { get; set; }

        [JsonProperty("method")]
        public Method Method { get; set; }
    }

    public partial class Method
    {
        [JsonProperty("fermentation")]
        public Fermentation Fermentation { get; set; }
    }

    public partial class Fermentation
    {
        [JsonProperty("temp")]
        public Temp Temp { get; set; }
    }

    public partial class Temp
    {
        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
