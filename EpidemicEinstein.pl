%  событие, место, профессия, кол-во зараженных
in_list([El|_],El).
in_list([_|T],El):-in_list(T,El).

pr_ein:-Event=[_,_,_,_],
    in_list(Event,[funeral,italy,_,_]),
    in_list(Event,[wedding,france,_,_]),
    in_list(Event,[_,france,_,15]),
    in_list(Event,[rest,china,_,_]),
    in_list(Event,[conference,_,programmer,_]),
    in_list(Event,[_,usa,_,1]),
    in_list(Event,[_,_,official,45]),
    in_list(Event,[_,_,banker,6]),
    in_list(Event,[_,_,blogger,_]),
    not(in_list(Event,[_,china,blogger,_])),
    not(in_list(Event,[_,china,official,_])),

    in_list(Event,[funeral,F1,F2,F3]),
    in_list(Event,[wedding,S1,S2,S3]),
    in_list(Event,[rest,T1,T2,T3]),
    in_list(Event,[conference,Frth1,Frth2,Frth3]),

    write("funeral "),write(F1),write(" "),write(F2),write(" "),write(F3),nl,
    write("wedding "),write(S1),write(" "),write(S2),write(" "),write(S3),nl,
    write("rest "),write(T1),write(" "),write(T2),write(" "),write(T3),nl,
    write("conference "),write(Frth1),write(" "),write(Frth2),write(" "),write(Frth3), !.