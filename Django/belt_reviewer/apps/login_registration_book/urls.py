from django.conf.urls import url
from . import views
urlpatterns = [
url(r'^$', views.index),
url(r'^register$', views.register), 
url(r'^books$', views.books_home),   
url(r'^login$', views.login),
url(r'^books/add$', views.books_add),   
url(r'^books/(?P<review_id>\d+)$', views.show_reviews),   
 
]