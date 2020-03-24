man(anatoliy).
man(dimitry).
man(zahar).
man(vladimir).
man(artem).
girl(vera).
girl(fjokla).
girl(dasha).
girl(lida).
girl(liza).

child(dimitry,anatoliy).
child(dimitry,vera).
child(vladimir,anatoliy).
child(vladimir,vara).
child(zahar,dimitry).
child(zahar,fjokla).
child(dasha,dimitry).
child(dasha,fjokla).
child(liza,vladimir).
child(liza,lida).
child(artem,vladimir).
child(artem,lida).

son(X,Y):-child(X,Y),man(X).
dauther(X,Y):-child(X,Y),girl(X).
brother(X,Y):-child(X,Z),!,child(Y,Z),X\=Y,man(Y),!.
sister(X,Y):-child(X,Z),!,child(Y,Z),X\=Y,girl(Y),!.
br_s(X,Y):-child(X,Z),!,child(Y,Z),X\=Y,!.

weeding(X,Y):-child(Z,X),child(Z,Y),!.

uncle(X,Y):-child(X,Z),br_s(Z,Y),man(Y),!.
uncle(X,Y):-child(X,Z),br_S(Z,R),weeding(R,Y),!.

/*aunt(X,Y):-child(X,Z),br_s(Z,Y),girl(Y),!.
aunt(X,Z):


aunt(X,Y).
vnuki_and_vnuchki(X,Y).*/
