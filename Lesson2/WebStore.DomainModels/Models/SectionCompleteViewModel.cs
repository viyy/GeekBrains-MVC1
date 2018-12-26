using System.Collections.Generic;

namespace WebStore.DomainModels.Models
{
    public class SectionCompleteViewModel
    {
        public IEnumerable<SectionViewModel> Sections { get; set; }
        public int? CurrentParentSectionId { get; set; }
        public int? CurrentSectionId { get; set; }
    }

}