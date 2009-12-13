using System;
using DomoMobile.Common;

namespace Main.ViewModels
{
    public class PropertySelectionItem : SelectionItem
    {
        public PropertySelectionItem(Context context, IServiceManager service, Property property, AggregatorSelectionItems parent)
            : base(context, service, parent)
        {
            Property = property;

            var action = new DelegateCommand(
                delegate()
                    {
                        CurrentContext.CurrentPropertyType = Property.Type;

                        var window = new PropertyTypePopup(PropertyTypeUserControlFactory.GetUserControl(context, service, Property));
                        window.Show();
                    });
            ActionCommand = action;
        }
        public Property Property { get; private set; }
    }
}