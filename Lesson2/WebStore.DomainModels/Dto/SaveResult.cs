using System.Collections.Generic;

namespace WebStore.DomainModels.Dto
{
    public class SaveResult
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
