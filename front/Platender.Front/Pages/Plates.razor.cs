using Microsoft.AspNetCore.Components;
using Platender.Front.Models;
using System.Net.Http.Json;
using System.Reflection;

namespace Platender.Front.Pages
{
    public partial class Plates : ComponentBase
    {
        protected Plate plate = new Plate();
        protected string style;
        protected string numbers;
        protected bool isResponseNull = false;

        private async Task OnValidSubmit(string numbers)
        {
            var paramName = "numbers";
            Console.WriteLine(numbers + " numbers");
            var url = $"https://localhost:7037/plate?{paramName}={numbers}";

            try
            {
                var response = await HttpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var convertedResponse = await response.Content.ReadFromJsonAsync<Plate>();
                    
                    if (convertedResponse is null)
                    {
                        PlateNotFound();
                    }
                    else
                    {
                        PlateFound();
                        plate = convertedResponse;
                    }
                }
                else
                {
                    // Handle HTTP response error
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exception
            }

            if (plate != null && plate.Culture == Models.Enums.CultureCode.PL.ToString())
            {
                style = "polish-plate-style";
            }
        }

        private void PlateNotFound()
        {
            isResponseNull = true;
        }

        private void PlateFound()
        {
            isResponseNull = false;
        }

        private void ClearPlate()
        {
            plate = new Plate();
            PlateFound();
        }

        protected override void OnInitialized()
        {
            Console.WriteLine(isResponseNull);
        }

        private async Task SavePlateAsync()
        {
            var plateDto = new
            {
                Numbers = plate.Number,
                CultureCode = plate.Culture
            };

            var response = await HttpClient.PostAsJsonAsync("https://localhost:7037/plate", plateDto);

            if (response.IsSuccessStatusCode)
            {
                // Obsłuż sukces
            }
            else
            {
                // Obsłuż błąd
            }
        }
    }
}
