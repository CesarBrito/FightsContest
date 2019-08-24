using FightsContest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FightsContest.Domain.Interfaces.Repository
{
    public interface IFightersRepository
    {
        List<Fighter> Get();
    }
}
