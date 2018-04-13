using System.Collections.Generic;

namespace JSLBracketBuilder
{
    public class Group
    {
        public List<Player> Members { get; set; }
        public char Id { get; private set; }

        public Group(char id)
        {
            Id = id;
            Members = new List<Player>();
        }

        public void SortGroup()
        {
            Members.Sort();
        }
    }
}
