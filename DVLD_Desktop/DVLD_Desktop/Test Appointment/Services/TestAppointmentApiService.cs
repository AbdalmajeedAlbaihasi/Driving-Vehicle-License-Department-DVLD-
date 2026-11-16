
using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs;
using DVLDShared.DTOs.TestAppointment;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.Test.Service
{
    public class TestAppointmentApiService : BaseApiService
    {
        public string LastError { get; private set; } = string.Empty;


        // 1. Get Test Appointment Info By ID
        public async Task<TestAppointmentDTO?> GetTestAppointmentInfoByIDAsync(
            int id)
        {
            return await GetAsync<TestAppointmentDTO>(
                $"TestAppointment/{id}");
        }


        // 2. Get Last Test Appointment
        public async Task<TestAppointmentDTO?> GetLastTestAppointmentAsync(
            int localDrivingLicenseApplicationID,
            int testTypeID)
        {
            return await GetAsync<TestAppointmentDTO>(
                $"TestAppointment/last/local-driving/{localDrivingLicenseApplicationID}/test-type/{testTypeID}");
        }


        // 3. Get All Test Appointments
        public async Task<List<TestAppointmentViewDTO>?> GetAllTestAppointmentsAsync()
        {
            return await GetAsync<List<TestAppointmentViewDTO>>(
                "TestAppointment/all");
        }


        // 4. Get Application Test Appointments Per Test Type
        public async Task<List<TestAppointmentListDTO>?>
            GetApplicationTestAppointmentsPerTestTypeAsync(
                int localDrivingLicenseApplicationID,
                int testTypeID)
        {
            return await GetAsync<List<TestAppointmentListDTO>>(
                $"TestAppointment/local-driving/{localDrivingLicenseApplicationID}/test-type/{testTypeID}");
        }


        // 5. Add New Test Appointment
        public async Task<SuccessMessageResponseIdDTO?>
            AddNewTestAppointmentAsync(AddNewTestAppointmentDTO dto)
        {
            return await PostAndParseResponseAsync(
                "TestAppointment", dto);
        }


        // 6. Update Test Appointment
        public async Task<SuccessMessageResponseIdDTO?>
            UpdateTestAppointmentAsync(UpdateTestAppointmentDTO dto)
        {
            try
            {
                string json = JsonConvert.SerializeObject(dto);

                using var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var response = await client.PutAsync(
                    "TestAppointment",
                    content);

                string responseBody =
                    await response.Content.ReadAsStringAsync();

                var result =
                    JsonConvert.DeserializeObject<SuccessMessageResponseIdDTO>(
                        responseBody);

                if (!response.IsSuccessStatusCode)
                {
                    ParseAndSetLastError(responseBody);

                    return result ??
                        new SuccessMessageResponseIdDTO(
                            false, -1,LastError);
                }

                LastError = string.Empty;

                return result;
            }
            catch (Exception ex)
            {
                LastError = "Server connection failed: " + ex.Message;
                return null;
            }
        }


        // 7. Get Test ID By Test Appointment ID
        public async Task<int?> GetTestIDAsync(int id)
        {
            return await GetAsync<int>(
                $"TestAppointment/{id}/test-id");
        }


        // Helper: POST Request
        private async Task<SuccessMessageResponseIdDTO?>
            PostAndParseResponseAsync<T>(string endpoint, T dto)
        {
            try
            {
                string json = JsonConvert.SerializeObject(dto);

                using var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var response = await client.PostAsync(
                    endpoint,
                    content);

                string responseBody =
                    await response.Content.ReadAsStringAsync();

                var result =
                    JsonConvert.DeserializeObject<SuccessMessageResponseIdDTO>(
                        responseBody);

                if (!response.IsSuccessStatusCode)
                {
                    ParseAndSetLastError(responseBody);

                    return result ??
                        new SuccessMessageResponseIdDTO(
                            false, -1, LastError);
                }

                LastError = string.Empty;

                return result;
            }
            catch (Exception ex)
            {
                LastError = "Server connection failed: " + ex.Message;
                return null;
            }
        }


        // Helper: Parse Backend Error
        private void ParseAndSetLastError(string responseBody)
        {
            try
            {
                var obj = JObject.Parse(responseBody);

                if (obj["Message"] != null)
                {
                    LastError = obj["Message"]!.ToString();
                    return;
                }

                if (obj["title"] != null)
                {
                    LastError = obj["title"]!.ToString();
                    return;
                }

                LastError = responseBody;
            }
            catch
            {
                LastError = responseBody;
            }
        }
    }
}
