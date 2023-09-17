using UndergroundApi.Entities;

namespace UndergroundApi.Repositories;

public interface IRapperRepository
{
    List<Rapper> GetRapper();

    bool DeleteRapper(int id);
}