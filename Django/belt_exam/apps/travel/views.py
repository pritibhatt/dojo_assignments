# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from ..users.models import User
from .models import Travel
from django.contrib.messages import constants as messages
from django.contrib import messages
from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    current_user= User.objects.get(id=request.session['id'])
    travels_user_joined = current_user.travels_joined.all()
    travels_user_not_joined = Travel.objects.exclude(favorite_travels=current_user)
    context = {
        "user":current_user,
        # "travels":Travel.objects.all()
    #     #courses_liked is related name from manytomany
        "travels_joined" : travels_user_joined,
        "other_travels" : travels_user_not_joined
     }
    return render(request, "travel/index.html", context)
def add_new_travel(request):
    
    return render(request, "travel/add_trip.html")

def process_new_travel(request):
    errors = Travel.objects.validate(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect("travels:add")
    if not errors:
        current_user= User.objects.get(id=request.session['id'])  
        new_travel = Travel.objects.create(
        
        destnation=request.POST['destination'],
        travel_start_date=request.POST['date_from'],
        travel_end_date=request.POST['date_to'],
        plan=request.POST['description'],
        travel_created_by=current_user, 
        )
        return redirect("travels:index")
def show(request, travel_id):
    current_travel = Travel.objects.get(id=travel_id)
    context = {
        "travel":current_travel
         }

    return render(request, "travel/show.html", context)
def add_to_join(request, travel_id):
    current_travel = Travel.objects.get(id=travel_id)
    current_user= User.objects.get(id=request.session['id'])  
    current_travel.favorite_travels.add(current_user)
    current_travel.save()
    return redirect("travels:index") 
def remove_from_join(request, travel_id):
    current_travel = Travel.objects.get(id=travel_id)
    current_user= User.objects.get(id=request.session['id'])  
    current_travel.favorite_travels.remove(current_user)
    current_travel.save()
    return redirect("travels:index") 
def delete(request, travel_id):
    travel_delete = Travel.objects.get(id=travel_id)
    travel_delete.delete()
    return redirect("travels:index") 
