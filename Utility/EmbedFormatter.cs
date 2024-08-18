using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaBot.Data;

namespace TriviaBot.Utility
{
    public class EmbedFormatter
    {
        public static DiscordEmbedBuilder FormatEmbed(Root trivia)
        {
            var question = trivia.results[0].question;
            var answers = trivia.results[0].incorrect_answers;
            answers.Add(trivia.results[0].correct_answer);

            answers.ForEach(a => a = System.Net.WebUtility.HtmlDecode(a));

            var correctAnswer = trivia.results[0].correct_answer;

            var shuffled = answers.OrderBy(a => Guid.NewGuid()).ToList();

            question = System.Net.WebUtility.HtmlDecode(question);

            var embed = new DiscordEmbedBuilder
            {
                Title = "__**Question:**__",
                Description = question,
                Color = DiscordColor.Gold,
            };

            for (var i = 0; i < shuffled.Count; i++)
            {
                embed.AddField($"__Option {i + 1}:__", shuffled[i]);
            }

            embed.AddField("Correct Answer", $"|| The correct answer is: {correctAnswer} ||");

            return embed;
        }
    }
}
