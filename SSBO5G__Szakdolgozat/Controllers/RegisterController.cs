﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSBO5G__Szakdolgozat.Dtos;
using SSBO5G__Szakdolgozat.Models;
using SSBO5G__Szakdolgozat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSBO5G__Szakdolgozat.Controllers
{
    [Authorize("Bearer")]
    [Route("[Controller]/")]
    public class RegisterController : Controller
    {

        IRegistrationService registrationService;
        IMapper mapper;

        public RegisterController(IMapper mapper, IRegistrationService registrationService)
        {
            this.mapper = mapper;
            this.registrationService = registrationService;
        }

        [HttpPut("register")]
        public async Task<IActionResult> Register([FromBody]Registration registration)
        {
            try
            {
                Registration reg = await registrationService.RegisterToHike(registration);
                RegistrationDto registrationDto1 = mapper.Map<RegistrationDto>(reg);
                return Ok(registrationDto1);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("unregister")]
        public async Task<IActionResult> UnRegister([FromBody]Registration registration)
        {
            try
            {
                int id = await registrationService.UnRegisterFromHike(registration);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}