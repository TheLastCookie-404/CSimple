////////////////////////////////////////////////////////////////////////////////////////////////////////////
//---------------------------------------------Interfaces-------------------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Интерфейсы


// Пример реализации интерфейса классом

ImplementingClass implementingClass = new(){Lol = "Message"}; // Создаём экземпляр класса, который реализует интерфейс
implementingClass.Print();


// Пример реализации функционала интерфейсом по умолчанию
Iinterface1 implementingClass1 = new ImplementingClass1();
implementingClass1.Print();

// Но если мы сделаем так, то функцтионал реализованый интерфейсом по умолчанию, доступен не будет.
// ImplementingClass1 implementingClass1 = new ImplementingClass1();
// implementingClass1.Print(); //Ошибка CS1061 класс не содержит определения для данного метода


// Пример явной реализации интерфейса
Iinterface2 implementingClass2 = new ImplementingClass2();
implementingClass2.Print();

// Но если мы сделаем так, то явно реализованый функционал, доступен не будет.
// ImplementingClass2 implementingClass2 = new ImplementingClass2();
// implementingClass2.Print(); //Ошибка CS1061 класс не содержит определения для данного метода


// Примеры изменения реализации интерфейсрв в дочерних классах:

// 1) Переопределение абстрактных членов
BaseImplementingClass baseImplementingClass = new BaseImplementingClass();
InheritanceImplementingClass inheritanceImplementingClass = new InheritanceImplementingClass();
baseImplementingClass.Print();
inheritanceImplementingClass.Print();

// 2) Сокрытие функционала родительского класса дочерним
BaseImplementingClass1 baseImplementingClass1 = new BaseImplementingClass1();
InheritanceImplementingClass1 inheritanceImplementingClass1 = new InheritanceImplementingClass1();
baseImplementingClass1.Print();
inheritanceImplementingClass1.Print();

// 3) Повторная реадизация интерфейса 
BaseImplementingClass2 baseImplementingClass2 = new BaseImplementingClass2();
InheritanceImplementingClass2 inheritanceImplementingClass2 = new InheritanceImplementingClass2();
baseImplementingClass2.Print();
inheritanceImplementingClass2.Print();

// 4) Повторная реадизация интерфейса 
BaseImplementingClass3 baseImplementingClass3 = new BaseImplementingClass3();
Iinterface6 inheritanceImplementingClass3 = new InheritanceImplementingClass3();
baseImplementingClass3.Print();
inheritanceImplementingClass3.Print();


// Пример интерфейсов в обобщениях
InheritanceInterface person = new Person();
Idk<InheritanceInterface> idk = new(person);


// Интерфейс - это ссылочный тип, кторый может определять некий функционал, но не иметь его реализации.
// Функционал, определёлеый интерфейсом может реализовывать класс или стркутура, и если они реализуют
// функционал, то обязоны реализовать весь. Иинтерфейс является контрактом реализации зараенее 
// определённого функционала, что позволяет определять объекты с похожим поведением, таким образом
// реализуется полиморфизм.
// Пример: есть метод, который в качестве параметра мпринимает интерфейс. Технически в такой метод мы
// можем передать любой объект, реализующий конкретный интерфейс и это гарантирует нам, что передаваемый
// объект точно будет соответсвовать определённым критериям и при попытке ображения к какому либо элементу
// или функционалу класса, не возникнет проблем ввиду его несовместимости 
// Для объявления интерфейса, используется ключевое interface, как правило интерфейс именуется с буквой "I"
// в начале.
//
// Важно, мы не можем создать объект типа интерфейса, используя его собственный конструктор!!!
// 
// Что может поределять интерфейс:
// 1) Методы
// 2) Свойства
// 3) Индексаторы
// 4) События
// 5) Статические поля и константы с версии C# 8
// Важно: интерфейс не можнет определять нестатические ПЕРЕМЕННЫЕ.
// Наследлвание от интерфейса "класс / стркутура : интерфейс" называется реализацией
// Если члены интерфейса не имеют модификатора, то по умолчанию, они public(публичны), 
// т.к. цель интерфейсов, определение функционала, для реализации его классом или структурой. 
// Тем не менее, начиная с .NET 8, мы можем явно указать модификаторы доступа, в том числе
// и private 
//
// Важно, класс может реализовывать несколько интерфейсов сразу
//
// Пример реализации интерфейса классом:

interface Iinterface 
{
    public string Lol { set; } // Определяем свойство
    public void Print(); // Определяем метод
}

class ImplementingClass : Iinterface
{
    public string Lol { set => _lol = value; } // Реализуем свойство
    private string? _lol;
    public void Print() // Реализуем метод
    {
        Console.WriteLine($"{_lol}");
    }
}


// По умолчанию, интерфейсы, как и классы имеют модификатор доступа internal
// это значит, что использовать его, мы можем только в текущем проекте, но
// с помощью public, мы можем сделать его общедоступным.
//
// Так же, начиная с версии .NET 8, интерфейсы могут реализовывать функцилнал
// по умолчанию. P.S. тут я немного не понял, зачем это нужно, если у нас есть
// абстрактные классы, похоже, в таком случае смысл интерфейсов немного 
// теряется, на данный момент, на счёт этого не могу выдыинуть твёрдых теорий.
// Тем не менее, без серьёзной необходимости, эту возможность стоит обходить
// стороной.
//
// Тем не менее, приведу пример:

