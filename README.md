# Semantic Kernel SignalR Streaming AI Chat

This project demonstrates a real-time AI-powered chat application using Microsoft Semantic Kernel, SignalR, and OpenAI. The application streams AI responses to user prompts in real-time, leveraging the power of Semantic Kernel plugins and SignalR for seamless communication.

## Features

- **Real-Time AI Chat**: Stream AI-generated responses to user inputs in real-time.
- **Microsoft Semantic Kernel**: Utilize Semantic Kernel for AI capabilities and plugin extensibility.
- **SignalR Integration**: Enable real-time communication between the server and clients (already included as a dependency in ASP.NET Core).
- **OpenAI Integration**: Connect to OpenAI for generating AI responses.
- **Extensible Plugins**: Add custom plugins like `CalculatorPlugin` and `ProductPlugin`.

## Project Structure

```
BestSelling.API/
SemanticKernel_SignalR/
UI/
```

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/)
- [Node.js](https://nodejs.org/) (for the UI)
- OpenAI API Key

## Setup

### Backend

1. Clone the repository:
```bash
git clone <repository-url>
cd SemanticKernel_SignalR
```

2. Configure OpenAI settings in `appsettings.Development.json`:
```json
{
  "OpenAI": {
    "ModelId": "<your-model-id>",
    "ApiKey": "<your-api-key>",
    "Endpoint": "https://openrouter.ai/api/v1"
  }
}
```

3. Restore dependencies and build the project:
```bash
dotnet restore
dotnet build
```

4. Run the backend:
```bash
dotnet run --project SemanticKernel_SignalR
```

### Frontend

1. Navigate to the `UI` folder:
```bash
cd UI
```

2. Install dependencies:
```bash
npm install
```

3. Start the frontend:
```bash
npm start
```

## Usage

1. Open the frontend in your browser (default: `http://localhost:...`).
2. Enter a prompt in the input box and click "Send".
3. View the AI-generated response streamed in real-time.

## Key Components

### Backend

- **`AIService`**: Handles AI response generation and streams messages to clients via SignalR.
- **`AIHub`**: SignalR hub for real-time communication.
- **`HistoryService`**: Manages chat history for each connection.
- **Plugins**:
  - `CalculatorPlugin`: Example plugin for mathematical operations.
  - `ProductPlugin`: Fetches best-selling products from an API.

### Frontend

- **`app.js`**: Manages SignalR connection and handles user interactions.
- **`index.html`**: Basic UI for the chat application.

## Extending the Application

### Adding a New Plugin

1. Create a new plugin class in the `Plugins` folder.
2. Annotate methods with `[KernelFunction]` and provide descriptions.
3. Register the plugin in `Program.cs`:
   ```csharp
   builder.Services.AddKernel()
       .Plugins.AddFromType<YourPlugin>();
   ```

### Customizing the UI

Modify the `index.html` and `style.css` files in the `UI` folder to update the look and feel of the chat application.
