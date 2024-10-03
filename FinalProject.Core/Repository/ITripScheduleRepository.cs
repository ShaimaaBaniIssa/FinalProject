﻿using FinalProject.Core.Data;

namespace FinalProject.Core.Repository
{
    public interface ITripScheduleRepository
    {
        List<Tripschedule> GetAllTripSchedules();
        Tripschedule GetTripScheduleById(int id);
        void CreateTripSchedule(Tripschedule tripSchedule);
        void UpdateTripSchedule(Tripschedule tripSchedule);
        void DeleteTripSchedule(int id);
    }
}