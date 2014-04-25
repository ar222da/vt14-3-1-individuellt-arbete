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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        public IEnumerable<PieceOfFurniture> FurnitureListView_GetData()
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

        public void FurnitureListView_InsertItem(PieceOfFurniture pieceoffurniture)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Service.SavePieceOfFurniture(pieceoffurniture);
                    Label1.Visible = true;
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då möbeluppgift skulle läggas till.");
                }
            }
        }


        public void FurnitureListView_UpdateItem(int PieceOfFurnitureID)
        {
            try
            {
                var pieceoffurniture = Service.GetPieceOfFurniture(PieceOfFurnitureID);
                if (pieceoffurniture == null)
                {
                    ModelState.AddModelError(String.Empty,
                        String.Format("Möbel med ID {0} hittades inte.", PieceOfFurnitureID));
                    return;
                }

                if (TryUpdateModel(pieceoffurniture))
                {
                    Service.SavePieceOfFurniture(pieceoffurniture);
                    Label2.Visible = true;
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då möbel skulle uppdateras.");
            }
        }

        public void FurnitureListView_DeleteItem(int PieceOfFurnitureID)
        {
            try
            {
                Service.DeletePieceOfFurniture(PieceOfFurnitureID);
                Label3.Visible = true;
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då möbel skulle tas bort.");
            }
        }



    }
}