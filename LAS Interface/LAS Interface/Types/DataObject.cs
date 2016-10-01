namespace LAS_Interface.Types
{
    public class DataObject
    {
        public DataObject(string teacher, string subject, string content, string remarks)
        {
            Teacher = teacher;
            Subject = subject;
            Content = content;
            Remarks = remarks;
        }

        public string Teacher { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Remarks { get; set; }
    }
}