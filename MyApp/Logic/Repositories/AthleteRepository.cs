using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Logic.Enums;
using MyApp.Logic.Models;
namespace MyApp.Logic.Repositories;

public class AthleteRepository : ControllerBase
{
    private readonly MyDbContext _context;

    public AthleteRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Athlete>> GetAllAthletes() => await _context.Athlete.ToListAsync();

    public async Task<(int?, APIEnums.Status)> InsertAthlete(Athlete model)
    {
        if (!ModelState.IsValid)
            return (null, APIEnums.Status.error);

        await _context.Athlete.AddAsync(model);
        await _context.SaveChangesAsync();

        return (model.ID, APIEnums.Status.success);
    }

    public async Task DeleteAthlete(int id)
    {
        var entity = await _context.Athlete.FindAsync(id);

        if (entity is not null)
            _context.Remove(entity);

        _context.SaveChanges();
    }
}
