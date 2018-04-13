namespace JSLBracketBuilder
{
    public enum Region
    {
        US,
        EU
    }

    public enum Race
    {
        TERRAN,
        PROTOSS,
        ZERG,
        RANDOM
    }

    public enum League
    {
        BRONZE = 0,
        SILVER = 1,
        GOLD = 2,
        PLATINUM = 3,
        DIAMOND = 4,
        MASTER = 5,
        GRANDMASTER = 6
    }

    public enum Operation
    {
        GET_SEASON_ID,
        GET_ALL_LADDERS,
        GET_PLAYERS_IN_LADDER,
        GENERATE_GROUPS,
    }
}
