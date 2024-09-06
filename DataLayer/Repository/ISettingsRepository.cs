using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface ISettingsRepository
    {
        Task<InitialFPSettings> GetInitialSettings();
        Task SaveInitialSettings(InitialFPSettings settings);

        Task<FavCountryAndPlayers> GetFavPlayersSettings();
        Task SaveFavPlayersSettings(FavCountryAndPlayers favCountryAndPlayers);

        Task ClearFavPlayersSettings();
    }
}
