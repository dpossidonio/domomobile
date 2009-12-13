using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Main.ViewModels
{
    public class SelectScreenViewModel : Screen
    {
        public SelectScreenViewModel(Context context, IServiceManager service, IWindowManager window)
            : base(context, service, window)
        {
            Items = new ObservableCollection<SelectionItem>();
            var house = new HouseSelectionItem(CurrentContext, ServiceManager, null)
                {
                    House = CurrentContext.CurrentHouse
                }; 

            SetContent(house.getChildren(), house);

            var goUpAction = new DelegateCommand(new Action(delegate()
            {
                if (CurrentItem == null || CurrentItem.Parent == null) return;
                SetContent(CurrentItem.Parent.getChildren(), CurrentItem.Parent);
            }));
            GoUpCommand = goUpAction;

            var housesAction = new Action(
                                delegate()
                                    {
                                        WindowManager.ChangeScreen<HouseSelectionViewModel>();
                                    });
            HousesCommand = new DelegateCommand(housesAction);
        }

        private SelectionItem CurrentItem { get; set; }

        private ICommand _goUpCommand;
        public ICommand GoUpCommand
        {
            get { return _goUpCommand; }
            set { _goUpCommand = value; Notify("GoUpCommand"); }
        }

        private ICommand _housesComamnd;
        public ICommand HousesCommand
        {
            get { return _housesComamnd; }
            set { _housesComamnd = value; Notify("HousesCommand"); }
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
            if (parent is HouseSelectionItem)
                CurrentContext.CurrentHouse = (parent as HouseSelectionItem).House;
            if (parent is DeviceSelectionItem)
                CurrentContext.CurrentDevice = (parent as DeviceSelectionItem).Device;

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
}
