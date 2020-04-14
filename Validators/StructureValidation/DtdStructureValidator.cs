using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Validators.StructureValidation
{
    public class DtdStructureValidator : IDisposable
    {
        private bool _doctypeOpen;
        private bool _doctypeClosed;

        private int _line;
        private int _column;

        private readonly string _textToProcess;

        private readonly Stream _textStream;

        public DtdStructureValidator(string text)
        {
            _textToProcess = text;
            _textStream = new MemoryStream();
            var writer = new StreamWriter(_textStream);
            writer.Write(text);
            writer.Flush();
            _textStream.Position = 0;
        }

        public bool Check()
        {
            var xmlOpen = FindSymbol('<');
            var xmlOpenQuest = IsNextSymbolEqualTo('?');
            var xmlClosedQuest = FindSymbol('?');
            var xmlClosed = IsNextSymbolEqualTo('>');

            if (!(xmlOpen && xmlOpenQuest && xmlClosedQuest && xmlClosed))
            {
                throw new Exception("Метаданные xml не найдены в первой строке");
            }

            if (!FindSymbolWithSpaceBefore('<'))
            {
                throw new Exception($"Ожидается '<' на строке {_line} в столбце {_column}");
            }

            if (!FindSymbol('!'))
            {
                throw new Exception($"Ожидается '!' на строке {_line} в столбце {_column}");
            }

            if (!CheckSequence("DOCTYPE"))
            {
                throw new Exception($"Ожидается название элемента 'DOCTYPE' на строке {_line} в столбце {_column}");
            }

            int currentLine = _line;
            int currentColumn = _column;

            if (!FindSymbol('['))
            {
                throw new Exception($"Ожидается '[' для элемента 'DOCTYPE' на строке {currentLine} в столбце {currentColumn}");
            }

            {
                var pos = _textStream.Position;
                StreamReader tr = new StreamReader(_textStream);
                var sdad = tr.ReadToEnd();
                _textStream.Position = pos;
            }

            while (PeekNextSymbol() != ']')
            {
                var pos = _textStream.Position;
                StreamReader tr = new StreamReader(_textStream);
                var sdad = tr.ReadToEnd();
                _textStream.Position = pos;

                ElementCheck();
            }

            if (!FindSymbolWithSpaceBefore(']'))
            {
                throw new Exception($"Ожидается ']' для элемента 'DOCTYPE' на строке {_line} в столбце {_column}");
            }

            if (!FindSymbol('>'))
            {
                throw new Exception($"Ожидается '>' для элемента 'DOCTYPE' на строке {_line} в столбце {_column}");
            }

            return true;
        }

        private void ElementCheck()
        {
            int currentLine = _line;
            int currentColumn = _column;

            bool openBracketExist = false;
            bool signExist = false;
            bool nameExist = false;
            bool closeBracketExist = false;

            // Находим <

            openBracketExist = FindSymbol('<');

            if (!openBracketExist)
            {
                throw new Exception($"Ожидается '<' на строке {currentLine} в столбце {currentColumn}");
            }

            // Находим знак !
            currentLine = _line;
            currentColumn = _column;

            signExist = IsNextSymbolEqualTo('!');

            if (!signExist)
            {
                throw new Exception($"Ожидается символ '!' на строке {currentLine} столбец {currentColumn}");
            }

            currentLine = _line;
            currentColumn = _column;

            bool nameClosed = false;

            // Находим название тега <{название}
            while (_textStream.Position != _textStream.Length)
            {
                var symbol = GetNextSymbol();

                // Проверяем, что первый символ - буква
                if (!nameExist && !IsLetter(symbol))
                {
                    throw new Exception($"Ожидалось имя элемента на строке {currentLine} в столбце {currentColumn}");
                }

                if (IsLetter(symbol))
                {
                    nameExist = true;
                    continue;
                }
                if (nameExist && symbol == ' ')
                {
                    nameClosed = true;
                    break;
                }
                else
                {
                    throw new Exception($"Ожидается пробел после имени элемента на строке {currentLine} столбец {currentColumn}");
                }
            }

            currentLine = _line;
            currentColumn = _column;

            // Находим закрывающую скобочку
            while (_textStream.Position != _textStream.Length)
            {
                var symbol = GetNextSymbol();

                if (symbol == '>')
                {
                    closeBracketExist = true;
                    break;
                }

                // Проверяем, что не открыт ноый тег
                if (symbol == '<')
                {
                    throw new Exception($"Не закрыт тег элемент на строке {currentLine} столбец {currentColumn}");
                }
            }

            if (!closeBracketExist)
            {
                throw new Exception($"Не найден символ '>' для элемента на строке {currentLine} столбец {currentColumn}");
            }

            currentLine = _line;
            currentColumn = _column;

            if (PeekNextSymbol() == '>')
            {
                throw new Exception($"Лишняя закрывающая скобка после элемента на строке {currentLine} столбец {currentColumn}");
            }
        }

        private void CheckEndLine(char symbol)
        {
            if (symbol != 13)
            {
                _column++;
            }
            else
            {
                _line++;
                _column = 0;
            }
        }

        private bool IsLetter(char symbol)
        {
            if ((symbol >= 'a' && symbol <= 'z') || 
                (symbol >= 'A' && symbol <= 'Z')|| 
                (symbol >= 'а' && symbol <= 'я') ||
                (symbol >= 'А' && symbol <= 'Я'))
            {
                return true;
            }

            return false;
        }

        private char GetNextSymbol()
        {
            var symbol = (char)_textStream.ReadByte();
            CheckEndLine(symbol);
            return symbol;
        }

        private bool FindSymbol(char symbolToFind)
        {
            bool found = false;
            while (_textStream.Position != _textStream.Length)
            {
                var symbol = GetNextSymbol();

                if (symbol == symbolToFind)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        private bool IsNextSymbolEqualTo(char symbolToCheck)
        {
            bool equal = false;

            if (_textStream.Position != _textStream.Length)
            {
                var symbol = GetNextSymbol();

                if (symbol == symbolToCheck)
                {
                    equal = true;
                }
            }

            return equal;
        }



        private bool FindSymbolWithSpaceBefore(char symbolToFind)
        {
            while (_textStream.Position != _textStream.Length)
            {
                var symbol = GetNextSymbol();

                if (symbol == symbolToFind)
                {
                    return true;
                }

                if (symbol == 10 || symbol == 13 || symbol == ' ')
                {
                    continue;
                }

                return false;
            }

            return false;
        }

        private bool CheckSequence(string sequence)
        {
            int curentIndex = 0;
            while (_textStream.Position != _textStream.Length && curentIndex < sequence.Length)
            {
                var symbol = GetNextSymbol();

                if (symbol != sequence[curentIndex])
                {
                   return false;
                }

                curentIndex++;
            }

            return true;
        }

        private char PeekNextSymbol()
        {
            long position = _textStream.Position;
            try
            {
                while (_textStream.Position != _textStream.Length)
                {
                    var symbol = (char)_textStream.ReadByte();

                    if (symbol == 10 || symbol == 13 || symbol == ' ')
                    {
                        continue;
                    }

                    return symbol;
                }

                return (char)0;
            }
            finally
            {
                _textStream.Position = position;
            }
        }

        public void Dispose()
        {
            _textStream?.Dispose();
        }
    }
}
