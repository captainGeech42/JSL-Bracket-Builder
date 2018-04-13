namespace JSLBracketBuilder
{
    public class Ladder
    {
        public Region Region { get; set; }
        public int Id { get; set; }
        public League League { get; set; }
        public int Division { get; set; }
        public int MinMMR { get; set; }
        public int MaxMMR { get; set; }

        public Ladder() { }

        public Ladder(Region region, int id, League league, int division, int minMMR, int maxMMR)
        {
            Region = region;
            Id = id;
            League = league;
            Division = division;
            MinMMR = minMMR;
            MaxMMR = maxMMR;
        }
    }
}
