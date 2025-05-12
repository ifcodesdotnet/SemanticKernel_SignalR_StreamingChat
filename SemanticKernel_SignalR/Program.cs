using System.ClientModel;
using Microsoft.SemanticKernel;
using OpenAI;
using SemanticKernel_SignalR.Hubs;
using SemanticKernel_SignalR.Plugins;
using SemanticKernel_SignalR.Services;
using SemanticKernel_SignalR.ViewModels;

var builder = WebApplication.CreateBuilder(args);

var openAISettings = builder.Configuration.GetSection("OpenAI");
var modelId = openAISettings["ModelId"];
var apiKey = openAISettings["ApiKey"];
var endpoint = openAISettings["Endpoint"];

builder.Services
    .AddKernel()
    .AddOpenAIChatCompletion(
        modelId: modelId,
        openAIClient: new OpenAIClient(
            credential: new ApiKeyCredential(apiKey),
            options: new OpenAIClientOptions
            {
                Endpoint = new Uri(endpoint)
            })
    )
    .Plugins.AddFromType<CalculatorPlugin>()
            .AddFromType<ProductPlugin>();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy => policy.AllowAnyMethod()
                                       .AllowAnyHeader()
                                       .AllowCredentials()
                                       .SetIsOriginAllowed(s => true)));

builder.Services.AddHttpClient();
builder.Services.AddSignalR();
builder.Services.AddSingleton<AIService>();

var app = builder.Build();
app.UseCors();

app.MapPost("/chat", async (AIService aiService, ChatRequestVM chatRequest, CancellationToken cancellationToken)
    => await aiService.GetMessageStreamAsync(chatRequest.Prompt, chatRequest.ConnectionId, cancellationToken));

app.MapHub<AIHub>("ai-hub");

app.Run();