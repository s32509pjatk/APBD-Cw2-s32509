# University Rental App - System Wypożyczalni Uniwersytetu

Projekt zaliczeniowy z przedmiotu APBD. Aplikacja zarządza sprzętem uniwersyteckim, pilnuje limitów i nalicza kary.

## Instrukcja uruchomienia
1. Otwórz projekt w JetBrains Rider.
2. Uruchom aplikację (zielona strzałka).
3. Wyniki testów scenariusza (limity, kary, raporty) wyświetlą się w konsoli.

## Architektura i Decyzje Projektowe

Projekt został podzielony na wyraźne warstwy, aby oddzielić dane od logiki:
1. **Models (Domena):**Klasy reprezentujące byty (Laptop, Student, Rental). Klasy `Equipment` i `User` są abstrakcyjne, co zapobiega tworzeniu niepełnych obiektów.
2. **Services (Logika Biznesowa):** Klasa `RentalService` odpowiada za reguły, sprawdzanie limitów i naliczanie kar.
3. **Program.cs (Prezentacja):** Punkt wejścia wyświetlający działanie systemu.

### 1. Kohezja i Odpowiedzialność (SRP)
Każda klasa ma jedno zadanie. Modele przechowują stan, a `RentalService` zarządza procesem. Dzięki temu kod jest przejrzysty i łatwy w utrzymaniu.

### 2. Niskie sprzężenie (Low Coupling)
Serwis `RentalService` operuje na klasie abstrakcyjnej `Equipment`. Dzięki temu nie musi znać szczegółów technicznych laptopów czy kamer. Dodanie nowego rodzaju sprzętu nie wymaga zmian w logice serwisu.

### 3. Logika kar i limitów
- **Limity:** Student (2), Pracownik (5). Zaimplementowane przez nadpisywanie właściwości w klasach pochodnych.
- **Kary:** System automatycznie wylicza karę 10 PLN za każdy dzień zwłoki ($K = d \times 10$).

### 4. Hermetyzacja
Właściwości takie jak `IsAvailable` w klasie sprzętu są zmieniane tylko przez metody serwisu, co gwarantuje spójność danych w całym cyklu życia obiektu.
