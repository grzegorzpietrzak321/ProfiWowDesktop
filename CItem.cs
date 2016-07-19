using System.Collections.Generic;

namespace profiwowdektop
{
    class CItem : IfaceItem
    {
        public string name;
        public string icon_src;
        public int quantity;
        public IList<IfaceItem> CItems;

       
        public void AddComponent(IfaceItem item)
        {
            CItems.Add(item);
        }
    }
}
