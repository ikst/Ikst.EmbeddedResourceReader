# Ikst.EmbeddedResourceReader
This is used to load files specified as "embedded resources".  
This is useful for including SQL and other files in the project for use.

## usage
This is an extension method of the System.Reflection.Assembly class.  
Get the Assembly with embedded resources and call the method.  

The following code is for loading "TextFile1.txt" as text in the UnitTest project.  
The file to be loaded must be set as an "embedded resource" in the properties.  
![GitHub_Readme1](https://user-images.githubusercontent.com/9896145/105632242-8043d800-5e95-11eb-8c51-37c4196a63ca.png) ![GitHub_Readme2](https://user-images.githubusercontent.com/9896145/105632264-8e91f400-5e95-11eb-9e61-90c57910c24c.png)

```C#
using Ikst.EmbeddedResourceReader;
 
var asm = System.Reflection.Assembly.GetExecutingAssembly();
var resTxt = asm.GetEmbeddedResourceString("TestResource.TextFile1.txt");
```

## nuget
https://www.nuget.org/packages/Ikst.EmbeddedResourceReader/