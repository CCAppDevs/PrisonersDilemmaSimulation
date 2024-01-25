namespace PrisonersDilemmaSimulation
{
    public class Toss
    {
        public string Name { get; set; }
        public int TossNumber { get; set; }
        public Result TossResult { get; set; }

        public Toss(string name, Result result, int toss)
        {
            Name = name;
            TossResult = result;
            TossNumber = toss;
        }
    }
}