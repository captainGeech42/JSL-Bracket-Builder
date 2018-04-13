using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSLBracketBuilder
{
    public class Group
    {
        public List<Player> Members { get; set; }
        public int Id { get; private set; }

        public Group(int id)
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
