using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffApi.Repository
{
    public class FeedBack:IFeedBack
    {
        private readonly RollOffProjectContext context;
        public FeedBack(RollOffProjectContext context)
        {
            this.context = context;
        }
        public async Task<FeedbackForm> AddFeedbackAsync(FeedbackForm feedback)
        {
            await context.AddAsync(feedback);
            await context.SaveChangesAsync();
            return feedback;
        }
    }
}

