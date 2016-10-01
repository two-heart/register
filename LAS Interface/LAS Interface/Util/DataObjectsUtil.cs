using System.Collections.Generic;
using System.Linq;
using LAS_Interface.PublicStuff;
using LAS_Interface.Types;

namespace LAS_Interface.Util
{
    public class DataObjectsUtil
    {
        public static List<DataObject> GetnEmptyDataObjects(int n)
        {
            var fin = new List<DataObject>();
            for (; n > 0; n--)
                fin.Add(new DataObject("", "", "", ""));
            return fin;
        }

        public static WeekDataObjects GetEmptyWeekDataObjects(int entriesPerDay) => new WeekDataObjects(
            GetnEmptyDataObjects(entriesPerDay),
            GetnEmptyDataObjects(entriesPerDay),
            GetnEmptyDataObjects(entriesPerDay),
            GetnEmptyDataObjects(entriesPerDay),
            GetnEmptyDataObjects(entriesPerDay));

        public static List<WeekDataObjects> GetEmptyAllDataObjects(int entriesPerDay, int count)
        {
            var that = new List<WeekDataObjects>();
            for (; count > 0; count--)
                that.Add(GetEmptyWeekDataObjects(entriesPerDay));
            return that;
        }

        public static List<ClassRegister> GenerateAllEmptyClassDataObjectses(List<string> classes)
            =>
            classes.Select(
                    c =>
                        new ClassRegister(
                            GetEmptyAllDataObjects(GeneralPublicStuff.EntriesPerDay, GeneralPublicStuff.WeeksPerYear), c))
                .ToList();
    }
}