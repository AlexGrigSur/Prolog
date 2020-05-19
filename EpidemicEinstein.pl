in_list([El|_],El).
in_list([_|T],El):-in_list(T,El).

/*
Пятеро детей Алик, Боря, Витя, Лена и Даша приехали в лагерь из 5
разных городов: Харькова, Умани, Полтавы, Славянска и Краматорска. Есть
4 высказывания: 1) Если Алик не из Умани, то Боря из Краматорска. 2) Или
Боря, или Витя приехали из Харькова. 3) Если Витя не из Славянска, то Лена
приехала из Харькова. 4) Или Даша приехала из Умани, или Лена из
Краматорска. Кто откуда приехал?
*/

iz4_predicate:-Childrens=[_,_,_,_,_],
    in_list(Childrens,[alik,_]),
    in_list(Childrens,[borya,_]),
    in_list(Childrens,[vitya,_]),
    in_list(Childrens,[lena,_]),
    in_list(Childrens,[dasha,_]),
    in_list(Childrens,[_,harkov]),
    in_list(Childrens,[_,ymani]),
    in_list(Childrens,[_,poltava]),
    in_list(Childrens,[_,slavyansk]),
    in_list(Childrens,[_,kramatorsk]),
    %1
    (
      (
         in_list(Childrens,[alik,ymani]);
         in_list(Childrens,[borya,kramatorsk])
       ),
       %2
       (
         in_list(Childrens,[borya,harkov]);
         in_list(Childrens,[vitya,harkov])
       ),
       %3
       (
         in_list(Childrens,[vitya,slavyansk]);
         in_list(Childrens,[lena,harkov])
       ),
       %4
       (
         in_list(Childrens,[dasha,ymani]);
         in_list(Childrens,[lena,kramatorsk])
       )
    ),
    in_list(Childrens,[F1,harkov]),
    in_list(Childrens,[F2,ymani]),
    in_list(Childrens,[F3,poltava]),
    in_list(Childrens,[F4,slavyansk]),
    in_list(Childrens,[F5,kramatorsk]),

    write("Harkov"),write(" "),write(F1),nl,
    write("Ymani"),write(" "),write(F2),nl,
    write("Poltava"),write(" "),write(F3),nl,
    write("Slavyansk"),write(" "),write(F4),nl,
    write("Kramatorsk"),write(" "),write(F5),!.
