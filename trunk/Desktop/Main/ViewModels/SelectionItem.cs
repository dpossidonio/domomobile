﻿using System.Windows.Input;

namespace Main.ViewModels
{
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
}