# -*- coding: utf-8 -*-
# Generated by Django 1.11 on 2017-12-19 17:19
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('login_registration_book', '0002_book'),
    ]

    operations = [
        migrations.AddField(
            model_name='book',
            name='rating',
            field=models.IntegerField(default=1),
            preserve_default=False,
        ),
    ]
