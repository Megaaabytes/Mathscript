function(main)
	def(string#,100,x)

	insert(x, "foo")
	insert(x, "bar")
	insert(x, "test")

	bfor(obj:index, x)
		info(obj)
		out(":")
		info(index)
		newline()
	endr()
	
	pause()
stop(0)