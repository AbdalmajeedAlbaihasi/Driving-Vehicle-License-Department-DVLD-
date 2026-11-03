using DVLDDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDShared.DTOs.Test_Appointment;
using Microsoft.EntityFrameworkCore;

namespace DVLDDataAccess
{
    public class clsTestAppointmentDataAccess
    {
        private readonly DVLDContext _context;
        public clsTestAppointmentDataAccess(DVLDContext context)
        {
            _context = context;
        }

        


            // 1. Get Test Appointment Info By ID
            public async Task<TestAppointmentDTO?> GetTestAppointmentInfoByIDAsync(
                int testAppointmentID)
            {
                try
                {
                    return await _context.TestAppointments
                        .AsNoTracking()
                        .Where(t => t.TestAppointmentId == testAppointmentID)
                        .Select(t => new TestAppointmentDTO
                        (
                            t.TestAppointmentId,
                            t.TestTypeId,
                            t.LocalDrivingLicenseApplicationId,
                            t.AppointmentDate,
                            t.PaidFees,
                            t.CreatedByUserId,
                            t.IsLocked
                        )).FirstOrDefaultAsync();
                }
                catch
                {
                    return null;
                }
            }

            // 2. Get Last Test Appointment
            public async Task<TestAppointmentDTO?> GetLastTestAppointmentAsync(
                int localDrivingLicenseApplicationID,
                int testTypeID)
            {
                try
                {
                    return await _context.TestAppointments
                        .AsNoTracking()
                        .Where(t =>
                            t.LocalDrivingLicenseApplicationId == localDrivingLicenseApplicationID &&
                            t.TestTypeId == testTypeID)
                        .OrderByDescending(t => t.TestAppointmentId)
                        .Select(t => new TestAppointmentDTO
                        (
                            t.TestAppointmentId,
                            t.TestTypeId,
                            t.LocalDrivingLicenseApplicationId,
                            t.AppointmentDate,
                            t.PaidFees,
                            t.CreatedByUserId,
                            t.IsLocked
                        ))
                        .FirstOrDefaultAsync();
                }
                catch
                {
                    return null;
                }
            }

            // 3. Get All Test Appointments
            public async Task<List<TestAppointmentViewDTO>> GetAllTestAppointmentsAsync()
            {
                try
                {
                    return await _context.TestAppointmentsViews
                        .AsNoTracking()
                        .OrderByDescending(t => t.AppointmentDate)
                        .Select(t => new TestAppointmentViewDTO
                        (
                            t.TestAppointmentId,
                            t.AppointmentDate,
                            t.PaidFees,
                            t.IsLocked
                        ))
                        .ToListAsync();
                }
                catch
                {
                    return new List<TestAppointmentViewDTO>();
                }
            }

            // 4. Get Application Test Appointments Per Test Type
            public async Task<List<TestAppointmentListDTO>>
                GetApplicationTestAppointmentsPerTestTypeAsync(
                    int localDrivingLicenseApplicationID,
                    int testTypeID)
            {
                try
                {
                    return await _context.TestAppointments
                        .AsNoTracking()
                        .Where(t =>
                            t.TestTypeId == testTypeID &&
                            t.LocalDrivingLicenseApplicationId ==
                            localDrivingLicenseApplicationID)
                        .OrderByDescending(t => t.TestAppointmentId)
                        .Select(t => new TestAppointmentListDTO
                        (
                            t.TestAppointmentId,
                            t.AppointmentDate,
                            t.PaidFees,
                            t.IsLocked
                        ))
                        .ToListAsync();
                }
                catch
                {
                    return new List<TestAppointmentListDTO>();
                }
            }

            // 5. Add New Test Appointment
            public async Task<int> AddNewTestAppointmentAsync(AddNewTestAppointmentDTO dto)
            {
                try
                {
                    var testAppointment = new TestAppointment
                    {
                        TestTypeId = dto.TestTypeId,
                        LocalDrivingLicenseApplicationId =
                            dto.LocalDrivingLicenseApplicationId,
                        AppointmentDate = dto.AppointmentDate,
                        PaidFees = dto.PaidFees,
                        CreatedByUserId = dto.CreatedByUserId,
                        IsLocked = false,
                    };

                    await _context.TestAppointments.AddAsync(testAppointment);

                    await _context.SaveChangesAsync();

                    return testAppointment.TestAppointmentId;
                }
                catch
                {
                    return -1;
                }
            }

            // 6. Update Test Appointment
            public async Task<bool> UpdateTestAppointmentAsync(UpdateTestAppointmentDTO dto)
            {
                try
                {
                    var testAppointment = await _context.TestAppointments
                        .FirstOrDefaultAsync(t =>
                            t.TestAppointmentId == dto.TestAppointmentId);

                    if (testAppointment == null)
                        return false;

                    testAppointment.TestTypeId = dto.TestTypeId;

                    testAppointment.LocalDrivingLicenseApplicationId =
                        dto.LocalDrivingLicenseApplicationId;

                    testAppointment.AppointmentDate = dto.AppointmentDate;

                    testAppointment.PaidFees = dto.PaidFees;
                    testAppointment.CreatedByUserId = dto.CreatedByUserId;

                    testAppointment.IsLocked = dto.IsLocked;


                    int rowsAffected = await _context.SaveChangesAsync();

                    return rowsAffected > 0;
                }
                catch
                {
                    return false;
                }
            }

            // 7. Get Test ID
            public async Task<int> GetTestIDAsync(int testAppointmentID)
            {
                try
                {
                    int? testID = await _context.Tests
                        .AsNoTracking()
                        .Where(t => t.TestAppointmentId == testAppointmentID)
                        .Select(t => (int?)t.TestId)
                        .FirstOrDefaultAsync();

                    return testID ?? -1;
                }
                catch
                {
                    return -1;
                }
            }
        }
    

    
}


