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
      Board newBoard = new Board();
      return View(newBoard);
    }

    [HttpPost("/")]
    public ActionResult IndexGuess()
    {
      string newGuess = Request.Form["guess"];
      if (Board.GetBoard().CheckValidGuess(newGuess))
      {
        Board.GetBoard().CheckGuess(newGuess);
        return View("index", Board.GetBoard());
      }
      else
      {
        return View("index", Board.GetBoard());
      }
    }
  }
}
