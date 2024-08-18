using Discord;
using DSharpPlus.CommandsNext;
using DSharpPlus;
using Microsoft.Extensions.Logging;
using TriviaBot.Commands;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Entities;
using TriviaBot.Utility;

namespace TriviaBot
{
    public class Program
    {
        public static async Task Main()
        {
            var discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "YOURTOKEN",
                TokenType = DSharpPlus.TokenType.Bot,
                Intents = DiscordIntents.All,
                MinimumLogLevel = LogLevel.Debug,
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = new[] { "!" }
            });

            commands.RegisterCommands<TriviaModule>();
            commands.SetHelpFormatter<CustomHelpFormatter>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
