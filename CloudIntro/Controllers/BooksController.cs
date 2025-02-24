﻿using CloudIntro.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.RateLimiting;

namespace CloudIntro.Controllers
{
    [EnableRateLimiting("fixed")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("/books")]
        public IActionResult Index()
        {
            return Ok(_bookService.FindBooks());
        }
    }
}
