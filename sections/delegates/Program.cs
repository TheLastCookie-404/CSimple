////////////////////////////////////////////////////////////////////////////////////////////////////////////
//----------------------------------------------Delegates-------------------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Делегаты, это такие объекты, которые указывают на методы, 
// проще говоря, делегаты, это указатели на методы.
// С помощью делегатов, мы можем вызывать данные методы.
//
// Для объявления делегатов, используют ключевое слово Delegate.
// Пример: delegate void Message();
//
// Если мы определяем делегаты в программах верхнего уровня
// (top-lvl program), коим является файл Programm.cs, начиная
// с 10 версии C#, то делегаты объявляются в конце кода.
// Это связано с особеностями новой версии. Компилятор автоматом 
// создает класс Program и метод Main, у себя под капотом.
// Но это не мешает сделать так (объявить делегат перед методм Main):
//
// class Program
// {
//     delegate void Abobus();
//     static void Main()
//     {
//         Abobus abobus = SayHello;
//         abobus();
//         void SayHello()
//         {
//             Console.WriteLine("Hello, Bebrener!!!!!");
//         }
//     }
// }
//
//
//
// Или сделать так (объявить делегат, вне класса):
//
// delegate void Abobus();
// class Program
// {
//     static void Main()
//     {
//         Abobus abobus = SayHello;
//         abobus();
//         void SayHello()
//         {
//             Console.WriteLine("Hello, Bebrener!!!!!");
//         }
//     }
// }


// В конце кода ↓ , объявляется делегат Abobus, затем мы создаём
// переменную с его типом и помещаем туда название нашей функции.
// Теперь эту функцию, мы можем вызывать через имя делегата.
//
// Так же делегаты могут указыватть не только на методы, которые
// определены в том же классе, где определена и переменная делаегата,
// это могут быть методы из других классов или струуктур.

using System.Reflection.Emit;

void SayHello()
{
    Console.WriteLine("Hello, Bebrener");
    void Leeel()
    {
        Console.WriteLine("Ahahahahah!!!");
    }
    Leeel();
}

SayHelloDelegate sayHelloDelegate = SayHello;
sayHelloDelegate();


// Если мы хотим вызывать функцию, которая возвращвет значение,
// через делегат, то делегат должен иметь тот же тип возвращаемого
// значения, что и функция.

GetStrDelegate getStrDelegate = GetStr;
Console.WriteLine(getStrDelegate());

string GetStr()
{
    return "Zdravstvuy, dyadya!!!";
}


// Тоже самое и с принимаемыми значениями

SummDelegate summDelegate = Summ;
summDelegate(12, 534);

void Summ(int a, int b)
{
    Console.WriteLine(a + b);
}


// Кстати, переменные типа делегата, мы тоже можем передавать как аргументы.

ReturnSomethingDelegate returnSomethingDelegate = GetValue;

int GetValue()
{
    return 43;
}

void DoSomethinng(ReturnSomethingDelegate value)
{
    Console.WriteLine($"{value()} is truly beautiful number!!!");
}

DoSomethinng(returnSomethingDelegate);



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------Delegates-Usage-----------------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Не смотря на простой, на первый взлгляд не слишком полезный 
// функционал, делегаты довольно удобны. По началу может показаться,
// что ссылки на методы и функции, не особо нужны, ведь мы можем 
// вызывать функции и без всяких ссылок, но благодаря таким ссылкам,
// мы можем пердавть отдельным частям программы, методы с разным 
// функционалом. Вот самый простой пример:

GetDataDelegate getDataDelegate = PrintWithConvertToStr;

void Print(int value)
{
    Console.WriteLine(value);
}

void PrintWithConvertToStr(int value)
{
    string result = Convert.ToString(value);
    Console.WriteLine(result);
}

void Multiply(int a, int b)
{
    getDataDelegate(a * b);
}

Multiply(5, 3);

// Так же делегаты используются событиями. К примеру, есть
// кнопка, она может выпольнять любые дейсттвия по нажатию,
// Но чтобы передать ей исполняемый функционал, мы используем
// делегаты.


