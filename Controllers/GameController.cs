
using Microsoft.AspNetCore.Mvc;


namespace Modul10_103022400068.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private static List<Game> games = new List<Game>
        {
            new Game
            {
                id = 1,
                Nama = "Valorant",
                Developer = "Riot Games",
                TahunRilis = 2020,
                Genre = "FPS",
                Rating = 8.5,
                Platform = new string[] { "PC" },
                Mode = new string[] { "Multiplayer" },
                IsOnline = true,
                Harga = 0
            },
            new Game
            {
                id = 2,
                Nama = "GTA V",
                Developer = "Rockstar Games",
                TahunRilis = 2013,
                Genre = "Open World",
                Rating = 9.5,
                Platform = new string[] { "PC", "PS4", "PS5", "Xbox" },
                Mode = new string[] { "Single-player", "Multiplayer"},
                IsOnline = true,
                Harga = 300000
            },
            new Game
            {
                id = 3,
                Nama = "The Witcher 3",
                Developer = "CD Projekt Red",
                TahunRilis = 2015,
                Genre = "RPG",
                Rating = 9.7,
                Platform = new string[] { "PC", "PS4", "PS5", "Xbox", "Switch" },
                Mode = new string[] { "Single-player"},
                IsOnline = true,
                Harga = 250000
            }
        };
        // GET: api/game
        [HttpGet]
        public ActionResult<List<Game>> Get()
        {
            return Ok(games);
        }

        // GET: api/game/{id}
        [HttpGet("{id}")]
        public ActionResult<Game> GetbyId(int id)
        {
            var game = games.FirstOrDefault(g => g.id == id);
            if (game == null)
            {
                return NotFound();
            }
            return game;
        }

        // POST: api/game
        [HttpPost]
        public ActionResult<Game> Post([FromBody] Game newGame)
        {
            games.Add(newGame);
            return Ok("Game berhasil ditambahkan.");
        }

        // PUT: api/game/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Game updatedGame)
        {
            var game = games.FirstOrDefault(g => g.id == id);
            if (game == null)
            {
                return NotFound();
            }
            game.Nama = updatedGame.Nama;
            game.Developer = updatedGame.Developer;
            game.TahunRilis = updatedGame.TahunRilis;
            game.Genre = updatedGame.Genre;
            game.Rating = updatedGame.Rating;
            game.Platform = updatedGame.Platform;
            game.Mode = updatedGame.Mode;
            game.IsOnline = updatedGame.IsOnline;
            game.Harga = updatedGame.Harga;
            return NoContent();
        }

        // DELETE: api/game/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var game = games.FirstOrDefault(g => g.id == id);
            if (game == null)
            {
                return NotFound();
            }
            games.Remove(game);
            return NoContent();
        }
    }
}
