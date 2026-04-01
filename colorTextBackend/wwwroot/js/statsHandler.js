const reposNum = document.getElementById("reposNum");
const followersNum = document.getElementById("followersNum");
const followingNum = document.getElementById("followingNum");
const createdAtNum = document.getElementById("createdAtNum");

async function loadGitStats() {
    const response = await fetch("/api/gitstats/gitstats");
    const data = await response.json();
    reposNum.innerHTML = data.public_repos;
    followersNum.innerHTML = data.followers;
    followingNum.innerHTML = data.following;
    createdAtNum.innerHTML = new Date(data.created_at).getFullYear();
}

loadGitStats();