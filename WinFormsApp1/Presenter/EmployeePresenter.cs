using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MVPForm.Model;
using MVPForm.View;
using WinFormsApp1.Model;

namespace MVPForm.Presenter
{
    class EmployeePresenter
    {

        IEmployee employeeView;
        public List<string> lista = new List<String>();
        public List<Employee> employees = new List<Employee>();
        public List<Employee> deserializedEmployees = new List<Employee>();

        public EmployeePresenter(IEmployee employeeView)
        {
            this.employeeView = employeeView;
            this.employeeView.Save += _form_Save;
            this.employeeView.Add += _form_Add;
            this.employeeView.Load += _form_Load;
            this.employeeView.Fill += _form_Fill;
        }

        private void _form_Fill(object sender, EventArgs e)
        {
            String currentLine = employeeView._currentLine;
            string[] splitedData = currentLine.Split(",");
            employeeView._name = splitedData[0];
            employeeView._surname = splitedData[1];
            employeeView._date = splitedData[2];
            employeeView._salary = splitedData[3];
            employeeView._occupation = splitedData[4];
            if (splitedData[5] == "umowa na czas nieokreślony")
            {
                employeeView._one = true;
            }
            else if(splitedData[5] == "umowa na czas określony")
            {
                employeeView._two = true;
            }
            else
            {
                employeeView._three = true;
            }
        }


        private void _form_Save(object sender, EventArgs e)
        {
            lista = employeeView._listBox;
            for (int i = 0; i < lista.Count; i++)
            {
                string[] splitedData = lista[i].Split(",");
                employees.Add(new Employee(splitedData[0], splitedData[1],
                                            splitedData[2], splitedData[3],
                                            splitedData[4], splitedData[5]));
            }

            // Serializacja do pliku
            serialize();
        }

        private void serialize()
        {
            // Serializacja do pliku
            XmlSerializer serializer = new XmlSerializer(typeof(EmployeeList));
            using (TextWriter writer = new StreamWriter(@"D:\c# projects\lab2\MVP-FORM\WinFormsApp1\Repository\employees.xml"))
            {
                EmployeeList employeeList = new EmployeeList();
                employeeList.Employees = employees;
                serializer.Serialize(writer, employeeList);
            }

        }

        private List<Employee> deserialize()
        {
            // Deserializacja z pliku
            XmlSerializer serializer = new XmlSerializer(typeof(EmployeeList));
            using (TextReader reader = new StreamReader(@"D:\c# projects\lab2\MVP-FORM\WinFormsApp1\Repository\employees.xml"))
            {
                EmployeeList employeeList = (EmployeeList)serializer.Deserialize(reader);
                employees = employeeList.Employees;
            }

            return employees;
        }

        private void _form_Load(object sender, EventArgs e)
        {
           
            
                List<Employee> deserialized = deserialize();
                List<string> lines = mapEmployeeToLine(deserialized);
                List<string> updatedList = new List<string>(); 

                // Clear the ListBoxData property
                employeeView.ListBoxData = new List<string>();

                // Add the new data from the lista list
                for (int i = 0; i < deserialized.Count; i++)
                {
                    updatedList.Add(lines[i]);
                }

                employeeView.ListBoxData = updatedList;
            
        }


        private List<String> mapEmployeeToLine(List<Employee> desEmployees)
        {
            lista.Clear();
            for(int i =0; i<desEmployees.Count; i++)
            {
                lista.Add(desEmployees[i].Name+","+ desEmployees[i].Surname + "," +
                    desEmployees[i].Date + "," + desEmployees[i].Salary + "," +
                    desEmployees[i].Occupation + "," + desEmployees[i].Contract);
            }
            return lista;
        }

        private void _form_Add(object sender, EventArgs e)
        {
            string employeeInfo = employeeView._name + ","
                                 + employeeView._surname + ","
                                 + employeeView._date.Replace(",", ".") + ","
                                 + employeeView._salary + ","
                                 + employeeView._occupation + ",";
            if (employeeView._one)
            {
                employeeInfo += "umowa na czas nieokreślony";
            }else if(employeeView._two)
            {
                employeeInfo += "umowa na czas określony";
            }
            else
            {
                employeeInfo += "umowa zlecenie";
            }
       
            lista.Add(employeeInfo);
            employeeView.ListBoxData = lista;
        }

    }
}
