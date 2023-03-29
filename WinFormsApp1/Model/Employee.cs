using System;

namespace MVPForm.Model
{
    [Serializable]
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

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Date { get => date; set => date = value; }
        public string Salary { get => salary; set => salary = value; }
        public string Occupation { get => occupation; set => occupation = value; }
        public string Contract { get => contract; set => contract = value; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}

