using RecruitmentSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy ApplicantsWindow.xaml
    /// </summary>
    public partial class ApplicantsWindow : Window
    {
        Company company;
        public ApplicantsWindow()
        {
            //string fname = "company.xml";
            //company = Company.ReadDC(fname);

            InitializeComponent();
            if (company != null)
            {
                LstApplicants.ItemsSource = new ObservableCollection<Applicant>(NotAccepted());
            }
        }
        public ApplicantsWindow(Company company)
        {
            this.company = company;
            InitializeComponent();
            if (company != null)
            {
                LstApplicants.ItemsSource = new ObservableCollection<Applicant>(NotAccepted());
            }
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (company != null && LstApplicants.SelectedIndex > -1)
            {
                Applicant applicant = (Applicant)LstApplicants.SelectedItem;
                applicant.Accept();
                LstApplicants.ItemsSource = new ObservableCollection<Applicant>(NotAccepted());
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            bool? result3 = addWindow.ShowDialog();
            if (result3 == true)
            {
                LstApplicants.ItemsSource = new ObservableCollection<Applicant>(NotAccepted());
            }
        }

        private List<Applicant> NotAccepted()
        {
            List<Applicant> notAccepted = new List<Applicant>();
            foreach (Applicant applicant in Applicant.GetAllApplicants())
            {
                if (applicant.Accepted == false)
                {
                    notAccepted.Add(applicant);
                }
            }
            return notAccepted;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
