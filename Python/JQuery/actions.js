$(document).ready(function () {
    console.log("ready!");
    $('button').click(function(){
        $(this).text("RESET THE BUTTON");
        $('.arena').append("<p>ANOTHER CHALLENGER</p>");
    });
    $('.arena').on("click", "p", function(){ 
        console.log("CLICKED A P TAG");
    });
    // $('a').click(function(){
    //     alert("going home!")
    // });
});