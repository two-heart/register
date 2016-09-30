using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Navigation;
using LAS_Interface.Types;
using LAS_Interface.Types.Humans.Teacher;
using LAS_Interface.Util;

namespace LAS_Interface.Automation
{
    public class AutoFill
    {
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
                oldWeekDataObject.Monday.Select(
                    (o, index) =>
                        string.IsNullOrEmpty(o.Subject) && index < timeTable.TimeTableRows.Count
                            ? new DataObject(
                                GeneralUtil.ReturnFirstOrException(teachers.Where(
                                        teacher =>
                                            teacher.TeacherProperties.Any(
                                                prop => prop.Subjects.Contains(timeTable.TimeTableRows[index].Monday)))
                                    .Select(teacher => teacher.Name).ToList(), o.Teacher)
                                , timeTable.TimeTableRows[index].Monday, o.Content, o.Remarks)
                            : new DataObject(
                                GeneralUtil.ReturnFirstOrException(teachers.Where(
                                        teacher =>
                                            teacher.TeacherProperties.Any(
                                                prop => prop.Subjects.Contains(o.Subject)))
                                    .Select(teacher => teacher.Name).ToList(), o.Teacher), o.Subject, o.Content,
                                o.Remarks)).ToList()
                let dataObjectTuesday =
                oldWeekDataObject.Tuesday.Select(
                    (o, index) =>
                        string.IsNullOrEmpty(o.Subject) && index < timeTable.TimeTableRows.Count
                            ? new DataObject(
                                GeneralUtil.ReturnFirstOrException(teachers.Where(
                                        teacher =>
                                            teacher.TeacherProperties.Any(
                                                prop => prop.Subjects.Contains(timeTable.TimeTableRows[index].Tuesday)))
                                    .Select(teacher => teacher.Name).ToList(), o.Teacher),
                                timeTable.TimeTableRows[index].Tuesday, o.Content, o.Remarks)
                            : new DataObject(
                                GeneralUtil.ReturnFirstOrException(teachers.Where(
                                        teacher =>
                                            teacher.TeacherProperties.Any(
                                                prop => prop.Subjects.Contains(o.Subject)))
                                    .Select(teacher => teacher.Name).ToList(), o.Teacher), o.Subject, o.Content,
                                o.Remarks)).ToList()
                let dataObjectWednesday =
                oldWeekDataObject.Wednesday.Select(
                    (o, index) =>
                        string.IsNullOrEmpty(o.Subject) && index < timeTable.TimeTableRows.Count
                            ? new DataObject(
                                GeneralUtil.ReturnFirstOrException(teachers.Where(
                                        teacher =>
                                            teacher.TeacherProperties.Any(
                                                prop => prop.Subjects.Contains(timeTable.TimeTableRows[index].Wednesday)))
                                    .Select(teacher => teacher.Name).ToList(), o.Teacher),
                                timeTable.TimeTableRows[index].Wednesday, o.Content, o.Remarks)
                            : new DataObject(
                                GeneralUtil.ReturnFirstOrException(teachers.Where(
                                        teacher =>
                                            teacher.TeacherProperties.Any(
                                                prop => prop.Subjects.Contains(o.Subject)))
                                    .Select(teacher => teacher.Name).ToList(), o.Teacher), o.Subject, o.Content,
                                o.Remarks)).ToList()
                let dataObjectThursday =
                oldWeekDataObject.Thursday.Select(
                    (o, index) =>
                        string.IsNullOrEmpty(o.Subject) && index < timeTable.TimeTableRows.Count
                            ? new DataObject(
                                GeneralUtil.ReturnFirstOrException(teachers.Where(
                                        teacher =>
                                            teacher.TeacherProperties.Any(
                                                prop => prop.Subjects.Contains(timeTable.TimeTableRows[index].Thursday)))
                                    .Select(teacher => teacher.Name).ToList(), o.Teacher),
                                timeTable.TimeTableRows[index].Thursday, o.Content, o.Remarks)
                            : new DataObject(
                                GeneralUtil.ReturnFirstOrException(teachers.Where(
                                        teacher =>
                                            teacher.TeacherProperties.Any(
                                                prop => prop.Subjects.Contains(o.Subject)))
                                    .Select(teacher => teacher.Name).ToList(), o.Teacher), o.Subject, o.Content,
                                o.Remarks)).ToList()
                let dataObjectFriday =
                oldWeekDataObject.Friday.Select(
                    (o, index) =>
                        string.IsNullOrEmpty(o.Subject) && index < timeTable.TimeTableRows.Count
                            ? new DataObject(
                                GeneralUtil.ReturnFirstOrException(teachers.Where(
                                        teacher =>
                                            teacher.TeacherProperties.Any(
                                                prop => prop.Subjects.Contains(timeTable.TimeTableRows[index].Friday)))
                                    .Select(teacher => teacher.Name).ToList(), o.Teacher),
                                timeTable.TimeTableRows[index].Friday, o.Content, o.Remarks)
                            : new DataObject(
                                GeneralUtil.ReturnFirstOrException(teachers.Where(
                                        teacher =>
                                            teacher.TeacherProperties.Any(
                                                prop => prop.Subjects.Contains(o.Subject)))
                                    .Select(teacher => teacher.Name).ToList(), o.Teacher), o.Subject, o.Content,
                                o.Remarks)).ToList()
                select
                new WeekDataObjects(dataObjectMonday, dataObjectTuesday, dataObjectWednesday, dataObjectThursday,
                    dataObjectFriday)).ToList(), classRegister.Class)).ToList();
    }
}