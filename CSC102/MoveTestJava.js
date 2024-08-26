
function enableMoveButton() {
    /* The Start button is enabled and the Stop button is disabled. */
    document.getElementById("MoveButton").disabled = false;
    document.getElementById("StopButton").disabled = true;
    }

    function enableStopButton() {
        /* The Start button is disabled and the Stop button is enabled. */
        document.getElementById("MoveButton").disabled = true;
        document.getElementById("StopButton").disabled = false;
        }

        document.getElementById("MoveButton").onclick = function() {
            enableStopButton();
            moveImage();
            };

         document.getElementById("StopButton").onclick = function() {
             enableMoveButton();
             stopImage();
            };
            
function moveImage() {
    function moveMeme() {
        /* The meme image is moved to the right and down. */
        var horse = document.getElementById("Horse");
        var x = 0;
        var y = 0;
        
        animationInterval = setInterval(function() {
        x += 20;
        y += 20;
        horse.style.left = x + "px";
        horse.style.top = y + "px";
        }, 500);
        }
}

function stopImage(){
    document.getElementById("Horse")
}
