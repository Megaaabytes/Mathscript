function(main)
    def(number,0,input)

    try() Prevent uneccessary errors by ignoring them
        out("Enter a positive number: ")
        in(number,input)
    finish()

    if(${input}+0=0) Check wether if the user inputted a number.
        out("No arugments specified.")
        newline()
        pause()
        stop(1)
    endif()

    def(number#,100,x)
    
    def(number,1,index)

    loopuntil(${input}) Get every previous number before and including the input number.
        insert(x,${index})
        increment(index)
    endl()

    def(number,1,result)

    bfor(obj:ind, x) Use Reverse-For loop or Before-For loop to get every number before the current number.
        mul(${result},${obj}) Multiply the results
    endr()

    info(result)
    newline()
    pause()
stop(0)