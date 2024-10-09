﻿using FinalProject.Core.Data;
using FinalProject.Core.DTO;

namespace FinalProject.Core.Services
{
    public interface ITripScheduleService
    {
        List<Tripschedule> GetAllTripSchedules();
        Tripschedule GetTripScheduleById(int id);
        void CreateTripSchedule(Tripschedule tripSchedule);
        void UpdateTripSchedule(Tripschedule tripSchedule);
        void DeleteTripSchedule(int id);
        List<SearchTripDTO> SearchTrip(DateTime tDate);
    }
}
