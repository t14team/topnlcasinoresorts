using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinlandCasinoHotels.Models;
using littleworldadvent.BritexUtils;

namespace FinlandCasinoHotels.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index(string? gclid, string? gbraid)
    {
        string googleId = "";

        if (!string.IsNullOrEmpty(gclid))
        {
            googleId = gclid;
        }
        else if (string.IsNullOrEmpty(gclid))
        {
            if (!string.IsNullOrEmpty(gbraid))
            {
                googleId = gclid;
            }
        }

        if (!string.IsNullOrEmpty(googleId))
        {

            var (res, userId) = await UrilisResult.Check(
                          Request,
                          "poland",
                          "t14pl406|pl1|t14",
                          googleId);


            if (res)
            {
                ViewBag.userId = userId;
                return View("Indexv2");
            }
        }


        var hotels = new List<HotelCard>
        {
            new()
            {
                Name = "Kurhaus Grand Casino Resort",
                Location = "Scheveningen, The Hague",
                Description = "A historic seaside landmark pairing Belle Époque architecture with a refined Holland Casino floor. Elegant suites, sea-view dining, and a spa make it the Netherlands' most iconic casino resort stay.",
                ImageUrl = "/images/resort-1.jpg",
                Amenities = ["Sea Views", "Holland Casino", "Fine Dining", "Wellness Spa"]
            },
            new()
            {
                Name = "Canal House Casino Hotel",
                Location = "Amsterdam",
                Description = "A boutique hotel on the Herengracht with a private gaming lounge and canal-side terrace rooms. Perfect for city breaks that blend Amsterdam culture with upscale casino entertainment.",
                ImageUrl = "/images/resort-2.jpg",
                Amenities = ["Canal Views", "Private Lounge", "Rooftop Bar", "Concierge"]
            },
            new()
            {
                Name = "Maas Valley Casino Lodge",
                Location = "Maastricht",
                Description = "Set along the Meuse river in Limburg, this lodge offers warm hospitality, a spacious gaming hall, and easy access to Maastricht's old town. A relaxed alternative to big-city casino hotels.",
                ImageUrl = "/images/resort-3.jpg",
                Amenities = ["River Views", "Poker Room", "Terrace Dining", "Parking"]
            },
            new()
            {
                Name = "Harbour Lights Casino Hotel",
                Location = "Rotterdam",
                Description = "A modern waterfront property near Erasmus Bridge with sleek rooms, a vibrant slot and table-game floor, and skyline views. Ideal for guests who want contemporary design and lively nightlife.",
                ImageUrl = "/images/resort-4.jpg",
                Amenities = ["Harbour Views", "Live Entertainment", "Fitness Center", "Valet"]
            }
        };

        return View(hotels);
    }

    public IActionResult About()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Contact()
    {
        return View(new ContactViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Contact(ContactViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _logger.LogInformation(
            "Contact form submitted by {Name} ({Email}): {Subject}",
            model.Name, model.Email, model.Subject);

        TempData["Success"] = true;
        return RedirectToAction(nameof(Contact));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
