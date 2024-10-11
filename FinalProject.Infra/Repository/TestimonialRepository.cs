using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.DTO;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infra.Repository
{
    public class TestimonialRepository: ITestimonialRepository
    {
        private readonly IDbContext _dbContext;
        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public List<Testimonial> GetAllTestimonials()
        //{
        //    IEnumerable<Testimonial> result = _dbContext.Connection.Query<Testimonial>("Testimonial_Package.GetAllTestimonials", commandType: CommandType.StoredProcedure);
        //    return result.ToList();
        //}
        public List<TestimonialDTO> GetAllTestimonials()
        {
            IEnumerable<TestimonialDTO> result = _dbContext.Connection.Query<TestimonialDTO>("Testimonial_Package.GetAllTestimonials", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public TestimonialDTO GetTestimonialById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<TestimonialDTO>("Testimonial_Package.GetTestimonialById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();

        }
        public void CreateTestimonial(Testimonial testimonial)
        {
            
            var p = new DynamicParameters();
            p.Add("Cust_Id", testimonial.Customerid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Station_Id", testimonial.Stationid , dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("T_Rating", testimonial.Rating, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("T_Comment", testimonial.Commenttext, dbType: DbType.String, direction: ParameterDirection.Input);


            _dbContext.Connection.Execute("Testimonial_Package.CreateTestimonial", p, commandType: CommandType.StoredProcedure);


        }
        public void UpdateTestimonial(Testimonial testimonial)
        {

            var p = new DynamicParameters();
            p.Add("T_Id", testimonial.Testimonialid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Cust_Id", testimonial.Customerid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Station_Id", testimonial.Stationid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("T_Rating", testimonial.Rating, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("T_Comment", testimonial.Commenttext, dbType: DbType.String, direction: ParameterDirection.Input);




            _dbContext.Connection.Execute("Testimonial_Package.UpdateTestimonial", p, commandType: CommandType.StoredProcedure);


        }

        public void DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Testimonial_Package.DeleteTestimonial", p, commandType: CommandType.StoredProcedure);


        }

        
    }
}
