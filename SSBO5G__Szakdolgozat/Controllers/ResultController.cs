﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSBO5G__Szakdolgozat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSBO5G__Szakdolgozat.Controllers
{
    [Authorize("Bearer")]
    [Route("[Controller]/")]
    public class ResultController : Controller
    {
        IResultService resultService;
        public ResultController(IResultService resultService)
        {
            this.resultService = resultService;
        }

        [AllowAnonymous]
        [HttpGet("result/{courseId}")]
        public async Task<IActionResult> Result(int courseId)
        {
            try
            {
                var result = await resultService.GetResults(courseId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("live-result/{courseId}")]
        public async Task<IActionResult> LiveResult(int courseId)
        {
            try
            {
                var result = await resultService.GetLiveResult(courseId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("live-result-netto/{courseId}")]
        public async Task<IActionResult> LiveResultNetto(int courseId)
        {
            try
            {
                var result = await resultService.GetLiveResultNettoTime(courseId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
