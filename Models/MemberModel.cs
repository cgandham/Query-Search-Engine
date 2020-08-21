using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace elastic.Models
{


    public class Members
    {
        public string ID { get; set; }
        public string Label { get; set; }
        [Keyword]
        public string KeywordLabel { get; set; }
        public string ParentID { get; set; }
        public string LeftVal { get; set; }
        public string RightVal { get; set; }
        public string LevelVal { get; set; }
        public string RollupOperator { get; set; }
        public string ParentsPath { get; set; }
        public string ParentLabelPath { get; set; }
        public string ParentDimenison { set; get; }
    }

    public class Node
    {
        // public List<Node> Children = new List<Node>();
        public Node Parent { get; set; }
        public Members AssociatedObject { get; set; }

    }

    public class tooltip
    {
        public string ID { get; set; }
        public string Label { get; set; }
        public string ParentID { get; set; }
        public string LeftVal { get; set; }
        public string RightVal { get; set; }
        public string LevelVal { get; set; }
        public string RollupOperator { get; set; }
        public string ParentsPath { get; set; }
        public string ParentLabelPath { get; set; }
        public string Type { get; set; }

    }
    public class Dimensions
    {
        public string Tablename { get; set; }
        public string Displayname { get; set; }
    }


}



