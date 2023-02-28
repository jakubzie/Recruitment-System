using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecruitmentSystem
{
    [DataContract(IsReference = true)]
    public class Applicant : Person, ICloneable, IRecrutation
    {
        static int countCV;

        int cvID;
        Team teamApplyingFor;
        bool accepted;
        private static List<Applicant> allApplicants = new List<Applicant>();

        [DataMember]
        public List<Applicant> AllApplicants { get { return allApplicants; } set { allApplicants = value; } }
        [DataMember]
        public int CountCV { get { return countCV; } set { countCV = value; } }
        [DataMember]
        public Team TeamApplyingFor { get { return teamApplyingFor; } set { teamApplyingFor = value; } } //fishy
        [DataMember]
        public bool Accepted { get { return accepted; } set { accepted = value; } }
        [DataMember]
        public int CVID { get { return cvID; } set { cvID = value; } }

        static Applicant()
        {
            countCV = 200;
        }
        public Applicant(string pesel, string name, string surname, string phoneNumber, string email, enumEducation education, Team teamApplyingFor)
            : base(pesel, name, surname, phoneNumber, email, education)
        {
            allApplicants.Add(this);
            CVID = CountCV;
            countCV++;
            TeamApplyingFor = teamApplyingFor;
            Accepted = false;
        }

        public static List<Applicant> GetAllApplicants()
        {
            return allApplicants;
        }

        public override string ToString()
        {
            return $"{base.ToString()}; {Education}; CV ID: {CVID}; Team: {TeamApplyingFor.TeamName}"; //nazwa zespołu tylko
        }
        public object Clone()
        {
            return MemberwiseClone();
        }

        public string CheckCandidate(Applicant applicant)
        {
            return applicant.ToString();
        }

        public void Accept()
        {
            if (Accepted) { return; }
            Accepted = true;
            TeamApplyingFor.AddMember(this);
            TeamApplyingFor.Recruiter.Recruit();
        }
        public void Decline()
        {
            if (!Accepted) { return; }
            Accepted = false;
            TeamApplyingFor.DeleteMember(this);
        }
    }
}
