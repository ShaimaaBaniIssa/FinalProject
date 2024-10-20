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
    public class HomePageRepository: IHomePageRepository
    {
        private readonly IDbContext _dbContext;

        public HomePageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Homepage> GetAllHomePages()
        {
            var result = _dbContext.Connection.Query<Homepage>("HomePage_Package.GetAllHomePages", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void CreateHomePage(Homepage homepage)
        {
            var p = new DynamicParameters();
            p.Add("p_LogoImage", homepage.Logoimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_WebsiteTitle", homepage.Websitetitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TopText", homepage.Toptext, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_FormImage", homepage.Formimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TitleAboutText", homepage.Titileabouttext, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutText1", homepage.Abouttext1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutText2", homepage.Abouttext2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TrainLogo", homepage.Trainlogo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointAboutText1", homepage.Pointabouttext1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointAboutText2", homepage.Pointabouttext2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DestTitle", homepage.Desttitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DestText", homepage.Desttext, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("HomePage_Package.CreateHomePage", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateHomePage(Homepage homepage)
        {
            var p = new DynamicParameters();
            p.Add("p_HomePageId", homepage.Homepageid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_LogoImage", homepage.Logoimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_WebsiteTitle", homepage.Websitetitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TopText", homepage.Toptext, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_FormImage", homepage.Formimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TitleAboutText", homepage.Titileabouttext, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutText1", homepage.Abouttext1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutText2", homepage.Abouttext2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TrainLogo", homepage.Trainlogo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointAboutText1", homepage.Pointabouttext1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointAboutText2", homepage.Pointabouttext2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DestTitle", homepage.Desttitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DestText", homepage.Desttext, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("HomePage_Package.UpdateHomePage", p, commandType: CommandType.StoredProcedure);
        }

        }
}
