from flask import Flask, render_template, request
app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')
@app.route('/ninjas')
def ninjas():
    return render_template('ninjas.html')
@app.route('/dojos')
def dojos():
    new = request.form('new')
    name = request.form('name')
    email = request.form('email')

    return render_template('dojos.html')
app.run(debug=True)
