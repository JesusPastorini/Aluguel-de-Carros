using RentCars.Types;

namespace RentCars.Models;

public class Rent
{
    public Vehicle Vehicle { get; set; }
    public Person Person { get; set; }
    public int DaysRented { get; set; }
    public double Price { get; set; }
    public RentStatus Status { get; set; }

    //10 - Crie o construtor de `Rent` seguindo as regras de negócio
    public Rent(Vehicle vehicle, Person person, int daysRented)
    {
        Vehicle = vehicle;
        Person = person;

        if (daysRented <= 0)
        {
            throw new ArgumentException("O número de dias alugados deve ser maior que zero.");
        }

        DaysRented = daysRented;

        CalculatePrice();
        Status = RentStatus.Confirmed;

        vehicle.IsRented = true;

        // Altera o atributo Debit da pessoa para o preço calculado
        person.Debit += Price;
    }

    private void CalculatePrice()
    {
        // calcular o preço
        double dailyRate = Vehicle.PricePerDay;

        if (Person is LegalPerson)
        {
            // Pessoas jurídicas têm desconto de 10%
            Price = dailyRate * DaysRented * 0.9;
        }
        else
        {
            // Pessoas físicas
            Price = dailyRate * DaysRented;
        }
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Cancel()
    {
        throw new NotImplementedException();
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Finish()
    {
        throw new NotImplementedException();
    }
}