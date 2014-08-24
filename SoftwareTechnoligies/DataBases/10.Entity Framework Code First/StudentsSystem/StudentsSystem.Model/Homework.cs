namespace StudentsSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        [Key, Column(Order = 0)]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        
        public virtual Course Course { get; set; }
    }
}