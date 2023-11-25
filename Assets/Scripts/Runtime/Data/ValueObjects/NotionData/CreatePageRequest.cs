using System;
using Newtonsoft.Json;

namespace Runtime.Data.ValueObjects.NotionData
{
    [Serializable]
    public class CreatePageRequest
    {
        [JsonProperty("parent")] public Parent Parent;

        //[JsonProperty("icon")] public Icon Icon;

        [JsonProperty("cover")] public Cover Cover;

        [JsonProperty("properties")] public Properties Properties;

        [JsonProperty("children")] public Child[] Children;
    }

    [Serializable]
    public class Child
    {
        [JsonProperty("object")] public string Object;

        [JsonProperty("type")] public string Type;

        [JsonProperty("heading_2", NullValueHandling = NullValueHandling.Ignore)]
        public Heading2 Heading2;

        [JsonProperty("paragraph", NullValueHandling = NullValueHandling.Ignore)]
        public Paragraph Paragraph;
    }

    [Serializable]
    public class Heading2
    {
        [JsonProperty("rich_text", NullValueHandling = NullValueHandling.Ignore)]
        public Title[] RichText;
    }

    [Serializable]
    public class Title
    {
        [JsonProperty("type")] public string Type;

        [JsonProperty("text")] public TitleText Text;
    }

    [Serializable]
    public class TitleText
    {
        [JsonProperty("content")] public string Content;
    }

    [Serializable]
    public class Paragraph
    {
        [JsonProperty("rich_text", NullValueHandling = NullValueHandling.Ignore)]
        public RichText[] RichText;
    }

    [Serializable]
    public class RichText
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type;

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public PurpleText Text;
    }

    [Serializable]
    public class PurpleText
    {
        [JsonProperty("content")] public string Content;

        [JsonProperty("link")] public External Link;
    }

    [Serializable]
    public class External
    {
        [JsonProperty("url")] public string Url;
    }

    [Serializable]
    public class Cover
    {
        [JsonProperty("type")] public string Type;

        [JsonProperty("external")] public External External;
    }

    [Serializable]
    public class Icon
    {
        [JsonProperty("type")] public string Type;

        [JsonProperty("emoji")] public string Emoji;
    }

    [Serializable]
    public class Parent
    {
        [JsonProperty("database_id")] public string DatabaseId;
    }

    [Serializable]
    public class Properties
    {
        [JsonProperty("Name")] public Name Name;
    }

    [Serializable]
    public class Name
    {
        [JsonProperty("title")] public Title[] Title;
    }
}