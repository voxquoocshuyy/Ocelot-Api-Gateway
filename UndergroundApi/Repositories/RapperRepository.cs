using UndergroundApi.Entities;

namespace UndergroundApi.Repositories;

public class RapperRepository : IRapperRepository
{
    private readonly OcelotUndergroundContext _context;
    private readonly ILogger<RapperRepository> _logger;

    public RapperRepository(OcelotUndergroundContext context, ILogger<RapperRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public List<Rapper> GetRapper()
    {
        try
        {
            _logger.LogInformation($"Get rapper: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            return _context.Rappers.ToList();
        }
        catch (Exception e)
        {
            _logger.LogError($"Error: {e.Message}");
            throw;
        }
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