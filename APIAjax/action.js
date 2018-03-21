$(document).ready(function(){
    $('button').click(function(){
        var cityChosen = $('#city').val();
        console.log(cityChosen);
        $.ajax({
            url: "http://api.openweathermap.org/data/2.5/weather?q=" + cityChosen + "&APPID=ab5d219c0bafd168444d30ada5673302",
            success: function (result) {
                var temperature = result['main']['temp'];
                temperature = Math.floor(temperature * (9/5) - 459.67);
                $(".temp").text("The temperature is "+temperature);
                $('#city').val('');
                        }
        });
    })
});