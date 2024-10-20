using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public interface IFeedbackServices
    {
        List<Feedback> GetAllFeedback();
        void CreateFeedback(Feedback feedback);
    }
}
