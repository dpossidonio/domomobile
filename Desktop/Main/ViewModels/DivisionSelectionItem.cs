using System.Collections.Generic;
using DomoMobile.Common;

namespace Main.ViewModels
{
    public class DivisionSelectionItem : AggregatorSelectionItems
    {
        public DivisionSelectionItem(Context context, Division division, AggregatorSelectionItems parent)
            : base(context, parent)
        {
            Division = division;
        }

        public Division Division { get; private set; }

        public override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var device in Division.Devices)
            {
                items.Add(new DeviceSelectionItem(CurrentContext, device, this));
            }
            return items;
        }
    }
}