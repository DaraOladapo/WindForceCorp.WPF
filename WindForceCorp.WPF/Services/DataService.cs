using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WindForceCorp.WPF.Models;

namespace WindForceCorp.WPF.Services
{
    public class DataService
    {
        public static ObservableCollection<Person> GetPeople()
        {
            return new ObservableCollection<Person>()
            {
                new Person(){
                    ID=Guid.NewGuid().ToString(),
                    FirstName="Smith",
                    LastName="Sanderson",
                    EmailAddress="smiths@randm.io"},
                new Person(){
                    ID=Guid.NewGuid().ToString(),
                    FirstName="James",
                    LastName="Rogers",
                    EmailAddress="jr@randmina.io"},
                new Person(){
                    ID=Guid.NewGuid().ToString(),
                    FirstName="Offi",
                    LastName="Akebe",
                    EmailAddress="offi@offia.com"},
                new Person(){
                    ID=Guid.NewGuid().ToString(),
                    FirstName="Kimba",
                    LastName="Zulu",
                    EmailAddress="kizulu@randm.io"},

            };
        }
    }
}
