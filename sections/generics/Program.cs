////////////////////////////////////////////////////////////////////////////////////////////////////////////
//-----------------------------------------------Generics-------------------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Generics (обобщённые типы)
// 
// Обобщения позволяют создавать единое решение задачи, для
// различных типов. Это значит, что с использованием обобщений,
// мы можем передавать классу или методу значения любых типов,
// но прежде чем передавать, мы должны выбрать нужный нам тип.
// Это позволяет избавиться от упаковки и распаковки типов, 
// помогает сохранить типобезопастность.

// Обобщённые типы
// Для выбора типа, используются угловые скобки <>
//
// User<int> userOne = new User<int>(123);
User<int> userOne = new(123);
userOne.Name = "Vasya";
Console.WriteLine(userOne.Name);
userOne.Print();

User<string> userTwo = new("234df");
userTwo.Name = "Petya";
userTwo.Print();


// Несколько обобщённых типов для одной функции или класса
RandomDuck randomDuck = new();
randomDuck.Print<int, string>("quack", 3, "Ten"); // Или так randomDuck.Print("quack", 3);
randomDuck.Print<string, int>("quack", "hundreed", 100); // Или так randomDuck.Print("quack", "hundreed");


// Статические поля обобщенных классов
Potato<int> potato = new Potato<int>(111);
Potato<string>.Value = "Lool";
Console.WriteLine(potato.Data);
Console.WriteLine(Potato<string>.Value);


// Наследование обобщённых классов
// Классы с обобщёнными типами, тоже могут наследоваться.
// При этом можно использовать разлтчниые варианты наследования
// 1) Класс наследник имеет тот же тип обобщения. "class UniversalPerson<T> : Person<T>"
// 2) Класс наследник не имеет обобщения. В таком  "class UniversalPerson : Person<int>"
//    случае, при наследовании, нужно явным образом
//    определить использкемый тип
// 3) Класс наследник имеет тип обобщения отличный от родительского,  "class UniversalPerson<T> : Person<int>"
//    в таком случае, при наследовании, нужно явным образом определить
//    используемый тип
Dyadya<string> dydya = new Dyadya<string>("Azazazaza");
Vasya<int> vasya = new Vasya<int>(010101);
dydya.Print();
vasya.Print();


// Ограничение обобщений
//
// Благодаря обобщениям, мы можем передавть любые типы, но иногда
// возникает потребность в ограничении передаваемых типов. Такая
// потребность, может возникнуть, если нам нужно принимать не все
// типы, а только некоторые. Допустим только значимые, или только
// ссылочные, или только тип необходимого класса, соответсвенно и
// всех его дочерних. 
//
// На этом этапе может возникнуть справедливый вопрос: А зачем это
// вообще нужно? Мы же можем и не использовать обобщение, а 
// принимаемый тип класса можем указать прямо так, без всяких 
// обобщений, соответственно и ограничения тогда нам и не нужны.
// Но тут опять возникают проблемы с типобезопасностью, так ещё
// и преобразовывать придётся, если мы передадим дочерный объект

// Тут, когда мы передаём объект дочернего класса, преобразования не происходит
Leel leel = new Leel() { text = "aoaoao"};
Lool lool = new Lool() { text = "ekekek"};
Ulala<Leel> omg = new Ulala<Leel>(leel);
Ulala<Lool> omagad = new Ulala<Lool>(lool);

Leel a = omg.Value;
Lool b = omagad.Value;

// Тут, когда мы передаём объект дочернего класса, он преобразовывается Upcast-ится
// к типу родительского класса, поэтому для дальнейшер работы с ним, надо преобразовать
// его обратно, к его изначальному типу За-Downcast-ить. А если вдруг мы передали не
// объект дочернего класса, а родительского, то при попытке преобраховать его к дочернему
// типу, мы поймаем исключение.
Leel2 leel2 = new Leel2() { text = "aoaoao"};
Lool2 lool2 = new Lool2() { text = "ekekek"};
Ulala2 omg2 = new Ulala2(leel2);
Ulala2 omagad2 = new Ulala2(lool2);

Leel2 a2 = (Leel2)omg2.Value;
Lool2 b2 = (Lool2)omagad2.Value;
// Leel2 a2 = omg.Value; // Cannot implicitly convert type 'Leel' to 'Leel2'
// Lool2 b2 = omagad.Value; // Cannot implicitly convert type 'Lool' to 'Lool2'


class User<Umung>
{

    private Umung _umung { get; }
    private string _name = "omg";
    public string Name { get => "U cant get it, use Print()"; set => _name = value; }
    public User(Umung umung)
    {
        _umung = umung;
    }
    public void Print()
    {
        Console.WriteLine($"{_name}, umung index is: {_umung}");
    }
}

class RandomDuck
{
    public void Print<LOOL, LAAL>(string a, LOOL b, LAAL c)
    {
        Console.WriteLine($"{a}: {b} times and {c} times bite");
    }
}



class Potato<Type>
{
    public Type Data { get; }
    public static Type? Value;
    public Potato(Type data)
    {
        Data = data;
    }
}



class Dyadya<Type>
{
    public Type Info { get; }
    public Dyadya(Type info)
    {
        Info = info;
    }
    public void Print()
    {
        Console.WriteLine($"Hahah, you looks like potato! Because {Info}");
    }
}

class Vasya<Type> : Dyadya<Type>
{
    public Vasya(Type info) : base(info) {}
}



// Этот клас в примере (строка 73), 
// принимает объекты нижеупоммянутых
// классов
class Ulala<Type> where Type : Leel
{
    public Type Value { get; }
    public Ulala(Type value)
    {
        Value = value;
    }
}

// Объекты этих классов принимает 
// класс Ulala. Они служат примером
// Родительского и дочернего типа
class Leel
{
    public string? text;
}

class Lool : Leel
{

}



// Этот клас в примере (строка 82), 
// принимает объекты нижеупоммянутых
// классов
class Ulala2
{
    public Leel2 Value { get; }
    public Ulala2(Leel2 value)
    {
        Value = value;
    }
}

// Объекты этих классов принимает 
// класс Ulala2. Они служат примером
// Родительского и дочернего типа
class Leel2
{
    public string? text;
}

class Lool2 : Leel2
{

}
