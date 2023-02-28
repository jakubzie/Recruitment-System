using RecruitmentSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Logika interakcji dla klasy osobaWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        Applicant applicant;
        public AddWindow()
        {
            InitializeComponent();
            ComboTeam.ItemsSource = Team.GetAllTeams();
            List<string> teamNames = new();
            List<Team> teams = Team.GetAllTeams();
            foreach (Team team in teams)
            {
                teamNames.Add(team.TeamName);
            }
            ComboTeam.DisplayMemberPath = "TeamName";
        }

        private void BtnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            bool? result = false;
            if (!string.IsNullOrEmpty(TxtName.Text) &&
                !string.IsNullOrEmpty(TxtSurname.Text) &&
                !string.IsNullOrEmpty(TxtPesel.Text) &&
                !string.IsNullOrEmpty(TxtPhoneNumber.Text) &&
                !string.IsNullOrEmpty(TxtEmail.Text) &&
                (ComboTeam.SelectedIndex > -1) &&
                (ComboEducation.SelectedIndex > -1))
            {
                Applicant applicant = new Applicant(TxtPesel.Text, TxtName.Text, TxtSurname.Text, TxtPhoneNumber.Text, TxtEmail.Text,
                    ComboEducation.Text == "Higher" ? enumEducation.higher : ComboEducation.Text == "Secondary" ? enumEducation.secondary : enumEducation.primary,
                    ComboTeam.SelectedItem as Team);
                result = true;
            }
            DialogResult = true;
        }
    }
}
