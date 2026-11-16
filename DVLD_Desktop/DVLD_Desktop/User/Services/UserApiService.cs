using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs;
using DVLDShared.DTOs.People;
using DVLDShared.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.User.Services
{
    public class UserApiService : BaseApiService
    {
        public string LastError { get; private set; } = string.Empty;



        public async Task<LoginResponseDTO?> LoginAsync(LoginDTO dto)
        {
            try
            {
                var content = new StringContent(
               JsonConvert.SerializeObject(dto),
               Encoding.UTF8,
               "application/json");

                var res = await client.PostAsync("users/Login", content);
                var responseBody = await res.Content.ReadAsStringAsync();
                LoginResponseDTO respon = JsonConvert.DeserializeObject<LoginResponseDTO>(responseBody);



                // 1. إذا كان الرد غير ناجح (مثل خطأ 400 الخاص بالـ ImagePath)
                if (!res.IsSuccessStatusCode)
                {
                    ParseAndSetLastError(responseBody); // استخراج رسالة الخطأ لتخزينها في LastError
                    return respon;
                }

                // 2. حالة النجاح (200 OK)
                LastError = string.Empty;
                return respon;
            }
           
        
            catch (Exception ex)
            {
                LastError = "Server connection failed: " + ex.Message;
                return null;
            }
}


        public async Task<List<UsersListDTO>?> GetAllUsersAsync()
        {
            return await GetAsync<List<UsersListDTO>>("users/All");
        }

        public async Task<UsersListDTO?> GetUserByIdAsync(int id)
        {
            return await GetAsync<UsersListDTO>($"users/{id}");
        }

        public async Task<SuccessMessageResponseIdDTO> AddUserAsync(AddNewUserDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PostAsync("users/Add", content);
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





        public async Task<SuccessMessageResponseDTO?> UpdateUserAsync(int id, UpdateUserDTO dto)
        {
            try
            {
                dto.UserID = id;
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PutAsync($"users/Update/{id}", content);
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
            




        
    
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await DeleteAsync($"users/Delete/{id}");
        }


        public async Task<SuccessMessageResponseDTO?> VerifyCurrentPassword(int userID, string password)
        {
            try
            {
                var json = JsonConvert.SerializeObject(password);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PostAsync($"users/VerifyPassword/{userID}", content);
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


        public async Task<SuccessMessageResponseDTO?> ChangePassword(int userID, string newPassword)
        {
            try
            {
                var json = JsonConvert.SerializeObject(newPassword);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var res = await client.PutAsync($"users/ChangePassword/{userID}", content);
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
}