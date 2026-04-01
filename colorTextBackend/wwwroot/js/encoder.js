const encodeButton = document.getElementById("encodeButton");
const encodeInput = document.getElementById("encodeInput");
const swatchDisplay = document.getElementById("swatchDisplay");
const decodeButton = document.getElementById("decodeButton")
const decodeInput = document.getElementById("decodeInput");
const decodeOutput = document.getElementById("decodeOutput");
let currentColors = [];




encodeButton.addEventListener("click", async () => {
    const response = await fetch("/api/encoder/encode", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify({ input: encodeInput.value})
    });
    const data = await response.json();
    currentColors = data;
    swatchDisplay.innerHTML = "";
    for (const color of currentColors)
    {
        let colorDiv = document.createElement("div");
        swatchDisplay.appendChild(colorDiv);
        colorDiv.classList.add("swatch");
        colorDiv.style.backgroundColor = color;
    }

});




decodeButton.addEventListener("click", async () => {
    let colorPayload;
    if(decodeInput.value != "")
    {
        colorPayload = decodeInput.value.split(",");
        
    }
    else
    {
        colorPayload = currentColors;
    }
    const response = await fetch("/api/encoder/decode", {
        method:"POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify({colors: colorPayload})
        
    });
    const data = await response.text();
    let decodedText = data;
    console.log(data);
    decodeOutput.innerHTML = decodedText;
});
