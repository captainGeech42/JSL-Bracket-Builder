using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace JSLBracketBuilder
{
    public static class API
    {
        private static Dictionary<string, string> Parameters { get; set; } = null;
        private static bool Initalized { get; set; } = false;
        private static RestClient Client { get; set; } = null;
        private static Region Region { get; set; } = Region.US;
        private static string AccessToken { get; set; } = String.Empty;

        public static void SetRegion(Region region)
        {
            Region = region;
            Initalize();
        }

        private static void Initalize()
        {
            if (AccessToken == String.Empty)
            {
                using (var sr = new StreamReader(@"access_token.txt"))
                {
                    AccessToken = sr.ReadToEnd();
                }
            }

            if (Parameters == null)
            {
                Parameters = new Dictionary<string, string>
                {
                    { @"access_token", AccessToken },
                    { @"locale", @"en_US" }
                };
            }

            if (Client == null || (Client != null && !Client.BaseUrl.ToString().Contains(Region.ToString().ToLower())))
            {
                Client = new RestClient($"https://{Region.ToString().ToLower()}.api.battle.net/data/sc2");
                foreach (var item in Parameters)
                {
                    Client.AddDefaultParameter(item.Key, item.Value);
                }
            }
        }

        public static int GetCurrentSeasonID()
        {
            Initalize();

            var request = new RestRequest("season/current", Method.GET);
            var response = Client.Execute(request);
            //TODO handle bad response code
            var data = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return data.id;
        }

        public static List<Ladder> GetAllLadders(League maxLeague, int seasonID)
        {
            Initalize();

            var ladders = new List<Ladder>();
            Ladder ladder;
            int division, minMMR, maxMMR, ladderId;

            for (int leagueId = 0; leagueId <= (int)maxLeague; leagueId++)
            {
                var request = new RestRequest($"league/{seasonID}/201/0/{leagueId}", Method.GET);
                var response = Client.Execute(request);
                //TODO handle bad response code
                var data = JsonConvert.DeserializeObject<dynamic>(response.Content);

                foreach(dynamic tier in data.tier)
                {
                    division = tier.id + 1;
                    minMMR = tier.min_rating;
                    maxMMR = tier.max_rating;
                    
                    foreach(dynamic i in tier.division)
                    {
                        ladderId = i.ladder_id;
                        ladder = new Ladder()
                        {
                            Region = Region,
                            Id = ladderId,
                            League = (League)leagueId,
                            Division = division,
                            MinMMR = minMMR,
                            MaxMMR = maxMMR
                        };
                        ladders.Add(ladder);
                    }
                }
            }

            return ladders;
        }

        public static List<Player> GetAllPlayersInLadder(Ladder ladder)
        {
            var players = new List<Player>();

            var request = new RestRequest($"ladder/{ladder.Id}", Method.GET);
            var response = Client.Execute(request);
            //TODO handle bad response code
            var data = JsonConvert.DeserializeObject<dynamic>(response.Content);

            string bnet, race;
            int mmr, games_played;

            foreach (dynamic team in data.team)
            {
                try
                {
                    bnet = team.member[0].character_link.battle_tag;
                    mmr = team.rating;
                    games_played = team.member[0].played_race_count[0].count;
                    race = team.member[0].played_race_count[0].race;

                    bnet = bnet.ToLower();

                    var player = (from p in players
                                  where p.Battletag == bnet
                                  select p).FirstOrDefault();

                    if (player == null)
                    {
                        player = new Player()
                        {
                            Battletag = bnet,
                            Region = Region
                        };
                        players.Add(player);
                    }
                    var erace = (Race)Enum.Parse(typeof(Race), race, true);
                    player.AddTeam(erace, ladder.League, ladder.Division, games_played, mmr);
                } catch
                {
                    continue;
                }
                
            }

            return players;
        }
    }
}
