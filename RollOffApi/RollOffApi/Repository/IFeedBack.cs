using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffApi.Repository
{
    public interface IFeedBack
    {
        Task<FeedbackForm> AddFeedbackAsync(FeedbackForm feedback);
    }
}
