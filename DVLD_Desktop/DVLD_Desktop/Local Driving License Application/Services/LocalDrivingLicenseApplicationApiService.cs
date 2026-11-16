using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs;
using DVLDShared.DTOs.LocalDrivingLicenseApplications;
using DVLDShared.DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.Local_Driving_License_Application.Services
{
    public class LocalDrivingLicenseApplicationApiService : BaseApiService
    {
        public string LastError { get; private set; } = string.Empty;


        public async Task<List<LocalDrivingLicenseApplicationListDTO>?> GetAllLocalDrivingLicenseApplication()
        {
            return await GetAsync<List<LocalDrivingLicenseApplicationListDTO>>("LocalDrivingLicenseApplication/All");
        }

        public async Task<LocalDrivingLicenseApplicationInfoDTO?>
            GetLocalDrivingLicenseApplicationInfoByIDAsync(int id)
        {
            return await GetAsync<LocalDrivingLicenseApplicationInfoDTO>(
                $"LocalDrivingLicenseApplication/{id}");
        }
        public async Task<GetOneLocalDrivingLicenseApplicationDTO?> GetOneLocalDrivingLicenseApplicationsAsync(int id)
        {
            return await GetAsync<GetOneLocalDrivingLicenseApplicationDTO>("LocalDrivingLicenseApplication/{id}");
        }

        

        public async Task<SuccessMessageResponseDTO?> UpdateLocalDrivingLicenseApplicationStatus(int id,UpdateStatusDTO updateStatusDTO)
        {
            try
            {
                var json = JsonConvert.SerializeObject(updateStatusDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PutAsync($"LocalDrivingLicenseApplication/UpdateStatus", content);
                var responseBody = await res.Content.ReadAsStringAsync();

                SuccessMessageResponseDTO respon = JsonConvert.DeserializeObject<SuccessMessageResponseDTO>(responseBody);

                if (!res.IsSuccessStatusCode)
                {
                    ParseAndSetLastError(responseBody); // استخراج رسالة الخطأ لتخزينها في LastError
                    return respon;
                }
                LastError = string.Empty;
                return respon;
            }
            catch (Exception ex)
            {
                LastError = "Server connection failed: " + ex.Message;
                return null;
            }
        }

        public async Task<SuccessMessageResponseIdDTO> AddNewLocalDrivingLicenseApplicationAsync(AddNewLocalDrivingLicenseApplicationDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PostAsync("LocalDrivingLicenseApplication/Add", content);
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


        private void ParseAndSetLastError(string responseBody)
        {
            try
            {
                var obj = JObject.Parse(responseBody);

                // Check for custom backend controller error: {"Error": "..."}
                if (obj["Error"] != null)
                {
                    LastError = obj["Error"].ToString();
                    return;
                }

                // Check for ASP.NET Validation errors: {"errors": {"Address": ["The Address field is required."]}}
                if (obj["errors"] != null)
                {
                    var errorsList = new List<string>();
                    foreach (var prop in obj["errors"].Children<JProperty>())
                    {
                        foreach (var err in prop.Value)
                        {
                            errorsList.Add(err.ToString());
                        }
                    }
                    LastError = string.Join("\n", errorsList);
                    return;
                }

                // Check for general ASP.NET title error: {"title": "..."}
                if (obj["title"] != null)
                {
                    LastError = obj["title"].ToString();
                    return;
                }

                LastError = responseBody;
            }
            catch
            {
                // Fallback to raw response if not a valid JSON structure
                LastError = responseBody;
            }
        }

    }

    //public class UserApiService : BaseApiService
    //{


    //    public async Task<UsersListDTO?> GetUserByIdAsync(int id)
    //    {
    //        return await GetAsync<UsersListDTO>($"users/{id}");
    //    }







    //    public async Task<SuccessMessageResponseDTO?> UpdateUserAsync(int id, UpdateUserDTO dto)
    //    {
    //        try
    //        {
    //            dto.UserID = id;
    //            var json = JsonConvert.SerializeObject(dto);
    //            var content = new StringContent(json, Encoding.UTF8, "application/json");

    //            var res = await client.PutAsync($"users/Update/{id}", content);
    //            var responseBody = await res.Content.ReadAsStringAsync();

    //            SuccessMessageResponseDTO respon = JsonConvert.DeserializeObject<SuccessMessageResponseDTO>(responseBody);

    //            if (!res.IsSuccessStatusCode)
    //            {
    //                ParseAndSetLastError(responseBody); // استخراج رسالة الخطأ لتخزينها في LastError
    //                return respon;
    //            }
    //            LastError = string.Empty;
    //            return respon;
    //        }
    //        catch (Exception ex)
    //        {
    //            LastError = "Server connection failed: " + ex.Message;
    //            return null;
    //        }
    //    }







    //    public async Task<bool> DeleteUserAsync(int id)
    //    {
    //        return await DeleteAsync($"users/Delete/{id}");
    //    }


     


       

    //    private void ParseAndSetLastError(string responseBody)
    //    {
    //        try
    //        {
    //            var obj = JObject.Parse(responseBody);

    //            // Check for custom backend controller error: {"Error": "..."}
    //            if (obj["Error"] != null)
    //            {
    //                LastError = obj["Error"].ToString();
    //                return;
    //            }

    //            // Check for ASP.NET Validation errors: {"errors": {"Address": ["The Address field is required."]}}
    //            if (obj["errors"] != null)
    //            {
    //                var errorsList = new List<string>();
    //                foreach (var prop in obj["errors"].Children<JProperty>())
    //                {
    //                    foreach (var err in prop.Value)
    //                    {
    //                        errorsList.Add(err.ToString());
    //                    }
    //                }
    //                LastError = string.Join("\n", errorsList);
    //                return;
    //            }

    //            // Check for general ASP.NET title error: {"title": "..."}
    //            if (obj["title"] != null)
    //            {
    //                LastError = obj["title"].ToString();
    //                return;
    //            }

    //            LastError = responseBody;
    //        }
    //        catch
    //        {
    //            // Fallback to raw response if not a valid JSON structure
    //            LastError = responseBody;
    //        }
    //    }
    //}
}
