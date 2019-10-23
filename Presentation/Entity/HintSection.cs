using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autocomplete.Entity
{
    public class HintSection
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }

        public HintSection(string title)
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.UtcNow;
            Title = title;
        }
    }
}
