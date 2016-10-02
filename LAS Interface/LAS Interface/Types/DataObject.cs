namespace LAS_Interface.Types
{
    public class DataObject
    {
        /// <summary>
        /// Initializes a Dataobject. This is one line in the register later. So it contains all the information for one subject.
        /// </summary>
        /// <returns>nothing</returns>
        public DataObject (string teacher, string subject, string content, string remarks)
        {
            Teacher = teacher;
            Subject = subject;
            Content = content;
            Remarks = remarks;
        }

        /// <summary>
        /// This is the data for teacher column later.
        /// </summary>
        /// <value>teacher data</value>
        public string Teacher { get; set; }
        /// <summary>
        /// This is the data for the Subject column later - so it should contain the subject of the lesson
        /// </summary>
        /// <value>Subject data</value>
        public string Subject { get; set; }
        /// <summary>
        /// This is the data for the content column in the register
        /// </summary>
        /// <value>content data</value>
        public string Content { get; set; }
        /// <summary>
        /// This is the data for the remarks column later.
        /// </summary>
        /// <value>remarks data</value>
        public string Remarks { get; set; }
    }
}