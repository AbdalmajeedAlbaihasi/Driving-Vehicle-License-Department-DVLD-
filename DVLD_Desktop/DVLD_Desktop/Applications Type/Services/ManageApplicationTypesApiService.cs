using DVLD_Desktop_Net8.Services;
using DVLDShared.DTOs;
using DVLDShared.DTOs.Applications;
using DVLDShared.DTOs.ApplicationsType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace DVLD_Desktop_Net8.Application.Services
{
    public class ManageApplicationTypesApiService : BaseApiService
    {
        public string LastError { get; private set; } = string.Empty;



        


        public async Task<List<ApplicationsTypeDTO>?> GetAllApplicationTypesAsync()
        {
            return await GetAsync<List<ApplicationsTypeDTO>>("applicationtypes/All");
        }

        public async Task<ApplicationsTypeDTO?> GetOneApplicationTypeAsync(int applicationTypeId)
        {
            return await GetAsync<ApplicationsTypeDTO>($"applicationtypes/{applicationTypeId}");
        }

       



        public async Task<GetApplicationTypeFeesByIdDTO?> GetApplicationTypeFeesById(int applicationTypeId)
        {
            return await GetAsync<GetApplicationTypeFeesByIdDTO>($"applicationtypes/GetFees/{applicationTypeId}");
        }

        public async Task<SuccessMessageResponseDTO?> UpdateApplicationsTypeAsync(int id, ApplicationsTypeDTO dto)
        {
            try
            {
                dto.ApplicationTypeId = id;
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PutAsync($"applicationtypes/Update/{id}", content);
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