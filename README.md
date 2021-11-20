# Mathscript
A simple scripting language in C#. This is not a serious attempt at making a language, this language isn't the best but it works.

# Simple Hello World Program
```
 function(main)
  out("Hello World!")
  newline()
 pause()
```

# Running the program
You can either use the command line or simply set the default program for the '.ms' extension to the intepreter to run your program. 
If your going to use the command-line, type the interpreter file location and then the path to your script. That's it, your program will execute.
If your going to set the default program to the '.ms' file extension, you can just double-click your script and it will run.

# Making Functions
Mathscript currently only supports void and parameterless functions.

An example of functions:
```
  function(printHello)
    out("Hello!")
  endf()
  
  function(main)
    run(printHello)
    newline()
  pause()
```

# Variables
In Mathscript, you can make characters, booleans, numbers and strings. To make a variable, simply do:
```
  function(main)
    def(string,"HelloWorld",x)
    info(x)
    newline()
  pause()
```

In the def() command, you can change string to char, boolean or number.

# Arrays
To make an array, you can use the def() command again.
However, Mathscript only supports number and string array's at the moment. However, an implementation of boolean and character arrays are soon.

To make an array:
```
  function(main)
    def(string#,10,x)
    insert(x,"helloworld!")
    infoAt(x#0)
    newline()
  pause()
```  

