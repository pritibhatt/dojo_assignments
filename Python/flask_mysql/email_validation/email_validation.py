from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
app.secret_key = 'key'
mysql = MySQLConnector(app, 'email_validation')

@app.route('/')
def email():
    query = "SELECT * FROM email"
    emails = mysql.query_db(query)  
    return render_template('index.html') 

@app.route('/success')
def insert():
     
    query = "SELECT * FROM email"
    emails = mysql.query_db(query) 
    
    return render_template('show.html', email=session['emailv'], all_emails=emails)

@app.route('/insert', methods = ['POST'])
def addnew():
    query = "SELECT * FROM email WHERE email = :dataemail"
    data = {'dataemail': request.form['email']}
    emails = mysql.query_db(query, data)
    session['emailv']=request.form['email']  
    
    if len(emails) == 0:
        
        query = "INSERT INTO email (email, created_at, updated_at) VALUES (:email, NOW(), NOW())"
        data = {
            'email': request.form['email']
        }
        emails = mysql.query_db(query, data)
        return redirect('/success')
        
        
    else:
        flash("Email is not valid!")
        return redirect('/')
        
       
        
app.run(debug=True)  