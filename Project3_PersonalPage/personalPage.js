function initializeThatsAllFolks(){
    console.log("In initializeThatsAllFolks()");
    thatsAllFolks();
}


function initializeDogState(){
    console.log("In dogState()");
    dogNames();
}


function thatsAllFolks() {
    let text = "As they say in Looney Tunes, \"That's All Folks!\"";
    document.getElementById("demo").innerHTML = text;
}

function dogState() {
    let text1 = "These dogs live in";
    let text2 = "North";
    let text3 = "Dakota";
    let result = text1.concat(" ", text2, " ", text3, ".");

    document.getElementById("demo").innerHTML = result;
}