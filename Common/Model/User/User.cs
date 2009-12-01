using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomoMobile.Common
{
    /// <summary>
    /// This class represents a User 
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Identication
        /// </summary>
        /// 
        public int UserID { get; set; }
        /// <summary>
        /// Level of Acess
        /// </summary>
        public int AcessLevel { get; set; }

        /// <summary>
        /// User 
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// List of Favorites
        /// </summary>
        public IList<Favorite> Favorites { get; set; }

    }

     
}
