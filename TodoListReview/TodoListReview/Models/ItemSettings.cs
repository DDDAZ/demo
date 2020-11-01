using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoListReview.Models
{
    public class ItemSettings : IItemSettings
    {
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
        public string Address { get; set; }
    }

    public interface IItemSettings
    {
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
        public string Address { get; set; }
    }
}