// Но делегат может ссылаться не только на 1 метод, но и на
// несколько. Делегаты, ссылающиеся на 1 метод называются 
// singlecast делегатами, делегаты, ссылающиеся на несколько,
// назывваются multicast делегатами.

MulticastSampleDelegate? multicastSampleDelegate = Message; // Здесь делегат ссылаетсся на одну функцию
multicastSampleDelegate += Message1; // А тут добавляется ссылка на ещё одну функцию

void Message() => Console.WriteLine("My name is Giovani Georgio");

void Message1() => Console.WriteLine("But everybody calls me Georgio");

multicastSampleDelegate(); // Теперь при обращении к делегату, у нас отработаются 2 функции

// При желании, мы можем избавиться от ссылки на какой либо метод или функцию.
// P.S. Для того, чтобы при такомм действии не высвечивалочь предупреждение 
// CS8601 Possible null reference assignment (такое предупреждение, появляется,
// еслии переменная не должна иметь null значение, но по каким то пречинам, null
// значение всё таки оказывается в ней. На строке 140, После объявления типа, с 
// помощь знака "?", мы говорм, что теперь переменная может иметь null значение.
multicastSampleDelegate -= Message1;

// Здесь я применил оператор null объединения, без него, при обращении,
// к делегату, будет придупреждение CS8602 Dereference of a possibly 
// null reference (это значит, что переменная может содержать null,
// при попытке обращения к делегату, не содержащемуу ссылок, можем
// получить исключение). Поэтому, при обнаружении типа null, в переменную
// делегата, будет помещено значенние Message.

multicastSampleDelegate ??= Message; 

multicastSampleDelegate();



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------Anonimous-Methods---------------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Анонимные методы неразрывно связаны с делегатами. Анонимные методы,
// это методы, не имеющие имени, через которое мы можем к ним обратиться.
// Анонимные методы не могут существовать сами по себе, они испотльзуются 
// для инициализации делегатов. Такие методы объявляются через ключевое
// слово delegate

AbobusDelegate abobusDelegate = delegate()
{
    Console.WriteLine("Hello, im function that dont have any name");
};

abobusDelegate();


// А ещё, мы можем передать анонимную функцию в качестве аргумента

void Idk(IdkDelegate idkDelegate)
{
    Console.WriteLine(idkDelegate);
}

Idk(delegate () { return "Ooooof"; });



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------Lambda-Expressions--------------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Лямбда выражения - это сокращённый вид записи анонимных 
// методов.
BruhDelegate bruhDelegate = () => Console.WriteLine("Leru-Leru-Leru");
BruhDelegate bruhDelegate1 = () => {
    Console.WriteLine("Yare-Yare!!!");
};

bruhDelegate();
bruhDelegate1();


// Так же лямбда выражения могут принимать аргументы
// А если аргумет только один, то скобки можно и опустить
BubildaDelegate bubildaDelegate = (string name, string msg) => Console.WriteLine($"Hello, {name}. Do you {msg}?");
BebraDelegate bebraDelegate = msg => Console.WriteLine($"{msg}");

bubildaDelegate("Sanya", "eat snakes");
bebraDelegate("Nya-nya-nya!!!");


// А ещё лямбды могут возвращать значения

AhahaDelegate ahahaDelegate = () => "Ne nado dydya!!!";
// Или так AhahaDelegate ahahaDelegate = () => { return "Ne nado dydya!!!" };
Console.WriteLine(ahahaDelegate());


// Добавление и удаление действий в лямбда выражении
//
// Здесь, мы присваиваем анонимные лямбды, переменной
var chihurchipus = () => Console.WriteLine("Lol, what?");
var glarflonchick = () => Console.WriteLine("This-is-my-kingdom.com");
var iWasHere = () => Console.WriteLine("This cake is made of dreams");

var chingachguk = () => Console.WriteLine("UgaBuga"); // Добавляем анонимное лямбда выражение
chingachguk += chihurchipus; // Добавляем лямбды из переменных
chingachguk += glarflonchick;
chingachguk += iWasHere;

