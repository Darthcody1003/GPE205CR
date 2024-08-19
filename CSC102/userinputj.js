
//gets values from fisrtName, lastName, and zip. It concatenates firstName + lastName
function validate() {
    var firstName = document.getElementById("firstName").value;
    var lastName = document.getElementById("lastName").value;
    var zip = document.getElementById("zip").value;
    var concat = firstName +""+ lastName;
//checks if zip is 5 digits, if not it alerts that it is not valid
if (zip.length !== 5) {
    alert("Zip code must be 5 digits");
//if ip is 5 digits, it alerts that it is valid    
} else {
    alert("Zip code is valid");
}
//checks whether or not the first and last name are less than 1 letter, alerts our user on those condition
if (concat.length < 1) {
    alert("First and last name must be 20 letters or less");
} else {
    alert("First and last name are both valid");
    if (concat.length <= 20 && zip.length === 5) {
        document.getElementById("result").innerHTML = "Hello!";
       
    }
}
}