using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PretragaLetaController : ControllerBase
{
    private readonly CheapFlyDbContext _context;
    private readonly AmadeusFlight _amadeusFlight;

    public PretragaLetaController(CheapFlyDbContext context, AmadeusFlight amadeusFlight)
    {
        _context = context;
        _amadeusFlight = amadeusFlight;  // Inicijaliziramo _amadeusFlight
    }


    [HttpGet]
    public async Task<IActionResult> SearchFlights(string polazniAerodrom, string odredisniAerodrom, DateTime datumPolaska, DateTime datumPovratka, int putnici, string valuta)
    {
        // Provjeri lokalnu bazu za postojeće podatke pretrage
        var searchResult = _context.PretragaLeta
            .Where(f => f.polazniAerodrom == polazniAerodrom && f.odredisniAerodrom == odredisniAerodrom
                        && f.datumPolaska == datumPolaska && f.datumPovratka == datumPovratka && f.valuta == valuta)
            .FirstOrDefault();

        if (searchResult != null)
        {
            return Ok(searchResult);
        }

        
        // Ako nema lokalno spremljenih podataka, dohvaćamo podatke s Amadeus API-d
        var ponudeLetova = await _amadeusFlight.GetFlightOffers(polazniAerodrom, odredisniAerodrom, datumPolaska.ToString("yyyy-MM-dd"), datumPovratka.ToString("yyyy-MM-dd"), putnici, valuta);


        if (ponudeLetova == null)
        {
            Console.WriteLine("Amadeus API nije vratio ponudu letova.");
            return BadRequest("Nije pronađena ni jedna ponuda leta.");
        }

        Console.WriteLine($"Amadeus API vraća sljedeći odgovor: {ponudeLetova}");
        // Dodaj logiku za spremanje novih podataka u bazu nakon što dobiješ rezultate
        // Možeš parsirati flightOffers JSON i pretvoriti ga u FlightSearch objekt, a zatim spremiti u bazu

        return Ok(ponudeLetova);  // Trenutno vraćamo sirovi JSON odgovor
    }
}
