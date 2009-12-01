using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomoMobile.Common
{
    /// <summary>
    /// This class represents User Favorites
    ///    - Devices
    ///    - Division
    ///    - Floor
    ///    - Service
    /// </summary>
    public class Favorite
    {
        /// <summary>
        /// Type of Favorite
        /// </summary>
        public string TypeOfFavorite { get; set; }
        /// <summary>
        /// Favorite ID
        /// </summary>
        public int FavoriteID { get; set; }

    }
}
