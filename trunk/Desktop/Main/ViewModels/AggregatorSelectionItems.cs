using System;
using System.Collections.Generic;

namespace Main.ViewModels
{
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
}