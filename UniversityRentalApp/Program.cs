using System;
using UniversityRentalApp.Models;
using UniversityRentalApp.Services;

Console.WriteLine(" SYSTEM WYPOŻYCZALNI UNIWERSYTETU ");


var rentalService = new RentalService();

var student = new Student(1, "Anna Kowalska");
var employee = new Employee(100, "dr inż. Marek Nowak");

var laptop1 = new Laptop("Dell Latitude", 16, "i7");
var laptop2 = new Laptop("MacBook Air", 8, "M1");
var laptop3 = new Laptop("Asus ZenBook", 16, "Ryzen 7");
var camera = new Camera("Sony Alpha", "Full Frame", "4K");

Console.WriteLine("\n--- TEST: Limity Studenta ---");
Console.WriteLine(rentalService.RentEquipment(student, laptop1)); 
Console.WriteLine(rentalService.RentEquipment(student, laptop2)); 
Console.WriteLine(rentalService.RentEquipment(student, laptop3)); 

Console.WriteLine("\n--- TEST: Limity Pracownika ---");
Console.WriteLine(rentalService.RentEquipment(employee, laptop3));

Console.WriteLine("\n--- SZCZEGÓŁY SPRZĘTU ---");
Console.WriteLine($"Wybrany sprzęt: {laptop1.Name}");
Console.WriteLine($"Specyfikacja: RAM: {laptop1.RamSize}GB, CPU: {laptop1.CpuType}");
Console.WriteLine($"Unikalne ID (GUID): {laptop1.Id}");

Console.WriteLine("\n--- TEST: Zwrot sprzętu ---");
Console.WriteLine(rentalService.ReturnEquipment(laptop1.Id));

