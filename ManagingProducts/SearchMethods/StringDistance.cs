using System;
using System.Collections.Generic;
using System.Text;

namespace ManagingProducts.SearchMethods
{
    public interface StringDistance
    {
        float GetDistance(string s1, string s2);

    }
}
