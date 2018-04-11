# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from ..users.models import User
from .models import Course
from django.contrib.messages import constants as messages
from django.contrib import messages
from django.shortcuts import render, HttpResponse, redirect


# Create your views here.
def index(request):
    current_user= User.objects.get(id=request.session['id'])
    courses_user_liked = current_user.courses_liked.all()
    courses_user_not_liked = Course.objects.exclude(favorite_courses=current_user)
    context = {
        "user":current_user,
        #courses_liked is related name from manytomany
        
        "courses_liked" : courses_user_liked,
        "other_courses" : courses_user_not_liked
     }
    return render(request, "new_courses/index.html", context)

def add_new_course(request):
    errors = Course.objects.validate(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect("travels:add")
    if not errors:
        current_user= User.objects.get(id=request.session['id'])  
        new_course = Course.objects.create(
        #blue in db
        # after request.post in form  
        # course_created_by is foreignKey name from one to many relations 
        course_name=request.POST['course_name'],
        description=request.POST['description'],
        course_created_by=current_user, 
        )
        return redirect("courses:index")
def show(request, course_id):
    current_course = Course.objects.get(id=course_id)
    context = {
        "course":current_course
    }
    return render(request, "new_courses/show.html", context)
def add_to_favorites(request, course_id):
    current_course = Course.objects.get(id=course_id)
    current_user= User.objects.get(id=request.session['id'])  
    current_course.favorite_courses.add(current_user)
    current_course.save()
    return redirect("courses:index") 
def remove_from_favorites(request, course_id):
    current_course = Course.objects.get(id=course_id)
    current_user= User.objects.get(id=request.session['id'])  
    current_course.favorite_courses.remove(current_user)
    current_course.save()
    return redirect("courses:index") 
# def delete(request, course_id):
#      context = {
#          #blue id = database
#          #yellow id = in function def id
#          "new_courses": Course.objects.get(id=course_id)
#      }
#      return render(request, "new_courses/delete.html", context)
def delete(request, course_id):
    course_delete = Course.objects.get(id=course_id)
    course_delete.delete()
    return redirect("courses:index") 
