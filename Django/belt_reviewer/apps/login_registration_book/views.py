# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import User, Author, Book, Review
from django.contrib import messages
from django.shortcuts import render, HttpResponse, redirect
import bcrypt

# Create your views here.
def index(request):
	context = {
		"users": User.objects.all(),
		}
	return render(request, "login_registration_book/index.html", context)
def register(request):
    errors = User.objects.validate_registration(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/')
    if not errors:
        hashedpw = bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt())
        new_user = User.objects.create(
        
        first_name=request.POST['first_name'],
        last_name=request.POST['last_name'],
        email=request.POST['email'],
        password= hashedpw
        )
        request.session['id'] = new_user.id    
        return redirect('/books')
def login(request):
    errors = User.objects.validate_login(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/')
    if not errors:
            user = User.objects.filter(email=request.POST['email'])[0]
            if  bcrypt.checkpw(request.POST['password'].encode(), user.password.encode()):
                return redirect('/books')
            else:
                messages.error(request, 'password is incorrect.') 
                return redirect('/')
def books_home(request):
        context = {
            'user': User.objects.get(id=request.session['id'])
        }
        return render(request, "login_registration_book/books_home.html", context)
def books_add(request):
     context = {
        'author': Author.objects.all()
     }
    
     return render(request, "login_registration_book/books_add.html", context)
def show_review(request,review_id):
    errors = course.objects.validate_review(request.POST)
    if errors:
        for error in errors:
            messages.error(request, error)
            return redirect('/')
    if not errors:
        current_user=User.objects.get(id=request.session['id'])
        new_book_title=Book.bojects.create(title=request.POST['title'])
        new_author=Author.objects.create(name=request.POST['author'])
        new_book=Book.objects.create(
            title=new_book_title,
            author=new_author,
        )
        new_review = Review.objects.create(
            review=request.POST['review'],
            rating=request.POST['rating'],
            
        )
        return redirect('/books/review_id')
    
def show_reviews(request, id):
        return render(request, "login_registration_book/show_reviews.html")
    