﻿using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EquationController : ControllerBase
	{

		private readonly IEquationService _equationService;

		public EquationController(IEquationService equationService)
		{
			_equationService = equationService;
		}

		[HttpPatch(Name = "EquationRoute")]
		public ActionResult<EquationInput> EquationRoute(EquationInput input)
		{
			_equationService.ValidateEquation(input);
			return input;
		}
	}
}
