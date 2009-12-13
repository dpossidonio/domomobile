using System.Collections.Generic;
using DomoMobile.Common;

namespace Main.ViewModels
{
    public class HouseSelectionItem : AggregatorSelectionItems
    {
        public HouseSelectionItem(Context context, IServiceManager service, AggregatorSelectionItems parent)
            : base(context, service, parent) { }

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
                items.Add(new FloorSelectionItem(CurrentContext, ServiceManager, floor, this));
            }
            return items;
        }
    }
}