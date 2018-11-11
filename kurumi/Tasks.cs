using System;
using System.Collections.Generic;

namespace trial_and_error_1028.kurumi
{
    public partial class Tasks
    {
        public int TaskId { get; set; }
        public int GroupId { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Pic { get; set; }
        public int? Period { get; set; }
    }
}
