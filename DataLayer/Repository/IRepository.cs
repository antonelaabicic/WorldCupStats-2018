﻿using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IRepository
    {
        Task<List<Match>> GetAllMatches(Gender gender);
        Task<List<Match>> GetMatchesByFifaCode(Gender gender, string fifaCode);
        Task<List<Team>> GetAllTeams(Gender gender);
        Task<List<Result>> GetResults(Gender gender);
    }
}
