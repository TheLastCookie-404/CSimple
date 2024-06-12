////////////////////////////////////////////////////////////////////////////////////////////////////////////
//-----------------------------------------Exception-treatment--------------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Обработка исключений
// Исключения, это такие ошибки, которые бывает 
// сложно или же даже невозможно предусммотреть
// для обрботи исключений, в C# используется конструкция
// Try Catch Finaly
//
// При использовании Try Catch Finaly, сначала отработается код,
// находящийся в Try. Если код выдаст исключение, то начнёт выполнятся
// среда CLR начнёт поиск блока Catch. Если среда не найдёт его, то
// выполнится блок Finaly и программа экстренно завершит работу. 
// Блок Catch позволяет обработать возникшее исключение

int a = 5;
int b = 0;

try 
{
    int c = a / b;
}
catch 
{
    Console.WriteLine("Error: EXCEPTION");
}
finally
{
    Console.WriteLine("Finaly");
}


// При наличии бллока Catch, мы можем опустить
// бллок Finaly.

try 
{
    int c = a / b;
}
catch 
{
    Console.WriteLine("Error: EXCEPTION");
}



// Обработка исключений и условные конструкции.
// Для обраоботки исключений, можно исользовать
// и условные конструкции.
//
// В первом случае, если мы передадим строку с
// числом, то всё будет нормально, но если попытаться
// передать строку с иным содержанием, то получим 
// исключение, для этого можем сспользовать TryParse

void MultiplyFromString(string firstNum, string seondNum)
{
    int result = 1;
    result = int.Parse(firstNum) * int.Parse(seondNum);
    Console.WriteLine($"Результат: {result}");
}
MultiplyFromString("25", "2");


void SummFromString(string firstNum, string seondNum)
{
    int value;
    int value1;
    if(int.TryParse(firstNum, out value) && int.TryParse(seondNum, out value1))
    {
        int result = value + value1;
        Console.WriteLine(value);
    } else Console.WriteLine("Error: input value is incorrect!");
}
SummFromString("25", "2q");



// Так же блок Catch, может иметь следующие формы:

// 1
try
{
    int c = a / b;
}
catch(DivideByZeroException) // Тип исключнеия
{
    Console.WriteLine("А я погляжу, ты шальной, на нолик делишь, ай ай ай!!!");
}

// 2
try
{
    int c = a / b;
}
catch(DivideByZeroException exceptionVar) // Тип исключнеия, переменная для вывода сообщения о типе исключения
{
    Console.WriteLine($"Тип исключения: {exceptionVar}. \nА я погляжу, ты шальной, на нолик делишь, ай ай ай!!!");
}

// 3 
try
{
    int c = a / b;
    int d = a / a;
}
catch(DivideByZeroException) when (b == 0)
{
    Console.WriteLine("Переменная b не должна быть равна нулю!");
}
catch(DivideByZeroException exceptionVar) // Тип исключнеия, переменная для вывода сообщения о типе исключения
{
    Console.WriteLine($"Тип исключения: {exceptionVar}. \n А я погляжу, ты шальной, на нолик делишь, ай ай ай!!!");
}





////////////////////////////////////////////////////////////////////////////////////////////////////////////
//-------------------------------------------Exception-types----------------------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Базовым типом искключений является Exeption, у этого типа
// статический список свойств, с помощью которого, мы можем
// получить информацию об исключении:
//
// 1) InnerExeption - хранит информации об исключении, послужившем вызову текущего.
// 2) Message - хранит сообщение об исключении, текст ошибки.
// 3) Source - хранит имя объекта или сборки, вызвавшей исключение.
// 4) StackTrace - возвращает стоковое представление стека вызовов, которые ппривели к вызову исключения
// 5) TargetSite - возвращает метод, в котором было вызвано исключениею.

try 
{
    int c = a / b;
}

catch(Exception exception)
{
    Console.WriteLine($"InnerExeption >>> {exception.InnerException}");
    Console.WriteLine($"Message       >>> {exception.Message}");
    Console.WriteLine($"Source        >>> {exception.Source}");
    Console.WriteLine($"StackTrace    >>> {exception.StackTrace}");
    Console.WriteLine($"TargetSite    >>> {exception.TargetSite}");
}


// Но помимо Базового типа Exception, есть и более специализированные
// типы исключеий:
//
// 1) DivideByZeroException - генерируется при делении на 0.
// 2) ArgumentOutOfRangeEception - генерируется, если значение аргумента выходит за диапазон допуст. значений.
// 3) ArgumentException - генерируется, если в метод передаётся некорректное значение.
// 4) IndexOutOfRangeException - генерируется, если значение выходит за пределы диапазона массива или коллекции.
// 5) InvalidCastExeption - генерируется при попытке невозможного преобразования типов.
// 6) NullReferenceException - генерируется при попытке обрашения к объекту равному null.
//
// Кроме этих исключений, есть ещё достаточно много типов,
// о них можно прочитать в этих ваших интернетах. ЪУЪ!!!





////////////////////////////////////////////////////////////////////////////////////////////////////////////
//--------------------------------Exception-genetation-&-Exception-Classes--------------------------------//
////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Обычно система генерирует искключения в особых ситуация. таких как деление
// на 0 и др., самостоятельно. Но мы можем сгенерировать исключение вручную. 
// В этом нам может помочь trow. С помощью ттого оператора, мы самостояятельно
// можем создавать исключения и вызывать их.
//
// К примеру, мы можем сделать проверку, если условие не соответствует, выдать
// исключение.

int value = 10;

if(value < 5 || value > 50)
{
    throw new Exception("Value can not be more or less than range!!!");
}
else
{
    Console.WriteLine($"Input value: {value} is correct!!!");
}



// Пример со своим типом исключения

try
{
    int value1 = 40;

    if(value1 < 20 || value1 > 30)
    {
        throw new LolException("Value can not be more or less than range!!!", 123);
    }
    else
    {
        Console.WriteLine($"Input value: {value} is correct!!!");
    }
}
catch(LolException lolException)
{
    Console.WriteLine($"Было найдено исключение: LolException, код исключения - {lolException.ExceptionCode}");
}

// Если нас не устраивают встроенныет типы исключений, мы можем
// создать свои, наследуясь от базового класса Exception.
// Так же наследоваться мы можем от производных типов, типа Exception.

class LolException : Exception
{
    public int ExceptionCode { get; } // Это отсебятина, дабы в производном типе хоть что то отличалось
    public LolException(string message, int exceptionCode) : base(message)
    {
        ExceptionCode = exceptionCode;
    }
}

