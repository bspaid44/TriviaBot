using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaBot.Data;
using TriviaBot.Utility;

namespace TriviaBot.Commands
{
    public class TriviaModule : BaseCommandModule
    {
        [Command("trivia")]
        public async Task GetTrivia(CommandContext ctx, string category = null ,string difficulty = null)
        {
            if (category == null || category == string.Empty)
            {
                category = "generalknowledge";
            }

            if (!Enum.IsDefined(typeof(Category), category.ToLower()))
            {
                await ctx.RespondAsync("Invalid category. Please choose a valid category.");
            }

            if (difficulty == null || difficulty == string.Empty)
            {
                difficulty = "easy";
            }

            if (difficulty.ToLower() != "easy" && difficulty.ToLower() != "medium" && difficulty.ToLower() != "hard")
            {
                await ctx.RespondAsync("Invalid difficulty. Please choose from easy, medium, or hard.");
            }

            category = ((Category)Enum.Parse(typeof(Category), category, true)).ToString("D");

            var api = new Api();
            
            var trivia = await api.GetTriviaQuestion($"https://opentdb.com/api.php?amount=1&category={category}&difficulty={difficulty}&type=multiple");

            var embed = EmbedFormatter.FormatEmbed(trivia);

            await ctx.RespondAsync(embed);
        }

        [Command("categories")]
        public async Task GetCategories(CommandContext ctx)
        {
            var categories = Enum.GetNames(typeof(Category));

            var embed = new DiscordEmbedBuilder
            {
                Title = "__**Trivia Categories:**__",
                Description = string.Join("\n", categories),
                Color = DiscordColor.Gold,
            };

            await ctx.RespondAsync(embed);
        }
    }
}
