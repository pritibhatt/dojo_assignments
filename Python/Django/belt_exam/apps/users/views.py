# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import User
from django.contrib.messages import constants as messages
from django.contrib import messages
from django.shortcuts import render, HttpResponse, redirect
import bcrypt

# Create your views here.
def index(request):
	return render(request, "users/index.html")
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
    return redirect('travels:index')
def login(request):
    errors = User.objects.validate_login(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/')
    if not errors:
            user = User.objects.filter(email=request.POST['email'])[0]
            request.session['id'] = user.id
            if  bcrypt.checkpw(request.POST['password'].encode(), user.password.encode()):
                return redirect('travels:index')
            else:
                messages.error(request, 'password is incorrect.') 
                return redirect('/')                      
def sucess(request):
    context = {
        'user': User.objects.get(email=request.session['emailuser'])
    }
    return render(request, "users/sucess.html", context)

