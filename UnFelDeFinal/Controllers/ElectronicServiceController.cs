﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InternProj.WebApi.Exceptions;
using InternProj.Extern.Dtos;
using InternProj.Models;
using InternProj.WebApi.Services;

namespace InternProj.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronicServiceController : ControllerBase
    {
        private readonly IElectronicServiceService eServiceService;
        private readonly IMapper mapper;

        public ElectronicServiceController(IElectronicServiceService eServiceService, IMapper mapper )
        {
            this.eServiceService = eServiceService;
            this.mapper = mapper;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get([FromQuery] FilterOptions filterOptions)
        {
            var eService = eServiceService.GetEservice(filterOptions);
            var result = eService.Select(eService => mapper.Map<ElectronicServiceDto>(eService));

            return Ok(result);
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var eService = eServiceService.GetEserviceById(id);
            if (eService == null)
                return NotFound();

            var result = mapper.Map<ElectronicServiceDto>(eService);
            return Ok(result);
        }


        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateElectronicServiceDto dto)
        {
            var eService = eServiceService.AddNewEservice(dto);

            if (eService == null)
                return NotFound("Service with such Trez already exists");

            var result = mapper.Map<ElectronicServiceDto>(eService);

            return CreatedAtAction(nameof(Get), new { id = eService.Id }, result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [ApiExceptionFilter]
        public IActionResult Put(int id, [FromBody] CreateElectronicServiceDto dto)
        {
            var eService = eServiceService.UpdateElectronicService(id, dto);

            if (eService == null)
                return NotFound("Did not found such Electronic Service");

            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = eServiceService.RemoveElectronicServiceById(id);

            // IDEMPOTENT deletion
            return NoContent();

            // NON-IDEMPOTENT deletion
            // return isDeleted ? NoContent() : NotFound();
        }
    }
}
