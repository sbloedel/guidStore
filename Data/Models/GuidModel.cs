using System;
using System.ComponentModel.DataAnnotations;

namespace guidStore.Data.Models {
    public class GuidModel
    {
        [Key]
        public string guid { get; set; }
        public int expire { get; set; }
        public string user { get; set; }
    }
}
