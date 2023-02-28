using RecruitmentSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RecruitmentSystem;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy TeamsWindow.xaml
    /// </summary>
    public partial class TeamsWindow : Window
    {
        Company company;
        public TeamsWindow()
        {
            InitializeComponent();
        }
        public TeamsWindow(Company company) : this()
        {
            this.company = company;
            ComboTeams.ItemsSource = Team.GetAllTeams();
            List<string> teamNames = new();
            List<Team> teams = Team.GetAllTeams();
            foreach (Team team in teams)
            {
                teamNames.Add(team.TeamName);
            }
            ComboTeams.DisplayMemberPath = "TeamName";
        }

        private void BtnChoose_Click(object sender, RoutedEventArgs e)
        {
            Team team = ComboTeams.SelectedItem as Team;
            TxtTeamLeader.Text = team.TeamLeader.ToString();
            TxtRecruiter.Text = team.Recruiter.ToString();
            LstAccepted.ItemsSource = new ObservableCollection<Applicant>(team.NewMembers);

        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (LstAccepted.Items.Count != 0)
            {
                Team team = ComboTeams.SelectedItem as Team;
                Applicant applicant = LstAccepted.SelectedItem as Applicant;
                applicant.Decline();
                LstAccepted.ItemsSource = new ObservableCollection<Applicant>(team.NewMembers);
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

