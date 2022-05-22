using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Remoting;
//https://discord.com/api/oauth2/authorize?client_id=974269746826579968&permissions=268435456&scope=bot
//OsTc0MjY5NzQ2ODI2NTc5OTY4.GZaphh.Z_dQG4WsLXUvEHGrz56KfWdxVEacKGzSpSTvRw
namespace discord_bot
{
    class Program
    {
        DiscordSocketClient client;
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();
        private async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "OsTc0MjY5NzQ2ODI2NTc5OTY4.GZaphh.Z_dQG4WsLXUvEHGrz56KfWdxVEacKGzSpSTvRw";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            Console.ReadLine();
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());

            return Task.CompletedTask;
        }
        private Task RoleGiver(IGuildUser user)
        {
            user.AddRoleAsync(974271142766460928);
            return Task.CompletedTask;
        }
        private Task CommandsHandler(SocketMessage msg)
        {
            Console.WriteLine($"{msg.Channel} ~ {msg.Timestamp} --> {msg.Author.Username}: {msg.Content}\n");
            if (msg.Channel.Name == "general"|| msg.Channel.Name == "qwas")
            {
            if (!msg.Author.IsBot)
                switch (msg.Content)
                {
                    case "!role":
                            {
                            //RoleGiver(client.GetUser(msg.Author.Username,msg.Author.Discriminator));
                            break;
                            }
                    case "!привет":
                        {
                            msg.Channel.SendMessageAsync($"Привет, {msg.Author.Username}");
                            break;
                        }
                    case "!rps":
                        {
                            Random rnd = new Random();
                                long game = rnd.Next(0,3);
                                if(game== 0)
                            msg.Channel.SendMessageAsync("Камень");
                                else if(game == 1)
                            msg.Channel.SendMessageAsync("Ножнецы");
                                else
                            msg.Channel.SendMessageAsync("Бумага");
                            break;
                        }
                }
            }
            return Task.CompletedTask;
        }
    }
}
