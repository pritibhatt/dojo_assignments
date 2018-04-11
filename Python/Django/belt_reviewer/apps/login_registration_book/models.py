# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.db import models
from datetime import datetime
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
# class ReviewManager(models.Manager):
    # def validate_review(self, post_data):
    #     errors = []
    #     if len(post_data['title']) < 1 or len(post_data['review']) < 1:
    #         errors.append('fields are required')
    #     if not "author" in post_data and len(post_data['new_author']) < 3:
    #         errors.append('new author names must 3 or more characters')

    #     if "author" in post_data and len(post_data['new_author']) > 0 and len(post_data['new_author']) < 3:
    #         errors.append('new author names must 3 or more characters')
    #     if not int(post_data['rating']) > 0 or not int(post_data['rating']) <= 5:
    #         errors.append('invalid rating')
    #     return errors
    # def create_review(self, post_data, user_id):
    #     # retrive or create author
    #     the_author = None
    #     if len(post_data['new_author']) < 1:
            # the_author = Author.objects.get(id=int(post_data['author']))
        # else:
            # the_author = Author.objects.create(name=post_data['new_author'])
        # retirive or create book
        # the_book = None
        # if not Book.objects.filter(title=post_data['title']):
        #     the_book = Book.objects.create(
        #         title=post_data['title'], author=the_author
        #     )
        # else:
        #     the_book = Book.objects.get(title=post_data['title'])
        # # returns a Review object
        # return self.create(
        #     review = post_data['review'],
        #     rating = post_data['rating'],
        #     book = the_book,
        #     reviewer = User.objects.get(id=user_id)
        # )
class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.TextField()
    objects = UserManager()

class Author(models.Model): 
    name = models.CharField(max_length=255)  


class Book(models.Model):
    title = models.CharField(max_length=255)
    author = models.ForeignKey(Author, related_name="books")
    user = models.ForeignKey(User, related_name="books_created") 

class Review(models.Model):
    review = models.TextField()
    rating = models.IntegerField()
    book = models.ForeignKey(Book, related_name="reviews")
    reviewer = models.ForeignKey(User, related_name="reviews_created")
    created_at = models.DateTimeField(auto_now_add=True)
    # objects = ReviewManager()
    