using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Repository
{
    public class FeedbackRepository: IFeedbackRepository
    {

        private readonly IDbContext _dbContext;
        public FeedbackRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //getAll
        public List<Feedback> GetAllFeedback()
        {

            var result = _dbContext.Connection.Query<Feedback>("Feedback_Package.GetAllFeedback", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateFeedback(Feedback feedback)
        {
            var p = new DynamicParameters();
            p.Add("p_Name", feedback.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Email", feedback.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Message",feedback.Message, dbType: DbType.String, direction: ParameterDirection.Input);
           
           
            _dbContext.Connection.Execute("Feedback_Package.CreateFeedback", p, commandType: CommandType.StoredProcedure);

        }
    }
}
