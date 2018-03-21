from flask import Flask, redirect, render_template, request, session
app = Flask(__name__)
app.secret_key = 'key'

@app.route('/')
def template():
    if 'counter' in session:
        session['counter'] += 1
    else:
        session['counter'] = 0
    return render_template('counter.html')

@app.route('/counter+2', methods = ['POST'])
def counter():
    print "printing"
    session['counter'] += 1
    
    return redirect('/')
@app.route('/counter_reset', methods = ['POST'])
def counter_reset():
    session.clear()
    # session['counter'] += 0
    
    return redirect('/')
app.run(debug=True)