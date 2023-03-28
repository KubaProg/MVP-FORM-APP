using System;

namespace MVPForm.View
{
    public interface IEmployee
    {

        string descriptionText { get; set; }

        event EventHandler SaveAttempted;


        // tutaj masz stworzyc pola typu emailText, numerText itd wraz z {get; set;}
        // ale rowniez np descriptionText to co ma sie z prawej strony wyswietlac po wczytaniu

    }
}
