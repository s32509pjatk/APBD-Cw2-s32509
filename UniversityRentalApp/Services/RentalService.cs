using UniversityRentalApp.Models;

namespace UniversityRentalApp.Services;

public class RentalService
{
    private readonly List<Rental> _rentals = new();
    private const decimal DailyPenalty = 10.0m; 
    private readonly List<Equipment> _allEquipment = new();
    
    public void AddEquipment(Equipment equipment)
    {
        _allEquipment.Add(equipment);
    }

    public string RentEquipment(User user, Equipment equipment)
    {
        if (!equipment.IsAvailable)
            return $"Błąd: {equipment.Name} jest już wypożyczony!";
        
        var activeRentalsCount = _rentals.Count(r => r.User.Id == user.Id && r.ReturnDate == null);
        if (activeRentalsCount >= user.MaxRentals)
            return $"Błąd: Użytkownik {user.Name} osiągnął limit ({user.MaxRentals}) wypożyczeń!";
        
        var rental = new Rental(equipment, user, 7);
        _rentals.Add(rental);
        equipment.IsAvailable = false;

        return $"Sukces: {user.Name} wypożyczył {equipment.Name}. Termin zwrotu: {rental.DueDate:dd.MM.yyyy}";
    }

    public string ReturnEquipment(string equipmentId, DateTime? actualReturnDate = null)
    {
        var rental = _rentals.FirstOrDefault(r => r.Equipment.Id == equipmentId && r.ReturnDate == null);
        
        if (rental == null) return "Błąd: Nie znaleziono aktywnego wypożyczenia dla tego sprzętu.";

        rental.ReturnDate = actualReturnDate ?? DateTime.Now;
        rental.Equipment.IsAvailable = true;
        
        if (rental.ReturnDate > rental.DueDate)
        {
            var delay = (rental.ReturnDate.Value - rental.DueDate).Days;
            var penalty = delay * DailyPenalty;
            return $"Zwrot przyjęty. Uwaga: Spóźnienie {delay} dni. Kara: {penalty} PLN.";
        }

        return "Zwrot przyjęty o czasie";
    }
    public void ShowInventoryReport()
    {
        Console.WriteLine("RAPORT STANU MAGAZYNOWEGO");
        foreach (var e in _allEquipment)
        {
            string status = e.IsAvailable ? "DOSTĘPNY" : "WYPOŻYCZONY";
            Console.WriteLine($"ID: {e.Id} | {e.Name} | Status: {status}");
        }
    }

    public List<Equipment> GetAvailableEquipment() => 
        _allEquipment.Where(e => e.IsAvailable).ToList();

    public void ShowOverdueReport()
    {
        Console.WriteLine("LISTA PRZETERMINOWANYCH WYPOŻYCZEŃ");

        var overdue = _rentals
            .Where(r => r.ReturnDate == null && DateTime.Now > r.DueDate)
            .ToList();

        if (!overdue.Any())
        {
            Console.WriteLine("Brak przeterminowanych wypożyczeń.");
            return;
        }

        foreach (var r in overdue)
        {
            Console.WriteLine(
                $"Użytkownik: {r.User.Name} | Sprzęt: {r.Equipment.Name} | Termin minął: {r.DueDate:dd.MM.yyyy}");
        }
    }
}