chingachguk();

// Удаляем лямбды

chingachguk -= chihurchipus;
chingachguk -= glarflonchick;
chingachguk -= iWasHere;

// На случай, если в chingachguk больше нет действий. 
// ( P.S. уточнить информацию о методе Invoke(); )
// https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.forms.control.invoke?view=windowsdesktop-8.0
chingachguk?.Invoke();

// Если переменная не содержит лямбд,
// чтобы не получть null, мы присваиваем
// лямбду с сообщеним по умолчанию
chingachguk ??= () => Console.WriteLine("Ссылок на иные лямбды, более не имеется");



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//-----------------------------------------------Events---------------------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Событие, это некая обёртка для делегатов, без делегата, 
// событие существовать не может. Событие, это оповещение 
// о том, что произошло какое либо дейсвие. В отличие от
// делегатотв, события нужны не для передачи в них метода,
// для выполненния ими функционала, необходимого программе,
// а для того, чтобы оповестить подписчиков о том, что 
// произошло какое то действие и выполнить какой-либо метод
// переданный событию.
// 
// Основные отличия событий, от делегатов:
// 1) События могут объявляться и вызиваться только внутри
//    класса.
// 2) События нельзя вызвать извне класса, только внутри
// 3) События не возвращают значений
// 4) Возможео объявление на уровне интерфейса
// 5) События не могут быть переданы в качестве аргумента 
//    метода.

Aoof aoof = new Aoof();
aoof.randomDelegate += () => Console.WriteLine("The world is made of cake!!!"); // Передаём событию анониимный метод ( подписываемся )
bool buttonIsPressed = true; // Эмуляция нажатия условной кнопки
if(buttonIsPressed) aoof.SayTrue(); // По нажатию отрабатываем метод, который передали



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//--------------------------------Covariance-&-Contrvariance-in-Delegates---------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Ковариантность и контрвариантность.
// 
// Ковариантность, это возможность использования более конкретных 
// типов, вместо более общих
//
// Контрвариантность, это возможность использования более общих
// типов, вместо более конкретных

// Ковариантность в делегатах, это способность делегата, принимать 
// в себя методы, возвращаемый тип которых является производным,
// от указанного возвращаемого типа в делегате. Что это означает?
// В делегате ( delegate NuDopustim CovarianceDelegate(); ) в 
// качестве возвращаемого типа указан тип "NuDopustim". Это значит,
// что мы можем передать ему метод, возвраащаемый тип которого
// является не только указанным в делегате типом, но и его дочерним 
// типом. Получается, что мы вместо более общего типа - "NuDopustim", 
// переаём более конкретный тип - "NuDopustimNya"
NuDopustimNya ReturnNyaMsg()
{
    return new NuDopustimNya("Я люблю кодек");
    // Эта функция возвращает объект класса "NuDopustimNya",
    // соответсвенно, обратиться к его свойствам и полям,
    // можно будет так: ReturnNyaMsg().
}

NuDopustim ReturnMsg()
{
    return new NuDopustim("Я люблю кодек");
    // Эта функция возвращает объект класса "NuDopustim",
    // соответсвенно, обратиться к его свойствам и полям,
    // можно будет так: ReturnMsg().
}

CovarianceDelegate? covarianceDelegate;
covarianceDelegate = ReturnMsg;
covarianceDelegate().Print();
covarianceDelegate -= ReturnMsg;
covarianceDelegate = ReturnNyaMsg;
covarianceDelegate().Print();


// Контрвариантность в делегатах, это способность делегата, принимать
// в себя методы, аргументы которых, имеют базовый тип, типа указанного
// в качесвет аргумента делегата. Что это означает? В делегате
// ( delegate void ContrvarianceDelegate(NuDopustimNya value); ), в
// качестве принимаемого аргумента, выступает аргуммент, с тиипом 
// "NuDopustimNya". Это значит, что мы можем передать ему функцию,
// принимаемым типом которой, является не только указанный в делегате тип,
// но и его базовый тип. Получается, что мы вместо более конкретного  
// типа - "NuDopustimNya", переаём более общий тип - "NuDopustim"
void GetNyaMsg(NuDopustimNya value)
{
    value.Print();
    value.PrintUgabugaValue();
    // Эта функция принимает объект класса "NuDopustimNya",
    // соответсвенно, обратиться к его свойствам и полям,
    // можно будет так: value().
}

