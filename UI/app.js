var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5047/ai-hub")
    .build();

hubConnection.start()
    .then(() =>
        document.getElementById("connectionId").innerHTML = `(${hubConnection.connectionId})`)
    .catch(err =>
        console.error(err.toString()));

hubConnection.on("ReceiveMessage", responseMessage => {
    const aiMessage = responseMessage;
    chatBox.innerHTML += aiMessage;
    chatBox.scrollTop = chatBox.scrollHeight;
});

const input = document.getElementById("user-input");
const chatBox = document.getElementById("chat-box");

function sendPrompt() {
    if (input.value.trim() === "") return;

    const userMessage = `<div><strong>Sen:</strong> ${input.value}</div>`;
    chatBox.innerHTML += userMessage;
    chatBox.scrollTop = chatBox.scrollHeight;

    fetch("http://localhost:5047/chat", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ prompt: input.value, connectionId: hubConnection.connectionId })
    })
        .then(response => response.json())
        .then(data => console.log("Success : ", data))
        .catch(error => console.error("Error", error));
    input.value = "";
}