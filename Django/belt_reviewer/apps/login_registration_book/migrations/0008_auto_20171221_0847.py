# -*- coding: utf-8 -*-
# Generated by Django 1.11 on 2017-12-21 14:47
from __future__ import unicode_literals

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('login_registration_book', '0007_auto_20171221_0841'),
    ]

    operations = [
        migrations.RemoveField(
            model_name='book',
            name='user',
        ),
        migrations.RemoveField(
            model_name='review',
            name='book',
        ),
        migrations.RemoveField(
            model_name='review',
            name='reviewer',
        ),
        migrations.DeleteModel(
            name='Book',
        ),
        migrations.DeleteModel(
            name='Review',
        ),
        migrations.DeleteModel(
            name='User',
        ),
    ]
