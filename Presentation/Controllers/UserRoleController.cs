﻿using Business.Dtos.UserRole;
using Business.Services.Abstract;
using Business.Wrappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin",AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        #region Documentation
        /// <summary>
        /// Add Role To User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response),StatusCodes.Status500InternalServerError)]
        #endregion
        [HttpPost]
        public async Task<Response> AddRoleToUserAsync(UserAddToRoleDto model)
            => await _userRoleService.AddRoleToUserAsync(model);


        #region Documentation
        /// <summary>
        /// Remove Role from User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
        #endregion

        [HttpDelete]
        public async Task<Response> RemoveRoleFromUserAsync(UserRemoveRoleDto model)
            => await _userRoleService.RemoveRoleFromUserAsync(model);
    }
}
