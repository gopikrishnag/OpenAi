using Microsoft.Extensions.Options;
using OpenAI_API.Models;
using OpenAiChatGPT.Configurations;

namespace OpenAiChatGPT.Services;

public class OpenAiService(IOptionsMonitor<OpenAiConfig> optionsMonitor) : IOpenAiService
{
    private readonly OpenAiConfig _openAiConfig = optionsMonitor.CurrentValue;

    public async Task<string> CompleteSentence(string text)
    {
        var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
        var result = await api.Completions.GetCompletion(text);
        return result;
    }

    public async Task<string> CompleteSentenceAdvance(string text)
    {
        var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
        var result = await api.Completions.CreateCompletionAsync(new OpenAI_API.Completions.CompletionRequest(text, model: Model.CurieText, temperature: 0.1 ));
        return result.Completions[0].Text;
    }

    public async Task<string> CheckProgrammingLanguage(string language)
    {
        var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
        var chat = api.Chat.CreateConversation();
        chat.AppendSystemMessage("You are a teacher who help new programmers understand");
        chat.AppendUserInput(language);
        var response = await chat.GetResponseFromChatbotAsync();
        return response;
    }
}