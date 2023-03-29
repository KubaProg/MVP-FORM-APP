using System;

namespace MVPForm.Model
{
    public class Employee
    {

        private String name;
        private String surname;
        private String date;
        private String salary;
        private String occupation;
        private String contract;

        public Employee()
        {
        }

        public Employee(string name, string surname, string date, string salary, string occupation, string contract)
        {
            this.name = name;
            this.surname = surname;
            this.date = date;
            this.salary = salary;
            this.occupation = occupation;
            this.contract = contract;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}

