using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Applicant))]
    [KnownType(typeof(TeamLeader))]
    [KnownType(typeof(Recruiter))]
    public class Team : ICloneable
    {
        string teamName;
        TeamLeader teamLeader;
        List<Applicant> newMembers;
        Recruiter recruiter;
        private static List<Team> allTeams = new();

        [DataMember]
        public string TeamName { get { return teamName; } set { teamName = value; } }
        [DataMember]
        public TeamLeader TeamLeader { get { return teamLeader; } set { teamLeader = value; } }
        [DataMember]
        public List<Applicant> NewMembers { get { return newMembers; } set { newMembers = value; } }
        [DataMember]
        public Recruiter Recruiter { get { return recruiter; } set { recruiter = value; } }
        [DataMember]
        public List<Team> AllTeams { get { return allTeams; } set { allTeams = value; } }

        public Team()
        {
            NewMembers = new();
            AllTeams.Add(this);
        }
        public static List<Team> GetAllTeams()
        {
            return allTeams;
        }

        public Team(string teamName, TeamLeader teamLeader, Recruiter recruiter) : this()
        {
            TeamName = teamName;
            TeamLeader = teamLeader;
            Recruiter = recruiter;
        }
        public void ChangeRecruiter(Recruiter recruiter)
        {
            Recruiter = recruiter;
        }
        public void AddMember(Applicant applicant)
        {
            if (applicant == null) { return; }
            NewMembers.Add(applicant);
        }
        public void DeleteMember(Applicant applicant)
        {
            NewMembers.Remove(applicant);
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"TEAM: {TeamName}");
            sb.AppendLine($"Leader: {TeamLeader}");
            sb.AppendLine($"Recruiter: {Recruiter}");
            sb.AppendLine($"Accepted applicants:");
            foreach (Applicant applicant in NewMembers)
            {
                sb.AppendLine($"{applicant.ToString()}");
            }
            return sb.ToString();
        }

        public object? Clone()
        {
            DataContractSerializer dc = new(typeof(Team));
            using MemoryStream ms = new();
            dc.WriteObject(ms, this);
            ms.Seek(0, SeekOrigin.Begin);
            return dc.ReadObject(ms);
        }
    }
}
