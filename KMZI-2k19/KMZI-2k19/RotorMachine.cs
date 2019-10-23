using System.Collections.Generic;
using System.Linq;

namespace KMZI_2k19
{
    public class RotorMachine
    {
        public int CurrentPosition { get; set; }

        private static readonly int[] LeftToRightRotor = {2, 5, 3, 4, 0, 1};
        private static readonly int[] RightToLeftRotor = {4, 5, 0, 2, 3, 1};
        private static readonly int[] Reflector = {2, 5, 0, 4, 3, 1};

        private static readonly Dictionary<char, int> InputCircleLettersNumbers = new Dictionary<char, int>
            {{'O', 0}, {'P', 1}, {'R', 2}, {'S', 3}, {'T', 4}, {'Y', 5}};

        private static readonly int KeysCount = LeftToRightRotor.Length;

        public RotorMachine(int startPosition)
        {
            CurrentPosition = startPosition;
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> text)
        {
            foreach (var letter in text)
            {
                yield return GetSymbol(letter);
                CurrentPosition++;
                CurrentPosition %= KeysCount;
            }
        }

        public IEnumerable<char> Decrypt(string text)
        {
            return DecryptReverse(text.Reverse(), text.Length).Reverse();
        }

        private IEnumerable<char> DecryptReverse(IEnumerable<char> text, int textLength)
        {
            var saveCurrentPosition = CurrentPosition;

            CurrentPosition = (CurrentPosition + textLength - 1) % KeysCount;

            foreach (var letter in text)
            {
                yield return GetSymbol(letter);
                CurrentPosition--;
                CurrentPosition = (CurrentPosition + KeysCount) % KeysCount;
            }

            CurrentPosition = saveCurrentPosition;
        }

        private char GetSymbol(char symbol)
        {
            var symbolIndex = InputCircleLettersNumbers[symbol];
            
            var inputSideRotorIndex = SubtractCurrentPosition(symbolIndex);

            var outputSideRotorIndex = LeftToRightRotor[inputSideRotorIndex];

            var reflectorInputIndex = AddCurrentPosition(outputSideRotorIndex);

            var reflectorOutputIndex = Reflector[reflectorInputIndex];

            outputSideRotorIndex = SubtractCurrentPosition(reflectorOutputIndex);

            inputSideRotorIndex = RightToLeftRotor[outputSideRotorIndex];

            symbolIndex = AddCurrentPosition(inputSideRotorIndex);

            return InputCircleLettersNumbers.First(x => x.Value == symbolIndex).Key;
        }

        private int AddCurrentPosition(int num)
        {
            return (num + CurrentPosition) % KeysCount;
        }

        private int SubtractCurrentPosition(int num)
        {
            return (num - CurrentPosition + KeysCount) % KeysCount;
        }
    }
}