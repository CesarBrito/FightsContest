using FightsContest.Domain.Entities.Model;
using System.Collections.Generic;

namespace FightsContest.Domain.Interfaces.Repository
{
    public interface IFightersRepository
    {
        List<Fighter> Get();
    }
}
