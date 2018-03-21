# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from ..users.models import User
from django.db import models
from datetime import date
from datetime import datetime
# Create your models here.
class TravelManager(models.Manager):
    def validate(self, postData):
        errors = {}
       
        if len(postData['destination']) < 1:
            errors["destination"] = "Destination cannot be empty"
        if len(postData['description']) < 1:
            errors["description"] = "Description cannot be empty"
        if postData['date_from'] < postData['date_to']:
                errors["date_from"] = "Travel Date To cannot be before Travel from Date"    
        return errors
    
   
class Travel(models.Model):
    destnation = models.CharField(max_length=255)
    travel_start_date = models.DateField()
    travel_end_date = models.DateField()
    plan = models.TextField()
    travel_created_by = models.ForeignKey(User, related_name="travels_created")
    favorite_travels = models.ManyToManyField(User, related_name="travels_joined")
    objects = TravelManager()