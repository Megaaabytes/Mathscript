# Mathscript
A simple scripting language in C#. This is not a serious attempt at making a language, this language isn't the best but it works.

# Simple Hello World Program
```
 function(main)
  out(Hello World!)
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
    out(Hello!)
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
    def(string,HelloWorld,x)
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
    insert(x,helloworld!)
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
     out(Hello World)
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
    out(Hello World)
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
      out(Hello World!)
      newline()
    endl()
  pause()
```  
This infinite loop will print Hello World onto the console indefinitely. 
**THE LOOP COMMAND DOES NOT TAKE ARGUMENTS, YOU WILL GET AN ERROR YOU TRY USING IT WITH ARGUMENTS!!**
  
# Temporary Loops
You've seen how to do infinite loops, but sometimes you don't want a infinite loop because you want your program to only print something a certain amount of times. Well there is a command for that. Using the loopuntil(<times>) command you can make your program do something that many times.

Example:
```  
  function(main)
    loopuntil(2)
      out(Hello World!)
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
      out(Hello World!)
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
    def(string,test,x)
    switch(x)
      case(test1)
        out(test1)
      case(test)
        out(test)
      default()
        out(Non of the conditions were met)
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
    def(string,hello,x)
    blur(x)
    info(x)
  pause()
```  
This script will be stopped by the interpreter and raise an exception because the info() command is looking for variable "x" but it dosen't exist because it was deleted. The script will work if you remove the "info(x)" command.
  
# A note about if, else, elseif and whilst.
As of right now, Operators and Operations are new and have not yet fully been compliant with variables or arrays. So they won't be covered in readme. However, you can find an example of them, in the "examples" folder in this repository.
