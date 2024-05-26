using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Infrastructure;


public class CarsDTO
{
    // Eigenschappen die overeenkomen met de kolommen in de "Car" tabel
    public int CarId { get; set; }
    public string Naam { get; set; }
    public int MaximaleSnelheid { get; set; }
    public int Cc { get; set; }
    public DateTime? DatumRegistratie { get; set; }

    public CarsDTO(int carId, string naam, int maximaleSnelheid, int cc, DateTime? datumRegistratie)
    {
        CarId = carId;
        Naam = naam;
        MaximaleSnelheid = maximaleSnelheid;
        Cc = cc;
        DatumRegistratie = datumRegistratie;
    }
}