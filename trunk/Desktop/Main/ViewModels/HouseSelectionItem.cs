using System.Collections.Generic;
using DomoMobile.Common;

namespace Main.ViewModels
{
    public class HouseSelectionItem : AggregatorSelectionItems
    {
        public HouseSelectionItem(Context context, AggregatorSelectionItems parent)
            : base(context, parent) { }

        private House _house;
        public House House
        {
            get { return _house; }
            set { _house = value; Notify("House"); }
        }

        public override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var floor in House.Floors)
            {
                items.Add(new FloorSelectionItem(CurrentContext, floor, this));
            }
            return items;
        }
    }
}