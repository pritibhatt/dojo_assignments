# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse, redirect
import datetime
from django.utils.crypto import get_random_string
from time import gmtime, strftime, localtime
def index(request):
  context = {
  "time": strftime("%b-%d-%Y %I:%M %p", localtime())
  
  }
  return render(request,'times_display/index.html', context)
 