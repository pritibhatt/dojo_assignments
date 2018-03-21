# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string

def index(request):
    
    if 'counter' in request.session:
        request.session['counter'] += 1
        request.session['unique_id'] = get_random_string(length=14)
    else:
        request.session['counter'] = 0
        # return 
    return render(request,'counter/index.html')
def reset(request):
   
       request.session.clear()
       return redirect("/random_word")
	