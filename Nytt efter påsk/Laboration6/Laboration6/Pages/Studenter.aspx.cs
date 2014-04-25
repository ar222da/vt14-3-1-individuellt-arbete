using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using Laboration6.Model;

namespace Laboration6
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        public IEnumerable<Student> StudentListView_GetData()
        {
            try
            {
                return Service.GetStudents();
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då studentuppgifter skulle hämtas.");
                return null;
            }
        }

        public void StudentListView_InsertItem(Student student)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveStudent(student);
                    Label1.Visible = true;
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då studentuppgift skulle läggas till.");
                }
            }
        }


        public void StudentListView_UpdateItem(int StudentID) 
        {
            try
            {
                var student = Service.GetStudent(StudentID);
                if (student == null)
                {
                    ModelState.AddModelError(String.Empty,
                        String.Format("Student med ID {0} hittades inte.", StudentID));
                    return;
                }

                if (TryUpdateModel(student))
                {
                    Service.SaveStudent(student);
                    Label2.Visible = true;
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då student skulle uppdateras.");
            }
        }

        public void StudentListView_DeleteItem(int StudentID)
        {
            try
            {
                Service.DeleteStudent(StudentID);
                Label3.Visible = true;
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då student skulle tas bort.");
            }
        }

      
    }
}