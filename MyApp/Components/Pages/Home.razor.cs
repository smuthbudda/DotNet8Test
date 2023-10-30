using Microsoft.AspNetCore.Components;
using MyApp.Logic.Models;
using MyApp.Logic.Repositories;
namespace MyApp.Components.Pages;

public partial class Home
{
    [Inject]
    protected AthleteRepository _athleteRepository { get; set; } = default!;

    private List<Athlete> Athletes { get; set; } = new();
    private bool Loading { get; set; } = true;

    protected override async Task OnInitializedAsync()
    {
        await LoadAthletes();
        Loading = false;
        StateHasChanged();
    }

    private async Task LoadAthletes() => Athletes = await _athleteRepository.GetAllAthletes();

    private async Task GenerateAthlete()
    {
        var athlete = new Athlete() { FirstName = "Jordan", LastName = "Samson", Event = "200m" };
        await _athleteRepository.InsertAthlete(athlete);
        Loading = true;
        Athletes = await _athleteRepository.GetAllAthletes();
        Loading = false;
        StateHasChanged();
    }
}