using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            while(numberOfTeams > 0)
            {
                string[] teamToCreate = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
                if (teams.FindIndex(x => x.Name == teamToCreate[1]) != -1)
                {
                    Console.WriteLine($"Team {teamToCreate[1]} was already created!");

                }
                else if (teams.FindIndex(x => x.Creator == teamToCreate[0]) != -1)
                {
                    Console.WriteLine($"{teamToCreate[0]} cannot create another team!");

                }
                else
                {
                    teams.Add(new Team(teamToCreate[1], teamToCreate[0]));
                }
                numberOfTeams--;
            }
            string userToJoin = Console.ReadLine();
            while(userToJoin != "end of assignment")
            {
                string[] joinComm = userToJoin.Split("->", StringSplitOptions.RemoveEmptyEntries);
                if(teams.FindIndex(x=> x.Name.Equals(joinComm[1])) == -1)
                {
                    Console.WriteLine($"Team {joinComm[1]} does not exist!");
                }
                else if((teams.FindIndex(x=> x.members.Contains(joinComm[0])) != -1) || (teams.FindIndex(x => x.Creator == joinComm[0]) != -1))
                {
                    Console.WriteLine($"Member {joinComm[0]} cannot join team {joinComm[1]}!");
                }
                else
                {
                    int teamIndex = teams.FindIndex(x => x.Name == (joinComm[1]));
                    teams[teamIndex].AddMember(joinComm[0]);
                }
                userToJoin = Console.ReadLine();
            }

            List<Team> validTeams = teams.Where(x => x.MembersCount > 0).ToList();
            List<Team> disbandTeams = teams.Where(x => x.MembersCount == 0).ToList();
            foreach (var team in validTeams.OrderByDescending(x => x.MembersCount).ThenBy(x=>x.Name))
            {
                team.PrintTeam();
            }
            Console.WriteLine("Teams to disband:");
            foreach (var team in disbandTeams.OrderBy(x => x.Name))
            {
                team.PrintTeam();
            }
                
        }
    }
    public class Team
    {
        public Team(string name, string creator)
        {
            this.Name = name;
            this.Creator = creator;
            this.members = new List<string>();
            this.MembersCount = 0;
            Console.WriteLine($"Team {this.Name} has been created by {this.Creator}!");
        }
        //Team() { }
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> members { get; set; }

        public int MembersCount { get; set; }

        public void AddMember(string name)
        {
            members.Add(name);
            MembersCount++;
        }
        public void PrintTeam()
        {
            Console.WriteLine(this.Name);
            if(this.MembersCount > 0)
            {
                Console.WriteLine($"- {this.Creator}");
                foreach(var member in members.OrderBy(x=> x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
        }
    }
}
