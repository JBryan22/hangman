using Microsoft.AspNetCore.Mvc;
using Hangman.Models;
using System.Collections.Generic;
using System;

namespace Hangman.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost("/")]
    public ActionResult IndexGuess()
    {
      string newGuess = Request.Form["guess"];
      if (Board.CheckValidGuess(newGuess))
      {
        Board.CheckGuess(newGuess);
        return View("/");
      }
      else
      {
        return View();
      }
    }
  }
}
