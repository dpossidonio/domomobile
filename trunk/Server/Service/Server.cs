using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomoMobile.Common;

namespace Service
{
    partial class DomoService : IDomoService
    {
        IList<House> Houses = new List<House>();
        House House = new House();


        private void InicializeComponent(){
            
        
        }
    }
}
