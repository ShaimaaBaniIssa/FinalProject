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
        public Aboutuspage  GetAllAboutPages()
        {
            var result = _dbContext.Connection.Query<Aboutuspage>("Aboutuspage_Package.GetAllAboutPages", commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public void CreateAboutUsPage(Aboutuspage aboutuspage)
        {
            var p = new DynamicParameters();
            p.Add("p_AboutImage", aboutuspage.About_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutTitle", aboutuspage.About_Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutText", aboutuspage.About_Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg1", aboutuspage.Point_Img_1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img1", aboutuspage.Img_1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg2", aboutuspage.Point_Img_2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img2", aboutuspage.Img_2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg3", aboutuspage.Point_Img_3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img3", aboutuspage.Img_3, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Aboutuspage_Package.CreateAboutUsPage", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateAboutUsPage(Aboutuspage aboutuspage)
        {
            var p = new DynamicParameters();
            p.Add("p_AboutId", aboutuspage.About_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_AboutImage", aboutuspage.About_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutTitle", aboutuspage.About_Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AboutText", aboutuspage.About_Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg1", aboutuspage.Point_Img_1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img1", aboutuspage.Img_1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg2", aboutuspage.Point_Img_2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img2", aboutuspage.Img_2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PointImg3", aboutuspage.Point_Img_3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Img3", aboutuspage.Img_3, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("Aboutuspage_Package.UpdateAboutUsPage", p, commandType: CommandType.StoredProcedure);

        }


    }
}
