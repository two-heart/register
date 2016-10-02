using System;
using System.Collections.Generic;
using System.Linq;
using LAS_Interface.PublicStuff;
using LAS_Interface.Types;

namespace LAS_Interface.Util
{
    public class DataObjectsUtil
    {
        /// <summary>
        /// Generates n empty Data objects - so it generates the content for one day in the register
        /// </summary>
        /// <returns>data objects</returns>
        public static List<DataObject> GetnEmptyDataObjects(int n)
        {
            var fin = new List<DataObject>();
            for (; n > 0; n--)
                fin.Add(new DataObject("", "", "", ""));
            return fin;
        }

        /// <summary>
        /// Generates one empty weekdata object - so it generates for every weekday one empty data object
        /// </summary>
        /// <returns>weekdata object</returns>
        public static WeekDataObjects GetEmptyWeekDataObjects(int entriesPerDay, string week) => new WeekDataObjects(
            GetnEmptyDataObjects(entriesPerDay),
            GetnEmptyDataObjects(entriesPerDay),
            GetnEmptyDataObjects(entriesPerDay),
            GetnEmptyDataObjects(entriesPerDay),
            GetnEmptyDataObjects(entriesPerDay), week);

        /// <summary>
        /// Generates all empty weekdata objects for a specific class. So it generates for every week one weekdata object
        /// </summary>
        /// <returns>weekdata objects</returns>
        public static List<WeekDataObjects> GetEmptyAllDataObjects(int entriesPerDay, List<string> weekList)
            => weekList.Select(week => GetEmptyWeekDataObjects(entriesPerDay, week)).ToList();

        /// <summary>
        /// Generates for every given class an empty classdata object - so it generates literally everything with no content.
        /// </summary>
        /// <returns>the classdata objects</returns>
        /*public static List<ClassRegister> GenerateAllEmptyClassDataObjectses(List<string> classes, List<string> weekList)
            =>
            classes.Select(
                    c =>
                        new ClassRegister(
                            GetEmptyAllDataObjects(Resources.EntriesPerDay, weekList), c))
                .ToList();

        public static List<ClassRegister> GenerateLeftEmptyClassDataObjectses(List<string> classes,
            List<string> weekList, List<ClassRegister> oldClassRegisters)
        {
            var fin = new List<ClassRegister>();
            foreach (var c in classes)
            {
                if (oldClassRegisters.Any(register => register.Class.Equals(c)))
                {
                    fin.Add(oldClassRegisters.FirstOrDefault(register => register.Class.Equals(c)));
                    continue;
                }
                fin.Add(G);
            }
            return null;
        }*/
    }
}