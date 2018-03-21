function draw_table(){
    // create our html string, open up the table tag
    let html_string = "<table>";
    // outer loop
    for(let i = 1; i<13; i++){
        // create a row for each iteration of the outer loop
        html_string += "<tr>";
        // inner loop
        for(let j = 1; j<13; j++){
            // calculate our number
            let nums = i * j;
            // attach our table data tags around the number
            let data = "<td>" + nums + "</td>";
            // add it to the html
            html_string += data;
        }
        // after the inner loop, we cap our table rows
        html_string += "</tr>";
    }
    // after the outer loop, we cap our entire table
    html_string += "</table>";
    // document.getElementById("target").innerHTML = html_string;
}
draw_table();