function(main)
    def(number,0,arg1)
    def(number,0,arg2)

    try()
        out("Enter a positive integer: ")
        in(number,arg1)

        newline()

        out("Enter a second postive integer: ")
        in(number,arg2) 
    finish()

    if(${arg1}+0=0)
        out("The first argument is not valid.")
        newline()
        pause()
        stop(0)
    endif()

    if(${arg2}+0=0)
        out("The second argument is not valid.")
        newline()
        pause()
        stop(0)
    endif()

    def(number,0,result)

    loop()
        add(${result},${arg2})
        
        try()
            if(${result}%${arg1}=0)
                out("LCM => ")
                info(result)
                cease()
            endif()
        finish()
    endl() 

    newline()
    pause()
stop(0)