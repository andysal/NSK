Sharp Tests Extensions (#TestsEx for friends)
=============================================


How to build:
-------------

Run build.bat the result of compilation will be available in
.\Build\Output.


Which assembly do I need to use #TestsEx?
-----------------------------------------

You need only one of the assemblies deployed depending on the unit
tests framework you are using.

For example, if you are using xUnit you need only
SharpTestsEx.xUnit.dll.


When do I need the SharpTestsEx.dll?
------------------------------------

If the unit tests framework you are using is not directly supported,
you can use the base SharpTestsEx.dll.

The main difference when SharpTestsEx.dll will be that your runner
will not recognize the exception and its output will look slightly
less "pretty" than native assertions.

