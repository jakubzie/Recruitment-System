using RecruitmentSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RecruitmentSystem;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Company company;
        public MainWindow()
        {
            string fname = "company.xml";
            company = Company.ReadDC(fname);

            InitializeComponent();

            if (company != null)
            {
            }
        }

        private void BtnTeamList_Click(object sender, RoutedEventArgs e)
        {
            if (Team.GetAllTeams() != null)
            {
                TeamsWindow teamsWindow = new TeamsWindow(company);
                bool? result1 = teamsWindow.ShowDialog();
                if (result1 == true)
                {
                    teamsWindow.ComboTeams.ItemsSource = Team.GetAllTeams(); //???
                    //teamsWindow.ComboTeams.ItemsSource = new ObservableCollection<Team>(Team.GetAllTeams());
                }
            }
        }

        private void BtnApplicantsList_Click(object sender, RoutedEventArgs e)
        {
            ApplicantsWindow applicantsWindow = new ApplicantsWindow(company);
            bool? result2 = applicantsWindow.ShowDialog();
            //if( result2 == true)
            //{
            //    applicantsWindow.LstApplicants.ItemsSource = new ObservableCollection<Team>(company.AllTeams);
            //    applicantsWindow.LblApplicants.Content = company.AllTeams.Count.ToString();
            //}
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string fname1 = "company.xml";
            if(company != null)
            {
                company.SaveDC(fname1);
            }
            Application.Current.Shutdown();
        }
    }
}

