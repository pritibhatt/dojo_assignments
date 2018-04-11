from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
import md5
import os, binascii

app = Flask(__name__)

app.secret_key = 'keyspass'

mysql = MySQLConnector(app, 'login_registration')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/process', methods=['POST'])
def login():
    email = request.form['email']
    # password = request.form['password']
    email_query = "SELECT * FROM user WHERE user.email = :email_1"
    email_data = {'email_1': email}
    user = mysql.query_db(email_query, email_data)
    if len(user) != 0:
        encrypted_password = md5.new(request.form['password'] + user[0]['salt']).hexdigest()
        if user[0]['password'] == encrypted_password:
            return redirect('/wall')
        else:
            flash("Invalid Password!")  
                          
    else:
        flash("Invalid email or register")
    
    return redirect ('/')
@app.route('/register', methods=['POST'])
def register():
    if len(request.form['first_name']) < 2:
        flash("First Name must contain at least 2 letters ")
    if len(request.form['last_name']) < 2:
        flash("Last Name must contain at least 2 letters ")
    if len(request.form['email']) < 1:
        flash("Email cannot be blank!")
    if not EMAIL_REGEX.match(request.form['email']):
        flash("Invalid Email Address!")
    if len(request.form['password']) < 8: 
        flash("Password must be at least 8 characters")
    if not request.form['password'] == request.form['confirm_password']: 
        flash("Passwords do not match!")
        return redirect('/')
    else:
        password = request.form['password']
        salt =  binascii.b2a_hex(os.urandom(15))
        hashed_pw = md5.new(password + salt).hexdigest()
        insert_query = "INSERT INTO user (first_name, last_name, email, password, salt, created_at, updated_at) VALUES (:first_name, :last_name, :email, :hashed_pw, :salt, NOW(), NOW())"
        query_data = { 'first_name': request.form['first_name'], 'last_name': request.form['last_name'], 'email': request.form['email'], 'hashed_pw': hashed_pw, 'salt': salt}
        mysql.query_db(insert_query, query_data)
        return redirect('/wall')

        
@app.route('/addmsg', methods = ['POST'])
def add_msg():
    postinto = request.form['postmsg']
    insert_q = "INSERT INTO post (post, created_at, updated_at) VALUES (:post, NOW(), NOW())"
    insert_data = {'post': postinto}
    mysql.query_db(insert_q, insert_data)
    return redirect('/wall')
@app.route('/wall')
def post():
    query = "SELECT post, post.created_at, first_name, last_name FROM user INNER JOIN post ON user.id = post.user_id ORDER BY created_at DESC"
    wall = mysql.query_db(query)
    return render_template('wall.html', all_posts=wall)

app.run(debug=True)