using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
    }

    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the none intent. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("Note.AddToNote")]
    public async TaskIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"I heard your request and you say: {result.Query}"); //
        await context.PostAsyc("I will get it don ASAP");
        context.Wait(MessageReceived);
    }

    [LuisIntent("Translate.Translate")]
    public async TaskIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Ok, let me translate for you, just wait: {result.Query}"); //
        context.Wait(MessageReceived);
    }
}