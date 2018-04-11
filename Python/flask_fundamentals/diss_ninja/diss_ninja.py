from flask import Flask, render_template, redirect, request, url_for
app = Flask(__name__)

@app.route('/')
def main():
    return "NO NINJAS HERE"
@app.route('/ninjas')
def ninjas():
    imagestring = url_for('static', filename='tmnt.png')
    return render_template('ninjas.html', imgstr = imagestring)
@app.route('/ninja/<color>')
def ninja(color):
    if color =="blue":
        imagestring = url_for('static', filename='leonardo.jpg')
    elif color == 'red':
        imagestring = url_for('static', filename='raphael.jpg')
        
    elif color == 'purple':
        imagestring = url_for('static', filename='donatello.jpg')
    elif color == 'orange':
        imagestring = url_for('static', filename='michelangelo.jpg')
       
    else:
        imagestring = url_for('static', filename='notapril.jpg')
         
        # imagestring = url_for('static', filename='imagestring.jpg')>>try later to replace all imagestring
        return render_template('ninjas.html', imgstr = imagestring)
app.run(debug=True)
