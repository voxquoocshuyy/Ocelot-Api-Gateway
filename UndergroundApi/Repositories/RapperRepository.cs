using UndergroundApi.Entities;

namespace UndergroundApi.Repositories;

public class RapperRepository : IRapperRepository
{
    private readonly OcelotUndergroundContext _context;

    public RapperRepository(OcelotUndergroundContext context)
    {
        _context = context;
    }

    public List<Rapper> GetRapper()
    {
        return _context.Rappers.ToList();   
    }

    public bool DeleteRapper(int id)
    {
        var rapper = _context.Rappers.FirstOrDefault(x => x.Id == id);
        if (rapper == null)
            return false;
        _context.Rappers.Remove(rapper);
        _context.SaveChanges();
        return true;
    }
}