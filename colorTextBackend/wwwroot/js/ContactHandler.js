const sendButton = document.getElementById("sendButton");
const messageBody = document.getElementById("messageBody");
const emailAddress = document.getElementById("emailAddress");
const senderName = document.getElementById("senderName");
const messageLimit = 1200;
let message = [];
sendButton.addEventListener("click", async() => {
    if(messageBody.value.length > 5 && messageBody.value.length <= messageLimit)
    {
        if(emailAddress.value.includes("@") && emailAddress.value.includes("."))
        {
            if(senderName.value.length > 0 && senderName.value.length < 24)
            {
                const response = await fetch("/api/contactform/contact",{
                    method: "POST",
                    headers: {"Content-Type":"application/json"},
                    body: JSON.stringify({
                        name: senderName.value,
                        email: emailAddress.value,
                        message: messageBody.value
                    })
                });
            } else {
                alert("Please enter a name between 1 and 23 characters long.")
            }
        } else {
            alert("Please enter a valid email address.")
        }
    } else {
        alert("Please enter a valid message under 1200 characters long.")
    }
    
});