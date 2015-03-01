using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Comment
{
    public int CommentID { get; set; }
    public int ParentID { get; set; }
    public int BugID { get; set; }
    public string Text { get; set; }
    public string Author { get; set; }
    public string TimeStamp { get; set; }
}
