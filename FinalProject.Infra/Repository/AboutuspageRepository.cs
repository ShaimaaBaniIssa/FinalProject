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
    public class AboutuspageRepository : IAboutuspageRepository
    {
        private readonly IDbContext _dbContext;
        public AboutuspageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Aboutuspage> GetAllAboutUsPages()
        {

            var result = _dbContext.Connection.Query<Aboutuspage>("AboutUsPage_Package.GetAllAboutUsPages", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void CreateAboutUsPage(Aboutuspage aboutuspage)
        {
            var p = new DynamicParameters();
            p.Add("p_AboutImage", aboutuspage.Aboutimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutTitle", aboutuspage.Abouttitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutText", aboutuspage.Abouttext, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg1", aboutuspage.Pointimg1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img1", aboutuspage.Img1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg2", aboutuspage.Pointimg2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img2", aboutuspage.Img2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg3", aboutuspage.Pointimg3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img3", aboutuspage.Img3, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("AboutUsPage_Package.CreateAboutUsPage", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateAboutUsPage(Aboutuspage aboutuspage)
        {
            var p = new DynamicParameters();
            p.Add("p_AboutId", aboutuspage.Aboutid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_AboutImage", aboutuspage.Aboutimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutTitle", aboutuspage.Abouttitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutText", aboutuspage.Abouttext, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg1", aboutuspage.Pointimg1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img1", aboutuspage.Img1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg2", aboutuspage.Pointimg2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img2", aboutuspage.Img2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg3", aboutuspage.Pointimg3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img3", aboutuspage.Img3, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("AboutUsPage_Package.CreateAboutUsPage", p, commandType: CommandType.StoredProcedure);

        }


    }
}
