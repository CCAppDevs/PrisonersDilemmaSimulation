namespace PrisonersDilemmaSimulation
{
    public class Toss
    {
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public int TossNumber { get; set; }
        public Result TossResult { get; set; }
        public string OpponentName { get; set; }
        public int PointsTotal { get; set; }
        public int PointsEarnedThisToss { get; set; }

        public Toss(string name, Guid guid, Result result, int toss, string oppName, int totalPoints, int earned)
        {
            Name = name;
            Guid = guid;
            TossResult = result;
            TossNumber = toss;
            OpponentName = oppName;
            PointsTotal = totalPoints;
            PointsEarnedThisToss = earned;
        }
    }
}