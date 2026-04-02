const phrase01 = "Thank you for visiting my site!";
const phrase02 = "I hope you've enjoyed using the encoder!"
const phrase03 = "Make sure you visit my GitHub profile at www.github.com/ansleysoftware."
const phrase04 = "Don't forget to drop me a line in the contact form!"
const example1 = document.getElementById("exampleSwatch1");
const example2 = document.getElementById("exampleSwatch2");
const example3 = document.getElementById("exampleSwatch3");
const example4 = document.getElementById("exampleSwatch4");
let phrase01Encode = [];
let phrase02Encode = [];
let phrase03Encode = [];
let phrase04Encode = [];

async function fetchEncode(phrase) {
    const response = await fetch("/api/encoder/encode", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify({input: phrase})
    });
    return await response.json();
}

const[result1, result2, result3, result4] = await Promise.all([
    phrase01Encode.push(fetchEncode("phrase01")),
    phrase02Encode.push(fetchEncode("phrase02")),
    phrase03Encode.push(fetchEncode("phrase03")),
    phrase04Encode.push(fetchEncode("phrase04"))
]);
    
function processArrays(phrase)
{
    for(let i = 0; i < phrase.length; i += 3)
    {
        let colorDiv = document.createElement("div");

    }
}