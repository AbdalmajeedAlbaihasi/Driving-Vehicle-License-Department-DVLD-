using DVLDShared.DTOs;
using DVLDShared.DTOs.People;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Desktop_Net8.Services
{
    public class PeopleApiService : BaseApiService
    {
        public string LastError { get; private set; } = string.Empty;

        // 1. Get All People
        public async Task<List<PersonListDTO>?> GetAllPeopleAsync()
        {
            try
            {
                return await GetAsync<List<PersonListDTO>>("people/All");
            }
            catch (Exception ex)
            {
                LastError = "Connection error: " + ex.Message;
                return null;
            }
        }

        // 2. Get Person by ID
        public async Task<OnePeopleDTO?> GetPersonByPersonIdAsync(int id)
        {
            try
            {
                return await GetAsync<OnePeopleDTO>($"people/{id}");
            }
            catch (Exception ex)
            {
                LastError = "Connection error: " + ex.Message;
                return null;
            }
        }

        public async Task<OnePeopleDTO?> GetPersonByUserIdAsync(int userID)
        {
            try
            {
                return await GetAsync<OnePeopleDTO>($"people/ByUserID/{userID}");
            }
            catch (Exception ex)
            {
                LastError = "Connection error: " + ex.Message;
                return null;
            }
        }

        // 3. Get Person by National Number
        public async Task<OnePeopleDTO?> GetPersonByNationalNoAsync(string nationalNo)
        {
            try
            {
                return await GetAsync<OnePeopleDTO>($"people/ByNationalNo/{nationalNo}");
            }
            catch (Exception ex)
            {
                LastError = "Connection error: " + ex.Message;
                return null;
            }
        }

        // 4. Add New Person
        public async Task<SuccessMessageResponseIdDTO?> AddPersonAsync(AddNewPeopleDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PostAsync("people/Add", content);
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

        // 5. Update Person
        public async Task<bool> UpdatePersonAsync(int id, UpdatePeopleDTO dto)
        {
            try
            {
                dto.PersonID = id;
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PutAsync($"people/Update/{id}", content);
                var responseBody = await res.Content.ReadAsStringAsync();

                if (!res.IsSuccessStatusCode)
                {
                    ParseAndSetLastError(responseBody);
                    return false;
                }

                LastError = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                LastError = "Server connection failed: " + ex.Message;
                return false;
            }
        }

        // 6. Delete Person
        public async Task<bool> DeletePersonAsync(int id)
        {
            try
            {
                var res = await client.DeleteAsync($"people/Delete/{id}");
                var body = await res.Content.ReadAsStringAsync();

                if (!res.IsSuccessStatusCode)
                {
                    ParseAndSetLastError(body);
                    return false;
                }

                LastError = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                LastError = "Server connection failed: " + ex.Message;
                return false;
            }
        }

        // 7. Check if National Number Exists
        public async Task<bool> IsNationalNoExistsAsync(string nationalNo)
        {
            try
            {
                return await GetAsync<bool>($"people/IsNationalNoExists/{nationalNo}");
            }
            catch (Exception ex)
            {
                LastError = "Connection error: " + ex.Message;
                return false;
            }
        }

        // Helper Method: Parse and extract error messages from various JSON error formats
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