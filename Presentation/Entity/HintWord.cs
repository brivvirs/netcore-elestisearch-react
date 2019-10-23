using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autocomplete.Entity
{
    public class HintWord
    {
        public string Id { get; set; }
        public HintSection Section { get; set; }
        public string Word { get; set; }
        public string SectionId { get; set; }

        public HintWord(HintSection Section, string title)
        {
            Id = Guid.NewGuid().ToString();
            Word = title;
            this.Section = Section;
            this.SectionId = Section.Id;
        }
    }
}