void GetMsg(NuDopustim value)
{
    value.Print();
    // value.PrintUgabugaValue(); error CS1061
    // Эта функция принимает объект класса "NuDopustimNya",
    // соответсвенно, обратиться к его свойствам и полям,
    // можно будет так: value().
}

ContrvarianceDelegate? contrvarianceDelegate;
contrvarianceDelegate = GetMsg; // Тут делегат принимает метод с агрументом базового типа
// Несмотря на то, что делегат в качестве параметра принимает объект EmailMessage, ему 
// можно присвоить метод, у которого параметр представляет базовый тип Message. Может 
// показаться на первый взгляд, что здесь есть некоторое противоречие, то есть 
// использование более универсального тип вместо более производного. Однако в 
// реальности в делегат при его вызове мы все равно можем передать только объекты 
// типа EmailMessage, а любой объект типа EmailMessage является объектом типа Message, 
// который используется в методе.
contrvarianceDelegate(new NuDopustimNya("А ты любишь кодек?"));

contrvarianceDelegate -= GetMsg;
contrvarianceDelegate = GetNyaMsg;
contrvarianceDelegate(new NuDopustimNya("А ты любишь кодек?"));



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//----------------------------Generalized-Delegates-&-(Co/Contr)variance----------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Делегаты тоже могут быть обобщёнными
GeneralizedDelegate <int>generalizedDelegate;
GeneralizedDelegate <float>generalizedDelegate1;

void IntSumm(int a, int b)
{
    Console.WriteLine(a + b);
}

void FloatSumm(float a, float b)
{
    Console.WriteLine(a + b);
}

generalizedDelegate = IntSumm;
generalizedDelegate1 = FloatSumm;
generalizedDelegate(2, 4);
generalizedDelegate1(2.5f, 4.3f);


// А обобщённые делегаты в свою очередь могут быть ковариантными и контрвариантными,
// что дает нам больше гибкости в их использовании.

NuDopustimNya ReturnInheritanceMsg()
{
    return new NuDopustimNya("Дооождь из мужикооооов!!!");
    // Эта функция возвращает объект класса "NuDopustimNya",
    // соответсвенно, обратиться к его свойствам и полям,
    // можно будет так: ReturnNyaMsg().
}

NuDopustim ReturnBaseMsg()
{
    return new NuDopustim("Дооождь из мужикооооов!!!");
    // Эта функция возвращает объект класса "NuDopustim",
    // соответсвенно, обратиться к его свойствам и полям,
    // можно будет так: ReturnMsg().
}

// Ковариантность в обобщённых делегатах
GeneralizedCovarianceDelegate<NuDopustim>? generalizedCovarianceDelegate = ReturnBaseMsg;
generalizedCovarianceDelegate().Print();
generalizedCovarianceDelegate -= ReturnBaseMsg;
generalizedCovarianceDelegate = ReturnInheritanceMsg;
generalizedCovarianceDelegate().Print();

// Но если мы захотим передать делегату другой делегат, то в объявлении делегата,
// нужно использовать ключевое слово "out" P.S. см ниже, где объявляются делегаты.
// В противном случае получим ошибку - error CS0029: Не удается неявно преобразовать тип
GeneralizedCovarianceDelegate<NuDopustimNya> generalizedCovarianceDelegateWithInheritanceType = ReturnInheritanceMsg;
GeneralizedCovarianceDelegate<NuDopustim> generalizedCovarianceDelegateWithBaseType = generalizedCovarianceDelegateWithInheritanceType;
generalizedCovarianceDelegateWithBaseType().Print();


// Контрвариантность в обобщённых делегатах