interface Iinterface1
{
    public void Print()
    {
        Console.WriteLine("Default Realization");
    }
}

class ImplementingClass1 : Iinterface1
{

}

// Преобразования типов, как это есть в отношкнии классов, так же работает и с интерфейсами



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//-----------------------------------Interfaces-explicit-implementation-----------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Явная реализация интерфейсов.

// При явной реализации перед ревлизуемым в классе методом указывается имя интерфейса
// при этом, при явной реализации, мы не можем указывать модификаторы доступа.

interface Iinterface2
{
    void Print();
}

class ImplementingClass2 : Iinterface2
{
    void Iinterface2.Print()
    {
        Console.WriteLine("Hello from Vasiliy!!!");
    }
}

// К явно реализованым полям и методам, мы не можем обратиться напрямую,
// через объект класса. 
//
// Но если объект создаётся от типа интерфейса, то к явно реализованным полям и 
// методам обратиться получится

// Где вообще может пригодиться явная реализвция?
// 1) Если класс реализует несколько интерфейсов с
//    одинаковыми названиями полей или методов
// 2) Если базовый коласс уже реализовал что-либо,
//    но в дочернем мы хотим реализовать по своему
// 3) Если не хотим использовать модификаторы достуа
//    P.S. В интерфейсе могут быть не только
//    public модификаторы, если не хотм менять в
//    реализуещем классе модификаторы, на какие
//    нибудь другие. На мой взгляд 3-й пример
//    немного бредовый ну или я чего то не понимаю :)



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//-------------------------------Interfaces-base-andinheritance-implementation----------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Реализация интерфейсов в базовых и дочкреих классах

// Немного очевидной информации:
// 1) Если базовый класс реализовал интерфейс, то дочернему его реализовывать не нужно,
//    Т.К. функционал наследуется
// 2) При реализации интерфейса каким-либо дочерним классом, учитывается реализация 
//    функционала родительского класса, даже если родитель и не собирался реализовывать
//    данный тинтерфейс. Т.К. функционал наследуется

// Иногда может возникнуть ситуация, когда в дочернем классе нужно изменить реалтзацию
// унаследованную от родительского класса, это можно сдедать несколькими способами:

// 1) Переопределение обстрактных методов (это мы уже знаем)
interface Iinterface3
{
    void Print();
}

class BaseImplementingClass : Iinterface3
{
    virtual public void Print()
    {
        Console.WriteLine("1) Dingle-Binglebob is perfect");
    }
}

class InheritanceImplementingClass : BaseImplementingClass
{
    override public void Print()
    {
        Console.WriteLine("1) Dingle-Binglebob is just good");
    }
}


// 2) сокрытие (то, что мы не одобряем, ибо небезопасно)
interface Iinterface4
{
    void Print();
}

class BaseImplementingClass1 : Iinterface4
{
    public void Print()
    {
        Console.WriteLine("2) Dingle-Binglebob is perfect");
    }
}

class InheritanceImplementingClass1 : BaseImplementingClass1
{
    public new void Print()
    {
        Console.WriteLine("2) Dingle-Binglebob is just good");
    }
}


// 3) Повторная реализация интерфейса в дочернем классе
// P.S. В жанном случае реализация из базового класса пргоигнорируется
interface Iinterface5
{
    void Print();
}

class BaseImplementingClass2 : Iinterface5
{
    public void Print()
    {
        Console.WriteLine("3) Dingle-Binglebob is perfect");
    }
}

class InheritanceImplementingClass2 : BaseImplementingClass2, Iinterface5
{
    public new void Print()
    {
        Console.WriteLine("3) Dingle-Binglebob is just good");
    }
}


// 4) Явная реализация интерфейса
interface Iinterface6
{
    void Print();
}

class BaseImplementingClass3 : Iinterface6
{
    public void Print()
    {
        Console.WriteLine("4) Dingle-Binglebob is perfect");
    }
}

class InheritanceImplementingClass3 : BaseImplementingClass3, Iinterface6
{
    void Iinterface6.Print()
    {
        Console.WriteLine("4) Dingle-Binglebob is just good");
    }
}



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------Interfaces-inheritance----------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Наследовани интерфейсов

// Интерфейсы, как и классы могут наследоваться.
// Собственно там всё практически так же, как и с наследованием классов,
// поэтому нет смысла рассказывать об том же, только в плане интерфейсов

interface BaseInterface
{
    void PrintAge();
}

interface InheritanceInterface : BaseInterface
{
    void PrintName();
}



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------Interfaces-in-generics----------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Интерфейсы в обобщениях

// Довольно очевидно, но интерфейся можно использовать в качестве
// ограничений для обобщений (это полнзно)

class Person : InheritanceInterface
{
    public void PrintAge()
    {
        Console.Write("19");
    }

    public void PrintName()
    {
        Console.WriteLine("Sergey");
    }
}

class Idk<T> where T : InheritanceInterface
{
    public Idk()
    {
    }

    public Idk(T value)
    {
        value.PrintAge();
        Console.Write(": "); // Просто даоеточие с пробелом между возрастом и именем
        value.PrintName();
    }
}