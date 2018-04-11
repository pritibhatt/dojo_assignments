$( document ).ready(function() {
    console.log( "ready!" );
    $('button').click(function(){
        console.log($(this).text())
        $('.arena').append("<p>Another Challenger</p");
    })
    $('.arena').on("click", "p", function(){
        console.log("clicked A P Tag")
    });




});