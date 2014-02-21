using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public abstract class Comment
    {
        private string listOfComments;

        public Comment()
        {
            this.listOfComments = String.Empty;
        }

        public Comment(string newComment)
            : this()
        {
            this.listOfComments = newComment;
        }
        public string ListOfComments
        {
            get { return this.listOfComments; }
        }

        public void AddComment(string input)
        {
            StringBuilder tempCommentValue = new StringBuilder(listOfComments);
            tempCommentValue.Append(input);
            tempCommentValue.Append("\n");
            listOfComments = tempCommentValue.ToString();
        }
    }
}