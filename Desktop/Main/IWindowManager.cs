using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main
{
    public interface IWindowManager
    {
        void ChangeScreen<T>() 
            where T: Screen;
    }
}
