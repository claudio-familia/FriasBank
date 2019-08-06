using FriaBank.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriaBank.Services
{
    public interface IBeerService
    {
        Task<IEnumerable<Beer>> GetAllSeriesAsync(int page, int perPage);
    }
}
