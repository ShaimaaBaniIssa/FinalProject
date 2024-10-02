﻿using Dapper;
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
    public class SeatRepository: ISeatRepository
    {
        private readonly IDbContext _dbContext;
        public SeatRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Seat> GetAllSeats()
        {
            IEnumerable<Seat> result = _dbContext.Connection.Query<Seat>("Seat_Package.GetAllSeats", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Seat GetSeatById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Seat>("Seat_Package.GetSeatById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();

        }
        public void CreateSeat(Seat seat)
        {
            bool availabilityValue = seat.Availability ?? false;
            var p = new DynamicParameters();
            p.Add("S_Number", seat.Seatnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("S_Availability", availabilityValue ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("S_TrainId", seat.Trainid, dbType: DbType.Int32, direction: ParameterDirection.Input);



            _dbContext.Connection.Execute("Seat_Package.CreateSeat", p, commandType: CommandType.StoredProcedure);


        }
        public void UpdateSeat(Seat seat)
        {
            bool availabilityValue = seat.Availability ?? false;

            var p = new DynamicParameters();
            p.Add("S_Id", seat.Seatid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("S_Number", seat.Seatnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("S_Availability", availabilityValue ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("S_TrainId", seat.Trainid, dbType: DbType.Int32, direction: ParameterDirection.Input);




            _dbContext.Connection.Execute("Seat_Package.UpdateSeat", p, commandType: CommandType.StoredProcedure);


        }

        public void DeleteSeat(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Seat_Package.DeleteSeat", p, commandType: CommandType.StoredProcedure);


        }
    }
}