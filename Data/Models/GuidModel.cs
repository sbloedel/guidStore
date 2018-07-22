using System;

namespace guidStore.Controllers {
    public class GuidModel
    {
        public string guid { get; set; }
        public int expire { get; set; }
        public string user { get; set; }
    }
}
