using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext.Entities;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaBot.Utility
{
    public class CustomHelpFormatter : DefaultHelpFormatter
    {
        public CustomHelpFormatter(CommandContext ctx) : base(ctx) { }

        public override CommandHelpMessage Build()
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = "Help",
                Description = "Here are the commands you can use.",
                Color = DiscordColor.Gold,
            };

            embed.AddField("Trivia", "Get a trivia question. You can specify a category and difficulty level. \n{!trivia anime medium} for example", false);
            embed.AddField("Categories", "Get a list of valid categories", false);
            embed.AddField("Difficulty", "Easy, Medium, or Hard", false);

            return new CommandHelpMessage(embed: embed);
        }
    }
}
