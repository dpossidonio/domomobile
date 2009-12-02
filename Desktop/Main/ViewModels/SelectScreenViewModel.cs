using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using DomoMobile.Common;
using System.Windows.Input;

namespace Main.ViewModels
{
    public class SelectScreenViewModel : BaseViewModel
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                Notify("Title");
            }
        }

        private ObservableCollection<object> _items;
        public ObservableCollection<object> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                Notify("Items");
            }
        }
    }

    public abstract class SelectionItem : BaseViewModel
    {

    }

    public abstract class AggregatorSelectionItems : SelectionItem
    {
        public event Action<IEnumerable<SelectionItem>> ItemClicked;

        private void NotifyItemClicked(IEnumerable<SelectionItem> items)
        {
            if (ItemClicked != null)
                ItemClicked(items);
        }

        private ICommand _actionCommand;
        public ICommand ActionCommand
        {
            get { return _actionCommand; }
            set { _actionCommand = value; Notify("ActionCommand"); }
        }

        public AggregatorSelectionItems()
        {
            var call = new Action(delegate()
            {
                var children = getChildren();
                NotifyItemClicked(children);
            });
            ActionCommand = new DelegateCommand(call);

        }
        protected abstract IEnumerable<SelectionItem> getChildren();
    }

    public class HouseSelectionItem : AggregatorSelectionItems
    {
        public HouseSelectionItem() { }

        private House _house;
        public House House
        {
            get
            {
                return _house;
            }
            set
            {
                _house = value;
                Notify("House");
            }
        }

        protected override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var floor in House.Floors)
            {
                items.Add(new FloorSelectionItem(floor));
            }
            return items;
        }
    }

    public class FloorSelectionItem : AggregatorSelectionItems
    {
        public FloorSelectionItem(Floor floor)
        {
            Floor = floor;
        }

        public Floor Floor { get; private set; }

        protected override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var division in Floor.Divisions)
            {
                items.Add(new DivisionSelectionItem(division));
            }
            return items;
        }
    }

    public class DivisionSelectionItem : AggregatorSelectionItems
    {
        public DivisionSelectionItem(Division division)
        {
            Division = division;
        }

        public Division Division { get; private set; }

        protected override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var device in Division.Devices)
            {
                items.Add(new DeviceSelectionItem(device));
            }
            return items;
        }
    }

    public class DeviceSelectionItem : AggregatorSelectionItems
    {
        public DeviceSelectionItem(Device device)
        {
            Device = device;
        }

        public Device Device { get; private set; }

        protected override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var property in Device.Properties)
            {
                items.Add(new PropertySelectionItem(property));
            }
            return items;
        }
    }

    public class PropertySelectionItem : SelectionItem
    {
        public PropertySelectionItem(Property property)
        {
            Property = property;
        }
        public Property Property { get; private set; }
    }
}
