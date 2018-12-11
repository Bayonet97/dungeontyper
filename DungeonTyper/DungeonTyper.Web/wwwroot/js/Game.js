function SubmitInput() {

    var formData = new FormData();

    var inputVar = $('#inputfield')[0].value;

    formData.set('inputText', inputVar);

    document.getElementById("inputfield").value = "";

    $.ajax({
        url: '/Game/Handle',
        data: formData,
        processData: false,
        contentType: false,
        type: 'POST',
        success: function (output) {
            WriteLine(output);
        }
    });
    return false;
}

function WriteLine(output) {
    var msg = output.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var outputMsg = msg + "\n"
    document.getElementById("dungeontextarea").value += outputMsg;
}

function LoadFile() {

}