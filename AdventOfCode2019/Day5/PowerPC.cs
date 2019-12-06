using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Day5
{
    public class PowerPC
    {
        private List<int> _instructions;
        private int _pointer;
        private int _output;

        public int Run(IEnumerable<int> instructions, int input)
        {
            _instructions = instructions.ToList();
            _pointer = 0;

            while (true)
            {
                var (opcode, mode1, mode2) = ReadInstruction(_instructions[_pointer]);
                switch (opcode)
                {
                    case 1:
                        Add(mode1, mode2);
                        break;
                    case 2:
                        Mul(mode1, mode2);
                        break;
                    case 3:
                        Read(input);
                        break;
                    case 4:
                        Write(mode1);
                        break;
                    case 5:
                        JumpIfTrue(mode1, mode2);
                        break;
                    case 6:
                        JumpIfFalse(mode1, mode2);
                        break;
                    case 7:
                        LessThen(mode1, mode2);
                        break;
                    case 8:
                        Equal(mode1, mode2);
                        break;
                    default:
                        return _output;
                }
            }
        }

        private static (int opcode, int mode1, int mode2) ReadInstruction(int instruction)
        {
            var opcode = instruction % 100;
            var mode1 = instruction % 1000 - opcode;
            var mode2 = instruction % 10000 - mode1 - opcode;

            return (opcode, mode1 / 100, mode2 / 1000);
        }

        private void Add(int mode1, int mode2)
        {
            var value1 = ReadValue(_instructions[_pointer + 1], mode1);
            var value2 = ReadValue(_instructions[_pointer + 2], mode2);
            SetValue(_instructions[_pointer + 3], value1 + value2);
            _pointer += 4;
        }

        private void Mul(int mode1, int mode2)
        {
            var value1 = ReadValue(_instructions[_pointer + 1], mode1);
            var value2 = ReadValue(_instructions[_pointer + 2], mode2);
            SetValue(_instructions[_pointer + 3], value1 * value2);
            _pointer += 4;
        }

        private void Read(int input)
        {
            SetValue(_instructions[_pointer + 1], input);
            _pointer += 2;
        }

        private void Write(int mode1)
        {
            _output = ReadValue(_instructions[_pointer + 1], mode1);
            _pointer += 2;
        }

        private void JumpIfTrue(int mode1, int mode2)
        {
            var value1 = ReadValue(_instructions[_pointer + 1], mode1);
            var value2 = ReadValue(_instructions[_pointer + 2], mode2);
            if (value1 != 0)
            {
                _pointer = value2;
            }
            else
            {
                _pointer += 3;
            }
        }

        private void JumpIfFalse(int mode1, int mode2)
        {
            var value1 = ReadValue(_instructions[_pointer + 1], mode1);
            var value2 = ReadValue(_instructions[_pointer + 2], mode2);
            if (value1 == 0)
            {
                _pointer = value2;
            }
            else
            {
                _pointer += 3;
            }
        }

        private void LessThen(int mode1, int mode2)
        {
            var value1 = ReadValue(_instructions[_pointer + 1], mode1);
            var value2 = ReadValue(_instructions[_pointer + 2], mode2);
            SetValue(_instructions[_pointer + 3], value1 < value2 ? 1 : 0);
            _pointer += 4;
        }
        private void Equal(int mode1, int mode2)
        {
            var value1 = ReadValue(_instructions[_pointer + 1], mode1);
            var value2 = ReadValue(_instructions[_pointer + 2], mode2);
            SetValue(_instructions[_pointer + 3], value1 == value2 ? 1 : 0);
            _pointer += 4;
        }

        private void SetValue(int pos, int value)
        {
            _instructions[pos] = value;
        }

        private int ReadValue(int pos, int mode)
        {
            if (mode == 0)
            {
                return _instructions[pos];
            }

            return pos;
        }
    }
}
