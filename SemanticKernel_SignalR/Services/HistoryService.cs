using Microsoft.SemanticKernel.ChatCompletion;

namespace SemanticKernel_SignalR.Services;
public static class HistoryService
{
    private static readonly Dictionary<string, ChatHistory> _chatHistories = new();
    public static ChatHistory GetChatHistory(string connectionId)
    {
        ChatHistory? chatHistory = null;
        if (_chatHistories.TryGetValue(connectionId, out chatHistory))
            return chatHistory;
        else
        {
            chatHistory = new();
            _chatHistories.Add(connectionId, chatHistory);
        }
        return chatHistory;
    }
}
