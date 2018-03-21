# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import User
from django.contrib import messages
from django.shortcuts import render, HttpResponse, redirect

def index(request):
	context = {
		"users": User.objects.all(),
		}
	return render(request, "users/index.html", context)
def new(request):
    return render(request, "users/new_user.html")
def show(request, id):
    context = {
		"user": User.objects.get(id=id),
		}
    return render(request, "users/show.html", context)
def create(request):
    errors = User.objects.validate(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/users/new')
    
    User.objects.create(
        
        first_name=request.POST['first_name'],
        last_name=request.POST['last_name'],
        email=request.POST['email'],
    )
    return redirect('/users')
def edit(request, id):
    context = {
		"user": User.objects.get(id=id),
		}
    return render(request, "users/edit.html",context)
def update(request, id):
    errors = User.objects.validate_edit(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/users/'+id+'/edit')
       
    
    user_update = User.objects.get(id=id)
    user_update.first_name = request.POST['first_name'],
    user_update.last_name = request.POST['last_name'],
    user_update.email = request.POST['email'],   
    user_update.save()
    return redirect('/users')
def destroy(request,id):
    user_delete = User.objects.get(id=id)
    user_delete.delete()
    return redirect('/users')
    


    
