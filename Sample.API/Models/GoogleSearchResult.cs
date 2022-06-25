using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.API.Models
{
    public class GoogleSearchResult
    {
        public string[] Answers  { get; set; } 
        public GoogleSearchResults[] Results { get; set; }

        public GoogleImageResults[] ImageResults { get; set; }

        public int Total { get; set; }
    }

    public class GoogleSearchResults
    {
        public string Title { get; set; }
        public string Link { get; set; }

        public string Description { get; set; }

        public (string text, string href)[] AdditionalLinks { get; set; }

        public (string domain, string span)[] Cite { get; set; }
    }

    public class GoogleImageResults
    {
        public (GoogleImage, GoogleLink link)[] Image { get; set; }
    }

    public class GoogleImage
    {
        public string Alt { get; set; }
        public string Src { get; set; }
    }

    public class GoogleLink
    {
        public string Domain { get; set; }
        public string Href { get; set; }
        public string Title { get; set; }
    }
}
