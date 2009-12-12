using System.Collections.Generic;
using DomoMobile.Common;

namespace Main.ViewModels
{
    public class DeviceSelectionItem : AggregatorSelectionItems
    {
        public DeviceSelectionItem(Context context, Device device, AggregatorSelectionItems parent)
            : base(context, parent)
        {
            Device = device;
        }

        public Device Device { get; private set; }

        public override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var property in Device.Properties)
            {
                items.Add(new PropertySelectionItem(CurrentContext, property, this));
            }
            return items;
        }
    }
}