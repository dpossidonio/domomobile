using System.Collections.Generic;
using DomoMobile.Common;

namespace Main.ViewModels
{
    public class DivisionSelectionItem : AggregatorSelectionItems
    {
        public DivisionSelectionItem(Context context, IServiceManager service, Division division, AggregatorSelectionItems parent)
            : base(context, service, parent)
        {
            Division = division;
        }

        public Division Division { get; private set; }

        public override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var device in Division.Devices)
            {
                items.Add(new DeviceSelectionItem(CurrentContext, ServiceManager, device, this));
            }
            return items;
        }
    }
}