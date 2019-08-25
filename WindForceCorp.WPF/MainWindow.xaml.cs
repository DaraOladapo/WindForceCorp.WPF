using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WindForceCorp.WPF.Models;
using WindForceCorp.WPF.Services;

namespace WindForceCorp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> People;
        private Person selectedPerson = new Person();
        public MainWindow()
        {
            People = new ObservableCollection<Person>();
            InitializeComponent();
            People = DataService.GetPeople();
            PeopleListView.ItemsSource = People;
        }
        void AddPerson(Person person)
        {
            Analytics.TrackEvent("Person Added");
            People.Add(person);
        }
        void Modify(Person person)
        {
            Analytics.TrackEvent("Person Modified");
            var Person = People.FirstOrDefault(opt => opt.ID == person.ID);
            Person.FirstName = EditFirstNameBox.Text;
            Person.LastName = EditLastNameBox.Text;
            Person.EmailAddress = EditEmailAddressBox.Text;
            var FreshPeople = People;
            People.Clear();
            People = FreshPeople;
            //PeopleListView.ItemsSource = People;
        }

        private void OnItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Analytics.TrackEvent("Person Selected");
            selectedPerson = (Person)e.AddedItems[0];
            EditFirstNameBox.Text = selectedPerson.FirstName;
            EditLastNameBox.Text = selectedPerson.LastName;
            EditEmailAddressBox.Text = selectedPerson.EmailAddress;
        }

        private void OnAddToList(object sender, RoutedEventArgs e)
        {
            var Person = new Person()
            {
                ID = Guid.NewGuid().ToString(),
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                EmailAddress = EmailAddressBox.Text
            };
            AddPerson(Person);
        }

        private void OnModifyPerson(object sender, RoutedEventArgs e)
        {
            selectedPerson.FirstName = EditFirstNameBox.Text;
            selectedPerson.LastName = EditLastNameBox.Text;
            selectedPerson.EmailAddress = EditEmailAddressBox.Text;
            Modify(selectedPerson);
        }
    }
}
