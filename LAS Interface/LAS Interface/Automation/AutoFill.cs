using System;
using System.Collections.Generic;
using System.Linq;
using LAS_Interface.Types;
using LAS_Interface.Types.Humans.Teacher;
using LAS_Interface.Util;

namespace LAS_Interface.Automation
{
    public class AutoFill
    {
        /// <summary>
        /// Gets all registers totally filled, with the information from the timetable and lists
        /// </summary>
        /// <returns>All filled Registers</returns>
        public static List<ClassRegister> GetFilledRegisters(List<ClassRegister> allRegisters,
            List<TimeTable> allTimeTables, List<Teacher> allTeachers) => (from classRegister in allRegisters
            let timeTable = allTimeTables.Where(tT => tT.Class.Equals(classRegister.Class)).ToList().FirstOrDefault()
            let teachers =
            allTeachers.Where(
                teacher =>
                    teacher.TeacherProperties.Where(properties => properties.Class.Equals(classRegister.Class))
                        .ToList()
                        .Count > 0)
            select new ClassRegister((from oldWeekDataObject in classRegister.WeekDataObjects
                let dataObjectMonday =
                GetDataObjectToWeekDay(DayOfWeek.Monday, oldWeekDataObject.Monday, timeTable, teachers)
                let dataObjectTuesday =
                GetDataObjectToWeekDay(DayOfWeek.Tuesday, oldWeekDataObject.Tuesday, timeTable, teachers)
                let dataObjectWednesday =
                GetDataObjectToWeekDay(DayOfWeek.Wednesday, oldWeekDataObject.Wednesday, timeTable, teachers)
                let dataObjectThursday =
                GetDataObjectToWeekDay(DayOfWeek.Thursday, oldWeekDataObject.Thursday, timeTable, teachers)
                let dataObjectFriday =
                GetDataObjectToWeekDay(DayOfWeek.Friday, oldWeekDataObject.Friday, timeTable, teachers)
                select
                new WeekDataObjects(dataObjectMonday, dataObjectTuesday, dataObjectWednesday, dataObjectThursday,
                    dataObjectFriday, oldWeekDataObject.Week)).ToList(), classRegister.Class)).ToList();


        /// <summary>
        /// Gets the filled Dataobject to a specific Weekday. This method is called five times, once for every Weekday
        /// </summary>
        /// <returns>The auot-filled Dataobject</returns>
        public static List<DataObject> GetDataObjectToWeekDay(DayOfWeek weekDay,
                List<DataObject> oldWeekDataObjectsToDay, TimeTable timeTable, IEnumerable<Teacher> teachers)
            => oldWeekDataObjectsToDay?.Select(
                (o, index) =>
                    string.IsNullOrEmpty(o.Subject) && (index < timeTable.TimeTableRows.Count)
                        ? new DataObject(
                            GeneralUtil.ReturnFirstOrException(teachers.Where(
                                    teacher =>
                                        teacher.TeacherProperties.Any(
                                            prop =>
                                                prop.Subjects.Contains(
                                                    GetStringToDateFromTimeTableRow(timeTable.TimeTableRows[index],
                                                        weekDay))))
                                .Select(teacher => teacher.Name).ToList(), o.Teacher),
                            GetStringToDateFromTimeTableRow(timeTable.TimeTableRows[index], weekDay), o.Content,
                            o.Remarks)
                        : new DataObject(
                            GeneralUtil.ReturnFirstOrException(teachers.Where(
                                    teacher =>
                                        teacher.TeacherProperties.Any(
                                            prop => prop.Subjects.Contains(o.Subject)))
                                .Select(teacher => teacher.Name).ToList(), o.Teacher), o.Subject, o.Content,
                            o.Remarks)).ToList();

        /// <summary>
        /// Gets the Timetable Data from a given TimeTableRow and a Day within the row.
        /// </summary>
        /// <returns>The Data as a string</returns>
        public static string GetStringToDateFromTimeTableRow(TimeTableRow row, DayOfWeek weekDay) =>
            weekDay == DayOfWeek.Monday
                ? row.Monday
                : weekDay == DayOfWeek.Tuesday
                    ? row.Tuesday
                    : weekDay == DayOfWeek.Wednesday
                        ? row.Wednesday
                        : weekDay == DayOfWeek.Thursday
                            ? row.Thursday
                            : weekDay == DayOfWeek.Friday ? row.Friday : null;
    }
}