from flask import Flask, render_template, redirect, request
app = Flask(__name__)

@app.route('/')
def survey():
    return render_template('dojo_survey.html')
@app.route('/results', methods=['POST'])
def results():
    
   
    your_name = request.form['your_name']
    dojo_place = request.form['dojo_place']
    typelanguage = request.form['typelanguage']
    write = request.form['write']
    return render_template('results.html', your_name = your_name, dojo_place=dojo_place,typelanguage=typelanguage,write=write)
    

app.run(debug=True)
