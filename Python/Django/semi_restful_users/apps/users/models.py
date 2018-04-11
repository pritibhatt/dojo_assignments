# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.db import models
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')
class UserManager(models.Manager):
    def validate(self, postData):
        errors = {}
       
        if len(postData['first_name']) < 1:
            errors["first_name"] = "User first name should be more than 2 characters"
        if len(postData['last_name']) < 1:
            errors["last_name"] = "User last name should be more than 2 characters"
        if not EMAIL_REGEX.match(postData['email']):
            errors['email'] = "Invalid email"
        else:
            if len(User.objects.filter(email=postData['email'])) > 0:
                errors['email'] = "Email already exists in the system"        
        return errors
    
    def validate_edit(self, postData):
        errors = {}
        readonly_fields=('email',)
        if len(postData['first_name']) < 2:
            errors["first_name"] = "User first name should be more than 2 characters"
        if len(postData['last_name']) < 2:
            errors["last_name"] = "User last name should be more than 2 characters"
        if len(postData['email']) > 0 :
            errors["email"] = "Email cannot be updated"     
        return errors

class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add = True)
    objects=UserManager()
    
    