namespace UniversityRentalApp.Models;

public class Rental
{
    public Equipment Equipment { get; set; }
    public User User { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; } 
    
    public Rental(Equipment equipment, User user, int rentalDays)
    {
        Equipment = equipment;
        User = user;
        RentalDate = DateTime.Now;
        DueDate = DateTime.Now.AddDays(rentalDays);
    }
}