using Dapper;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Services
{
    public class FeedbackServices: IFeedbackServices
    {

        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackServices(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }



        public List<Feedback> GetAllFeedback()
        {

            return _feedbackRepository.GetAllFeedback();
            
        }

        public void CreateFeedback(Feedback feedback)
        {
            _feedbackRepository.CreateFeedback(feedback);



        }
    }
}
