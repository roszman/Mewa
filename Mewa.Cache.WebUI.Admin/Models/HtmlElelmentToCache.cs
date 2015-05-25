using System.ComponentModel.DataAnnotations;

namespace Mewa.Cache.WebUI.Admin.Models
{
    public class HtmlElelmentToCache
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public string TagName { get; set; }
        [Required]
        public string TagAttributeName { get; set; }
        [Required]
        public string TagAttributeValue { get; set; }
    }
}