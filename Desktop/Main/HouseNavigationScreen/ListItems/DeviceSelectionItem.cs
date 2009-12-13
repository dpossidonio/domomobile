using System.Collections.Generic;
using DomoMobile.Common;

namespace Main.ViewModels
{
    public class DeviceSelectionItem : AggregatorSelectionItems
    {
        public DeviceSelectionItem(Context context, IServiceManager service, Device device, AggregatorSelectionItems parent)
            : base(context, service, parent)
        {
            Device = device;
        }

        public Device Device { get; private set; }

        public override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var property in Device.Properties)
            {
                items.Add(new PropertySelectionItem(CurrentContext, ServiceManager, property, this));
            }
            return items;
        }
    }
}