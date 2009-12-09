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
    public class ContextualizedViewModel : BaseViewModel
    {
        protected Context CurrentContext { get; set; }

        public ContextualizedViewModel(Context context)
        {
            CurrentContext = context;
        }
    }
    
    public class SelectScreenViewModel : ContextualizedViewModel
    {
        public SelectScreenViewModel(Context context)
            : base(context)
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
                    if (i is HouseSelectionItem)
                        CurrentContext.CurrentHouse = (i as HouseSelectionItem).House;
                    if (i is DeviceSelectionItem)
                        CurrentContext.CurrentDevice = (i as DeviceSelectionItem).Device;
                    i.ItemClicked += new Action<IEnumerable<SelectionItem>, AggregatorSelectionItems>(i_ItemClicked);
                }
            }
        }

        void i_ItemClicked(IEnumerable<SelectionItem> obj, AggregatorSelectionItems parent)
        {
            SetContent(obj, parent);
        }
    }

    public abstract class SelectionItem : ContextualizedViewModel
    {
        public AggregatorSelectionItems Parent { get; set; }

        private ICommand _actionCommand;
        public ICommand ActionCommand
        {
            get { return _actionCommand; }
            set { _actionCommand = value; Notify("ActionCommand"); }
        }

        public SelectionItem(Context context, AggregatorSelectionItems parent)
            : base(context)
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

        public AggregatorSelectionItems(Context context, AggregatorSelectionItems parent)
            : base(context, parent)
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

    public class FloorSelectionItem : AggregatorSelectionItems
    {
        public FloorSelectionItem(Context context, Floor floor, AggregatorSelectionItems parent)
            : base(context, parent)
        {
            Floor = floor;
        }

        public Floor Floor { get; private set; }

        public override IEnumerable<SelectionItem> getChildren()
        {
            IList<SelectionItem> items = new List<SelectionItem>();
            foreach (var division in Floor.Divisions)
            {
                items.Add(new DivisionSelectionItem(CurrentContext, division, this));
            }
            return items;
        }
    }

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

    public class PropertySelectionItem : SelectionItem
    {
        public PropertySelectionItem(Context context, Property property, AggregatorSelectionItems parent)
            : base(context, parent)
        {
            Property = property;

            var action = new DelegateCommand(new Action(delegate()
            {
                var window = new PropertyTypePopup(PropertyTypeUserControlFactory.GetUserControl(context, Property));
                window.Show();
            }));
            ActionCommand = action;
        }
        public Property Property { get; private set; }
    }

    public static class PropertyTypeUserControlFactory
    {
        public static UserControl GetUserControl(Context context, Property prop)
        {
            if (prop.Type.TypeOfValue == PropertyType.TypeOfValues.ENUM)
            {
                return new EnumPropertyTypeUserControl(context, prop);
            }
            else if (prop.Type.TypeOfValue == PropertyType.TypeOfValues.SCALAR)
            {
                return new ScalarPropertyTypeUserControl(context, prop);
            }
            else if (prop.Type.TypeOfValue == PropertyType.TypeOfValues.VECTOR)
            {
                return new VectorPropertyTypeUserControl(context, prop);
            }
            else
            {
                throw new Exception("PropertyTypeNotSuported by PropertyTypeUserControlFactory");
            }
        }
    }
}