void GetInheritanceMsg(NuDopustimNya value)
{
    value.Print();
    value.PrintUgabugaValue();
    // Эта функция принимает объект класса "NuDopustimNya",
    // соответсвенно, обратиться к его свойствам и полям,
    // можно будет так: value().
}

void GetBaseMsg(NuDopustim value)
{
    value.Print();
    // value.PrintUgabugaValue(); error CS1061
    // Эта функция принимает объект класса "NuDopustimNya",
    // соответсвенно, обратиться к его свойствам и полям,
    // можно будет так: value().
}

GeneralizedContrvarianceDelegate<NuDopustimNya>? generalizedContrvarianceDelegate = GetInheritanceMsg;
generalizedContrvarianceDelegate(new NuDopustimNya("Hello fom Durka!!!"));
generalizedContrvarianceDelegate -= GetInheritanceMsg;
generalizedContrvarianceDelegate = GetBaseMsg;
generalizedContrvarianceDelegate(new NuDopustimNya("Hello fom Durka!!!"));

// Но если мы захотим передать делегату другой делегат, то в объявлении делегата,
// нужно использовать ключевое слово "out" P.S. см ниже, где объявляются делегаты.
// В противном случае получим ошибку - error CS0029: Не удается неявно преобразовать тип
GeneralizedContrvarianceDelegate<NuDopustim> generalizedContrvarianceDelegateWithBaseType = GetBaseMsg;
GeneralizedContrvarianceDelegate<NuDopustimNya>generalizedContrvarianceDelegateWithInheritanceType = generalizedContrvarianceDelegateWithBaseType;
generalizedContrvarianceDelegateWithInheritanceType(new NuDopustimNya("Ratatuy"));



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//--------------------------------------Action-Func-Predicate-delegates-----------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// В C# есть встроенные делегаты, которые можно использовать в разных ситуациях
// Наиболее часто используемыми являются Action, Predivate и Func

// Делегат Action
// Данный делегат не возвращает значений, но может принисать до
// 16 аргументов, так как имеет перегрузки. Каждая перегрузка имеет разное количество
// аргументов. Чаще всего, этот делегат передаётся в качестве аргумента метода и 
// предусматривает вызов определённых действий в ответ на какие либо действия.
//
// P.S. ключевое слово params тут для того, чтобы можно было передать нефиксированное 
// количество аргументов "args" вместо того, чтобы передавать массив. 
// Пример:
// function(int[] args) {}. function(new int[] {1, 2, 3}); VS function(params int[] args) {}. function(1, 2, 3);
void DoSomethinngCool(Action<int, int, int> action, params int[] args)
{
    action(args[0], args[1], args[2]);
}

void DoSumm(int a, int b, int c) => Console.WriteLine($"{a} + {b} + {c} = {a + b + c}");

DoSomethinngCool(DoSumm, 1, 5, 6);


// Делегат Pedicate
// Данный делегат принимает один аргумент, возвращает bool. Чаще всего 
// испотльзуется когда нужно сопоставить какой либо объект T, условию. 
// В качестве резулльтата true, если условие соблюдено, если нет, то false.
Predicate<int> predicate = (x) => x > 3;
Console.WriteLine($"{predicate(5)}");

// Делегат Func
// Данный делегат как и Action, может принимать до 16 аргументов, но ещё
// он может возвращать значения. Его тоже довольно чвсто используют в
// качестве аргумента метода.
void DoSomethinngAgain(Func<int, string, string> func, int val1, string val2)
{
    Console.WriteLine(func(val1, val2));
}

string Person(int age, string name)
{
    return $"{name}`s age is {age}";
}

DoSomethinngAgain(Person, 32, "Valdemal");



////////////////////////////////////////////////////////////////////////////////////////////////////////////
//-------------------------------------------------Closures-----------------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Замыкания.
// Это такой мехфнизм, который позволяет методу запомнить своё окружение,
// даже если она выполняется не в своей области видимости. Как пример, в
// качестве окружения может выступать переменная.
// Фактически замыкание включает в себя 3 основные составляющие:
// 1) Наружний метод
// 2) Лексическое окружение (поля и свойства)
// 3) Внутренний метод (пользуется лексическм окружением
//
// В данном примере, внешняя функци возвращает внутреннюю, она в свою очередь ничего не
// принимает и не возвращает. Благодаря использованию делегата Action во внешней функции,
// в качестве возвращаемого типа, она может вернуть внутреннюю функцию
// Action - это встроенный делегат. Про него есть выше (можно использовать и свой собственный)

