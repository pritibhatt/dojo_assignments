# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from ..users.models import User
from django.db import models

# Create your models here.
class CourseManager(models.Manager):
    def validate(self, postData):
        errors = {}
       
        if len(postData['course_name']) < 5:
            errors["course_name"] = "Course name should be more than 5 characters"
        if len(postData['description']) < 5:
            errors["description"] = "Description should be more than 5 characters"
              
        return errors
    
   
class Course(models.Model):
    course_name = models.CharField(max_length=255)
    description = models.TextField()
    course_created_by = models.ForeignKey(User, related_name="courses_created")
    favorite_courses = models.ManyToManyField(User, related_name="courses_liked")
    created_at = models.DateTimeField(auto_now_add = True)
    objects = CourseManager()