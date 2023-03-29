using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MVPForm.Model;
using MVPForm.View;

namespace MVPForm.Presenter
{
    class EmployeePresenter
    {

        IEmployee employeeView;
        public List<string> lista = new List<String>();
        public List<Employee> employees = new List<Employee>();

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
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            using (TextWriter writer = new StreamWriter(@"D:\c# projects\lab2\MVP-FORM\WinFormsApp1\Repository\employees.xml"))
            {
                serializer.Serialize(writer, employees);
            }
        }


        private void _form_Load(object sender, EventArgs e)
        {    
            lista = employeeView._listBox;
            lista.Add("One");
            lista.Add("Two");
            lista.Add("Three");
            employeeView.ListBoxData = lista;
            // tutaj zaimplementuj odczyt (deserializacje) i wyświetl listy do listboxa

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
