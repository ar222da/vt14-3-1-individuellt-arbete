using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Laboration6.Model.DAL;
using Laboration6.App_Infrastructure;

namespace Laboration6.Model
{
    public class Service
    {
        private StudentDAL _studentDAL;

        private StudentDAL StudentDAL
        {
            get { return _studentDAL ?? (_studentDAL = new StudentDAL()); }
        }

        private PieceOfFurnitureDAL _pieceOfFurnitureDAL;

        private PieceOfFurnitureDAL PieceOfFurnitureDAL
        {
            get { return _pieceOfFurnitureDAL ?? (_pieceOfFurnitureDAL = new PieceOfFurnitureDAL()); }
        }

        private BookingDAL _bookingDAL;

        private BookingDAL BookingDAL
        {
            get { return _bookingDAL ?? (_bookingDAL = new BookingDAL()); }
        }

        public IEnumerable<Student> GetStudents()
        {
            return StudentDAL.GetStudents();
        }

        public Student GetStudent(int studentid)
        {
            return StudentDAL.GetStudentById(studentid);
        }

        public void SaveStudent(Student student)
        {
            ICollection<ValidationResult> validationResults;
            if (!student.Validate(out validationResults)) 
            {                                              
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (student.StudentID == 0) 
            {
                StudentDAL.InsertStudent(student);
            }
            else
            {
                StudentDAL.UpdateStudent(student);
            }
        }

        public void DeleteStudent(int studentID)
        {
            StudentDAL.DeleteStudent(studentID);
        }

        public IEnumerable<PieceOfFurniture> GetFurniture()
        {
            return PieceOfFurnitureDAL.GetFurniture();
        }

        public PieceOfFurniture GetPieceOfFurniture(int pieceoffurnitureID)
        {
            return PieceOfFurnitureDAL.GetPieceOfFurnitureById(pieceoffurnitureID);
        }

        public void SavePieceOfFurniture(PieceOfFurniture pieceoffurniture)
        {
            ICollection<ValidationResult> validationResults;
            if (!pieceoffurniture.Validate(out validationResults)) 
            {                                              
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (pieceoffurniture.PieceOfFurnitureID == 0) 
            {
                PieceOfFurnitureDAL.InsertPieceOfFurniture(pieceoffurniture);
            }
            else
            {
                PieceOfFurnitureDAL.UpdatePieceOfFurniture(pieceoffurniture);
            }
        }

        public void DeletePieceOfFurniture(int pieceoffurnitureID)
        {
            PieceOfFurnitureDAL.DeletePieceOfFurniture(pieceoffurnitureID);
        }

        public IEnumerable<Booking> GetBookings()
        {
            return BookingDAL.GetBookings();
        }

        public IEnumerable<Booking> GetBookingsByStudent(int studentid)
        {
            return BookingDAL.GetBookingsByID(studentid);
        }

        public void SaveBooking(Booking booking)
        {
            ICollection<ValidationResult> validationResults;
            if (!booking.Validate(out validationResults)) 
            {                                              
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
                BookingDAL.InsertBooking(booking);
        }

        public void DeleteBooking(int bookingID)
        {
            BookingDAL.DeleteBooking(bookingID);
        }

    
    
    
    }
}