using System;

namespace JSLBracketBuilder
{
    public class Team
    {
        public Race Race { get; set; }
        public League League { get; set; }
        public int Division { get; set; }
        public int GamesPlayed { get; set; }
        public int MMR { get; set; }

        public Team() { }

        public Team(Race race, League league, int division, int gamesPlayed, int mmr)
        {
            Race = race;
            League = league;
            Division = division;
            GamesPlayed = gamesPlayed;
            MMR = mmr;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Team otherItem = obj as Team;
            if (otherItem != null)
            {
                return MMR.CompareTo(otherItem.MMR);
            }
            else
            {
                throw new ArgumentException("Object is not a Team");
            }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Team otherItem = obj as Team;
            if (otherItem != null)
            {
                return MMR == otherItem.MMR;
            }
            else
            {
                return false;
            }
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 11;
            hash = (hash * 101) + MMR.GetHashCode();
            hash = (hash * 101) + Race.GetHashCode();
            return hash;
        }
    }
}
