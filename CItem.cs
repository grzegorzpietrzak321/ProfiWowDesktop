using System.Collections.Generic;

namespace profiwowdektop
{
    class CItem : IFaceItem
    {
        public string Name;
        public string IconSrc;
        public int Quantity;
        private readonly IList<IFaceItem> _cItems;

        public CItem(IList<IFaceItem> cItems)
        {
            _cItems = cItems;
        }


        public void AddComponent(IFaceItem item)
        {
            _cItems.Add(item);
        }
    }
}
