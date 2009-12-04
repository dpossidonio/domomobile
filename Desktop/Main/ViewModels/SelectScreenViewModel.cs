using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using DomoMobile.Common;
using System.Windows.Input;
using System.Windows.Controls;
using Main.UserControls;

namespace Main.ViewModels
{
    public class SelectScreenViewModel : BaseViewModel
    {
        public SelectScreenViewModel()
        {
            var goUpAction = new DelegateCommand(new Action(delegate()
            {
                if (CurrentItem == null || CurrentItem.Parent == null) return;
                SetContent(CurrentItem.Parent.getChildren(), CurrentItem.Parent);
            }));
            GoUpCommand = goUpAction;
        }

        private SelectionItem CurrentItem { get; set; }

        private ICommand _goUpComamnd;
        public ICommand GoUpCommand
        {
            get { return _goUpComamnd; }
            set { _goUpComamnd = value; Notify("GoUpCommand"); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; Notify("Title"); }
        }

        private ObservableCollection<SelectionItem> _items;
        public ObservableCollection<SelectionItem> Items
        {
            get { return _items; }
            set { _items = value; Notify("Items"); }
        }

        public void SetContent(IEnumerable<SelectionItem> items, AggregatorSelectionItems parent)
        {
            CurrentItem = parent;

            foreach (var item in Items)
            {
                var i = item as AggregatorSelectionItems;
                if (i != null)
                {
                    i.ItemClicked -= i_ItemClicked;
                }
            }

            Items.Clear();

            foreach (var item in items)
            {
                Items.Add(item);

                var i = item as AggregatorSelectionItems;
                if (i != null)
                {
                    i.ItemClicked += new Action<IEnumerable<SelectionItem>, AggregatorSelectionItems>(i_ItemClicked);
                }
            }
        }

        void i_ItemClicked(IEnumerable<SelectionItem> obj, AggregatorSelectionItems parent)
        {
            SetContent(obj, parent);
        }
    }

    public abstract class SelectionItem : BaseViewModel
    {
        public AggregatorSelectionItems Parent { get; set; }

        private ICommand _actionCommand;
        public ICommand ActionCommand
        {
            get { return _actionCommand; }
            set { _actionCommand = value; Notify("ActionCommand"); }
        }

        public SelectionItem(AggregatorSelectionItems parent)
        {
            Parent = parent;
        }
    }

    public abstract class AggregatorSelectionItems : SelectionItem
    {
        public event Action<IEnumerable<SelectionItem>, AggregatorSelectionItems> ItemClicked;

        private void NotifyItemClicked(IEnumerable<SelectionItem> items, AggregatorSelectionItems parent)
        {
            if (ItemClicked != null)
                ItemClicked(items, parent);
        }

        public AggregatorSelectionItems(AggregatorSelectionItems parent)
            : base(parent)
        {
            var call = new Action(delegate()
            {
                var children = getChildren();
                NotifyItemClicked(children, this);
            });
            ActionCommand = new DelegateCommand(call);

        }

        public abstract IEnumerable<SelectionItem> getChildren();
    }

    public class HouseSelectionItem : AggregatorSelectionItems
    {
        public HouseSelectionItem(AggregatorSelectionItems parent)
            : base(parent) { }

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
                items.Add(new FloorSelectionItem(floor, this));
            }
            return items;
        }
    }

    public class FloorSelectionItem : AggregatorSelectionItems
    {
        public FloorSelectionItem(Floor floor, AggregatorSelectionItems parent)
            : base(parent)
        {
            Floor = floor;
        }

        public Floor Floor { get; private set; }

        public override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var division in Floor.Divisions)
            {
                items.Add(new DivisionSelectionItem(division, this));
            }
            return items;
        }
    }

    public class DivisionSelectionItem : AggregatorSelectionItems
    {
        public DivisionSelectionItem(Division division, AggregatorSelectionItems parent)
            : base(parent)
        {
            Division = division;
        }

        public Division Division { get; private set; }

        public override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var device in Division.Devices)
            {
                items.Add(new DeviceSelectionItem(device, this));
            }
            return items;
        }
    }

    public class DeviceSelectionItem : AggregatorSelectionItems
    {
        public DeviceSelectionItem(Device device, AggregatorSelectionItems parent)
            : base(parent)
        {
            Device = device;
        }

        public Device Device { get; private set; }

        public override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var property in Device.Properties)
            {
                items.Add(new PropertySelectionItem(property, this));
            }
            return items;
        }
    }

    public class PropertySelectionItem : SelectionItem
    {
        public PropertySelectionItem(Property property, AggregatorSelectionItems parent)
            : base(parent)
        {
            Property = property;

            var action = new DelegateCommand(new Action(delegate()
            {
                var window = new PropertyTypePopup(PropertyTypeUserControlFactory.GetUserControl(Property));
                window.Show();
            }));
            ActionCommand = action;
        }
        public Property Property { get; private set; }
    }

    public static class PropertyTypeUserControlFactory
    {
        public static UserControl GetUserControl(Property prop)
        {
            if (prop.Type.TypeOfValue == PropertyType.TypeOfValues.ENUM)
            {
                return new EnumPropertyTypeUserControl(prop);
            }
            else if (prop.Type.TypeOfValue == PropertyType.TypeOfValues.SCALAR)
            {
                return new ScalarPropertyTypeUserControl(prop);
            }
            else if (prop.Type.TypeOfValue == PropertyType.TypeOfValues.VECTOR)
            {
                return new VectorPropertyTypeUserControl(prop);
            }
            else
            {
                throw new Exception("PropertyTypeNotSuported by PropertyTypeUserControlFactory");
            }
        }
    }
}
