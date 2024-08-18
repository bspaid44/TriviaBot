using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaBot.Data
{
    public class Result
    {
        public string type { get; set; }
        public string difficulty { get; set; }
        public string category { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }

    public class Root
    {
        public int response_code { get; set; }
        public List<Result> results { get; set; }
    }

    public enum Category
    {
        generalknowledge = 9,
        books = 10,
        film = 11,
        music = 12,
        musicals = 13,
        television = 14,
        videoGames = 15,
        boardGames = 16,
        nature = 17,
        computers = 18,
        mathematics = 19,
        mythology = 20,
        sports = 21,
        geography = 22,
        history = 23,
        politics = 24,
        art = 25,
        celebrities = 26,
        animals = 27,
        vehicles = 28,
        comics = 29,
        gadgets = 30,
        anime = 31,
        cartoons = 32
    }
}
