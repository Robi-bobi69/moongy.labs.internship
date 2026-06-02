namespace moongy.labs.internships.Domain.Entities
{
    public class Interview
    {
        public int InterviewId { get; set; }

        public int InternId { get; set; }
        public int MentorId { get; set; }

        public DateTime InterviewDate { get; set; }
    }
}