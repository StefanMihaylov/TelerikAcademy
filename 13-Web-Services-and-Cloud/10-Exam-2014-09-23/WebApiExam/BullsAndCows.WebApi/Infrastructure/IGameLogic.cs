using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.WebApi.Infrastructure
{
    public interface IGameLogic
    {
        bool IsNumberValid(int number);

        Tuple<int, int> CalculateBullsAndCows(int number, int guess);

        long CalculateScore(int wins, int losses);
    }
}
