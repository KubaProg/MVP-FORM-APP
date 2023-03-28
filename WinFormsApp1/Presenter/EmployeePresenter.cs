using System;
using MVPForm.View;

namespace MVPForm.Presenter
{
    class EmployeePresenter
    {

        IEmployee employeeView;

        public EmployeePresenter(IEmployee employeeView)
        {
            this.employeeView = employeeView;
            this.employeeView.SaveAttempted += _form_SaveAttempted;
        }

        private void _form_SaveAttempted(object sender, EventArgs e)
        {
            employeeView.descriptionText = "SUKCES";
        }





    }
}
