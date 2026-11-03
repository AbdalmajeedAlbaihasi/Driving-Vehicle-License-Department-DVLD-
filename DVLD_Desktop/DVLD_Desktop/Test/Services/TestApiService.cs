using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs;
using DVLDShared.DTOs.People;
using DVLDShared.DTOs.Tests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.Test.Services
{
    public class TestApiService : BaseApiService
    {
        public string LastError { get; private set; } = string.Empty;

        // Get Test By ID
        public async Task<TestDTO?> GetTestByIdAsync(int id)
        {
            return await GetAsync<TestDTO>($"Test/{id}");
        }

        // Get Last Test by Person, License Class, and Test Type
        public async Task<TestDTO?> GetLastTestAsync(int personId, int licenseClassId, int testTypeId)
        {
            return await GetAsync<TestDTO>($"Test/last/person/{personId}/license-class/{licenseClassId}/test-type/{testTypeId}");
        }

        // Get All Tests
        public async Task<List<TestDTO>?> GetAllTestsAsync()
        {
            return await GetAsync<List<TestDTO>>("Test");
        }

        // Get Passed Test Count
        public async Task<byte> GetPassedTestCountAsync(int localDrivingId)
        {
            return await GetAsync<byte>($"Test/passed-count/{localDrivingId}");
        }

        // Check if Passed All Tests
        public async Task<bool> PassedAllTestsAsync(int localDrivingId)
        {
            return await GetAsync<bool>($"Test/passed-all/{localDrivingId}");
        }

        // Update Test
        public async Task<SuccessMessageResponseIdDTO?> UpdateTestAsync(UpdateTestDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PutAsync("Test", content);
                var responseBody = await res.Content.ReadAsStringAsync();

                SuccessMessageResponseIdDTO? response = JsonConvert.DeserializeObject<SuccessMessageResponseIdDTO>(responseBody);

                if (!res.IsSuccessStatusCode)
                {
                    ParseAndSetLastError(responseBody);
                    return response;
                }

                LastError = string.Empty;
                return response;
            }
            catch (Exception ex)
            {
                LastError = "Server connection failed: " + ex.Message;
                return null;
            }
        }





        public async Task<SuccessMessageResponseIdDTO?> AddNewTestAsync(AddNewTestDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PostAsync("Test/AddNewTest", content);
                var responseBody = await res.Content.ReadAsStringAsync();

                SuccessMessageResponseIdDTO respon = JsonConvert.DeserializeObject<SuccessMessageResponseIdDTO>(responseBody);

                // 1. إذا كان الرد غير ناجح (مثل خطأ 400 الخاص بالـ ImagePath)
                if (!res.IsSuccessStatusCode)
                {
                    ParseAndSetLastError(responseBody); // استخراج رسالة الخطأ لتخزينها في LastError
                    return respon;
                }

                // 2. إذا كان الرد ناجحاً (201 Created) يتم تفكيك النتيجة فقط هنا
                LastError = string.Empty;
                return respon;
            }
            catch (Exception ex)
            {
                LastError = "Server connection failed: " + ex.Message;
                return null;
            }
        }

        // Helper to parse backend error responses
        private void ParseAndSetLastError(string responseBody)
        {
            try
            {
                var obj = JObject.Parse(responseBody);

                if (obj["Message"] != null)
                {
                    LastError = obj["Message"].ToString();
                    return;
                }

                if (obj["title"] != null)
                {
                    LastError = obj["title"].ToString();
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
