using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoardgameNight.Core.Interfaces;
using BoardgameNight.Core.Model;
using BoardgameNight.Infrastructure.Data;

namespace BoardGameNight.Controllers
{
    public class BoardgamesController : Controller
    {

        private readonly IBoardGameRepository _boardGameRepository;

        public BoardgamesController(IBoardGameRepository boardGameRepository)
        {
            _boardGameRepository = boardGameRepository;
        }

        public BoardgamesController() :
            this(new BoardgameRepository())
        {
        }

        public ActionResult Index()
        {
            var games = _boardGameRepository.ListGames();
            
            return View(games);
        }

        public ActionResult Create()
        {
            return View(new Boardgame
            {
                BoardgameName = "Test",
                PlayerCount = 2,
                HasBeenPlayed = true
            });
        }
    }
}
