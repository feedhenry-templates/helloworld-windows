[![Build status](https://ci.appveyor.com/api/projects/status/lrlv2l28en4saq7e?svg=true)](https://ci.appveyor.com/project/edewit/helloworld-windows)

helloworld-windows: Basic Windows Mobile Hello World App
========================================================
Author: Erik Jan de Wit (edewit)
Level: Beginner  
Technologies: Windows
Summary: A basic example of the Platform : Send your name and get a Hello <name> response
Target Product: Mobile  
Product Versions: MP 1.0   
Source: https://github.com/feedhenry-templates/helloworld-windows

What is it?
-----------

This project is a very simple helloworld, to show how to send something to the platform and have get a response ("Hello <name>")

System requirements
-------------------

Visual Studio 2015 or 2013

Build and Install
-----------------

Open the HelloWorld Visual Studio project and build.

> Note: Temporary dev certificate expired every year. To renew it follow [VisualStudio instructions](https://msdn.microsoft.com/en-us/library/windows/apps/br230260(v=vs.110).aspx).

Build and Deploy the HelloWorld
-------------------------------

fhconfig.json will be automaticly filled if build / created from the platform if you use this manually you'll have to update the configuration

Application Flow
----------------

Fill in a name and push "Say Hello" to send it to the [cloud app](https://github.com/feedhenry-templates/helloworld-cloud) see the response appear below the button.
