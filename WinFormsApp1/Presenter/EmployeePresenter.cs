using System;
using System.Collections.Generic;
using MVPForm.View;

namespace MVPForm.Presenter
{
    class EmployeePresenter
    {

        IEmployee employeeView;
        List<string> lista = new List<String>();

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
            // tutaj splituj springa i wsadz dane do formularza na odpowiednie miejsca;
        }

        private void _form_Save(object sender, EventArgs e)
        {
            lista = employeeView._listBox;
            // tutaj zaimplementuj zapis (serializacje)
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
            // zaimplementuj dodawanie do glownej listy tak ze zbierasz dane z formularza, budujesz string i dodajesz do listy      
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
