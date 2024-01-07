﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class OrdersController : ControllerBase
{
	private readonly IOrderService _orderService;

	public OrdersController(IOrderService orderService)
	{
		_orderService = orderService;
	}

	[HttpGet]

	public IActionResult TotalOrderCount()
	{
		return Ok(_orderService.TTotalOrderCount());
	}

	[HttpGet]

	public IActionResult ActiveOrderCount()
	{
		return Ok(_orderService.TActiveOrderCount());
	}

	[HttpGet]

	public IActionResult LastOrderPrice()
	{
		return Ok(_orderService.TLastOrderPrice());
	}

	[HttpGet]
	public IActionResult TodayTotalPrice()
	{
		return Ok(_orderService.TTodayTotalPrice());
	}
}
