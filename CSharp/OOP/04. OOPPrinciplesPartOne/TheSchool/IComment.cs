namespace TheSchool
{
    public interface IComment
    {
        string ListOfComments
        {
            get;
        }

        void AddComment(string input);
    }
}
