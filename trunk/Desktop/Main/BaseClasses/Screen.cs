using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Main.ViewModels;

namespace Main
{
    public abstract class Screen: ContextualizedViewModel
    {
        public virtual IWindowManager WindowManager { get; protected set; }

        public Screen(Context context, IServiceManager service, IWindowManager window)
        :base(context, service)
        {
            WindowManager = window;
        }
    }
}