Action Outer() // Внешняя функция
{
    int num = 2; // Лексическое окружение
    void Inner() // Внутренняя функция использующая окружение
    {
        Console.WriteLine($"Do a flip {num} times");
        num++;
    }
    return Inner; 
}

// В результате, при каждом вызове значение будет увеличиваться
var chipichipi = Outer();
chipichipi();
chipichipi();
chipichipi();


// Тем не менее, наша внутренняя функция может возвращать и принимать значения, в зависимости от 
// того, какой делегат мы будем использовать во внешней функции. P.S. Аргументы родительской функии,
// для дочерней тоже могут быть лексическим окружением

Func<int, int> Outer1(int a)
{
    int Inner1(int b)
    {
        return a + b;
    }
    return Inner1;
}

var chapachapa = Outer1(2);
Console.WriteLine(chapachapa(6));
Console.WriteLine(chapachapa(7));
Console.WriteLine(chapachapa(8));

// Важно !!! Дополнить, как работает под капотом и добавить объяснений




//-------------------------------------All-Classes-used-in-this-file--------------------------------------//

// Events
class Aoof
{
    public event RandomDelegate? randomDelegate;
    public void SayTrue()
    {
        // Null объединение, дабы избежать предупреждения и в целом для безопасности
        randomDelegate ??= () => Console.WriteLine("You need to put a methot here, before calling the 'SayTrue'");
        randomDelegate();
    }
}

// Covariance & Contrvariance of Delegates
class NuDopustim
{
    public string Message { get; }
    public NuDopustim(string message)
    {
        Message = message;
    }
    public virtual void Print() => Console.WriteLine($"Сообщение: {Message}");
}

class NuDopustimNya : NuDopustim
{
    public NuDopustimNya(string message) :base(message){}
    public override void Print() => Console.WriteLine($"Молва: {Message}");
    public void PrintUgabugaValue() => Console.WriteLine("Bread with BOMBS!!!");
}


//------------------------------------All-Delegates-used-in-this-file-------------------------------------//

// Все делегаты, используемые в данном файле. P.S. выше объяснение, 
// почему они объявляются именно здесь, в конце кода.

// Delegates
delegate void SayHelloDelegate();
delegate string GetStrDelegate();
delegate void SummDelegate(int value1, int value2);
delegate int ReturnSomethingDelegate();

// Delegates Usage
delegate void GetDataDelegate(int gata);
delegate void MulticastSampleDelegate();

// Anonimous Methods
delegate void AbobusDelegate();
delegate string IdkDelegate();

// Lambda Expessions
delegate void BruhDelegate();
delegate void BubildaDelegate(string value1, string value2);
delegate void BebraDelegate(string value);
delegate string AhahaDelegate();

// Events
delegate void RandomDelegate();

// Covariance &Contrvariance of Delegates
delegate NuDopustim CovarianceDelegate();
delegate void ContrvarianceDelegate(NuDopustimNya value);

// Generalized Delegates & (Co/Contr)variance
delegate void GeneralizedDelegate<T>(T val1, T val2);
delegate T GeneralizedCovarianceDelegate<out T>();
delegate void GeneralizedContrvarianceDelegate<in T>(T value);

// Action Predicate Func
// Данные делегаты являются встроенными
//
// Action:
// public delegate void Action()
// public delegate void Action<in T>(T obj) | Action<in T, int T1, ..., in T15>
//
// Predicate:
// delegate bool Predicate<in T>(T obj);
//
// Func:
// TResult Func<out TResult>()
// TResult Func<in T, out TResult>(T arg)
// TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2)
// TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3)
// TResult Func<in T1, in T2, in T3, in T4, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)