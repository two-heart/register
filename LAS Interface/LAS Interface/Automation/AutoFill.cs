using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Navigation;
using LAS_Interface.Types;

namespace LAS_Interface.Automation
{
    public class AutoFill
    {
        public static List<ClassRegister> GetFilledRegissters(List<ClassRegister> allRegisters,
            List<TimeTable> allTimeTables) => (from classRegister in allRegisters
            let timeTable = allTimeTables.Where(tT => tT.Class.Equals(classRegister.Class)).ToList().FirstOrDefault()
            select new ClassRegister((from oldWeekDataObject in classRegister.WeekDataObjects
                let dataObjectMonday =
                oldWeekDataObject.Monday.Select(
                    (o, index) =>
                        string.IsNullOrEmpty(o.Subject) && index < timeTable.TimeTableRows.Count
                            ? new DataObject(o.Teacher, timeTable.TimeTableRows[index].Monday, o.Content, o.Remarks)
                            : o).ToList()
                let dataObjectTuesday =
                oldWeekDataObject.Tuesday.Select(
                    (o, index) =>
                        string.IsNullOrEmpty(o.Subject) && index < timeTable.TimeTableRows.Count
                            ? new DataObject(o.Teacher, timeTable.TimeTableRows[index].Tuesday, o.Content, o.Remarks)
                            : o).ToList()
                let dataObjectWednesday =
                oldWeekDataObject.Wednesday.Select(
                    (o, index) =>
                        string.IsNullOrEmpty(o.Subject) && index < timeTable.TimeTableRows.Count
                            ? new DataObject(o.Teacher, timeTable.TimeTableRows[index].Wednesday, o.Content, o.Remarks)
                            : o).ToList()
                let dataObjectThursday =
                oldWeekDataObject.Thursday.Select(
                    (o, index) =>
                        string.IsNullOrEmpty(o.Subject) && index < timeTable.TimeTableRows.Count
                            ? new DataObject(o.Teacher, timeTable.TimeTableRows[index].Thursday, o.Content, o.Remarks)
                            : o).ToList()
                let dataObjectFriday =
                oldWeekDataObject.Friday.Select(
                    (o, index) =>
                        string.IsNullOrEmpty(o.Subject) && index < timeTable.TimeTableRows.Count
                            ? new DataObject(o.Teacher, timeTable.TimeTableRows[index].Friday, o.Content, o.Remarks)
                            : o).ToList()
                select
                new WeekDataObjects(dataObjectMonday, dataObjectTuesday, dataObjectWednesday, dataObjectThursday,
                    dataObjectFriday)).ToList(), classRegister.Class)).ToList();
    }
}