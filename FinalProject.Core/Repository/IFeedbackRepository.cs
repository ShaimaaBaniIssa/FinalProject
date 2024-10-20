using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Repository
{
    public interface IFeedbackRepository
    {
        List<Feedback> GetAllFeedback();
        void CreateFeedback(Feedback feedback);
    }
}
