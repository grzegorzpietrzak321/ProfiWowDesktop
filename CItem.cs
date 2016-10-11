using System.Collections.Generic;

namespace profiwowdektop
{
    class CItem : IFaceItem
    {
        public string Name;
        public string IconSrc;
        public int Quantity;
        public IList<IFaceItem> CItems;


        public void AddComponent(IFaceItem item)
        {
            CItems.Add(item);
        }
    }
}
