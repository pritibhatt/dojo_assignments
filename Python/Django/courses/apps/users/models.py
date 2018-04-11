# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.db import models
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')
class UserManager(models.Manager):
    def validate_registration(self, postData):
        errors = {}
       
        if len(postData['first_name']) < 2:
            errors["first_name"] = "User first name should be more than 2 characters"
        if len(postData['last_name']) < 2:
            errors["last_name"] = "User last name should be more than 2 characters"
        if len(postData['password']) < 8:
            errors["password"] = "password must be at least 8 characters"
        if postData['password'] != postData['password_confirm']:
            errors["password_confirm"] = "passwords do not match"
        if not EMAIL_REGEX.match(postData['email']):
            errors['email'] = "Invalid email"
        else:
            if len(User.objects.filter(email=postData['email'])) > 0:
                errors['email'] = "Email already exists in the system"                                   
        return errors
    def validate_login(self, postData):
        errors = {} 
        if len(postData['password']) < 8:
            errors["password"] = "password must be at least 8 characters"
        if not EMAIL_REGEX.match(postData['email']):
            errors['email'] = "Invalid email"
        else:
            if not len(User.objects.filter(email=postData['email'])) > 0:
                errors['email'] = "Email incorrect"                                   
        return errors
       
class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.TextField()
    objects=UserManager()
