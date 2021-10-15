using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PhoneShop.Models;

namespace PhoneShop.ViewModels
{
    public class CommentPageViewModel
    {
        [JsonPropertyName("comments")]
        public IEnumerable<Comment> Comments { get; set; }

        [JsonPropertyName("maxPage")]
        public int MaxPage { get; set; }

        [JsonPropertyName("curPage")]
        public int CurPage { get; set; }
    }
}
