using DVLDBusiness;
using DVLDShared.DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLDAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly clsUsersBusiness _usersBusiness;

        public UsersController(clsUsersBusiness usersBusiness)
        {
            _usersBusiness = usersBusiness;
        }


        // Login
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return BadRequest("Invalid data");
            }

            var result =
                await _usersBusiness.LoginAsync(loginDTO);

            if (!result.Success)
            {
                if (result.Message == "User account is inactive")
                {
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        new
                        {
                            Message = result.Message
                        });
                }

                return Unauthorized(new
                {
                    Message = result.Message
                });
            }

            return Ok(new
            {
                UserID = result.UserID,
                IsActive = result.IsActive,
                Message = result.Message
            });
        }


        // Get All Users
        [HttpGet("All", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllUsers()
        {
            var result =
                await _usersBusiness.GetAllUsersAsync();

            if (!result.Success)
            {
                return NotFound(new
                {
                    Message = result.Message
                });
            }

            return Ok(result.UsersList);
        }


        // Get User By ID
        [HttpGet("{userID}", Name = "GetUserByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsersListDTO>> GetUserByID(int userID)
        {
            if (userID < 1)
            {
                return BadRequest("Invalid user ID");
            }

            UsersListDTO? user =
                await _usersBusiness.GetUserByIDAsync(userID);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }


        // Add New User
        [HttpPost("Add", Name = "AddNewUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddNewUser(
            [FromBody] AddNewUserDTO addNewUserDTO)
        {
            if (addNewUserDTO == null)
            {
                return BadRequest("Invalid data");
            }

            var result =
                await _usersBusiness.AddNewUserAsync(addNewUserDTO);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    Message = result.Message
                });
            }

            return CreatedAtRoute(
                "GetUserByID",
                new
                {
                    userID = result.UserID
                },
                new
                {
                    UserID = result.UserID,
                    Message = result.Message
                });
        }


        // Update User
        [HttpPut("Update/{userID}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUser(
            int userID,
            [FromBody] UpdateUserDTO updateUserDTO)
        {
            if (userID < 1)
            {
                return BadRequest("Invalid user ID");
            }

            if (updateUserDTO == null)
            {
                return BadRequest("Invalid data");
            }

            UsersListDTO? user =
                await _usersBusiness.GetUserByIDAsync(userID);

            if (user == null)
            {
                return NotFound("User not found");
            }

            updateUserDTO.UserID = userID;

            var result =
                await _usersBusiness.UpdateUserAsync(updateUserDTO);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    Message = result.Message
                });
            }

            return Ok(new
            {
                Message = result.Message
            });
        }


        // Delete User
        [HttpDelete("Delete/{userID}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUser(int userID)
        {
            if (userID < 1)
            {
                return BadRequest("Invalid user ID");
            }

            UsersListDTO? user =
                await _usersBusiness.GetUserByIDAsync(userID);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var result =
                await _usersBusiness.DeleteUserAsync(userID);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    Message = result.Message
                });
            }

            return Ok(new
            {
                Message = result.Message
            });
        }


        // Verify Current Password
        [HttpPost("VerifyPassword/{userID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> VerifyCurrentPassword(
            int userID,
            [FromBody] string password)
        {
            if (userID < 1)
            {
                return BadRequest("Invalid user ID");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Password is required");
            }

            var result =
                await _usersBusiness.VerifyCurrentPasswordAsync(
                    userID,
                    password);

            if (!result.Success)
            {
                if (result.Message == "User not found")
                {
                    return NotFound(new
                    {
                        Message = result.Message
                    });
                }

                return BadRequest(new
                {
                    Message = result.Message
                });
            }

            return Ok(new
            {
                Message = result.Message
            });
        }


        // Change Password
        [HttpPut("ChangePassword/{userID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ChangePassword(
            int userID,
            [FromBody] string newPassword)
        {
            if (userID < 1)
            {
                return BadRequest("Invalid user ID");
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                return BadRequest("New password is required");
            }

            UsersListDTO? user =
                await _usersBusiness.GetUserByIDAsync(userID);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var result =
                await _usersBusiness.ChangePasswordAsync(
                    userID,
                    newPassword);

            if (!result.Success)
            {
                return BadRequest(new
                {
                    Message = result.Message
                });
            }

            return Ok(new
            {
                Message = result.Message
            });
        }
    }
}