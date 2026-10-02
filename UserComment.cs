namespace Comments2026
{
    public class UserComment
    {
        //private fields
        private string rawComment;
        private string sanitizedComment;
        //public properties
        public string RawComment { get { return rawComment; } set { rawComment = value; } }
        public string SanitizedComment { get {return sanitizedComment; } set { sanitizedComment = value; } }

        //constructor
        public UserComment(string rawComment) 
        {
            this.rawComment = rawComment;
            this.sanitizedComment = SanitizeService.SanitizeTextJSON(rawComment);
        }

    }
}
