using System.Collections.Generic;
using DomoMobile.Common;

namespace Main.ViewModels
{
    public class FloorSelectionItem : AggregatorSelectionItems
    {
        public FloorSelectionItem(Context context, IServiceManager service, Floor floor, AggregatorSelectionItems parent)
            : base(context, service, parent)
        {
            Floor = floor;
        }

        public Floor Floor { get; private set; }

        public override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var division in Floor.Divisions)
            {
                items.Add(new DivisionSelectionItem(CurrentContext, ServiceManager, division, this));
            }
            return items;
        }
    }
}