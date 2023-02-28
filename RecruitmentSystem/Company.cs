using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem
{
    [DataContract]
    [KnownType(typeof(Applicant))]
    [KnownType(typeof(TeamLeader))]
    [KnownType(typeof(Recruiter))]
    [KnownType(typeof(Team))]
    //[KnownType(typeof(TeamLeader))]
    //[KnownType(typeof(Recruiter))]
    public class Company
    {
        string nazwa = "X";
        List<Team> allTeams = new List<Team>();

        [DataMember]
        public string Nazwa { get { return nazwa; } set { nazwa = value; } }
        [DataMember]
        public List<Team> AllTeams { get { return allTeams; } set { allTeams = value; } }

        public Company()
        {
            AllTeams = Team.GetAllTeams();
        }
        public void SaveDC(string fname)
        {
            using FileStream fs = new(fname, FileMode.Create);
            DataContractSerializer dc = new(typeof(Company));
            dc.WriteObject(fs, this);
        }
        public static Company? ReadDC(string fname)
        {
            if (!File.Exists(fname)) { return null; }
            using FileStream fs = new(fname, FileMode.Open);
            DataContractSerializer dc = new(typeof(Company));
            return dc.ReadObject(fs) as Company;
        }
    }
}
