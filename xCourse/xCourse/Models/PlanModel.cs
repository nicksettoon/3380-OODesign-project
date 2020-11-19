namespace xCourse.Models
{
    public class PlanModel
    {
        public string Degree { get; set; }
        
        public string Nodes { get; set; }

        public string Links { get; set; }

        public PlanModel(string _Degree, string _Nodes, string _Links)
        {
            Degree = _Degree;
            Nodes = _Nodes;
            Links = _Links;
        }

    }
}
