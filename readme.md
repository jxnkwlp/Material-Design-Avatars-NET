# Material Design Avatars For .NET     
Create material deisgn avatars for users just like Google Messager. 


Example
------------
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=E&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=N&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=G&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=L&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=I&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=S&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=H&size=64)

![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=简&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=体&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=中&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=文&size=64)

![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=繁&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=體&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=中&size=64)
![](http://materialdesignavatars.azurewebsites.net/home/Avatar?letter=文&size=64)


Usage
------------

``` C# 

var avatar = new MdAvatar();

byte[] result = avatar.Build("E",512);

// File.WriteAllBytes(filename, result);

``` 

Fonts
------------
[Source Code Pro](https://github.com/adobe-fonts/source-code-pro)

[Source Han Sans](https://github.com/adobe-fonts/source-han-sans)


Reference
--------------
https://github.com/lincanbin/Material-Design-Avatars