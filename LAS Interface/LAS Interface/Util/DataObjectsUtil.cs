using System.Collections.Generic;
using LAS_Interface.Types;

namespace LAS_Interface.Util
{
    public class DataObjectsUtil
    {
        public static List<DataObject> GetnEmptyDataObjects (int n)
        {
            var fin = new List<DataObject>();
            while (n > 0)
            {
                fin.Add(new DataObject("", "", "", ""));
                n--;
            }
            return fin;
        }
    }
}