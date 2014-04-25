using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using Laboration6.Model;

namespace Laboration6.Pages
{
    public partial class Bookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        public IEnumerable<Booking> BookingListView_GetData()
        {
            
            try
            {
                
                if (Request.QueryString["FileName"] == null)
                {
                    return Service.GetBookings();
                }

                else
                {
                    int studentid = int.Parse(Request.QueryString["FileName"]);
                    return Service.GetBookingsByStudent(studentid);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Bokningar kunde inte visas.");
                return null;
            }
        }

        public IEnumerable<Student> BookingListView_GetStudents()
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

        public IEnumerable<PieceOfFurniture> BookingListView_GetFurniture()
        {
            try
            {
                return Service.GetFurniture();
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då möbeluppgifter skulle hämtas.");
                return null;
            }
        }

        public void BookingListView_InsertItem(Booking booking)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveBooking(booking);
                    Label1.Visible = true;
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då bokningsuppgift skulle läggas till.");
                }
            }
        }

        public void BookingListView_DeleteItem(int BookingID)
        {
            try
            {
                Service.DeleteBooking(BookingID);
                Label2.Visible = true;
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Bokning kunde inte tas bort.");
            }
        }

        public void ListView2_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            DropDownList ddl = e.Item.FindControl("DropDownList1") as DropDownList;
            if (ddl != null)
            {
                e.Values["StudentID"] = ddl.SelectedValue;
            }

            DropDownList ddl2 = e.Item.FindControl("DropDownList2") as DropDownList;
            if (ddl != null)
            {
                e.Values["PieceOfFurnitureID"] = ddl2.SelectedValue;
            }


        }

    }
}