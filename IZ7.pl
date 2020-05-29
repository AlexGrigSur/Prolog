:- dynamic origin/2, class/2, cost/2, isFullAuto/2, recoil/2,break/1.

write_list([]):-!.
write_list([H|T]):- write(H), write(" "), write_list(T).

write_str([]):-!.
write_str([H|T]):- write(H), write_str(T).

read_str(A):-get0(_),get0(X1),r_str(X1,A,[]).
r_str(10,A,A):-!.
r_str(X,A,B):-append(B,[X],B1),get0(X1),r_str(X1,A,B1).

game:- clear_DB,see('iz7.txt'), getWeapon, seen,!, q1(Ans1), q2(Ans2), q3(Ans3), q4(Ans4),
    q5(Ans5),answer_check(Ans1,Ans2,Ans3,Ans4,Ans5),write('Желаете продолжить игру? (0.-Нет,1.-Да)'),read(Continue),continue(Continue),clear_DB.

getWeapon:- readln(Weapon), Weapon \=[], readln(Info), origin_funct(Weapon, Info),getWeapon.
getWeapon:-!.

origin_funct(_, []):- !.
origin_funct(Weapon,[H|T]):- asserta(origin(Weapon,H)), class_funct(Weapon, T),!.

class_funct(_, []):- !.
class_funct(Weapon, [H|T]):- asserta(class(Weapon, H)), cost_funct(Weapon, T),!.

cost_funct(_,[]):- !.
cost_funct(Weapon,[H|T]):- asserta(cost(Weapon,H)), isFullAuto_funct(Weapon, T),!.

isFullAuto_funct(_, []):- !.
isFullAuto_funct(Weapon, [H|T]):- asserta(isFullAuto(Weapon, H)), recoil_funct(Weapon, T),!.

recoil_funct(_, []):- !.
recoil_funct(Weapon, [H|_]):- asserta(recoil(Weapon,H)).

q1(Ans):- write('Выберите сторону-производителя загаданного оружия'), nl, write('0. NATO.'), nl, write('1. Russia.'), nl,read(Ans).
q2(Ans):- write('\n\nВыберите класс загаданного оружия'), nl, write('0.Pistol.'), nl, write('1. SMG'),nl, write('2. Assault Rifle'),nl, write('3. MarkSman'),nl, write('4. Sniper\n'),
read(Ans).
q3(Ans):- write('\n\nЗагаданное оружие обладает возможностью ведения автоматического огня?'), nl, write('0. Нет.'), nl, write('1. Да.'),nl,read(Ans).
q4(Ans):- write('\n\nЗагаданное оружие обладает высокой стоимостью относительно своего класса?'), nl, write('0. Нет.'), nl, write('1. Да.'),nl,read(Ans).
q5(Ans):- write('\n\nВаше оружие обладает высокой отдачей?'),nl, write('0. Нет.'), nl, write('1. Да.'),nl,read(Ans).

answer_check(Ans1,Ans2,Ans3,Ans4,Ans5):-asserta(break(1)),findWeapon(Ans1,Ans2,Ans3,Ans4,Ans5,Weapon),
    forall((findWeapon(Ans1,Ans2,Ans3,Ans4,Ans5,Weapon)),(write('\nВаше оружие - '), write(Weapon),write('?\n0.-Нет,1.-Да'),read(Answer),answerYaUstalSpasitePojojda(Answer))),fail.
answer_check(_,_,_,_,_):-checkBreak0.
answer_check(Ans1,Ans2,Ans3,Ans4,Ans5):-write('Ваше оружие не было найдено в базе данных\nЖелаете добавить оружие в базу данных?\n0. Нет.\n1. Да.\n'), read(Answer),
    add_Weapon(Answer,[Ans1,Ans2,Ans3,Ans4,Ans5]).

answerYaUstalSpasitePojojda(Answer):-Answer=1,asserta(break(0)),!.
answerYaUstalSpasitePojojda(_):-asserta(break(1)).

findWeapon(Ans1,Ans2,Ans3,Ans4,Ans5,Weapon):-origin(Weapon,Ans1), class(Weapon,Ans2), cost(Weapon,Ans3), isFullAuto(Weapon,Ans4), recoil(Weapon,Ans5),checkBreak1.
findWeapon(_,_,_,_,_,_):-fail.

continue(0):-!.
continue(1):-clear_DB,game.
clear_DB:-retractall(origin(_,_)),retractall(class(_,_)),retractall(cost(_,_)),retractall(isFullAuto(_,_)),retractall(recoil(_,_)), retractall(break(_)).

checkBreak1:-break(X),!,X=1.
checkBreak0:-break(X),!,X=0.

add_Weapon(1, List):-write('Введите название вашего оружия -- '), read_str(Name), name(Weapon, Name), add_Weapon_to_DB(Weapon, List), !.
add_Weapon(0,_):- !.

add_Weapon_to_DB(CharName, List):- append('iz7.txt'), nl, write(CharName), nl, write_list(List), told.
