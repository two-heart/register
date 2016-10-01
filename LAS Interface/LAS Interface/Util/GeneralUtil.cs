using System.Collections.Generic;

namespace LAS_Interface.Util
{
    public class GeneralUtil
    {
        public static List<string> GetClasses() //TODO
        {
            var fin = new List<string>();
            for (var i = 1; i < 13; i++)
                for (var j = 0; j < 4; j++)
                    fin.Add(i.ToString() + (char) (j + 'a'));
            return fin;
        }

        public static string ReturnFirstOrException(List<string> list, string exception)
            => list.Count > 0 ? list[0] : exception;
    }
}