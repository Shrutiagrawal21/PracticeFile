using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollOffApi.DTO;
using RollOffApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBack feedbackrepo;
        private readonly IMapper mapper;
        public FeedBackController(IFeedBack feedbackrepo, IMapper mapper)
        {
            this.feedbackrepo = feedbackrepo;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddFeedbackAsync(FeedBackDTO feedBackDTO)
        {
            //DTO to Model
            var employeeForm = mapper.Map<FeedbackForm>(feedBackDTO); var response = await feedbackrepo.AddFeedbackAsync(employeeForm);             //Convert back to DTO
            var feedBackDTO2 = mapper.Map<FeedBackDTO>(response);
            return Ok(feedBackDTO2);
        }
    }
}
