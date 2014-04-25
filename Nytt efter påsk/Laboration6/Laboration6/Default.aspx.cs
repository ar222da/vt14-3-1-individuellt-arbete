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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
          get { return _service ?? (_service = new Service()); }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Contact> ContactListView_GetData()
        {
            try
            {
                return Service.GetContacts();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kontaktuppgifter skulle hämtas.");
                return null;
            }
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            ListView1.InsertItemPosition = InsertItemPosition.None;
            Button1.Enabled = true;
            
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveContact(contact);
                }
                catch (Exception ex)
                {
                    var validationResults = ex.Data["ValidationResults"] as IEnumerable<ValidationResult>;
                    if (validationResults != null && validationResults.Any())
                    {
                        foreach (var validationResult in validationResults)
                        {
                            foreach (var memberName in validationResult.MemberNames)
                            {
                                ModelState.AddModelError(memberName, validationResult.ErrorMessage);
                            }
                        }
                    }
                    
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kontaktuppgiften skulle läggas till.");
                }
            }
        }

        public void ContactListView_UpdateItem(int contactID)
        {
            try
            {
                var contact = Service.GetContact(contactID);
                if (contact == null)
                {
                    ModelState.AddModelError(String.Empty,
                        String.Format("Kontakten med kontaktnummer {0} hittades inte.", contactID));
                    return;
                }

                if (TryUpdateModel(contact))
                {
                    Service.SaveContact(contact);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kontaktuppgiften skulle uppdateras.");
            }
        }

        public void ContactListView_DeleteItem(int contactID) 
        {
            try
            {
                Service.DeleteContact(contactID);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kontaktuppgiften skulle tas bort.");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListView1.InsertItemPosition = InsertItemPosition.FirstItem;
            Button1.Enabled = false;
            ListView1.EditIndex = -1;
        }


    }
}