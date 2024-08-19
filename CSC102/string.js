function checkForPalindrome() {
    // Get the word from the form
    var inputString = document.getElementById("inputString").value;
    // Get the element to display the result
    var resultElement = document.getElementById("result");
  
    // 1. Remove all non-alphanumeric characters
    var newString = inputString.replace(/[\W_]/g, "").toLowerCase();
  
    // 2. Reverse the string
    var reversedString = newString.split("").reverse().join("");
  
    // 3. Compare the original with the reversed output either true or false
    if (newString === reversedString) {
        // Display the result and outputs the result either it is or isn't a palidrome
        resultElement.innerHTML = "The word is a palindrome.";
    } else {
        resultElement.innerHTML = "The word is not a palindrome.";
    }

}