Using the insert command we can insert objects into our array, an example of this is insert(<variable>,<object>). Use can use remove(<variable#index>) to delete a variable from the array. Inside the def() command you may notice that
the command contains an integer inside where normal variable declarations would contain a default value. The reason it is an integer is because that is the maximum size of
the array.
  
# Labels and navigating your code
In Mathscript, there are 3 ways you can navigate your code, the first method is using goto(<line>). There are a few problems with goto(). First of all, it can only navigate to
a specific line of your script. Meaning that lets say you reformat your code and that line now contains a different command, well goto won't change automatically so you'll have to manually change where the goto command is headed. 
  
The second way is using functions, however functions will eventually go back where they were called using the "run" command.
  
The third way is the best way. You can declare a label. Once you declare a label, the interpreter will do the rest of the work for you. It will memorize what line the label is declared on. Meaning that, if you were to goto that label, the goto command is filled in for you. Here is a quick example of how to use labels.
```  
  function(main)
     label(x)
     out("Hello World!")
     toLabel(x)
     stop(0)
  pause()
```  
This program will loop forever, because the toLabel() command will teleport the interpreter back to where the label was declared.
  
# Pausing the program temporarily
In Mathscript, you are able to freeze the program temporarily for a certain amount of milliseconds. To do this you use the sleep() command.
  
Example:
```
  function(main)
    sleep(2000)
    out("Hello World!")
    newline()
  pause()
```  
The sleep() command takes an argument of an integer. The argument will be in milliseconds how long you want the program to sleep for.
  
# Infinite Loops
You've seen how to do label loops. However, label loops are inconsistent and aren't the greatest thing to use. Mathscript has a few ways of making loops but the easiest way of 
making an infinite loop is using the loop() command.

Example:
```  
  function(main)
    loop()
      out("Hello World!")
      newline()
    endl()
  pause()
```  
This infinite loop will print Hello World onto the console indefinitely. 
 
**THE LOOP COMMAND DOES NOT TAKE ARGUMENTS, YOU WILL GET AN ERROR IF YOU TRY USING IT WITH ARGUMENTS!!**
  
# Temporary Loops
You've seen how to do infinite loops, but sometimes you don't want a infinite loop because you want your program to only print something a certain amount of times. Well there is a command for that. Using the loopuntil(<times>) command you can make your program do something that many times.

Example:
```  
  function(main)
    loopuntil(2)
      out("Hello World!")
      newline()
    endl()
  pause()
```  
This simple program will print "Hello World!" 3 times. Why 3? Well, the reason is because the number 0 is actually a 1. Meaning that, 2 will loop 3 times. So if you want the loop to loop once, use loopuntil(0).
  
# Ceasing loops
If you want to cease or break a loop. You're looking for the cease() command. The cease() command can break loops and switches at the moment.
  
An example:
```  
  function(main)
    loopuntil(2)
      out("Hello World!")
      newline()
      cease()
    endl()
  pause()
```  
Even though this loop tells the interpreter to loop 3 times. The cease command breaks it and stops the loop before it can execute the print command 3 times, so it will only execute once.
  
# Switches
In many languages a simple if statement exists simply known as switch. In Mathscript, a switch command exists with similar syntax to the one in C#. Here's how to do it.
```  
  function(main)
    def(string,"test",x)
    switch(x)
      case(test1)
        out("test1")
      case(test)
        out("test")
      default()
        out("Non of the conditions were met")
    endw()
    newline()
  pause()
```  
The default() command will run if any of the cases do not match, once a case runs it will compare its value to the variable. If it matches it will break the switch and run the code below the case. If it dosen't, it will block reading until a switch or a default.
  
**DO NOT PUT THE DEFAULT() CASE FIRST, ONCE IT RUNS IT WILL CEASE THE SWITCH!!**
  
You can also put the cease() command to break the switch and stop it from executing.
  
# Deleting variables
In Mathscript, deleting variables is easy. Simply use the blur(<name of variable>) command. This command only works with regular variables not arrays.
  
Example:
```  
  function(main)
    def(string,"hello",x)
    blur(x)
    info(x)
  pause()
```  
This script will be stopped by the interpreter and raise an exception because the info() command is looking for variable "x" but it dosen't exist because it was deleted. The script will work if you remove the "info(x)" command.
  
# If, Elseif, Else
In Mathscript, you are able to check if a given statement is true. To do this, you use an If statement.
 
Example of a regular if:
 
```
 function(main)
    def(string,"test",x)
    if(${x}+?=test)
        out("Hello World!")
        newline()
    endif()
 pause()
```
 
Example of Elseif:
 
```
 function(main)
    def(string,"test1",x)
    if(${x}+?=test)
        out("Hello World!")
        newline()
    elseif(${x}+?=test1)
        out("Else if!")
        newline()
    endif()
 pause()
```
 
Example of Else:
 
```
   function(main)
    def(string,"test12",x)
    if(${x}+?=test)
        out("Hello World!")
        newline()
    elseif(${x}+?=test1)
        out("Else if!")
        newline()
    else()
        out("Else ran!")
        newline()
    endif()
 pause()
```

# For Loops!
Mathscript allows you now easily create a for loop. Heres how to do it:
```
function(main)
	 def(string#,10000,x)
	 insert(x, "bar")
  	 insert(x, "foo")
	 insert(x, "test")

	 for(object:index,x)
		 infoAt(x#${index}) alternatively, you could use info(object)
		 out(":")
		 info(index)
		 newline()
	 endr()

	 pause()
stop(0)
```
 
The variable "object" gets created when the for loop runs and kept once the execution finishes for if later use is needed. The object variable stores a string value of the variable in current index the for loop is on. For example, if the for loop is on index 3. The value of object will be set to the value of the third variable in the array.
 
The variable index is automatically set to 0 when the loop startes and gradually increases every time the loop hits a endr or next block. The index variable is what makes the for loop function. If the index variable did not exist, then there would be no for loop. The index variable will keep increasing until the last index in the array.
 
Variable x is the array which is being looped through in the for loop.
 
# Bfor loop
Bfor is type of loop which is essentially a reverse for loop. Basically, bfor starts at the end of the array rather than the beginning and makes it's way down until its on the first item.
	
```
function(main)
	 def(string#,10000,x)
	 insert(x, "bar")
  	 insert(x, "foo")
	 insert(x, "test")

	 bfor(object:index,x)
		 info(object)
		 out(":")
		 info(index)
		 newline()
	 endr()

	 pause()
stop(0)	
```
	
# Checking the interpreter version
To ensure your program will work on any device, Mathscript allows you to check the version of the interpreter your program is being ran on. If it dosen't match the expected version, your program will raise an exception.
	
How to check the interpreter version:
```
function(main)
	chkver(1.0.4)
stop(0)
```
	
The code above will not raise any errors if the current version is 1.0.4
	
```
function(main)
	chkver(1.0.2)
stop(0)
```
	
The code above will not work on versions above 1.0.2. 
	
**The Chkver command was only added in version 1.0.4. It will not be recognized on versions below 1.0.4.**
	
# Math!
Inorder to do math in Mathscript, you will primarily use the following:
	
mul(<variable>,<veriable or digit>) This command will multiply 2 numbers together.
add(<variable>,<veriable or digit>) This command will add 2 numbers together.
div(<variable>,<veriable or digit>) This command will divide 2 numbers together.
pow(<variable>,<veriable or digit>) This command will power the first number to the second the number.
per(<variable>,<veriable or digit>) This command is an easy way of converting two numbers into a single percent.
sub(<variable>,<veriable or digit>) This command will subtract 2 numbers together.

# A note about whilst.
As of right now, The whilst statement is new and has not yet fully been compliant with variables or arrays. So it won't be covered in readme. However, you can find an example of it, in the "examples" folder in this repository.
