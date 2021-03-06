using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using MongoDB.Bson;
using MongoDB.Driver;
using PrototonBot.MongoUtil;
using System.Linq;

namespace PrototonBot.Commands {
  public class DebugCommands : ModuleBase<SocketCommandContext> {
    //Developers can peek at a user's information on the server, such as [prefix]peek users id USERID
    [Command("peek")] [Alias("read")]
    public async Task Peek(string collection, string searchkey, [Remainder] string searchvalue) {
      if (UtilityHelper.IsUserDeveloper(Context.User.Id.ToString())) {
        switch (collection.ToLower()) {
          case "users": {
              var filter = Builders<UserObject>.Filter.Eq(searchkey, searchvalue);
              var result = MongoHelper.SearchUsers(filter).Result;
              var cursor = await result.ToCursorAsync();
              foreach (var user in cursor.ToEnumerable()) {
                await Context.Channel.SendMessageAsync($"```json\n{UtilityHelper.FormatPeekData(user.ToJson())}```");
              }
              break;
            }
          case "invs": {
              var filter = Builders<InventoryObject>.Filter.Eq(searchkey, searchvalue);
              var result = MongoHelper.SearchInvs(filter).Result;
              var cursor = await result.ToCursorAsync();
              foreach (var inv in cursor.ToEnumerable()) {
                await Context.Channel.SendMessageAsync($"```json\n{UtilityHelper.FormatPeekData(inv.ToJson())}```");
              }
              break;
            }
          case "servers": {
              var filter = Builders<ServerObject>.Filter.Eq(searchkey, searchvalue);
              var result = MongoHelper.SearchSvrs(filter).Result;
              var cursor = await result.ToCursorAsync();
              foreach (var server in cursor.ToEnumerable()) {
                await Context.Channel.SendMessageAsync($"```json\n{UtilityHelper.FormatPeekData(server.ToJson())}```");
              }
              break;
            }
          default: {
              await Context.Channel.SendMessageAsync("Invalid collection. Try `users`, `invs`, or `servers`.");
              break;
            }
        }
      }
    }
    
    //Developers can poke at a user's information on the server, such as [prefix]poke users id USERID Money 9999 long
    [Command("poke")] [Alias("write")]
    public async Task Poke(string collection, string searchkey, string searchvalue, string updatekey, string updatevalue, string updatetype) {
      if (UtilityHelper.IsUserDeveloper(Context.User.Id.ToString())) {
        if (!updatetype.Contains("System.")) updatetype = $"System.{updatetype}";
        var qualifiedTypeName = Type.GetType(updatetype)?.AssemblyQualifiedName;
        if (qualifiedTypeName == null) {
          await Context.Channel.SendMessageAsync("The type of your poke is not valid.\nPlease match the type of the key value in the database.");
          return;
        }
        switch (collection.ToLower()) {
          case "users": {
            var filter = Builders<UserObject>.Filter.Eq(searchkey, searchvalue);
            var result = MongoHelper.SearchUsers(filter).Result;
            var cursor = await result.ToCursorAsync();
            foreach (var user in cursor.ToEnumerable()) {
              await MongoHelper.UpdateUser(user.Id, updatekey, Convert.ChangeType(updatevalue, qualifiedTypeName.GetType()));
              await Context.Channel.SendMessageAsync($"{user.Name} / {updatekey} has been changed to {updatevalue}");
            }
            break;
          }
          case "invs": {
            var filter = Builders<InventoryObject>.Filter.Eq(searchkey, searchvalue);
            var result = MongoHelper.SearchInvs(filter).Result;
            var cursor = await result.ToCursorAsync();
            foreach (var inv in cursor.ToEnumerable()) {
              await MongoHelper.UpdateInventory(inv.Id, updatekey, Convert.ChangeType(updatevalue, qualifiedTypeName.GetType()));
              await Context.Channel.SendMessageAsync($"{inv.Name} / {updatekey} has been changed to {updatevalue}");
            }
            break;
          }
          case "servers": {
            var filter = Builders<ServerObject>.Filter.Eq(searchkey, searchvalue);
            var result = MongoHelper.SearchSvrs(filter).Result;
            var cursor = await result.ToCursorAsync();
            foreach (var server in cursor.ToEnumerable()) {
              await MongoHelper.UpdateServer(server.Id, updatekey, Convert.ChangeType(updatevalue, qualifiedTypeName.GetType()));
              await Context.Channel.SendMessageAsync($"{server.Name} / {updatekey} has been changed to {updatevalue}");
            }
            break;
          }
          default: {
            await Context.Channel.SendMessageAsync("Invalid collection. Try `users`, `invs`, or `servers`.");
            break;
          }
        }
      }
    }

    //TODO: Fix ( Displays the ping from response )
    [Command("ping")]
    public async Task BotPingTime() {
      var receivedTime = DateTime.Now;
      var difference = receivedTime - Context.Message.Timestamp;
      var embed = new EmbedBuilder();
      embed.WithTitle("Pong!");
      embed.WithColor(0x7289DA);
      embed.AddField("Response Time", $":dart: {Math.Abs(Math.Round(difference.TotalMilliseconds, 1))}ms", true);
      await Context.Channel.SendMessageAsync("", false, embed.Build());
    }

    [Command("bottime")]
    public async Task BotTime() {
      await Context.Channel.SendMessageAsync($"The bot's current time is: {DateTime.Now.ToString("MMMM dd yyyy h:mm tt")}");
    }
  }
}