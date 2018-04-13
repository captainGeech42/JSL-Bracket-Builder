using System.Collections.Generic;
using System.Linq;
using System;

namespace JSLBracketBuilder
{
    public class Player
    {
        public string Battletag { get; set; }
        public Region Region { get; set; }
        public List<Team> Teams { get; private set; }

        public Player()
        {
            Teams = new List<Team>();
        }

        public Player(string battletag, Region region)
        {
            Battletag = battletag;
            Region = region;

            Teams = new List<Team>();
        }

        public void AddTeam(Race race, League league, int division, int gamesPlayed, int mmr)
        {
            Teams.Add(new Team()
            {
                Race = race,
                League = league,
                Division = division,
                GamesPlayed = gamesPlayed,
                MMR = mmr
            });
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Player other = obj as Player;
            if (other != null)
            {
                // compare largest team for each player
                return (from t in Teams select t).Max().CompareTo((from t in other.Teams select t));
            } else
            {
                throw new ArgumentException("Object is not a Player");
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

            Player otherItem = obj as Player;
            if (otherItem != null)
            {
                return Battletag == otherItem.Battletag && Region == otherItem.Region;
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
            hash = (hash * 101) + Battletag.GetHashCode();
            hash = (hash * 101) + Region.GetHashCode();
            return hash;
        }
    }
}
