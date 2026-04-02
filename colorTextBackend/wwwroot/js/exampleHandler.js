const phrase01 = "Thank you for visiting my site!";
const phrase02 = "I hope you've enjoyed using the encoder!"
const phrase03 = "Make sure you visit my GitHub profile at www.github.com/ansleysoftware."
const phrase04 = "Don't forget to drop me a line in the contact form!"
const example1 = document.getElementById("exampleSwatch1");
const example2 = document.getElementById("exampleSwatch2");
const example3 = document.getElementById("exampleSwatch3");
const example4 = document.getElementById("exampleSwatch4");
let colors1 = "";
let colors2 = "";
let colors3 = "";
let colors4 = "";

async function fetchEncode(phrase) {
    const response = await fetch("/api/encoder/encode", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify({input: phrase})
    });
    return await response.json();
}

async function loadExamples() {
    const[result1, result2, result3, result4] = await Promise.all([
    fetchEncode(phrase01),
    fetchEncode(phrase02),
    fetchEncode(phrase03),
    fetchEncode(phrase04)
]);
    colors1 = result1;
    colors2 = result2;
    colors3 = result3;
    colors4 = result4;
    AssignDivsColors(result1, example1);
    AssignDivsColors(result2, example2);
    AssignDivsColors(result3, example3);
    AssignDivsColors(result4, example4);
}

function AssignDivsColors (result, example) {
    for (let i = 0; i < result.length; i++){
        let phraseDiv = document.createElement("div");
        example.appendChild(phraseDiv);
        phraseDiv.classList.add("exampleSwatch");
        phraseDiv.style.backgroundColor = result[i];
    }
    
}
example1.addEventListener("click", async () => {
    decodeInput.value = colors1;
    console.log("This is a test");
});
example2.addEventListener("click", async () => {
    decodeInput.value = colors2;
})
example3.addEventListener("click", async() => {
    decodeInput.value = colors3;
} )
example4.addEventListener("click", async() => {
    decodeInput.value = colors4;
})
    
loadExamples();