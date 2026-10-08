namespace Comments2026;

public class UserComment
{
    private string rawComment;
    private string sanitizedComment;
    
    public string RawComment
    {
        get {return rawComment;} 
        set {rawComment = value;}
    }

    public string SanitizedComment
    {
        get { return sanitizedComment; }
        set { sanitizedComment = value; }
    }

    public UserComment(string rawComment)
    {
        this.rawComment = rawComment;
        this.sanitizedComment = SanitizeService.SanitizeTextXML(rawComment);
    }
}