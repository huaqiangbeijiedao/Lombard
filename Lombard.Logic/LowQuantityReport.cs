using System;
using System.Collections.Generic;
using System.Text;

namespace Lombard.Logic
{
    public class LowQuantityReport
    {
        public bool CheckProductQuantity(Item item)
        {
            if(item.Quantity < 5)
            {
                return false;
            }

            return true;
        }
    }
}
