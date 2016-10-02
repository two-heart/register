using System.Collections.Generic;
using LAS_Interface.Types;

namespace LAS_Interface.Util
{
    public class GeneralUtil
    {
        /// <summary>
        /// Generates some classes (1a-12d)
        /// </summary>
        /// <returns>the classes</returns>
        public static List<string> GetClasses ()
        {
            var fin = new List<string> ();
            for (var i = 1; i < 13; i++)
                for (var j = 0; j < 4; j++)
                    fin.Add (i.ToString () + (char) (j + 'a'));
            return fin;
        }

        /// <summary>
        /// Returns the first occurence in the list or the exceptional string - does NOT throw an exception!
        /// </summary>
        /// <returns>the string</returns>
        public static string ReturnFirstOrException (List<string> list, string exception)
                    => list.Count > 0 ? list[0] : exception;

        public static List<WeekDataObjects> ReturnWithAddedRange(List<WeekDataObjects> list, IEnumerable<WeekDataObjects> range)
        {
            list.AddRange(range);
            return list;
        }
    }
}