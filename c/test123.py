def myFun(*argv, **kwargs):
	for arg in argv:
		print(arg)
	print(kwargs)


myFun('Hello', 'Welcome', 'to', 'GeeksforGeeks', foo="bar")
