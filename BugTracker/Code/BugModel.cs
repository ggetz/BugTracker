﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class BugModel
{
    public int BugID { get; set; }
    public string Project { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string Assigned { get; set; }
    public string Catagory { get; set; }
    public string Status { get; set; }
    public List<Comment> Comments{ get; set;}
}
