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
   public class ContactuspageRepository: IContactuspageRepository
    {
        private readonly IDbContext _dbContext;
        public ContactuspageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //getAll
        public Contactuspage GetAllContactusPages() {

            var result = _dbContext.Connection.Query<Contactuspage>("ContactusPage_Package.GetAllContactusPages", commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateContactusPage(Contactuspage contactuspage) {
            var p =new DynamicParameters();
            p.Add("p_HeadingImage", contactuspage.Headingimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Heading", contactuspage.Heading, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Subheading", contactuspage.Subheading, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_QuoteBox", contactuspage.Quotebox, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Icon", contactuspage.Icon, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_IconText1", contactuspage.Icontext1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_IconText2", contactuspage.Icontext2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", contactuspage.Email, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("p_phon", contactuspage.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("p_ContactFormImage", contactuspage.Contactformimage, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ContactusPage_Package.CreateContactusPage", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateContactusPage(Contactuspage contactuspage)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", contactuspage.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_HeadingImage", contactuspage.Headingimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Heading", contactuspage.Heading, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Subheading", contactuspage.Subheading, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_QuoteBox", contactuspage.Quotebox, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Icon", contactuspage.Icon, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_IconText1", contactuspage.Icontext1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_IconText2", contactuspage.Icontext2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ContactFormImage", contactuspage.Contactformimage, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("p_email", contactuspage.Email, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("p_phon", contactuspage.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("ContactusPage_Package.UpdateContactusPage", p, commandType: CommandType.StoredProcedure);

        }

    }
}
