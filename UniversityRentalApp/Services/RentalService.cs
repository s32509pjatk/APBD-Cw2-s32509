using System;
using System.Collections.Generic;
using System.Linq;
using UniversityRentalApp.Models;

namespace UniversityRentalApp.Services;

public class RentalService
{
    private readonly List<Rental> _rentals = new();
    private const decimal DailyPenalty = 10.0m; 

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

    public string ReturnEquipment(string equipmentId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Equipment.Id == equipmentId && r.ReturnDate == null);
        
        if (rental == null) return "Błąd: Nie znaleziono aktywnego wypożyczenia dla tego sprzętu.";

        rental.ReturnDate = DateTime.Now;
        rental.Equipment.IsAvailable = true;
        
        if (rental.ReturnDate > rental.DueDate)
        {
            var delay = (rental.ReturnDate.Value - rental.DueDate).Days;
            var penalty = delay * DailyPenalty;
            return $"Zwrot przyjęty. Uwaga: Spóźnienie {delay} dni. Kara: {penalty} PLN.";
        }

        return "Zwrot przyjęty o czasie. Dziękujemy!";
    }
}