from flask import Flask, render_template, redirect, request
app = Flask(__name__)

@app.route('/')
def form():
    
    return render_template('my_name.html')
@app.route('/process/name', methods=['POST'])
def process(name):
     name = request.form['name'] 
     print request.form 
     
     return redirect('/')
app.run(debug=True)

