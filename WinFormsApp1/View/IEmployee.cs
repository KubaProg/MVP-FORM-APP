using System;
using System.Collections.Generic;

namespace MVPForm.View
{
    public interface IEmployee
    {

        string descriptionText { get; set; }

        string _name { get; set; }

        string _surname { get; set; }

        string _date { get; set; }

        string _salary { get; set; }

        string _occupation { get; set; }
        string _currentLine { get; set; }
        List<String> _listBox { get; set; }

        public List<string> ListBoxData { get; set; }


        Boolean _one { get; set; }

        Boolean _two { get; set; }

        Boolean _three { get; set; }

        event EventHandler Save;

        event EventHandler Add;

        event EventHandler Load;

        event EventHandler Fill;

    }
}
