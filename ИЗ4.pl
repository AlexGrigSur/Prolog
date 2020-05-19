in_list([El|_],El).
in_list([_|T],El):-in_list(T,El).

/*
#2) Пятеро детей Алик, Боря, Витя, Лена и Даша приехали в лагерь из 5
разных городов: Харькова, Умани, Полтавы, Славянска и Краматорска. Есть
4 высказывания: 1) Если Алик не из Умани, то Боря из Краматорска. 2) Или
Боря, или Витя приехали из Харькова. 3) Если Витя не из Славянска, то Лена
приехала из Харькова. 4) Или Даша приехала из Умани, или Лена из
Краматорска. Кто откуда приехал?
*/

iz3_predicate:-Childrens=[_,_,_,_,_],
    in_list(Childrens,[Alik,_]),
    in_list(Childrens,[Borya,_]),
    in_list(Childrens,[Vitya,_]),
    in_list(Childrens,[Lena,_]),
    in_list(Childrens,[Dasha,_]),
    in_list(Childrens,[_,Harkov]),
    in_list(Childrens,[_,Ymani]),
    in_list(Childrens,[_,Poltava]),
    in_list(Childrens,[_,Slavyansk]),
    in_list(Childrens,[_,Kramatorsk]),
    
    (    % начало обработки высказываний
        ( % №1
            not(in_list(Childrens,[Alik,Ymani])),
            in_list(Childrens,[Borya,Kramatorsk])
        );
        ( % №2
          (
            in_list(Childrens,[Borya,Harkov]);
            in_list(Childrens,[Vitya,Harkov])
          )
        );
        ( % №3
            not(in_list(Childrens,[Vitya,Slavyansk])),
            in_list(Childrens,[Lena,Harkov])
        );
        ( % №4
            (
              in_list(Childrens,[Dasha,Ymani]);
              in_list(Childrens,[Lena,Kramatorsk])
            )
        )
    ),

    in_list(Childrens,[F1,Harkov]),
    in_list(Childrens,[F2,Ymani]),
    in_list(Childrens,[F3,Poltava]),
    in_list(Childrens,[F4,Slavyansk]),
    in_list(Childrens,[F5,Kramatorsk]),

    write("Harkov"),write(" "),write(F1),nl,
    write("Ymani"),write(" "),write(F2),nl,
    write("Poltava"),write(" "),write(F3),nl,
    write("Slavyansk"),write(" "),write(F4),nl,
    write("Kramatorsk"),write(" "),write(F5),!.
